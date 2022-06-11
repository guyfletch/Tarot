using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SkiaSharp;

namespace TarotFunctions
{
    public class Card
    {
        public SKBitmap Image { get; set; }
        public string Name { get; set; }
        public string FileLoc { get; set; }
        public bool Reversed { get; set; }

        public Card(string name)
        {
            Name = name;
            var path = FindAddress(name);
            FileLoc = Path.GetFullPath(path);
            Image = LoadImage(path);
        }

        private SKBitmap LoadImage(string path)
        {
            FileLoc = Path.GetFullPath(path);            
            return SKBitmap.Decode(path);
        }

        private static string FindAddress(string name)
        {
            return $"./Images/{name}.jpg";
        }
    }
}
