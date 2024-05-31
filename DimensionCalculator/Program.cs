using System;
using System.Reflection.Metadata;
using System.Text;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


namespace JumpOverFence

{
    class Program
    {
        private static void EncodingProvider(EncodingProvider instance)
        {
            throw new NotImplementedException();
        }
        static void Main(string[] args)
        {

            string[] Rooms = { "Living Room", "Guest Room 1", "Kitchen", "Master Bedroom", "Master Toilet", "Tosin's Room", "Tosin's Toilet", "Guest Room 2", "Guest Room 2 Toilet", "Passage way", "Balcony" ,"Office" };
            double[] Lenght = { 5.0, 3.8, 3.8, 4.3, 2, 4.4, 2.2, 5.8, 2.3, 2.1, 3, 3.4 };
            double[] Breadth = { 6.5, 2.5, 3.2, 6, 2.1, 3.7, 1.2, 4.2, 2.2, 1.1, 1, 2.1 };
            double[] Height = { 3, 3, 3, 2.9, 2.9, 2.9, 2.9, 2.9, 2.9, 2.9, 0, 3 };
            double FloorArea =0;
            double WallArea=0;


            Console.WriteLine("House Dimension:");
            Console.WriteLine(  );

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Floor Area";
            PdfDocument document2 = new PdfDocument();
            document2.Info.Title = "Dimensions";

            // Create an empty page
            PdfPage page1 = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page1);

            PdfPage page2 = document2.AddPage();
            XGraphics gfx2 = XGraphics.FromPdfPage(page2);

            // Create a font
            XFont font1 = new XFont("Arial", 20, XFontStyleEx.Bold);
            XFont font2 = new XFont("Arial", 12, XFontStyleEx.Regular);
            XFont font3 = new XFont("Arial", 16, XFontStyleEx.Bold);

            bool one = true;

            Console.WriteLine("Press 1 to Publish Dimensions and Press 2 to Publish Measurements.");
            string s = Console.ReadLine();
            if ( s != 1.ToString())
            {
                one = false;
            }

            if (one == true)
            {
gfx.DrawString("Uncle Babatunde's House Measurements", font1, XBrushes.IndianRed, new XRect((page1.Width/2)-200, 20, page1.Width, page1.Height), XStringFormats.TopLeft);
            }
            else
            {
gfx2.DrawString("Uncle Babatunde's House Dimensions", font1, XBrushes.IndianRed, new XRect((page2.Width / 2) - 200, 20, page2.Width, page2.Height), XStringFormats.TopLeft);

            }
                                  

            int x =10; int y=50;
                                

            for (int i = 0; i < Rooms.Length; i++)
            {
                
                //// Floor area
                gfx.DrawString($"{i+1}. {Rooms[i]} : Floor Area = {Math.Round(Lenght[i] * Breadth[i], 1)} m², Wall Area={Math.Round(Height[i] * (2 * (Lenght[i] + Breadth[i])), 1)}  m²", font2, XBrushes.Black, new XRect(x, y, page1.Width, page1.Height), XStringFormats.TopLeft);
                FloorArea=FloorArea + Math.Round(Lenght[i] * Breadth[i], 1);
                WallArea = WallArea + Math.Round(Height[i] * (2 * (Lenght[i] + Breadth[i])), 1);

                gfx2.DrawString($" {i + 1}. {Rooms[i]} : Lenght:{Lenght[i]}m Breadth:{Breadth[i]}m  Height:{Height[i]}m ", font2, XBrushes.Black, new XRect(x, y, page2.Width, page2.Height), XStringFormats.TopLeft);
                y = y + 15;

               
        }
            y = y + 15;



            gfx.DrawString($"Total Floor Area = {FloorArea} m²", font3, XBrushes.IndianRed, new XRect((page1.Width / 2) - 280, y, page1.Width, page1.Height), XStringFormats.TopLeft);
            y = y + 20;
            gfx.DrawString($"Total Wall Area = {Math.Round(WallArea, 1)} m²", font3, XBrushes.IndianRed, new XRect((page1.Width / 2) - 280, y, page1.Width, page1.Height), XStringFormats.TopLeft);
            y = y + 35;

            





            //// Save the document
            const string filename = "Dim.pdf";
            document.Save(filename);
            //// Save the document
            const string filename2 = "Dim.pdf";
            document2.Save(filename);
            if (one==true)
            {
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });

            }
            else
            {
                Process.Start(new ProcessStartInfo(filename2) { UseShellExecute = true });

            }

        }

        
    }
}
