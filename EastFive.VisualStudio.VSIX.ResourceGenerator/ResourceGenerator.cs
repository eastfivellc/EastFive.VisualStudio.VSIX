using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;

namespace EastFive.VisualStudio.VSIX.ResourceGenerator
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ResourceGenerator
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("c6857ca0-05b8-41a9-a4c6-90120ce51f0d");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command1"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private ResourceGenerator(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ResourceGenerator Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new ResourceGenerator(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            var result = GetProjectInfos(
                (projectInfos) =>
                {
                    Func<ResourceInfo, bool> resourceTransfer = (resourceInfo) =>
                    {
                        var projectInfo = resourceInfo.APIProjectName + "   " + resourceInfo.BusinessProjectName + "   " + resourceInfo.PersistenceProjectName + "   " + resourceInfo.APITestProjectName;
                        MsgBox("Returned resource info", projectInfo);

                        GetTemplateFilePath(
                            (templateFilePath) =>
                            {
                                MsgBox("TemplateFilePath", templateFilePath);

                                WriteProjectFilesFromTemplates(templateFilePath, projectInfos, resourceInfo,
                                    () =>
                                    {
                                        return true;
                                    },
                                    () =>
                                    {
                                        return false;
                                    });

                                UpdateBusinessContext(resourceInfo, projectInfos);
                                UpdatePersistenceContext(resourceInfo, projectInfos);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });
                        return true;
                    };

                    Func<string, string, bool> msgBox = (title, message) =>
                    {
                        AlertMsgBox(title, message);
                        return true;
                    };

                    var projectNames = projectInfos.Select(x => x.Name).ToArray();
                    var suggestedProjectNames = GetSuggestedProjectNames(projectNames);
                    var frm = new ResourceDetailsForm(projectNames, suggestedProjectNames, msgBox, resourceTransfer);
                    frm.ShowDialog();
                    AlertMsgBox("Completed", "The resource has been created");
                    return true;
                },
                () =>
                {
                    return false;
                });
        }

        public void UpdatePersistenceContext(ResourceInfo resourceInfo, Project[] projectInfos)
        {
            var outputPersistencePath = Path.GetDirectoryName(projectInfos.First(x => x.Name == resourceInfo.PersistenceProjectName).FullName);
            var contextFilePath = Path.Combine(outputPersistencePath, "DataContext.cs");
            string text = File.ReadAllText(contextFilePath);

            var index = text.LastIndexOf('}');
            text = text.Remove(index, 1);
            index = text.LastIndexOf('}');
            text = text.Remove(index, 1);

            text += "\n";
            text += "\t\t";
            text += $"private {resourceInfo.ResourceNamePlural} {resourceInfo.ResourceNameVariable}s = default({resourceInfo.ResourceNamePlural});";
            text += "\n";
            text += "\t\t\t";
            text += $"public {resourceInfo.ResourceNamePlural} {resourceInfo.ResourceNamePlural}";
            text += "\n";
            text += "\t\t\t";
            text += "{";
            text += "\n";
            text += "\t\t\t\t";
            text += "get";
            text += "\n";
            text += "\t\t\t\t";
            text += "{";
            text += "\n";
            text += "\t\t\t\t\t";
            text += $"if (default({resourceInfo.ResourceNamePlural}) == {resourceInfo.ResourceNameVariable}s)";
            text += "\n";
            text += "\t\t\t\t\t\t";
            text += $"{resourceInfo.ResourceNameVariable}s = new {resourceInfo.ResourceNamePlural}(this);";
            text += "\n";
            text += "\t\t\t\t\t";
            text += $"return {resourceInfo.ResourceNameVariable}s;";
            text += "\n";
            text += "\t\t\t\t";
            text += "}";
            text += "\n";
            text += "\t\t\t";
            text += "}";
            text += "\n";
            text += "\t\t";
            text += "}";
            text += "\n";
            text += "}";

            /*
             private CSMDRecordReviews appointmentReviews = default(CSMDRecordReviews);
            public CSMDRecordReviews CSMDRecordReviews
            {
                get
                {
                    if (default(CSMDRecordReviews) == appointmentReviews)
                        appointmentReviews = new CSMDRecordReviews(this);
                    return appointmentReviews;
                }
            }
            */


            File.WriteAllText(contextFilePath, text);
        }

        public void UpdateBusinessContext(ResourceInfo resourceInfo, Project[] projectInfos)
        {
            var outputBusinessPath = Path.GetDirectoryName(projectInfos.First(x => x.Name == resourceInfo.BusinessProjectName).FullName);
            var contextFilePath = Path.Combine(outputBusinessPath, "Context.cs");
            string text = File.ReadAllText(contextFilePath);

            var index = text.LastIndexOf('}');
            text = text.Remove(index, 1);
            index = text.LastIndexOf('}');
            text = text.Remove(index, 1);

            text += "\n";
            text += "\t\t";
            text += $"private {resourceInfo.ResourceNamePlural} {resourceInfo.ResourceNameVariable}s;";
            text += "\n";
            text += "\t\t\t";
            text += $"public {resourceInfo.ResourceNamePlural} {resourceInfo.ResourceNamePlural}";
            text += "\n";
            text += "\t\t\t";
            text += "{";
            text += "\n";
            text += "\t\t\t\t";
            text += "get";
            text += "\n";
            text += "\t\t\t\t";
            text += "{";
            text += "\n";
            text += "\t\t\t\t\t";
            text += $"if (default({resourceInfo.ResourceNamePlural}) == {resourceInfo.ResourceNameVariable}s)";
            text += "\n";
            text += "\t\t\t\t\t\t";
            text += $"{resourceInfo.ResourceNameVariable}s = new {resourceInfo.ResourceNamePlural}(this, DataContext);";
            text += "\n";
            text += "\t\t\t\t\t";
            text += $"return {resourceInfo.ResourceNameVariable}s;";
            text += "\n";
            text += "\t\t\t\t";
            text += "}";
            text += "\n";
            text += "\t\t\t";
            text += "}";
            text += "\n";
            text += "\t\t";
            text += "}";
            text += "\n";
            text += "}";

            //private PracticeAdmins practiceAdmins;
            //public PracticeAdmins PracticeAdmins
            //{
            //    get
            //    {
            //        if (default(PracticeAdmins) == practiceAdmins)
            //            practiceAdmins = new PracticeAdmins(this, DataContext);
            //        return practiceAdmins;
            //    }
            //}


            File.WriteAllText(contextFilePath, text);
        }

        private IDictionary<string, string> GetSuggestedProjectNames(string[] projectNames)
        {
            // This is a super kludge, but we don't have a distinct name for our biz layers on which to match
            var shortestCount = 9999;
            var business = string.Empty;
            foreach(var projectName in projectNames)
            {
                if (projectName.StartsWith("EastFive"))
                    continue;

                if (projectName.StartsWith("BlackBarLabs"))
                    continue;

                if (projectName.Length < shortestCount)
                {
                    business = projectName;
                    shortestCount = projectName.Length;
                }
            }
            var api = projectNames.FirstOrDefault(name => name.EndsWith(".Api"));
            var persistence = projectNames.FirstOrDefault(name => name.EndsWith(".Persistence.Azure"));
            var test = projectNames.FirstOrDefault(name => name.EndsWith(".Api.Tests"));
            return new Dictionary<string, string>
            {
                { "api", api },
                { "business", business },
                { "persistence", persistence },
                { "test", test }
            };
        }

        private TResult GetProjectInfos<TResult>(
            Func<EnvDTE.Project[], TResult> onSuccess,
            Func<TResult> onError)
        {
            try
            {
                var solution = VsixHelper.Ide.Solution;
                var projects = solution.GetProjects().OrderBy(x => x.Name).ToArray();
                return onSuccess(projects);
            }
            catch(Exception ex)
            {
                return onError();
            }
        }

        private TResult GetTemplateFilePath<TResult>(
            Func<string, TResult> onFoundPath,
            Func<TResult> onError)
        {
            try
            {
                var installationPath = GetAssemblyLocalPathFrom(typeof(ResourceGenerator));
                var path = Path.GetDirectoryName(installationPath);
                return onFoundPath(path);
            }
            catch(Exception ex)
            {
                return onError();
            }
        }

        private TResult WriteProjectFilesFromTemplates<TResult>(string templateFilePath, Project[] projectInfos, ResourceInfo resourceInfo,
            Func<TResult> onSuccess,
            Func<TResult> onError)
        {
            try
            {
                return GetSubstitutions(resourceInfo,
                    (substitutions) =>
                    {
                        var outputApiPath = Path.GetDirectoryName(projectInfos.First(x => x.Name == resourceInfo.APIProjectName).FullName);
                        var outputBusinessPath = Path.GetDirectoryName(projectInfos.First(x => x.Name == resourceInfo.BusinessProjectName).FullName);
                        var outputPersistencePath = Path.GetDirectoryName(projectInfos.First(x => x.Name == resourceInfo.PersistenceProjectName).FullName);
                        var outputApiTestPath = Path.GetDirectoryName(projectInfos.First(x => x.Name == resourceInfo.APITestProjectName).FullName);

                        //API\Controllers\<Controller>.cs
                        var outputPath = Path.Combine(outputApiPath, $"Controllers\\{resourceInfo.ResourceName}Controller.cs");
                        var templatePath = Path.Combine(templateFilePath, "FileTemplates\\API\\Controllers\\Controller.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            ()=>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.APIProjectName), outputPath);
                                return true;
                            },
                            ()=>
                            {
                                return false;
                            });

                        //API\Resources\Resource.cs
                        outputPath = Path.Combine(outputApiPath, $"Resources\\{resourceInfo.ResourceName}\\{resourceInfo.ResourceName}.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\API\\Resources\\ResourceName\\Resource.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.APIProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        //API\Resources\ResourceActions.cs
                        outputPath = Path.Combine(outputApiPath, $"Resources\\{resourceInfo.ResourceName}\\{resourceInfo.ResourceName}Actions.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\API\\Resources\\ResourceName\\ResourceActions.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.APIProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        //API\Resources\ResourceOptions.cs
                        outputPath = Path.Combine(outputApiPath, $"Resources\\{resourceInfo.ResourceName}\\{resourceInfo.ResourceName}Options.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\API\\Resources\\ResourceName\\ResourceOptions.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.APIProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        //Business\Business.cs
                        outputPath = Path.Combine(outputBusinessPath, $"{resourceInfo.ResourceNamePlural}.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\Business\\Business.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.BusinessProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        //Persistence\Persistence.cs
                        outputPath = Path.Combine(outputPersistencePath, $"{resourceInfo.ResourceNamePlural}.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\Persistence\\Persistence.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.PersistenceProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        //Persistence\Documents\Document.cs
                        outputPath = Path.Combine(outputPersistencePath, $"Documents\\{resourceInfo.ResourceName}Document.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\Persistence\\Documents\\Document.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.PersistenceProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        //Api.Test\CRUD\CRUD.cs
                        outputPath = Path.Combine(outputApiTestPath, $"CRUD\\{resourceInfo.ResourceName}.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\Test\\CRUD\\CRUD.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.APITestProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        //Api.Test\Helpers\ResourceHelper.cs
                        outputPath = Path.Combine(outputApiTestPath, $"Helpers\\{resourceInfo.ResourceName}Helpers.cs");
                        templatePath = Path.Combine(templateFilePath, "FileTemplates\\Test\\Helpers\\ResourceHelper.txt");
                        WriteFileFromTemplate(templatePath, outputPath, substitutions, resourceInfo,
                            () =>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.APITestProjectName), outputPath);
                                return true;
                            },
                            () =>
                            {
                                return false;
                            });

                        return onSuccess();
                    },
                    () =>
                    {
                        return onError();
                    });
            }
            catch(Exception ex)
            {
                MsgBox("Error in WriteProjectFilesFromTemplates", ex.Message);
                return onError();
            }
        }

        private void AddFileToProject(Project project, string filePath)
        {
            project.ProjectItems.AddFromFile(filePath);
        }

        private TResult GetSubstitutions<TResult>(ResourceInfo resourceInfo,
            Func<IDictionary<string, string>, TResult> onSuccess,
            Func<TResult> onError)
        {
            try
            {
                var subs = new Dictionary<string, string>
                {
                    { "{{resource_name}}", resourceInfo.ResourceName },
                    { "{{resource_name_plural}}", resourceInfo.ResourceNamePlural },
                    { "{{resource_name_variable}}", resourceInfo.ResourceNameVariable },
                    { "{{project_namespace_api}}", resourceInfo.APIProjectName  },
                    { "{{project_namespace_business}}", resourceInfo.BusinessProjectName  },
                    { "{{project_namespace_persistence}}", resourceInfo.PersistenceProjectName  },
                    { "{{project_namespace_test}}", resourceInfo.APITestProjectName  },


                };

                subs.Add("{{api_resource_definition}}", GetResourceDefinition(resourceInfo));
                subs.Add("{{persistence_document_definition}}", GetDocumentDefinition(resourceInfo));



                return onSuccess(subs);
            }
            catch (Exception ex)
            {
                MsgBox("GetSubstitutions", ex.Message);
                return onError();
            }
        }

        private string GetResourceDefinition(ResourceInfo resourceInfo)
        {
            var resourceDefinition = string.Empty;

            foreach(var parameter in resourceInfo.ParameterInfos)
            {
                resourceDefinition += "\n";
                resourceDefinition += "\t\t";
                resourceDefinition += $"[JsonProperty(PropertyName = \"{parameter.ParameterNameJson}\")]";
                resourceDefinition += "\n";
                resourceDefinition += "\t\t";
                resourceDefinition += $"public {parameter.Type} {parameter.Name} ";
                resourceDefinition += "{ get; set; }";
                resourceDefinition += "\n";
            }

            return resourceDefinition;
        }

        private string GetDocumentDefinition(ResourceInfo resourceInfo)
        {
            var documentDefinition = string.Empty;

            foreach (var parameter in resourceInfo.ParameterInfos)
            {
                documentDefinition += "\n";
                documentDefinition += "\t\t";
                documentDefinition += $"public {parameter.Type} {parameter.Name} ";
                documentDefinition += "{ get; set; }";
                documentDefinition += "\n";
            }

            return documentDefinition;
        }


        private TResult WriteFileFromTemplate<TResult>(string templateFilePath, string outputFilePath, 
                IDictionary<string, string> substitutions, ResourceInfo resourceInfo,
            Func<TResult> onSuccess,
            Func<TResult> onError)
        {
            try
            {
                MsgBox("WriteFileFromTemplate", $"templateFilePath: {templateFilePath}     outputFilePath: {outputFilePath}");
                var subInfo = "SubstitutionInfo---    ";
                foreach (var substitution in substitutions)
                {
                    subInfo += $"{substitution.Key} : {substitution.Value}";
                }
                MsgBox("WriteFileFromTemplate", subInfo);

                using (TextReader reader = File.OpenText(templateFilePath))
                {
                    string templateText = reader.ReadToEnd();
                    foreach (var substitution in substitutions)
                    {
                        templateText = templateText.Replace(substitution.Key, substitution.Value);
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        writer.Write(templateText);
                    }
                }
                return onSuccess();
            }
            catch (Exception ex)
            {
                MsgBox("WriteFileFromTemplate", ex.Message);
                return onError();
            }
        }

        /// <summary>
        /// Message box, used primarily when debugging in a project that is not the VSIX project
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        private void MsgBox(string title, string message)
        {
            return;
            // Leave this return in unless debugging

            AlertMsgBox(title, message);
        }


        private void AlertMsgBox(string title, string message)
        {
            VsShellUtilities.ShowMessageBox(
                            this.ServiceProvider,
                            message,
                            title,
                            OLEMSGICON.OLEMSGICON_INFO,
                            OLEMSGBUTTON.OLEMSGBUTTON_OK,
                            OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }


        static string GetAssemblyLocalPathFrom(Type type)
        {
            string codebase = type.Assembly.CodeBase;
            var uri = new Uri(codebase, UriKind.Absolute);
            return uri.LocalPath;
        }
    }
}
