using FellowOakDicom;
using FellowOakDicom.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DICOMToJPEGConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFolderPath = "path_to_your_dicom_files";
            string outputFolderPath = "path_to_save_jpeg_files";

            foreach (string file in Directory.EnumerateFiles(inputFolderPath, "*.dcm"))
            {
                try
                {
                    var dicomImage = new DicomImage(file);
                    using var image = dicomImage.RenderImage().As<Bitmap>(); // Convert to Bitmap
                    var jpegPath = Path.Combine(outputFolderPath, Path.GetFileNameWithoutExtension(file) + ".jpeg");
                    image.Save(jpegPath, ImageFormat.Jpeg); // Save as JPEG
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }

            Console.WriteLine("Conversion complete.");
        }
    }
}
