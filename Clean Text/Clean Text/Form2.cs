using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clean_Text
{
    public partial class Form2 : Form
    {
        string tempValue = "";

        public Form2()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Program.tempString = tempValue;
            Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "txt files (*.txt)|*.txt",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePathTextBox.Text = openFileDialog1.FileName;

                    Stream stream = openFileDialog1.OpenFile();
                    StreamReader reader = new StreamReader(stream);
                    tempValue = reader.ReadToEnd();
                    previewTextBox.Text = tempValue;

                    reader.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Program.tempString = "";
            this.Close();
        }
    }
}
