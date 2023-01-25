namespace Clean_Text
{
    public partial class Form1 : Form
    {
        //booleans for use throughout program
        bool loading, validEntry, validRemove, validReplace, forceLogInputOutput, forceLogReplace, forceLogRemove;
        string tempLoadedValue = "";

        public Form1()
        {
            InitializeComponent();
            ResetForm();
        }

        //method to reset the form
        private void ResetForm()
        {
            loading = true; //start loading (disable other methods)

            validEntry = validRemove = validReplace = forceLogRemove = forceLogReplace = forceLogInputOutput = false; //reset bools

            //empty and disable replace text box
            replaceTextBox.Enabled = false;
            replaceFromLoadButton.Enabled = false;
            replaceTextBox.Text = "";

            generateLogCheck.Enabled = true;

            replaceTextButton.Checked = false; //uncheck replace text button

            entryTextBox.Text = ""; //empty entry text box

            removeTextBox.Text = ""; //empty remove text box

            runButton.Enabled = false; //disable run button

            loading = false; //stop loading (other methods will run now)
        }

        //check for valid inputs
        private void CheckValid()
        {
            if (validEntry && validRemove) //if valid entry and remove
            {
                if (replaceTextButton.Checked && !validReplace) runButton.Enabled = false; //if replacing and not valid replace disable run button
                else runButton.Enabled = true; //otherwise enable run button
            }
            else runButton.Enabled = false; //disable run button

            if (forceLogReplace || forceLogInputOutput || forceLogRemove)
            {
                generateLogCheck.Checked = true;
                generateLogCheck.Enabled = false;
            }
            else generateLogCheck.Enabled = true;
        }

        //text in remove text box changed
        private void removeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading break
            if (removeTextBox.Text == null || removeTextBox.Text == "") validRemove = false; //if empty, mark as invalid
            else validRemove = true; //otherwise valid

            if (removeTextBox.Text.Length >= 36000) forceLogRemove = true;
            else forceLogRemove = false;

            CheckValid(); //check for readiness to run
        }

        //text in replace text box changed
        private void replaceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading break
            if (replaceTextBox.Text == null || replaceTextBox.Text == "") validReplace = false; //if empty, mark as invalid
            else validReplace = true; //otherwise valid

            if (replaceTextBox.Text.Length >= 36000) forceLogReplace = true;
            else forceLogReplace = false;

            CheckValid(); //check for readiness to run
        }

        //display help when button is clicked
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This tool can be used to easily remove duplicate strings from the input text.\n" +
                "1 - Enter the original text in the first box.\n" +
                "2 - Enter the text you want removed (Note: The tool will look for complete compies of this text," +
                " if there are multiple strings you want to remove, you will need to run the tool once for each)\n" +
                "3 - If you would like to REPLACE the text instead of removing it, check the box and enter the text" +
                " to replace with.\n" +
                "4 - Press Run.\n\n" +
                "Find me on GitHub: https://github.com/wowgeewhiz");
        }

        //when run button is clicked
        private void runButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //assign variables for use
            string tempOutput = "";
            string input = entryTextBox.Text;
            string remove = removeTextBox.Text;
            string replace = replaceTextBox.Text;
            bool repeat = true;


            bool log = generateLogCheck.Checked;
            Log generatedLog = new Log();

            generatedLog.ResetName(forceLogInputOutput, forceLogRemove, forceLogReplace);

            if (log)
            {
                if (generatedLog.original || forceLogInputOutput) generatedLog.AddOriginal(new string[] { input });
                if (generatedLog.removed || forceLogRemove) generatedLog.AddRemoved(new string[] { remove });
                if (generatedLog.replaced || forceLogReplace) generatedLog.AddReplaced(new string[] { replace });
            }

            int numKeysFound = 0;
            int numKeysRemoved = 0;
            int numKeysReplaced = 0;
            List<string> events = new List<string>();
            events.Add("Process started at " + DateTime.Now.ToString("MM.dd.yy-hh.mm.ss"));
            while (repeat) //loop until done
            {
                int temp; //temp integer for use
                if (input.Contains(remove)) //if key is in the input variable
                {
                    temp = input.IndexOf(remove); //temp is the index of the key
                    numKeysFound++;
                    events.Add("Key found at " + (temp + tempOutput.Length));
                    tempOutput += input.Substring(0, temp); //add section of input before key to output
                    numKeysRemoved++;
                    events.Add("Key removed at " + (temp + tempOutput.Length));
                    if (replaceTextButton.Checked)
                    {
                        tempOutput += replace; //add replace value if checked
                        numKeysReplaced++;
                        events.Add("Key replaced at " + (temp + tempOutput.Length));
                    }
                }
                else //if key is not in the remaining input
                {
                    events.Add("No remaining keys");
                    tempOutput += input; //add the remaining input to output
                    break; //break repeat loop
                }
                input = input.Substring(temp + remove.Length); //shorten input
            }
            events.Add("Keys found: " + numKeysFound);
            events.Add("Keys removed: " + numKeysRemoved);
            events.Add("Keys replaced: " + numKeysReplaced);
            events.Add("Process ended at " + DateTime.Now.ToString("MM.dd.yy-hh.mm.ss"));

            if (log)
            {
                if (generatedLog.cleaned || forceLogInputOutput) generatedLog.AddCleaned(new string[] { tempOutput });
                if (generatedLog.events) generatedLog.AddEvents(events.ToArray());
                generatedLog.GenerateLog();
            }

            Clipboard.SetText(tempOutput); //copy output to clipboard
            MessageBox.Show("\"" + tempOutput + "\" has been copied to your clipboard."); //display output

            this.Cursor = Cursors.Default;
            ResetForm(); //reset the form
        }

        //close the form
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //when load input text button clicked
        private void inputFromLoadButton_Click(object sender, EventArgs e)
        {
            Form getFile = new Form2(); //call form 2
            getFile.ShowDialog(); //show form 2 and pause until it is closed

            if (Program.tempString == "" || Program.tempString == null) return; //if return is empty, break
            else
            {
                entryTextBox.Text = Program.tempString; //otherwise update text
                Program.tempString = ""; //reset reference
            }
        }

        private void removeFromLoadButton_Click(object sender, EventArgs e)
        {
            Form getFile = new Form2(); //call form 2
            getFile.ShowDialog(); //show form 2 and pause until it is closed

            if (Program.tempString == "" || Program.tempString == null) return; //if return is empty, break
            else
            {
                removeTextBox.Text = Program.tempString; //otherwise update text
                Program.tempString = ""; //reset reference
            }
        }

        private void replaceFromLoadButton_Click(object sender, EventArgs e)
        {
            Form getFile = new Form2(); //call form 2
            getFile.ShowDialog(); //show form 2 and pause until it is closed

            if (Program.tempString == "" || Program.tempString == null) return; //if return is empty, break
            else
            {
                replaceTextBox.Text = Program.tempString; //otherwise update text
                Program.tempString = ""; //reset reference
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Form settings = new Form3(); //create a new settings form
            settings.ShowDialog(); //show form 3 and pause until it is closed
        }

        //replace text button is checked/unchecked
        private void replaceTextButton_CheckedChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading, break
            if (replaceTextButton.Checked)
            {
                replaceTextBox.Enabled = true; //enable text box if checked
                replaceFromLoadButton.Enabled = true; //enable button to load replace value from a text file
            }
            else
            {
                replaceTextBox.Enabled = false; //disable text box if not checked
                replaceFromLoadButton.Enabled = false; //disable button to load if not checked
            }
            CheckValid(); //check for readiness to run
        }

        //reset form
        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        //entry text box is changed
        private void entryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //break if loading
            if (entryTextBox.Text == null || entryTextBox.Text == "") validEntry = false; //if empty, mark as invalid
            else validEntry = true; //otherwise valid

            if (entryTextBox.Text.Length >= 36000) forceLogInputOutput = true;
            else forceLogInputOutput = false;

            CheckValid(); //check for readiness to run
        }
    }
}