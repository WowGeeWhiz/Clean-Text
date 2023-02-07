using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Clean_Text.Program;

namespace Clean_Text
{
    internal class Log
    {
        //log filename for single file output
        string name;

        //log list of file names for separate file output
        List<string> nameList = new List<string>();

        //strings for filename
        public string dir, addToName;

        //bools for which logs to create
        public bool original, removed, replaced, cleaned, events, separate, asTxt;

        //bool for determining if the keys were replaced with a new value
        private bool emptyReplace;

        //list of all log contents
        List<string[]> contents = new List<string[]>();

        //string for containing the generated files
        public string generatedFiles = "";

        //constructor
        public Log()
        {
            //set all values to default(empty&false)
            ResetBoolsAndName();
        }

        //constructor for forcing logs
        public void ResetBoolsAndName(
            bool forceO = false,
            bool forceRm = false, 
            bool forceRp = false, 
            bool forceC = false, 
            bool forceE = false, 
            bool notReplace = false)
        {
            //update the current preferences
            Preferences.LoadPrefs();

            //set the directory to the loaded directory
            dir = Preferences.currentConfig[0, 1];

            //check for which logs to generate
            original = Preferences.StringToBool(Preferences.currentConfig[1, 1]) || forceO;
            removed = Preferences.StringToBool(Preferences.currentConfig[2, 1]) || forceRm;
            replaced = Preferences.StringToBool(Preferences.currentConfig[3, 1]) || forceRp;
            cleaned = Preferences.StringToBool(Preferences.currentConfig[4, 1]) || forceC;
            events = Preferences.StringToBool(Preferences.currentConfig[5, 1]) forceC;
            separate = Preferences.StringToBool(Preferences.currentConfig[6, 1]);

            //check for empty replace value
            emptyReplace = notReplace;

            //initialize list of names and single name
            nameList = new List<string>();
            name = "\\" + Preferences.currentConfig[7, 1];

            //get current time
            string time = DateTime.Now.ToString("-MM.dd.yy-hh.mm.ss");

            //if generating as single file
            if (!separate)
            {
                //add indicator for each log type generated
                if (original) name += "O";
                if (removed) name += "Rm";
                if (replaced) name += "Rp";
                if (cleaned) name += "C";
                if (events) name += "E";

                //add time and .txt to file name
                name += time;
                name += ".txt";
            }
            //if generating as separate files
            else
            {
                //get prefix
                string temp = "\\" + Preferences.currentConfig[8, 1];

                //add each generated log type to the list
                if (original) nameList.Add(temp + "original" + time + ".txt");
                if (removed) nameList.Add(temp + "removed" + time + ".txt");
                if (replaced) nameList.Add(temp + "replaced" + time + ".txt");
                if (cleaned) nameList.Add(temp + "cleaned" + time + ".txt");
                if (events) nameList.Add(temp + "events" + time + ".txt");
            }
        }

        //generate the log
        public void GenerateLog()
        {
            //try catch to prevent crashes
            try
            {
                //Check for if the program can actually generate to the defined directory
                if (!Program.CreateDir(dir, "Log(s) failed to generate.")) break;

                //if generating separate logs
                if (separate)
                {

                    //why is there a separate index here?
                    //I need to try removing the index int and just using a inside the loop
                    //see issue 17

                    //temp index for reference
                    int index = 0;

                    //foreach different log being generated
                    for (int a = 0; a < nameList.Count; a++)
                    {
                        //write the file
                        Program.WriteFile(dir + @nameList[index], contents[index]);

                        //add the filename to the list of generated files
                        generatedFiles = " " + generatedFiles + dir + @nameList[index];
                        index++;
                    }
                }
                //if generating a single log
                else
                {
                    //list of strings for content
                    List<string> lines = new List<string>();

                    //foreach array in contents
                    for (int i = 0; i < contents.Count; i++)
                    {
                        //foreach string in contents
                        for (int a = 0; a < contents[i].Length; a++)
                        {
                            //add each line to a list
                            lines.Add(contents[i][a]);
                        }

                        //add space between arrays
                        lines.Add("\n\n\n");
                    }

                    //write the file
                    Program.WriteFile(dir + @name, lines.ToArray());

                    //add the name to the list of filenames
                    generatedFiles = generatedFiles + dir + @name;
                }
            }
            //catch generic exception
            catch (Exception ex)
            {
                //display error message and break
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        //this can probably be done more efficiently
        //requiring 2 input string[] is goofy
        //one input string[] and create a new one inside the array
        //one input string passed from AddXXXXX() function, this will be indicator
        //then the new array gets the indicator, then the contents
        //could also be done inside of the generic AddXXXXX() function after issue 18 is resolved
        //see issue 19

        //create buffer space in an array   
        private string[] CopyToAddArray(string[] input, string[] newArray)
        {
            //get difference in lines between the array to add and the new array
            int offset = (newArray.Length) - (input.Length);

            //foreach line in the input array
            for (int a = 0; a < input.Length; a++)
            {
                //add the line to the new array with the buffer space at the top of the array
                newArray[a + offset] = input[a];
            }

            //return the finished array
            return newArray;
        }

        //these AddXXXX() functions need to be replaced with one function
        //the function can just use a second argument to determine the indicator
        //not commenting each one, as they will be deprecated and replaced with one method
        //calls to each will also need to be replaced to calls to the generic function with the correct identifier string
        //see issue 18


        //add the input text to an array with an indicator
        public void AddOriginal(string[] originalTxt)
        {
            //new array that is 2 lines longer than the input
            string[] temp = new string[originalTxt.Length + 2];

            //set first line to indicator
            temp[0] = "Original Text: ";

            //add the array to the new array, leaving 2 lines untouched at beginning
            temp = CopyToAddArray(originalTxt, temp);

            //add array to the list of content
            contents.Add(temp);
        }

        public void AddRemoved(string[] removedTxt)
        {
            string[] temp = new string[removedTxt.Length + 2];
            temp[0] = "Key: ";
            temp = CopyToAddArray(removedTxt, temp);
            contents.Add(temp);
        }

        public void AddReplaced(string[] replacedTxt)
        {
            string[] temp = new string[replacedTxt.Length + 2];
            if (!emptyReplace) temp[0] = "Keys replaced with: ";
            else temp[0] = "Key was not replaced";
            temp = CopyToAddArray(replacedTxt, temp);
            contents.Add(temp);
        }

        public void AddCleaned(string[] cleanedTxt)
        {
            string[] temp = new string[cleanedTxt.Length + 2];
            temp[0] = "Cleaned text: ";
            temp = CopyToAddArray(cleanedTxt, temp);
            contents.Add(temp);
        }

        public void AddEvents(string[] eventsTxt)
        {
            string[] temp = new string[eventsTxt.Length + 2];
            temp[0] = "Log of Events: ";
            temp = CopyToAddArray(eventsTxt, temp);
            contents.Add(temp);
        }
    }
}
