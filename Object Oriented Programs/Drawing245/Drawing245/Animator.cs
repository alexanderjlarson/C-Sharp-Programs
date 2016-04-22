using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawing245
{
    class Animator
    {
        private Random rnd;
        private int rangeX; //how far to cap motion in the x direction
        private int rangeY; //how far to cap motion in the y direction
        public int RangeX
        {
            get
            {
                return rangeX;
            }
            set
            {
                rangeX = Math.Abs(value);
            }
        }
        public int RangeY
        {
            get
            {
                return rangeY;
            }
            set
            {
                rangeY = Math.Abs(value);
            }
        }
        public Animator(){
            rnd = new Random();
            rangeX = 5;
            rangeY = 5;
        }
        public Animator(int rx, int ry)
        {
            rnd = new Random();
            RangeX = rx;
            RangeY = ry;
        }
        public void MoveDrawingRandomly(Drawing d)
        {
            d.Move(rnd.Next(-RangeX, RangeX), rnd.Next(-RangeY, RangeY));
        }
        public void MoveDrawingLeft(Drawing d)
        {
            d.Move(-RangeX, 0);
        }
        public void MoveDrawingRight(Drawing d)
        {
            d.Move(RangeX, 0);
        }
        public void MoveDrawingUp(Drawing d)
        {
            d.Move(0, -RangeY);
        }
        public void MoveDrawingDown(Drawing d)
        {
            d.Move(0, RangeY);
        }
    }
}
