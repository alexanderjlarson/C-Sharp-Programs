using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Drawing245
{
    class Illustrator
    {
        public static void Draw(Drawing drawing, Graphics graph)
        {
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            foreach (Shape s in drawing.Shapes)
            {
                if (s.GetShapeType() == "Rectangle")
                {
                    graph.DrawRectangle(p, s.X + drawing.DispX, s.Y + drawing.DispY, s.Width, s.Height);
                }
                else if (s.GetShapeType() == "Ellipse")
                {
                    graph.DrawEllipse(p, s.X + drawing.DispX, s.Y + drawing.DispY, s.Width, s.Height);
                }
                else if (s.GetShapeType() == "Ball")
                {
                    graph.FillEllipse(sb, s.X + drawing.DispX, s.Y + drawing.DispY, s.Width, s.Height);
                }
            }
        }
    }
}
