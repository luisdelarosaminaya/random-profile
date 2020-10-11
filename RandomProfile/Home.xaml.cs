using System;
using System.Windows;

using RandomProfileApp.Models;
using RandomProfileApp.Data;
using Microsoft.Win32;
using System.IO;

namespace RandomProfileApp
{    
    public partial class Home : Window
    {
        public Profile _profile = default;
        
        public Home()
        {
            InitializeComponent();

            _profile = new Profile();
            GenerateProfile();
            DataContext = _profile;            
        }

        private void GenerateProfile()
        {
            try
            {
                RandomUserApi.FromJson(API.GET, _profile);                
                scrollViewer.ScrollToTop();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            GenerateProfile();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "json";
            saveFile.Filter = "Json|*.json";

            if (saveFile.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFile.FileName, _profile.Serialize());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }                       
        }
    }
}
