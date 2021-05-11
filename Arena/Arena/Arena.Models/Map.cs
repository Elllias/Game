using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Arena.Models
{
    public class Map
    {
        public static int[,] map = new int[MapHeight, MapWidth];
        public const int MapHeight = 20;
        public const int MapWidth = 20;
        public static int CellSize = 31;
        public static Image MapSprite;

        public static void Init()
        {
            map = GetMap();
            MapSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Backgrounds\\background.png"));
        }

        public static int[,] GetMap()
        {
            return new int[,]
            {
                { 1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,12,12,12,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,12,11,12,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,12,12,12,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            };
        }
    }
}
