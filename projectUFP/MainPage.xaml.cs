using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Pratice.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExamPaper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<String> imagePaths = new ObservableCollection<String>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ImagesCombo_Loaded(object sender, RoutedEventArgs e)
        {
            string folderPath = "Assets";
            IEnumerable<string> filePaths = await ImageService.GetAssetFiles(folderPath);
            foreach (var filePath in filePaths)
            {
                imagePaths.Add(filePath);
            }
        }
        private void ProductList_Loaded(object sender, RoutedEventArgs e)
        {
            ProductList.Items.Add(new Product { Name = "Product", Description = "1 ", ImagePath = "Assets/1.jfif" });
            ProductList.Items.Add(new Product { Name = "Product", Description = "2", ImagePath = "Assets/3.3.jfif" });
            ProductList.Items.Add(new Product { Name = "Product", Description = "3", ImagePath = "Assets/33.jfif" });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(ImagesCombo.SelectedValue);
            ProductList.Items.Add(new Product
            {
                Name = NameText.Text,
                Description = DescriptionText.Text,
                ImagePath = (string)ImagesCombo.SelectedValue
            });
        }
    }
}
