using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using valorant_instalock.Models;

namespace valorant_instalock.Classes
{
    internal static class ImageRecognition
    {
        internal static Coordinate GetCoordinates(Image image)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(new Bitmap(ScreenCapture.CaptureScreen()));
            Image<Bgr, byte> template = new Image<Bgr, byte>(new Bitmap(image));

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    int X = match.X + (match.Width / 2);
                    int Y = match.Y + (match.Height / 2);

                    return new Coordinate(X, Y);
                }
                else return null;
            }
        }
    }
}
