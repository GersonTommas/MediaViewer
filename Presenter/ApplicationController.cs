using System;
using System.IO;
using Microsoft.Win32;

namespace MediaViewer.Presenter
{
    public class ApplicationController
    {
        private readonly MainWindow _shell;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="shell">An instance of MainWindow</param>
        public ApplicationController(MainWindow shell)
        {
            _shell = shell;
        }

        public void ShowMenu()
        {
            new MenuPresenter(this);
        }

        public void DisplayInShell(object view)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _shell.TransitionTo(view);
        }

        /// <summary>
        /// Asks the User to select a directory
        /// </summary>
        /// <returns>STRING - Directory Selected OR Empty</returns>
        public string RequestDirectoryFromUser()
        {
            // Folder selector window
            OpenFileDialog dialog = new OpenFileDialog() { Title = "Please choose a folder.", CheckFileExists = false, FileName = "[Get Folder]", Filter = "Folders|no.files" };

            // Folder selector starts in MyDocuments folder
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // If something is selected, pass the path
            if ((bool)dialog.ShowDialog())
            {
                string path = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            // If nothing is selected pass an empty string
            return string.Empty;
        }
    }
}
