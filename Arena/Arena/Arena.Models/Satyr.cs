using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Arena.Models
{
    public static class Satyr
    {
        public static int IdleFrames = 7;
        public static int RunFrames = 10;
        public static int AttackFrames = 7;
        public static int DeathFrames = 8;

        public static Image Icon = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Satyr\\SatyrFrames.png"));
    }
}
