using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EastFive.VisualStudio.VSIX.ResourceGenerator
{
    public partial class ResourceDetailsForm : Form
    {
        Func<ResourceInfo, bool> resourceTransfer;

        public ResourceDetailsForm(string[] projects, Func<ResourceInfo, bool> resourceTransfer)
        {
            this.resourceTransfer = resourceTransfer;
            InitializeComponent();

            if (projects.Length > 0)
            {
                cboAPI.Items.AddRange(projects);
                cboBusiness.Items.AddRange(projects);
                cboPersistence.Items.AddRange(projects);
                cboAPITest.Items.AddRange(projects);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            resourceTransfer(
                new ResourceInfo
                {
                    ResourceName = txtResourceName.Text,
                    APIProjectName = cboAPI.SelectedItem.ToString(),
                    BusinessProjectName = cboBusiness.SelectedItem.ToString(),
                    PersistenceProjectName = cboPersistence.SelectedItem.ToString(),
                    APITestProjectName = cboAPITest.SelectedItem.ToString()
                });
            this.Close();
        }

        private void ResourceDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
