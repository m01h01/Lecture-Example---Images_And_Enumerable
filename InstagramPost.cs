using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lecture_Example___Images_and_Enumerable
{
    
    internal class InstagramPost
    {
        public enum PhotoFilter { Regular, GreyScale }

        PhotoFilter _filter;
        string _header;
        string _body;
        BitmapSource _image;
        DateTime _posted;
        public InstagramPost(string header, string body, string filePath, PhotoFilter filter)
        {
            _header = header;
            _posted = DateTime.Now;
            _body = body;
            _filter = filter;
            if (filter == PhotoFilter.GreyScale)
            {

                _image = GenerateGreyScale(GenerateImage(filePath));
            }
            else
            {
                _image = GenerateImage(filePath);
                
            }

        }
        public string Header { get => _header; set => _header = value; }
        public string Body { get => _body; set => _body = value; }
        public BitmapSource Image { get => _image; set => _image = value; }
       
        public Run HeaderFormatted(string headerText)
        { 
          Run RunHeader = new Run (headerText);

            return RunHeader;
        }
        public Run BodyFormatted(string bodyText)
        {
            Run RunBody = new Run(bodyText);

            return RunBody;
        }

        public Paragraph InstaPostFormatted()
        {
            Paragraph paragraph = new Paragraph();

            string header = $"{_header} - {_posted.ToShortDateString()}";
            string body = _body;

            //Create a run
            Run runHeader = HeaderFormatted(header);
            Run runBody = BodyFormatted(body);

            //add to Paragragh
            paragraph.Inlines.Add(runHeader);
            paragraph.Inlines.Add("\n");
            paragraph.Inlines.Add(runBody);

            return paragraph;
        }
        private BitmapImage GenerateImage(string filePath)
        {

            return new BitmapImage(new Uri(filePath));
        }
        private FormatConvertedBitmap GenerateGreyScale(BitmapImage bitmap)
        {
            FormatConvertedBitmap gray = new FormatConvertedBitmap();
            gray.BeginInit();
            gray.Source = bitmap;
            gray.DestinationFormat = PixelFormats.Gray32Float;
            gray.EndInit();

            return gray;
        }
        public override string ToString()
        {
            return $"{_header} - {_posted.ToShortDateString()}" +
                $"\n" +
                $"{_body}";
        }
    }
}
