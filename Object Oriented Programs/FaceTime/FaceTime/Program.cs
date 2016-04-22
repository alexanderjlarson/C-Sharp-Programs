using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Face defaultFace = new Face();
            Console.WriteLine("Here is the default face: ");
            Console.WriteLine(defaultFace);
            string response;

            string[] parts;

            int ox, oy, or, lex, ley, ler, rex, rey, rer, nx, ny, nw, nh, mx, my, mw, mh;

            Console.Write("Enter the x, y, and radius of the head: ");

            response = Console.ReadLine();

            parts = response.Split(' ');

            ox = int.Parse(parts[0]);

            oy = int.Parse(parts[1]);

            or = int.Parse(parts[2]);

            Console.Write("Enter the x, y, and radius of the left eye: ");

            response = Console.ReadLine();

            parts = response.Split(' ');

            lex = int.Parse(parts[0]);

            ley = int.Parse(parts[1]);

            ler = int.Parse(parts[2]);

            Console.Write("Enter the x, y, and radius of the right eye: ");

            response = Console.ReadLine();

            parts = response.Split(' ');

            rex = int.Parse(parts[0]);

            rey = int.Parse(parts[1]);

            rer = int.Parse(parts[2]);

            Console.Write("Enter the x, y, w, and h of the nose: ");

            response = Console.ReadLine();

            parts = response.Split(' ');

            nx = int.Parse(parts[0]);

            ny = int.Parse(parts[1]);

            nw = int.Parse(parts[2]);

            nh = int.Parse(parts[3]);

            Console.Write("Enter the x, y, w, and h of the mouth: ");

            response = Console.ReadLine();

            parts = response.Split(' ');

            mx = int.Parse(parts[0]);

            my = int.Parse(parts[1]);

            mw = int.Parse(parts[2]);

            mh = int.Parse(parts[3]);

            Face f = new Face(ox, oy, or, lex, ley, ler, rex, rey, rer, nx, ny, nw, nh, mx, my, mw, mh);

            Console.WriteLine(f);
        }
    }
}
