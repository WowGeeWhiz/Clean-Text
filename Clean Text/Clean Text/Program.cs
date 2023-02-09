namespace Clean_Text
{
    public static class Program
    {
        public static class Preferences
        {
            //static values for reference accross entire program
            public static string prefsVersion = "1.2.2";
            public static string prefDir = @Application.StartupPath + "config.ini";
            public static string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //default preferences
            public static string[,] prefs = new string[,]
            {
                {"outputDirectory=", ""}, //[0]
                {"outputOriginal=","0"}, //[1]
                {"outputRemoved=","0"}, //[2]
                {"outputReplace=","0"}, //[3]
                {"outputCleaned=","1"}, //[4]
                {"generateLog=","0"}, //[5]
                {"outputSeparate=","0"}, //[6]
                {"logName=","CleanedText-"}, //[7] - different pref was here but has been deprecated
                {"prefsVersion=",prefsVersion} //[8]
            };

            //loaded preferences
            public static string[,] currentConfig = prefs;

            //invalid characters for filenames, plus '='
            static char[] invalidDirChars = new char[] { '/', '\\', ':', ':', '"', '<', '>', '=' };

            //check for invalid character names in a given input
            public static bool CheckVaildNameChars(string name)
            {
                //foreach character in the invalid array
                foreach (char c in invalidDirChars)
                {
                    //return false if the character is in the input
                    if (name.Contains(c)) return false;
                }

                //if no invalid characters found, return true
                return true;
            }

            //load the saved preferences from the disk
            public static void LoadPrefs()
            {
                //try-catch for error handling
                try
                {
                    //if the prefs file does not exist
                    if (!File.Exists(prefDir))
                    {
                        //display that file is missing
                        MessageBox.Show("No config file found, generating file...");

                        //generate new prefs file with default values
                        WriteFile(prefDir, DoubleArrayToSingle(prefs));
                    }

                    //load values from the prefs file
                    string[] loadedConfigs = ReadFile(prefDir);

                    //if the config file does not match up with the current prefs
                    if (loadedConfigs.Length != prefs.GetLength(0))
                    {
                        //restore default settings, set them as the loaded values
                        MessageBox.Show("Config file missing keys, restoring default settings...");
                        loadedConfigs = DoubleArrayToSingle(prefs);

                        //write the defaults to disk
                        WriteFile(prefDir, loadedConfigs);
                    }

                    //foreach line of loaded prefs
                    for (int a = 0; a < loadedConfigs.Length; a++)
                    {
                        //split loaded pref on the '='
                        string[] tempArray = loadedConfigs[a].Split('=');

                        //set config to actual loaded value
                        currentConfig[a, 1] = tempArray[1];
                    }
                }
                //catch generic exception
                catch (Exception ex)
                {
                    //display error message
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            //write given preferences to disk
            public static void WritePrefs(string[] values)
            {
                //create new temp string for reference
                string[] temp = new string[values.Length];

                //try-catch for exception handling
                try
                {
                    //foreach line in the input
                    for (int i = 0; i < values.Length; i++)
                    {
                        //add the identifier to the string and set to temp value
                        temp[i] = currentConfig[i, 0] + values[i];

                        //set the chosen pref to given value
                        currentConfig[i, 1] = values[i];
                    }

                    //write the file
                    WriteFile(prefDir, temp);
                }
                //catch generic exception
                catch (Exception ex)
                {
                    //display error message
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            //convert 0/1 to false/true
            public static bool StringToBool(string input)
            {
                if (input == "1") return true;
                if (input == "0") return false;
                MessageBox.Show("Error loading bool, no valid input\nReturning false...");
                return false;
            }

            //combine a string[,] array into a string[] array
            static private string[] DoubleArrayToSingle(string[,] input)
            {
                //list of strings
                List<string> temp = new List<string>();

                //foreach array
                for (int i = 0; i < input.GetLength(0); i++)
                {
                    //add add columns 1 and 2 of given row to list
                    temp.Add(input[i, 0] + input[i, 1]);
                }

                //return list as array
                return temp.ToArray();
            }
        }

        //create a directory on the disk
        public static bool CreateDir(string dir, string extraMessage)
        {
            //try-catch for exception handling
            try
            {
                //create directory if it does not exist
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            }
            //if program cannot access the given directory
            catch (UnauthorizedAccessException)
            {
                //display message, return false
                MessageBox.Show(extraMessage + "\n" + dir + " is innacessible. Cannot create/use directory.");
                return false;
            }
            //generic exception catch
            catch (Exception ex)
            {
                //display message & return false
                MessageBox.Show(extraMessage + "\nError: " + ex.Message);
                return false;
            }
            //if no exceptions were triggered
            //return true
            return true;
        }

        //write a file
        public static void WriteFile(string dir, string[] lines)
        {
            //try-catch for exception handling
            try
            {
                //wrtie the file
                File.WriteAllLines(dir, lines);
            }
            //generic exception
            catch (Exception ex)
            {
                //display message
                MessageBox.Show("Error writing file: " + ex.Message);
            }
        }

        //read a file
        public static string[] ReadFile(string dir)
        {
            //temp array for values
            string[] temp = new string[0];

            //try-catch for exception handling
            try
            {
                //read all lines
                temp = File.ReadAllLines(dir);
            }
            //generic exception
            catch (Exception ex)
            {
                //display message
                MessageBox.Show("Failed to read file: " + ex.Message);
            }
            return temp;
        }

        //check if dir is accessible
        static public bool AccessibleDirectory(string dir)
        {
            //return value starts as true
            bool temp = true;

            //try-catch for exception handling
            try
            {
                //if directory does not exist, create directory
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                //write a test file to check for access
                File.WriteAllLines(dir + "\\test.txt", new string[] { "test file" });
            }
            //catch program cannot access dir
            catch (UnauthorizedAccessException)
            {
                //display message, mark as invalid
                MessageBox.Show("The program cannot access that directory.\nTry running the program as an administrator, or changing the security of the directory");
                temp = false;
            }
            //generic exception
            catch (Exception ex)
            {
                //dispaly message, mark as invalid
                MessageBox.Show("Error: " + ex.Message);
                temp = false;
            }
            finally
            {
                //delete temp file, return validit
                if (File.Exists(dir + "\\test.txt")) File.Delete(dir + "\\test.txt");
            }
            return temp;
        }

        //temp ref string to pass values between forms
        public static string tempString = ""; //static temp reference string

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Preferences.currentUser = Preferences.currentUser.Substring(Preferences.currentUser.IndexOf('\\') + 1); //must be before any calls to currentUser, this removes the machine name
            Preferences.prefs[0, 1] = @"C:\Users\" + Preferences.currentUser + @"\Downloads\CleanTextOutputFiles";
            Application.Run(new Form1());
        }
    }
}