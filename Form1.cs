using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string fileContent = string.Empty;
            string filePath = string.Empty;
            //code from Microsoft documentation
            //explorer-like file selection
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

            textBox1.Text = filePath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //space-holders for now, would use GUI.PromptMenu() for each Question once
            string[] test = { "one", "two", "three", "four" };
            GUI.PromptMenu("1 A long text\nit goes on\nand on",test);
        }
    }
}
