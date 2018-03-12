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
                        var asdf = resourceInfo.APIProjectName + "   " + resourceInfo.BusinessProjectName + "   " + resourceInfo.PersistenceProjectName + "   " + resourceInfo.APITestProjectName;
                        MsgBox("Returned resource info", asdf);

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
                                return true;

                            },
                            () =>
                            {
                                return false;
                            });
                        return true;
                    };

                    var projectNames = projectInfos.Select(x => x.Name).ToArray();
                    var frm = new ResourceDetailsForm(projectNames, resourceTransfer);
                    frm.ShowDialog();
                    return true;
                },
                () =>
                {
                    return false;
                });
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
                        //API
                        var outputApiPath = Path.GetDirectoryName(projectInfos.First(x => x.Name == resourceInfo.APIProjectName).FullName);
                        var outputControllerPath = Path.Combine(outputApiPath, $"Controllers\\{resourceInfo.ResourceName}Controller.cs");
                        var controllerTemplatePath = Path.Combine(templateFilePath, "FileTemplates\\API\\Controllers\\Controller.txt");
                        WriteFileFromTemplate(controllerTemplatePath, outputControllerPath, substitutions,
                            ()=>
                            {
                                AddFileToProject(projectInfos.First(x => x.Name == resourceInfo.APIProjectName), outputControllerPath);
                                return true;
                            },
                            ()=>
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
                var subs = new Dictionary<string, string>();
                subs.Add("{{resource_name}}", resourceInfo.ResourceName);
                subs.Add("{{resource_name_plural}}", resourceInfo.ResourceNamePlural);
                return onSuccess(subs);
            }
            catch (Exception ex)
            {
                MsgBox("GetSubstitutions", ex.Message);
                return onError();
            }
        }

        private TResult WriteFileFromTemplate<TResult>(string templateFilePath, string outputFilePath, IDictionary<string, string> substitutions,
            Func<TResult> onSuccess,
            Func<TResult> onError)
        {
            try
            {
                MsgBox("WriteFileFromTemplate", $"templateFilePath: {templateFilePath}     outputFilePath: {outputFilePath}");

                using (TextReader reader = File.OpenText(templateFilePath))
                {
                    string templateText = reader.ReadToEnd();
                    foreach (var substitution in substitutions)
                    {
                        templateText = templateText.Replace(substitution.Key, substitution.Value);
                    }

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
