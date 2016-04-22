using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace FaceTime
{
    class Face
    {
        private Circle outline;
        private Circle leftEye;
        private Circle rightEye;
        private Line nose;
        private Line mouth;
        public Circle getOutLine()
        {
            return outline;
        }
        public Circle getLeftEye()
        {
            return leftEye;
        }
        public Circle getRightEye()
        {
            return rightEye;
        }
        public Line getNose()
        {
            return nose;
        }
        public Line getMouth()
        {
            return mouth;
        }
        public Face()
        {
            outline = new Circle(0, 0, 100);
            leftEye = new Circle(10, 10, 10);
            rightEye = new Circle(50, 10, 10);
            nose = new Line(30, 30, 10, 30);
            mouth = new Line(10, 50, 40, 10);
        }
        public Face(int ox, int oy, int or,
            int lex, int ley, int ler,
            int rex, int rey, int rer,
            int nx, int ny, int nh, int nw,
            int mx, int my, int mh, int mw)
        {
            outline = new Circle(ox, oy, or);
            leftEye = new Circle(lex, ley, ler);
            rightEye = new Circle(rex, rey, rer);
            nose = new Line(nx, ny, nw, nh);
            mouth = new Line(mx, my, mw, mh);
        }
        public override string ToString()
        {
            string result = "";
            result += outline;
            result += " " + leftEye;
            result += " " + rightEye;
            result += " " + nose;
            result += " " + mouth;
            return result;
        }
    }
}
