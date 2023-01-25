using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clean_Text.Program;

namespace Clean_Text
{
    internal class Log
    {
        string name;
        List<string> nameList = new List<string>();
        string dir = Preferences.currentConfig[0, 1];
        public bool original = Preferences.StringToBool(Preferences.currentConfig[1, 1]);
        public bool removed = Preferences.StringToBool(Preferences.currentConfig[2, 1]);
        public bool replaced = Preferences.StringToBool(Preferences.currentConfig[3, 1]);
        public bool cleaned = Preferences.StringToBool(Preferences.currentConfig[4, 1]);
        public bool events = Preferences.StringToBool(Preferences.currentConfig[5, 1]);
        public bool separate = Preferences.StringToBool(Preferences.currentConfig[6, 1]);
        public bool asTxt = Preferences.StringToBool(Preferences.currentConfig[7, 1]);

        List<string[]> contents = new List<string[]>();

        public Log()
        {
            name = "\\";
            string time = DateTime.Now.ToString("-MM.dd.yy-hh.mm.ss");

            if (!separate)
            {
                if (original) name += "O";
                if (removed) name += "Rm";
                if (replaced) name += "Rp";
                if (cleaned) name += "C";
                if (events) name += "E";
                name += time;
                if (asTxt) name += ".txt";
                else name += ".log";
            }
            else
            {
                if (original) nameList.Add("\\original" + time);
                if (removed) nameList.Add("\\removed" + time);
                if (replaced) nameList.Add("\\replaced" + time);
                if (cleaned) nameList.Add("\\cleaned" + time);
                if (events) nameList.Add("\\events" + time);


                for (int a = 0; a < nameList.Count; a++)
                {
                    if (asTxt) nameList[a] = nameList[a] + ".txt";
                    else nameList[a] = nameList[a] + ".log";
                }
            }
            
        }

        public void GenerateLog()
        {
            try
            {
                if (separate)
                {
                    int index = 0;
                    for (int a = 0; a < nameList.Count; a++)
                    {
                        File.WriteAllLines(@Preferences.currentConfig[0, 1] + @nameList[index], contents[index]);
                        index++;
                    }
                }
                else
                {
                    List<string> lines = new List<string>();
                    for (int i = 0; i < contents.Count; i++)
                    {
                        for (int a = 0; a < contents[i].Length; a++)
                        {
                            lines.Add(contents[i][a]);
                        }
                        lines.Add("\n\n\n");
                    }
                    File.WriteAllLines(@Preferences.currentConfig[0, 1] + @name, lines.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string[] CopyToAddArray(string[] input, string[] newArray)
        {
            int offset = (newArray.Length) - (input.Length);
            for (int a = 0; a < input.Length; a++)
            {
                newArray[a + offset] = input[a];
            }

            return newArray;
        }

        public void AddOriginal(string[] originalTxt)
        {
            string[] temp = new string[originalTxt.Length + 2];
            temp[0] = "Original Text: ";
            temp = CopyToAddArray(originalTxt, temp);
            contents.Add(temp);
        }

        public void AddRemoved(string[] removedTxt)
        {
            string[] temp = new string[removedTxt.Length + 2];
            temp[0] = "Text that was removed: ";
            temp = CopyToAddArray(removedTxt, temp);
            contents.Add(temp);
        }

        public void AddReplaced(string[] replacedTxt)
        {
            string[] temp = new string[replacedTxt.Length + 2];
            temp[0] = "Text that was inserted: ";
            temp = CopyToAddArray(replacedTxt, temp);
            contents.Add(temp);
        }

        public void AddCleaned(string[] cleanedTxt)
        {
            string[] temp = new string[cleanedTxt.Length + 2];
            temp[0] = "Finished text: ";
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
