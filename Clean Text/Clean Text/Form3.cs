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

namespace Clean_Text
{
    public partial class Form3 : Form
    {

        string prefDir = @Application.StartupPath + "config.ini";//.StartupPath;
        string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        string[,] defaultConfig = new string[,]
        {
            {"outputDirectory=", ""},
            {"outputOriginal=","0"},
            {"outputRemoved=","0"},
            {"outputReplace=","0"},
            {"outputCleaned=","1"},
            {"generateLog=","0"},
            {"outputSeparate=","0"},
            {"outputTxt=","0" }
        };
        string[,] currentConfig;

        bool isLoading = false;

        public Form3()
        {
            InitializeComponent();
            currentUser = currentUser.Substring(currentUser.IndexOf('\\') + 1); //must be before any calls to currentUser, this removes the machine name
            defaultConfig[0, 1] = @"C:\Users\" + @currentUser + @"\Downloads\CleanTextOutputFiles";
            currentConfig = defaultConfig;
            ReloadSavedValues();
        }

        private string[] DoubleArrayToSingle(string[,] input)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < input.GetLength(0); i++)
            {
                temp.Add(input[i, 0] + input[i, 1]);
            }
            return temp.ToArray();
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

        private void WriteToFile(string dir, string[] lines)
        {
            File.WriteAllLines(dir, lines);
            return;
        }

        private void ReloadSavedValues()
        {
            isLoading = true;

            try
            {
                if (!File.Exists(prefDir))
                {
                    MessageBox.Show("No config file found, generating file...");
                    WriteToFile(prefDir, DoubleArrayToSingle(defaultConfig));
                }

                string[] loadedConfigs = File.ReadAllLines(prefDir);
                if (loadedConfigs.Length != defaultConfig.GetLength(0))
                {
                    MessageBox.Show("Config file missing keys, restoring default settings...");
                    loadedConfigs = DoubleArrayToSingle(defaultConfig);
                    WriteToFile(prefDir, loadedConfigs);
                }

                for (int a = 0; a < loadedConfigs.Length; a++)
                {
                    string[] tempArray = loadedConfigs[a].Split('=');
                    currentConfig[a, 1] = tempArray[1];
                }

                outputDirectoryTextBox.Text = "";
                outputDirectoryTextBox.PlaceholderText = currentConfig[0, 1];
                outputOriginalCheckBox.Checked = StringToBool(currentConfig[1, 1]);
                outputRemovedCheckBox.Checked = StringToBool(currentConfig[2, 1]);
                outputReplaceCheckBox.Checked = StringToBool(currentConfig[3, 1]);
                outputCleanedCheckBox.Checked = StringToBool(currentConfig[4, 1]);
                generateEventLogCheckBox.Checked = StringToBool(currentConfig[5, 1]);
                outputSeparateCheckBox.Checked = StringToBool(currentConfig[6, 1]);
                outputAsTxtCheckBox.Checked = StringToBool(currentConfig[7, 1]);


                SetEnabledStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            isLoading = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            ReloadSavedValues();
        }

        private void outputOriginalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            SetEnabledStates();
        }

        private void outputRemovedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            SetEnabledStates();
        }

        private void outputReplaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            SetEnabledStates();
        }

        private void outputCleanedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            SetEnabledStates();
        }

        private void generateEventLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

        }

        private void outputSeparateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

        }

        private void outputAsTxtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

        }

        private void browseForOutputDirButton_Click(object sender, EventArgs e)
        {
            string tempDir = "";
            try
            {
                FolderBrowserDialog browser = new FolderBrowserDialog();
                browser.InitialDirectory = outputDirectoryTextBox.Text;
                browser.Description = "Select output folder";
                browser.UseDescriptionForTitle = true;


                if (browser.ShowDialog() == DialogResult.OK)
                {
                    tempDir = browser.SelectedPath;
                    WriteToFile(tempDir + "\\test.txt", new string[] { "test file" });

                }

            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The program cannot access that directory.\nTry running the program as an administrator, or changing the security of the directory");
                tempDir = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                tempDir = "";
            }
            finally
            {
                if (File.Exists(tempDir + "\\test.txt")) File.Delete(tempDir + "\\test.txt");
                if (tempDir != "") outputDirectoryTextBox.Text = tempDir;
            }
        }
    }
}
