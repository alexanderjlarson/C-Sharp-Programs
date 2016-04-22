using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawing245
{
    [Serializable()]
    class Shape
    {
        public int X;
        public int Y;
        private int width;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {

            }
        }
        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {

            }
        }
        public Shape()
        {
            X = 0;
            Y = 0;
            width = 0;
            height = 0;
        }
        public Shape(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }
        public virtual string GetShapeType(){
            return "Shape";
        }
    }
    [Serializable()]
    class Rectangle : Shape
    {
        public Rectangle() : base() { }
        public Rectangle(int x, int y, int w, int h) : base(x, y, w, h) { }
        public override string GetShapeType()
        {
            return "Rectangle";
        }
    }
    [Serializable()]
    class Ellipse : Shape
    {
        public Ellipse() : base() { }
        public Ellipse(int x, int y, int w, int h) : base(x, y, w, h) { }
        public override string GetShapeType()
        {
            return "Ellipse";
        }
    }
    [Serializable()]
    class Ball : Ellipse
    {
        public Ball() : base() { }
        public Ball(int x, int y, int w) : base(x, y, w, w) { }
        public override string GetShapeType()
        {
            return "Ball";
        }
    }
}
