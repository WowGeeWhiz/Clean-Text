namespace Clean_Text
{
    public  static class Program
    {
        public static class Preferences
        {
            public static string prefsVersion = "1.2.2";
            public static string prefDir = @Application.StartupPath + "config.ini";
            public static string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            public static string[,] prefs = new string[,]
            {
                {"outputDirectory=", ""}, //[0]
                {"outputOriginal=","0"}, //[1]
                {"outputRemoved=","0"}, //[2]
                {"outputReplace=","0"}, //[3]
                {"outputCleaned=","1"}, //[4]
                {"generateLog=","0"}, //[5]
                {"outputSeparate=","0"}, //[6]
                {"logName=","CleanedText-"}, //[7] - different value was here but has been deprecated
                {"prefsVersion=",prefsVersion} //[8]
            };
            public static string[,] currentConfig = prefs;
            static char[] invalidDirChars = new char[] { '/', '\\', ':', ':', '"', '<', '>', '=' };

            public static bool CheckVaildNameChars(string name)
            {
                foreach (char c in invalidDirChars)
                {
                    if (name.Contains(c)) return false;
                }
                return true;
            }

            public static void LoadPrefs()
            {
                try
                {
                    if (!File.Exists(prefDir))
                    {
                        MessageBox.Show("No config file found, generating file...");
                        File.WriteAllLines(prefDir, DoubleArrayToSingle(prefs));
                    }

                    string[] loadedConfigs = File.ReadAllLines(prefDir);
                    if (loadedConfigs.Length != prefs.GetLength(0))
                    {
                        MessageBox.Show("Config file missing keys, restoring default settings...");
                        loadedConfigs = DoubleArrayToSingle(prefs);
                        File.WriteAllLines(prefDir, loadedConfigs);
                    }

                    for (int a = 0; a < loadedConfigs.Length; a++)
                    {
                        string[] tempArray = loadedConfigs[a].Split('=');
                        currentConfig[a, 1] = tempArray[1];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            public static void WritePrefs(string[] values)
            {
                string[] temp = new string[values.Length];

                try
                {
                    for(int i = 0; i < values.Length; i++)
                    {
                        temp[i] = currentConfig[i, 0] + values[i];
                        currentConfig[i, 1] = values[i];
                    }

                    File.WriteAllLines(prefDir, temp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            public static bool StringToBool(string input)
            {
                if (input == "1") return true;
                if (input == "0") return false;
                MessageBox.Show("Error loading bool, no valid input\nReturning false...");
                return false;
            }

            static private string[] DoubleArrayToSingle(string[,] input)
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < input.GetLength(0); i++)
                {
                    temp.Add(input[i, 0] + input[i, 1]);
                }
                return temp.ToArray();
            }

            static public bool AccessibleDirectory(string dir)
            {
                bool temp = true;
                try
                {
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                    File.WriteAllLines(dir + "\\test.txt", new string[] { "test file" });
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("The program cannot access that directory.\nTry running the program as an administrator, or changing the security of the directory");
                    temp = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    temp = false;
                }
                finally
                {
                    if (File.Exists(dir + "\\test.txt")) File.Delete(dir + "\\test.txt");
                }
                return temp;
            }
        }

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