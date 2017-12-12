using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLction11Task3
{
    public class Vector
    {
        public int Length { get; private set; }
        public int Offset { get; private set; }

        public Vector(int size) : this(size, 0) { }
        public Vector(int size, int startIndex)
        {
            Length = size >= 0 ? size : throw new ArgumentException("Argument must be non-negative number", nameof(size));

            _values = new int[size];

            Offset = startIndex;
        }

        public int this[int index]
        {
            get
            {
                index -= Offset;

                if (index < 0 || index >= Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _values[index];
            }
            set
            {

                if (index < 0 || index >= Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                _values[index] = value;
            }
        }

        public void InitVector()
        {
            for (int i = this.Offset-1; i < this.Length; i++)
            {
                this._values[i] = i+1;
            }
        }

        public void Output()
        {
            Console.Write("Vector : ");

            for (int i = 0; i < this.Length; i++)
            {
                Console.Write("{0} ", this._values[i]);
            }
            Console.WriteLine();
        }

        public Vector Add(Vector vector)
        {
            CheckNull(vector, nameof(vector));

            return this + vector;
        }

        public Vector Subtract(Vector vector)
        {
            CheckNull(vector, nameof(vector));

            return this - vector;
        }

        public Vector Multiply(int value) => this * value;

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            CheckNull(vector1, nameof(vector1));
            CheckNull(vector2, nameof(vector2));

            if (vector1.Length-vector1.Offset != vector2.Length-vector2.Offset)
            {
                throw new ArgumentException("Vectors must have same size");
            }

            var newVector = new Vector(vector1.Length-vector1.Offset+1);
            for (int i = 0; i < newVector.Length; i++)
            {
                newVector._values[i] = vector1._values[i+vector1.Offset-1] + vector2._values[i+vector2.Offset-1];
            }

            return newVector;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            CheckNull(vector1, nameof(vector1));
            CheckNull(vector2, nameof(vector2));

            if (vector1.Length-vector1.Offset != vector2.Length-vector2.Offset)
            {
                throw new ArgumentException("Vectors must have same size");
            }

            var newVector = new Vector(vector1.Length-vector1.Offset+1);
            for (int i = 0; i < newVector.Length; i++)
            {
                newVector._values[i] = vector1._values[i+vector1.Offset-1] - vector2._values[i+vector2.Offset-1];
            }

            return newVector;
        }

        public static Vector operator *(Vector vector, int value)
        {
            CheckNull(vector, nameof(vector));

            var newVector = new Vector(vector.Length, vector.Offset);
            for (int i = 0; i < vector.Length; i++)
            {
                newVector._values[i] = vector._values[i] * value;
            }

            return newVector;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector vector && Length == vector.Length && Offset == vector.Offset)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_values[i] != vector._values[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _values.Length;
        }

        private static void CheckNull(Vector obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        private readonly int[] _values;
    }
}
