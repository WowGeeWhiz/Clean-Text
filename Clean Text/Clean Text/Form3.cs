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
        //bools for reference
        bool isLoading = false, validLogPrefix;

        //array of loaded settings
        string[] tempArray = new string[Preferences.prefs.GetLength(0)];

        //public constructor for settings page
        public Form3()
        {
            InitializeComponent();
            ReloadSavedValues();
        }

        //set the enabled states of boxes based on selected values
        private void SetEnabledStates()
        {
            if (outputOriginalCheckBox.Checked 
                && !(outputRemovedCheckBox.Checked 
                || outputReplaceCheckBox.Checked 
                || outputCleanedCheckBox.Checked)) 
                    outputOriginalCheckBox.Enabled = false;
            else outputOriginalCheckBox.Enabled = true;
            if (outputRemovedCheckBox.Checked 
                && !(outputOriginalCheckBox.Checked 
                || outputReplaceCheckBox.Checked 
                || outputCleanedCheckBox.Checked)) 
                    outputRemovedCheckBox.Enabled = false;
            else outputRemovedCheckBox.Enabled = true;
            if (outputReplaceCheckBox.Checked 
                && !(outputRemovedCheckBox.Checked 
                || outputOriginalCheckBox.Checked 
                || outputCleanedCheckBox.Checked)) 
                    outputReplaceCheckBox.Enabled = false;
            else outputReplaceCheckBox.Enabled = true;
            if (outputCleanedCheckBox.Checked 
                && !(outputRemovedCheckBox.Checked 
                || outputReplaceCheckBox.Checked 
                || outputOriginalCheckBox.Checked)) 
                    outputCleanedCheckBox.Enabled = false;
            else outputCleanedCheckBox.Enabled = true;
        }

        //reload the actual preferences
        private void ReloadSavedValues(bool revertToDefault = false)
        {
            //set program to loading state
            this.Cursor = Cursors.WaitCursor;
            isLoading = true;

            //load the preferences
            Preferences.LoadPrefs();

            //initialize the settings array
            string[,] settings;

            //set the settings to default if option chosen
            if (!revertToDefault) settings = Preferences.currentConfig;
            //otherwise set the settings to the loaded values
            else settings = Preferences.prefs;

            //reset the settings fields to their loaded or default values (based on choice)
            outputDirectoryTextBox.Text = "";
            outputDirectoryTextBox.PlaceholderText = settings[0, 1];
            logPrefixTextBox.Text = "";
            logPrefixTextBox.PlaceholderText = settings[7, 1];
            validLogPrefix = true;
            outputOriginalCheckBox.Checked = Preferences.StringToBool(settings[1, 1]);
            outputRemovedCheckBox.Checked = Preferences.StringToBool(settings[2, 1]);
            outputReplaceCheckBox.Checked = Preferences.StringToBool(settings[3, 1]);
            outputCleanedCheckBox.Checked = Preferences.StringToBool(settings[4, 1]);
            generateEventLogCheckBox.Checked = Preferences.StringToBool(settings[5, 1]);
            outputSeparateCheckBox.Checked = Preferences.StringToBool(settings[6, 1]);

            //apply the current settings to the temp array of values
            for (int i = 0; i < settings.GetLength(0); i++)
            {
                tempArray[i] = settings[i, 1];
            }

            //reset the states of the buttons
            SetEnabledStates();

            //stop loading process
            isLoading = false;
            this.Cursor = Cursors.Default;
        }

        //close button for this form (not application)
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //reload the currently saved values (undo changes)
        private void revertButton_Click(object sender, EventArgs e)
        {
            ReloadSavedValues();
        }

        //checkbox for loging input
        private void outputOriginalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //assign value
            if (outputOriginalCheckBox.Checked) tempArray[1] = "1";
            else tempArray[1] = "0";

            //update enabled states
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
            if (!validLogPrefix)
            {
                MessageBox.Show(tempArray[8] + " is empty or contains invalid characters.");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            if (!Preferences.AccessibleDirectory(tempArray[0]))
            {
                this.Cursor = Cursors.Default;
                return;
            }

            Preferences.WritePrefs(tempArray);

            this.Cursor = Cursors.Default;

            MessageBox.Show("Preferences updated.");
            Close();
        }

        private void outputDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (outputDirectoryTextBox.Text == "" || outputDirectoryTextBox.Text == " ") tempArray[0] = Preferences.currentConfig[0, 1];
            tempArray[0] = outputDirectoryTextBox.Text;
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            ReloadSavedValues(true);
        }

        private void logPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (logPrefixTextBox.Text == "" || logPrefixTextBox.Text == null || (logPrefixTextBox.Text != " " && Preferences.CheckVaildNameChars(logPrefixTextBox.Text))) validLogPrefix = true;
            else validLogPrefix = false;

            if (validLogPrefix) tempArray[7] = logPrefixTextBox.Text;
        }
    }
}
