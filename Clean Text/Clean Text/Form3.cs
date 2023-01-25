using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Clean_Text.Program;

namespace Clean_Text
{
    public partial class Form3 : Form
    {

        bool isLoading = false;
        string[] tempArray = new string[Preferences.prefs.GetLength(0)];

        public Form3()
        {
            InitializeComponent();
            ReloadSavedValues();
        }

        private bool StringToBool(string input)
        {
            if (input == "1") return true;
            if (input == "0") return false;
            MessageBox.Show("Error loading bool, no valid input\nReturning false...");
            return false;
        }

        private void SetEnabledStates()
        {
            if (outputOriginalCheckBox.Checked && !(outputRemovedCheckBox.Checked || outputReplaceCheckBox.Checked || outputCleanedCheckBox.Checked)) outputOriginalCheckBox.Enabled = false;
            else outputOriginalCheckBox.Enabled = true;
            if (outputRemovedCheckBox.Checked && !(outputOriginalCheckBox.Checked || outputReplaceCheckBox.Checked || outputCleanedCheckBox.Checked)) outputRemovedCheckBox.Enabled = false;
            else outputRemovedCheckBox.Enabled = true;
            if (outputReplaceCheckBox.Checked && !(outputRemovedCheckBox.Checked || outputOriginalCheckBox.Checked || outputCleanedCheckBox.Checked)) outputReplaceCheckBox.Enabled = false;
            else outputReplaceCheckBox.Enabled = true;
            if (outputCleanedCheckBox.Checked && !(outputRemovedCheckBox.Checked || outputReplaceCheckBox.Checked || outputOriginalCheckBox.Checked)) outputCleanedCheckBox.Enabled = false;
            else outputCleanedCheckBox.Enabled = true;
        }

        private void ReloadSavedValues()
        {
            this.Cursor = Cursors.WaitCursor;
            isLoading = true;

            Preferences.LoadPrefs();

            string[,] settings = Preferences.currentConfig;

            outputDirectoryTextBox.Text = "";
            outputDirectoryTextBox.PlaceholderText = settings[0, 1];
            outputOriginalCheckBox.Checked = StringToBool(settings[1, 1]);
            outputRemovedCheckBox.Checked = StringToBool(settings[2, 1]);
            outputReplaceCheckBox.Checked = StringToBool(settings[3, 1]);
            outputCleanedCheckBox.Checked = StringToBool(settings[4, 1]);
            generateEventLogCheckBox.Checked = StringToBool(settings[5, 1]);
            outputSeparateCheckBox.Checked = StringToBool(settings[6, 1]);
            outputAsTxtCheckBox.Checked = StringToBool(settings[7, 1]);

            for (int i = 0; i < settings.GetLength(0); i++)
            {
                tempArray[i] = settings[i, 1];
            }


            SetEnabledStates();

            isLoading = false;
            this.Cursor = Cursors.Default;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            ReloadSavedValues();
        }

        private void outputOriginalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputOriginalCheckBox.Checked) tempArray[1] = "1";
            else tempArray[1] = "0";
            SetEnabledStates();
        }

        private void outputRemovedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputRemovedCheckBox.Checked) tempArray[2] = "1";
            else tempArray[2] = "0";
            SetEnabledStates();
        }

        private void outputReplaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputReplaceCheckBox.Checked) tempArray[3] = "1";
            else tempArray[3] = "0";
            SetEnabledStates();
        }

        private void outputCleanedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputCleanedCheckBox.Checked) tempArray[4] = "1";
            else tempArray[4] = "0";
            SetEnabledStates();
        }

        private void generateEventLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (generateEventLogCheckBox.Checked) tempArray[5] = "1";
            else tempArray[5] = "0";
        }

        private void outputSeparateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputSeparateCheckBox.Checked) tempArray[6] = "1";
            else tempArray[6] = "0";
        }

        private void outputAsTxtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputAsTxtCheckBox.Checked) tempArray[7] = "1";
            else tempArray[7] = "1";
        }

        private void browseForOutputDirButton_Click(object sender, EventArgs e)
        {
            string tempDir = "";

            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.InitialDirectory = outputDirectoryTextBox.Text;
            browser.Description = "Select output folder";
            browser.UseDescriptionForTitle = true;


            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempDir = browser.SelectedPath;
            }

            if (Preferences.AccessibleDirectory(tempDir)) outputDirectoryTextBox.Text = tempDir;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (!Preferences.AccessibleDirectory(tempArray[0]))
            {
                this.Cursor = Cursors.Default;
                return;
            }

            Preferences.WritePrefs(tempArray);

            this.Cursor = Cursors.Default;

            MessageBox.Show("Preferences updated.");
        }

        private void outputDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputDirectoryTextBox.Text == "" || outputDirectoryTextBox.Text == " ") tempArray[0] = Preferences.currentConfig[0, 1];
            tempArray[0] = outputDirectoryTextBox.Text;
        }
    }
}
