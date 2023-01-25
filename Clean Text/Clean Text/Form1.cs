namespace Clean_Text
{
    public partial class Form1 : Form
    {
        //booleans for use throughout program
        bool loading, validEntry, validRemove, validReplace;
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

            validEntry = validRemove = validReplace = false; //mark entries invalid

            //empty and disable replace text box
            replaceTextBox.Enabled = false;
            replaceFromLoadButton.Enabled = false;
            replaceTextBox.Text = "";

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
        }

        //text in remove text box changed
        private void removeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading break
            if (removeTextBox.Text == null || removeTextBox.Text == "") validRemove = false; //if empty, mark as invalid
            else validRemove = true; //otherwise valid
            CheckValid(); //check for readiness to run
        }

        //text in replace text box changed
        private void replaceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return; //if loading break
            if (replaceTextBox.Text == null || replaceTextBox.Text == "") validReplace = false; //if empty, mark as invalid
            else validReplace = true; //otherwise valid
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
            //assign variables for use
            string tempOutput = "";
            string input = entryTextBox.Text;
            string remove = removeTextBox.Text;
            string replace = replaceTextBox.Text;
            bool repeat = true;

            while (repeat) //loop until done
            {
                int temp; //temp integer for use
                if (input.Contains(remove)) //if key is in the input variable
                {
                    temp = input.IndexOf(remove); //temp is the index of the key
                    tempOutput += input.Substring(0, temp); //add section of input before key to output
                    if (replaceTextButton.Checked) tempOutput += replace; //add replace value if checked
                }
                else //if key is not in the remaining input
                {
                    tempOutput += input; //add the remaining input to output
                    break; //break repeat loop
                }
                input = input.Substring(temp + remove.Length); //shorten input
            }

            Clipboard.SetText(tempOutput); //copy output to clipboard
            MessageBox.Show("\"" + tempOutput + "\" has been copied to your clipboard."); //display output
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
            CheckValid(); //check for readiness to run
        }
    }
}