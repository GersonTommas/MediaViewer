using System;
using System.IO;
using Microsoft.Win32;

namespace MediaViewer.Presenter
{
    public class ApplicationController
    {

        #region Private Variables

        // Instance of Main Window
        private readonly MainWindow _shell;

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="shell">An instance of MainWindow</param>
        public ApplicationController(MainWindow shell)
        {
            _shell = shell;
        }

        #endregion


        #region Show Manu Function

        /// <summary>
        /// Returns to the Main Menu
        /// </summary>
        public void ShowMenu()
        {
            new MenuPresenter(this);
        }

        #endregion


        #region Change View

        /// <summary>
        /// Cleans the Buffer and loads the new View
        /// </summary>
        /// <param name="view"></param>
        public void DisplayInShell(object view)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _shell.TransitionTo(view);
        }

        #endregion


        #region Directory Request

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

        #endregion

    }
}
