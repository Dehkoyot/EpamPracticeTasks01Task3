using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLction11Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var vector1 = new Vector(5, 2);
            var vector2 = new Vector(8, 5);

            //Show first Vector
            vector1.InitVector();
            vector1.Output();

            //Show second Vector
            vector2.InitVector();
            vector2.Output();

            //Addition of Vectors
            Console.WriteLine("Adding vectors");
            (vector1 + vector2).Output();

            //Substraction of Vectors
            Console.WriteLine("Substraction vectors");
            (vector1 - vector2).Output();

            //Scalar product of Vector and number
            Console.WriteLine("Scalar product of number");
            (vector1 * 2).Output();

            //If vectors are Equal
            if (vector1.Equals(vector2)) Console.WriteLine("Vectors are equal");
            else Console.WriteLine("Vectors aren't equal");

            Console.ReadKey();
        }
    }
}
