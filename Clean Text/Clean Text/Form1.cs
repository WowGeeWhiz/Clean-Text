namespace Clean_Text
{
    public partial class Form1 : Form
    {
        //booleans for use throughout program
        bool loading, validEntry, validRemove, validReplace, forceLogInput, forceLogOutput, forceLogReplace, forceLogRemove;

        //force a log if a field has or will have this many characters
        int forceLogCharLimit = 36000;

        //constructor
        public Form1()
        {
            InitializeComponent();
            ResetForm();
        }

        //method to reset the form
        private void ResetForm()
        {
            loading = true; //start loading (disable other methods)

            validEntry = validRemove = validReplace = forceLogRemove = forceLogReplace = forceLogInput = forceLogOutput = false; //reset bools

            //empty and disable replace text box
            replaceTextBox.Enabled = false;
            replaceFromLoadButton.Enabled = false;
            replaceTextBox.Text = "";

            generateLogCheck.Enabled = true; //enable the generate log check box

            replaceTextButton.Checked = false; //uncheck replace text button

            entryTextBox.Text = ""; //empty entry text box

            removeTextBox.Text = ""; //empty remove text box

            runButton.Enabled = false; //disable run button

            loading = false; //stop loading (other methods will run now)
        }

        //check for valid inputs
        private void CheckValid()
        {
            if (validEntry && validRemove) //if valid entry text is given and remove text is also valid
            {
                if (replaceTextButton.Checked && !validReplace) runButton.Enabled = false; //if replacing the keys and not valid replacement value disable run button
                else runButton.Enabled = true; //otherwise enable run button
            }
            else runButton.Enabled = false; //disable run button

            //if forcing any log
            if (forceLogReplace || forceLogInput || forceLogOutput || forceLogRemove)
            {
                //check generate log box, disable it
                generateLogCheck.Checked = true;
                generateLogCheck.Enabled = false;

                //if the replace text or input text marked for force, force output as well
                if (forceLogReplace || forceLogInput) forceLogOutput = true;
            }
            else generateLogCheck.Enabled = true; //if not forcing log, enable generate log box
        }

        //text in remove box changed
        private void removeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading, break
            if (removeTextBox.Text == null || removeTextBox.Text == "") validRemove = false; //if empty, mark as invalid removal key
            else validRemove = true; //otherwise valid

            //force log of removal text if over char limit
            if (removeTextBox.Text.Length >= forceLogCharLimit) forceLogRemove = true;
            else forceLogRemove = false;

            CheckValid(); //check for readiness to run
        }

        //text in replace box changed
        private void replaceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading, break
            if (replaceTextBox.Text == null || replaceTextBox.Text == "") validReplace = false; //if empty, mark as invalid replacement value
            else validReplace = true; //otherwise valid

            //force log of replacement text if over char limit
            if (replaceTextBox.Text.Length >= forceLogCharLimit) forceLogReplace = true;
            else forceLogReplace = false;

            CheckValid(); //check for readiness to run
        }

        //text in entry box is changed
        private void entryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading, break
            if (entryTextBox.Text == null || entryTextBox.Text == "") validEntry = false; //if empty, mark as invalid entry
            else validEntry = true; //otherwise valid

            //force log entry if over char limit
            if (entryTextBox.Text.Length >= forceLogCharLimit) forceLogInput = true;
            else forceLogInput = false;

            CheckValid(); //check for readiness to run
        }

        //display help when button is clicked
        private void helpButton_Click(object sender, EventArgs e)
        {
            /*
            MessageBox.Show("This tool can be used to easily remove duplicate strings from the input text.\n" +
                "1 - Enter the original text in the first box.\n" +
                "2 - Enter the text you want removed (Note: The tool will look for complete compies of this text," +
                " if there are multiple strings you want to remove, you will need to run the tool once for each)\n" +
                "3 - If you would like to REPLACE the text instead of removing it, check the box and enter the text" +
                " to replace with.\n" +
                "4 - Press Run.\n\n" +
                "Find me on GitHub: https://github.com/wowgeewhiz");
                //this needs to be updated, see Issues
                */
        }

        //when run button is clicked
        private void runButton_Click(object sender, EventArgs e)
        {
            //use loading cursor
            Cursor = Cursors.WaitCursor;

            //assign variables for use
            string tempOutput = "";
            string input = entryTextBox.Text;
            string remove = removeTextBox.Text;
            string replace = replaceTextBox.Text;
            bool repeat = true;

            //check for generating log
            bool log = generateLogCheck.Checked;

            //new log instance (only used if log = true)
            Log generatedLog = new Log();

            //set log values to match forced values
            generatedLog.ResetBoolsAndName(
                forceLogInput,
                forceLogRemove, 
                forceLogReplace, 
                forceLogOutput, 
                (forceLogInput 
                    && forceLogOutput 
                    && forceLogRemove 
                    && forceLogReplace)
                );

            //if generating a log, add input, removal, and replacement texts (if logging these values)
            if (log)
            {
                if (generatedLog.original) generatedLog.AddOriginal(new string[] { input });
                if (generatedLog.removed) generatedLog.AddRemoved(new string[] { remove });
                if (generatedLog.replaced) generatedLog.AddReplaced(new string[] { replace });
            }

            //setup event log
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
                    //found key, mark index and increase count
                    temp = input.IndexOf(remove);
                    numKeysFound++;
                    events.Add("Key found at " + (temp + tempOutput.Length));

                    //remove key, increase count
                    tempOutput += input.Substring(0, temp);
                    numKeysRemoved++;
                    events.Add("Key removed at " + (temp + tempOutput.Length));

                    //if replacing, replace key, increase count
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
                input = input.Substring(temp + remove.Length); //shorten to unparsed input
            }

            //finish event log
            events.Add("\n\nKeys found: " + numKeysFound);
            events.Add("Keys removed: " + numKeysRemoved);
            events.Add("Keys replaced: " + numKeysReplaced);
            events.Add("\nProcess ended at " + DateTime.Now.ToString("MM.dd.yy-hh.mm.ss"));

            //if generating log, add cleaned text and event log (if logging these values)
            //then generate the log
            if (log)
            {
                if (generatedLog.cleaned) generatedLog.AddCleaned(new string[] { tempOutput });
                if (generatedLog.events) generatedLog.AddEvents(events.ToArray());

                //generate the actual log files
                generatedLog.GenerateLog();
                //display output
                MessageBox.Show("Text cleaned and saved to generated file(s) at " + generatedLog.dir + "\n" +
                "Files Generated: " + generatedLog.generatedFiles);
            }
            else //if not generating log
            {
                Clipboard.SetText(tempOutput); //copy output to clipboard
                MessageBox.Show("Cleaned text has been copied to your clipboard."); //display output
            }

            Cursor = Cursors.Default; //return cursor to normal
            ResetForm(); //reset the form
        }

        //close button
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //when "load input text" button clicked
        private void inputFromLoadButton_Click(object sender, EventArgs e)
        {
            //This needs to be updated, replace with file load dialogue here and remove form 2. 
            //See issue 12

            Form getFile = new Form2(); //call form 2
            getFile.ShowDialog(); //show form 2 and pause until it is closed

            if (Program.tempString == "" || Program.tempString == null) return; //if return is empty, break
            else
            {
                entryTextBox.Text = Program.tempString; //otherwise update text
                Program.tempString = ""; //reset reference
            }
        }

        //when "load remove text" button clicked
        private void removeFromLoadButton_Click(object sender, EventArgs e)
        {
            //This needs to be updated, replace with file load dialogue here and remove form 2. 
            //See issue 12
            
            Form getFile = new Form2(); //call form 2
            getFile.ShowDialog(); //show form 2 and pause until it is closed

            if (Program.tempString == "" || Program.tempString == null) return; //if return is empty, break
            else
            {
                removeTextBox.Text = Program.tempString; //otherwise update text
                Program.tempString = ""; //reset reference
            }
        }

        //when "load replacement text" button clicked
        private void replaceFromLoadButton_Click(object sender, EventArgs e)
        {
            //This needs to be updated, replace with file load dialogue here and remove form 2. 
            //See issue 12
            
            Form getFile = new Form2(); //call form 2
            getFile.ShowDialog(); //show form 2 and pause until it is closed

            if (Program.tempString == "" || Program.tempString == null) return; //if return is empty, break
            else
            {
                replaceTextBox.Text = Program.tempString; //otherwise update text
                Program.tempString = ""; //reset reference
            }
        }

        //open settings page
        private void settingsButton_Click(object sender, EventArgs e)
        {
            Form settings = new Form3(); //create a new settings form
            settings.ShowDialog(); //show settings form and pause this form until settings is closed
        }

        //replace text button is checked/unchecked
        private void replaceTextButton_CheckedChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading, break

            //if the box is now checked
            if (replaceTextButton.Checked)
            {
                replaceTextBox.Enabled = true; //enable text box
                replaceFromLoadButton.Enabled = true; //enable button to load replace value from a text file
            }
            //if the box is now unchecked
            else
            {
                replaceTextBox.Enabled = false; //disable text box 
                replaceFromLoadButton.Enabled = false; //disable button to load
            }
            CheckValid(); //check for readiness to run
        }

        //reset form
        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}