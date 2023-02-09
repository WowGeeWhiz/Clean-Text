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
                || generateEventLogCheckBox.Checked
                || outputCleanedCheckBox.Checked)) 
                    outputOriginalCheckBox.Enabled = false;
            else outputOriginalCheckBox.Enabled = true;
            if (outputRemovedCheckBox.Checked 
                && !(outputRemovedCheckBox.Checked
                || outputReplaceCheckBox.Checked
                || generateEventLogCheckBox.Checked
                || outputCleanedCheckBox.Checked)) 
                    outputRemovedCheckBox.Enabled = false;
            else outputRemovedCheckBox.Enabled = true;
            if (outputReplaceCheckBox.Checked 
                && !(outputRemovedCheckBox.Checked
                || generateEventLogCheckBox.Checked
                || outputOriginalCheckBox.Checked
                || outputCleanedCheckBox.Checked)) 
                    outputReplaceCheckBox.Enabled = false;
            else outputReplaceCheckBox.Enabled = true;
            if (outputCleanedCheckBox.Checked 
                && !(outputRemovedCheckBox.Checked
                || outputReplaceCheckBox.Checked
                || outputOriginalCheckBox.Checked
                || generateEventLogCheckBox.Checked)) 
                    outputCleanedCheckBox.Enabled = false;
            else outputCleanedCheckBox.Enabled = true;
            if (generateEventLogCheckBox.Checked
                && !(outputRemovedCheckBox.Checked
                || outputReplaceCheckBox.Checked
                || outputOriginalCheckBox.Checked
                || outputCleanedCheckBox.Checked))
                    generateEventLogCheckBox.Enabled = false;
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

        //checkbox for logging input
        private void outputOriginalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //assign value to temp array
            if (outputOriginalCheckBox.Checked) tempArray[1] = "1";
            else tempArray[1] = "0";

            //update enabled states
            SetEnabledStates();
        }

        //checkbox for logging removal key
        private void outputRemovedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //assign value to temp array
            if (outputRemovedCheckBox.Checked) tempArray[2] = "1";
            else tempArray[2] = "0";

            //update enabled states
            SetEnabledStates();
        }

        //checkbox for logging replacement text
        private void outputReplaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //assign value to temp array
            if (outputReplaceCheckBox.Checked) tempArray[3] = "1";
            else tempArray[3] = "0";

            //update enabled states
            SetEnabledStates();
        }

        //checkbox for logging the cleaned text
        private void outputCleanedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //assign value to temp array
            if (outputCleanedCheckBox.Checked) tempArray[4] = "1";
            else tempArray[4] = "0";

            //update enabled states
            SetEnabledStates();
        }

        //checkbox for logging events during runtime
        private void generateEventLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //assign value to temp array
            if (generateEventLogCheckBox.Checked) tempArray[5] = "1";
            else tempArray[5] = "0";

            //update enabled states
            SetEnabledStates();
        }

        //checkbox for generating each log as a separate file
        private void outputSeparateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //assign value to temp array
            if (outputSeparateCheckBox.Checked) tempArray[6] = "1";
            else tempArray[6] = "0";
        }

        //open the Directory browser
        private void browseForOutputDirButton_Click(object sender, EventArgs e)
        {
            //temp string for reference
            string tempDir = "";

            //create a new folder browser window
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.InitialDirectory = outputDirectoryTextBox.Text;
            browser.Description = "Select output folder";
            browser.UseDescriptionForTitle = true;

            //if valid result from the dialogue
            if (browser.ShowDialog() == DialogResult.OK)
            {
                //set the chosen directory to the temp value
                tempDir = browser.SelectedPath;
            }

            //Check for progrem access to directory
            //if program has access, set the new directory to the value of the textbox
            if (AccessibleDirectory(tempDir)) outputDirectoryTextBox.Text = tempDir;
            //message appears during call to Preferences.AccessibleDirectory if the directory is inaccessible
        }

        //button to apply settings changes
        private void applyButton_Click(object sender, EventArgs e)
        {
            //set cursor to loading
            this.Cursor = Cursors.WaitCursor;

            //if invalid prefix for a log
            if (!validLogPrefix)
            {
                //display invalid warning, then break method
                MessageBox.Show(tempArray[8] + " is empty or contains invalid characters.");
                this.Cursor = Cursors.Default;
                return;
            }

            //if directory is inaccessbile
            if (!AccessibleDirectory(tempArray[0]))
            {
                //break method
                //warning appears as part of Preferences.AccessibleDirectory
                this.Cursor = Cursors.Default;
                return;
            }

            //Write the new preferences to the disk
            Preferences.WritePrefs(tempArray);

            //reset the cursor
            this.Cursor = Cursors.Default;

            //display update successful
            MessageBox.Show("Preferences updated.");

            //close the settings form
            Close();
        }

        //output directory text
        private void outputDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;
            
            //use existing value as temp value if input is empty
            if (outputDirectoryTextBox.Text == "" || outputDirectoryTextBox.Text == " ") tempArray[0] = Preferences.currentConfig[0, 1];

            //set temp value to the text
            tempArray[0] = outputDirectoryTextBox.Text;
        }

        //reset defaults button
        private void defaultButton_Click(object sender, EventArgs e)
        {
            //set temp values to default
            ReloadSavedValues(true);
        }

        //prefix for logs text
        private void logPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            //if loading, break
            if (isLoading) return;

            //mark valid or invalid text to bool
            if (logPrefixTextBox.Text == "" 
                || logPrefixTextBox.Text == null 
                || (logPrefixTextBox.Text != " " 
                && Preferences.CheckVaildNameChars(logPrefixTextBox.Text))) 
                    validLogPrefix = true;
            else validLogPrefix = false;

            //if valid, assign value to temp value
            if (validLogPrefix) tempArray[7] = logPrefixTextBox.Text;
        }
    }
}
