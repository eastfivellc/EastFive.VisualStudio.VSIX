using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace EastFive.VisualStudio.VSIX.ResourceGenerator
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class Command1
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
        private Command1(Package package)
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
        public static Command1 Instance
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
            Instance = new Command1(package);
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
            var solution = VsixHelper.Ide.Solution;
            var projectNames = solution.GetProjects().Select(proj => proj.Name).OrderBy(x => x).ToArray();

            Func<ResourceInfo, bool> resourceTransfer = (rsrc) => 
            {
                WriteFile("EastFive.VisualStudio.VSIX.ResourceGenerator.FileTemplates.API.Controllers.Controller.txt", 
                            "filepath", rsrc.APIProjectName);

                var asdf = rsrc.APIProjectName + rsrc.BusinessProjectName + rsrc.PersistenceProjectName + rsrc.APITestProjectName;
                VsShellUtilities.ShowMessageBox(
                    this.ServiceProvider,
                    asdf,
                    rsrc.ResourceName,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);

                //File.Create(@"c:\temp\testResource.txt");

                return true;
            };

            var frm = new ResourceDetailsForm(projectNames, resourceTransfer);
            frm.ShowDialog();

        }

        private void WriteFile(string resourceName, string filePath, string projectNamespace)
        {
            // Get current assembly
            var assembly = Assembly.GetExecutingAssembly();

            string template = String.Empty;

            // Read resource from assembly
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                template = reader.ReadToEnd();
                template
                    .Replace("{{project_namespace}}", projectNamespace)
                    .Replace("{{resource_name}}", resourceName);

                // Write data in the new text file
                filePath = "C:\\temp\\myFileName.cs";
                using (TextWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine(template);
                }
            }
        }
    }
}
