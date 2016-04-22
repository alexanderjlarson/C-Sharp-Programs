using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawing245
{
    [Serializable()]
    class Drawing
    {
        public string Name;
        public List<Shape> Shapes;
        public int DispX;
        public int DispY;
        public Drawing()
        {
            Name = "Masterpiece";
            Shapes = new List<Shape>(); // or (10)
            DispX = 0;
            DispY = 0;

        }
        public Drawing(string name, int intitialCap)
        {
            Name = name;
            Shapes = new List<Shape>(intitialCap);
            DispX = 0;
            DispY = 0;
        }
        public void Clear()
        {
            Shapes.Clear();
        }
        public void UndoLast()
        {
            if (Shapes.Count > 0)
            {
                Shapes.RemoveAt(Shapes.Count - 1);
            }
        }
        public void AddShape(Shape s)
        {
            Shapes.Add(s);
        }
        public void Move(int dx, int dy)
        {
            DispX += dx;
            DispY += dy;
        }
        public void ResetDisplacements()
        {
            DispX = 0;
            DispY = 0;
        }
    }
}
