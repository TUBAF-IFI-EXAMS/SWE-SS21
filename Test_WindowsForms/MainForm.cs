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
using Microsoft.WindowsAPICodePack.Dialogs;


namespace Test_WindowsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const string mainDir = "c:\\";
        private const string ooxmlFilter = "Word files (*.docx)|*.docx";
        //private const string txtFilter = "Text files (*.txt)|*.txt";
        //private const string xmlFilter = "XML files (*.xml)|*.xml";
        private const string generalFilter = "All files(*.*) | *.* ";
        private const string defaultType = ".txt";
        private const string defaultName = "Output";

        private const string pBegin = "<p>";
        private const string pEnd = "</p>";
        private const string listSign = " - ";

        private void button1_Click(object sender, EventArgs e)
        {
         
            string filePath = Explorer.Open(mainDir, ooxmlFilter + "|" + generalFilter);
            
            textBox1.Text = filePath;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string outputPath = string.Empty;
            var folderExplorer = new CommonOpenFileDialog();

            folderExplorer.IsFolderPicker = true;
            folderExplorer.Multiselect = false;
            folderExplorer.DefaultDirectory = mainDir;


            if (folderExplorer.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputPath = folderExplorer.FileName;
            }

            textBox2.Text = outputPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlParser parser;
            try{ 
                 parser = new XmlParser(textBox1.Text);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show($"Path {textBox1.Text} could not be found");
                return;
            }

            string fileName = textBox3.Text == string.Empty ? defaultName : textBox3.Text;

            StreamWriter sw;
            try
            {
                 sw = File.CreateText(textBox2.Text + "\\" + fileName + defaultType);
            }
            catch(System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show($"Path {textBox2.Text} could not be found");
                return;
            }

            while (parser.ReadSection(out var Paragraph))
            {
                if(!radioButton3.Checked) sw.Write(pBegin);
                if(radioButton2.Checked && Paragraph.isList) sw.Write(listSign);
                sw.WriteQti(Paragraph);
                if(!radioButton3.Checked) sw.Write(pEnd);
            }
            sw.Close();
            MessageBox.Show($"Content written to {textBox2.Text} ");
        }
    }
}
