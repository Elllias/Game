using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Models
{
    public static class Hero
    {
        public static int IdleFrames = 5;
        public static int RunFrames = 7;
        public static int AttackFrames = 7;
        public static int DeathFrames = 8;

        public static Image Icon = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Hero\\Frames.png"));
    }
}
