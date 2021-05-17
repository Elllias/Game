using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Arena.Models
{
    public class Thing
    {
        public PointF Position;
        public Size Size;

        public Thing(PointF pos, Size size) 
        {
            Position = pos;
            Size = size;
        }
    }
}
