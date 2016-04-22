using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    class Shape
    {
        private int x;
        private int y;
        public int GetX()
        {
            return x;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public int GetY()
        {
            return y;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public Shape()
        {
            x = 0;
            y = 0; //or x = y = 0;
        }
        public Shape(int x, int y)
        {
            SetX(x);
            SetY(y);
        }
        public override string ToString()
        {
            return String.Format("{0} {1}",x,y);
        }
    }
    class Line : Shape
    {
        private int width;
        private int height;
        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }
        public void SetWidth(int w)
        {
            if (w < 0)
            {
                width = 0;
            }
            else
            {
                width = w;
            }
        }
        public void SetHeight(int h)
        {
            if (h < 0)
            {
                height = 0;
            }
            else
            {
                height = h;
            }
        }
        public Line()
            : base(0, 0)
        {
            SetWidth(0);
            SetHeight(0);
        }
        public Line(int x, int y, int w, int h)
            : base(x, y)
        {
            SetWidth(w);
            SetHeight(h);
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", GetX(), GetY(), width, height);
        }
    }
    class Circle : Shape
    {
        private int radius;

        public int GetRadius()
        {
            return radius;
        }

        public void SetRadius(int radius)
        {
            if (radius < 0)
            {
                radius = 0;
            }
            else
            {
                this.radius = radius;
            }
        }
        public Circle()
            : base(0, 0)
        {
            radius = 0;
        }
        public Circle(int x, int y, int radius)
            : base(x, y)
        {
            SetRadius(radius);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", GetX(), GetY(), radius);
        }

    }
}
