using System;
using System.Windows.Forms;


static class Explorer
    {
        public static string Open(string Startup_Path, string Filter)
    {
        string filePath = string.Empty;
        //code from Microsoft documentation
        //explorer-like file selection
        var openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = Startup_Path;
        openFileDialog.Filter = Filter;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            //Get the path of specified file
            filePath = openFileDialog.FileName;

        }
        return filePath;
    }
    }

