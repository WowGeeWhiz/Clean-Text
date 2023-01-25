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
        string name;
        List<string> nameList = new List<string>();
        public string dir, addToName;
        public bool original, removed, replaced, cleaned, events, separate, asTxt;
        private bool emptyReplace;

        List<string[]> contents = new List<string[]>();

        public string generatedFiles = "";

        public Log()
        {
            ResetBoolsAndName();
        }

        public void ResetBoolsAndName(bool forceO = false, bool forceRm = false, bool forceRp = false, bool forceC = false, bool forceE = false, bool notReplace = false)
        {
            Preferences.LoadPrefs();

            dir = Preferences.currentConfig[0, 1];
            original = Preferences.StringToBool(Preferences.currentConfig[1, 1]);
            removed = Preferences.StringToBool(Preferences.currentConfig[2, 1]);
            replaced = Preferences.StringToBool(Preferences.currentConfig[3, 1]);
            cleaned = Preferences.StringToBool(Preferences.currentConfig[4, 1]);
            events = Preferences.StringToBool(Preferences.currentConfig[5, 1]);
            separate = Preferences.StringToBool(Preferences.currentConfig[6, 1]);
            asTxt = Preferences.StringToBool(Preferences.currentConfig[7, 1]);

            if (forceO) original = true;
            if (forceRm) removed = true;
            if (forceRp) replaced = true;
            if (forceC) cleaned = true;
            if (forceE) events = true;
            emptyReplace = notReplace;

            nameList = new List<string>();
            name = "\\" + Preferences.currentConfig[8, 1];
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
                string temp = "\\" + Preferences.currentConfig[8, 1];
                if (original) nameList.Add(temp + "original" + time);
                if (removed) nameList.Add(temp + "removed" + time);
                if (replaced) nameList.Add(temp + "replaced" + time);
                if (cleaned) nameList.Add(temp + "cleaned" + time);
                if (events) nameList.Add(temp + "events" + time);

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
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                if (separate)
                {
                    int index = 0;
                    for (int a = 0; a < nameList.Count; a++)
                    {
                        File.WriteAllLines(dir + @nameList[index], contents[index]);
                        generatedFiles = " " + generatedFiles + dir + @nameList[index];
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
                    File.WriteAllLines(dir + @name, lines.ToArray());
                    generatedFiles = generatedFiles + dir + @name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            MessageBox.Show("Logs generated at " + dir);

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
