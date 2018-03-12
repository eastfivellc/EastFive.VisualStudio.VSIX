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
        private List<ParameterInfo> parameterInfos;

        public ResourceDetailsForm(string[] projects, IDictionary<string, string> suggestedProjectNames,
            Func<ResourceInfo, bool> resourceTransfer)
        {
            this.resourceTransfer = resourceTransfer;
            InitializeComponent();
            parameterInfos = new List<ParameterInfo>();

            if (projects.Length > 0)
            {
                cboAPI.Items.AddRange(projects);
                cboBusiness.Items.AddRange(projects);
                cboPersistence.Items.AddRange(projects);
                cboAPITest.Items.AddRange(projects);

                cboAPI.Text = suggestedProjectNames["api"];
                cboBusiness.Text = suggestedProjectNames["business"];
                cboPersistence.Text = suggestedProjectNames["persistence"];
                cboAPITest.Text = suggestedProjectNames["test"];

                cboParameterType.Items.Add("string");
                cboParameterType.Items.Add("int");
                cboParameterType.Items.Add("DateTime");
                cboParameterType.Items.Add("Guid");
                cboParameterType.Items.Add("WebId");
            }
        }

        private void btnCreateResource_Click(object sender, EventArgs e)
        {
            resourceTransfer(
                new ResourceInfo
                {
                    ResourceName = txtResourceName.Text,
                    ResourceNameVariable = txtResourceNameVariable.Text,
                    ResourceNamePlural = txtResourceNamePlural.Text,
                    APIProjectName = cboAPI.SelectedItem.ToString(),
                    BusinessProjectName = cboBusiness.SelectedItem.ToString(),
                    PersistenceProjectName = cboPersistence.SelectedItem.ToString(),
                    APITestProjectName = cboAPITest.SelectedItem.ToString(),
                    ParameterInfos = parameterInfos.ToArray()
                });
            this.Close();
        }

        private void btnAddParamter_Click(object sender, EventArgs e)
        {
            var parameterInfo = new ParameterInfo
            {
                Name = txtParameterName.Text,
                NameAsVariable = txtParameterNameVariable.Text,
                NameAsVariablePlural = txtParameterNameVariablePlural.Text,
                Type = cboParameterType.Text,
                ParameterNameJson = txtParameterNameJson.Text
            };
            parameterInfos.Add(parameterInfo);

            var paramInfo = $"{parameterInfo.Type}    {parameterInfo.Name}    {parameterInfo.NameAsVariable}    {parameterInfo.NameAsVariablePlural}    {parameterInfo.ParameterNameJson}";
            lstParameterInfo.Items.Add(paramInfo);

            txtParameterName.Text = string.Empty;
            txtParameterNameVariable.Text = string.Empty;
            txtParameterNameVariablePlural.Text = string.Empty;
            cboParameterType.Text = string.Empty;
            txtParameterNameJson.Text = string.Empty;
        }
    }
}
