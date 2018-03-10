using System;
using System.Collections.Generic;
using System.IO;
using EnvDTE80;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace EastFive.VisualStudio.VSIX
{
    // Taken from http://codeblog.vurdalakov.net/2016/11/vsix-get-list-of-projects-in-visual-studio-solution.html
    public static class VsixHelper
    {
        public static DTE2 Ide { get; private set; }

        static VsixHelper()
        {
            VsixHelper.Ide = Package.GetGlobalService(typeof(DTE)) as DTE2;
        }

        public static Project[] GetProjects(this Solution solution)
        {
            var projects = new List<Project>();

            var enumerator = solution.Projects.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var project = enumerator.Current as Project;
                projects.AddRange(project.GetProjects());
            }

            return projects.ToArray();
        }

        private static Project[] GetProjects(this Project project)
        {
            if (null == project)
            {
                return new Project[0];
            }

            var projects = new List<Project>();

            //if (project.Kind != ProjectKinds.vsProjectKindSolutionFolder)
            if (project.Kind != "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}")
            {
                projects.Add(project);
            }

            if (project.ProjectItems != null)
            {
                for (var i = 1; i <= project.ProjectItems.Count; i++)
                {
                    var subProject = project.ProjectItems.Item(i).SubProject;
                    projects.AddRange(GetProjects(subProject));
                }
            }

            return projects.ToArray();
        }
    }
}
