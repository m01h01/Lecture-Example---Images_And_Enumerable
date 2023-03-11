using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Lecture_Example___Images_and_Enumerable.InstagramPost;

namespace Lecture_Example___Images_and_Enumerable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlowDocument flDocument = new FlowDocument();
        List <InstagramPost> posts = new List <InstagramPost> ();
        public MainWindow()
        {
            InitializeComponent();
            PreloadComboBox();
        }
        public void PreloadComboBox()
        {
            cbColor.Items.Add("Regular");
            cbColor.Items.Add("Greyscale");

            cbColor.SelectedIndex = 0;
        }
        private void btnGetImage_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = filePath();
 
        }
        public string filePath()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filePath = "";

            if (op.ShowDialog() == true)
            {
                tbImage.Text += op.FileName;

                return op.FileName;
            }
            else
            {
                return "";
            }
        }

        private void btnMakePost_Click(object sender, RoutedEventArgs e)
        {
            string header = tbHeader.Text;
            string body = tbBody.Text;
            string FilePath = tbImage.Text;

            if (FilePath != "")
            {
                int ImageFilterSelected = cbColor.SelectedIndex;
                InstagramPost.PhotoFilter photoFilter = (InstagramPost.PhotoFilter)ImageFilterSelected;

                InstagramPost instaPost = new InstagramPost(header, body, FilePath, photoFilter);
                posts.Add(instaPost);

                //no appending, only display the lastest updateted information
                flDocument.Blocks.Clear();
                int i = posts.Count;
                flDocument.Blocks.Add(posts[i - 1].InstaPostFormatted());

                rtbDisplay.Document = flDocument;

                ImagePost.Source = instaPost.Image;
            }
            else 
            {
                MessageBox.Show("Please select an image.");
            }

        }
    }
}
