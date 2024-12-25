using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace WPFTextEditor
{
    public partial class MainWindow : Window
    {
        private string currentFileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            EditorTextBox.Clear();
            currentFileName = null;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                currentFileName = openFileDialog.FileName;
                EditorTextBox.Text = File.ReadAllText(currentFileName);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFileName))
            {
                SaveAsFile_Click(sender, e);
            }
            else
            {
                File.WriteAllText(currentFileName, EditorTextBox.Text);
            }
        }

        private void SaveAsFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                currentFileName = saveFileDialog.FileName;
                File.WriteAllText(currentFileName, EditorTextBox.Text);
            }
        }
    }
}
