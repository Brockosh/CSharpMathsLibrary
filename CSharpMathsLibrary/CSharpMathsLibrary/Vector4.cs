using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        private const float Tolerance = 0.0001f;

        public Vector4(float xVal, float yVal, float zVal, float wVal)
        {
            x = xVal;
            y = yVal;
            z = zVal;
            //Check how to default this to 1.
            w = wVal;
        }

        public Vector4(float xVal, float yVal, float zVal)
        {
            x = xVal;
            y = yVal;
            z = zVal;
            w = 1f;
        }

        public static Vector4 operator +(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

        public static Vector4 operator *(Vector4 v1, float multiplicationValue)
        {
            return new Vector4(v1.x * multiplicationValue, v1.y * multiplicationValue, v1.z * multiplicationValue, v1.w * multiplicationValue);
        }

        public static Vector4 operator *(float multiplicationValue, Vector4 v1)
        {
            return new Vector4(v1.x * multiplicationValue, v1.y * multiplicationValue, v1.z * multiplicationValue, v1.w * multiplicationValue);
        }

        public static Vector4 operator /(Vector4 v1, float divisionValue)
        {
            return new Vector4(v1.x / divisionValue, v1.y / divisionValue, v1.z / divisionValue, v1.w / divisionValue);
        }

        public static bool operator ==(Vector4 v1, Vector4 v2)
        {
            return Math.Abs(v1.x - v2.x) < Tolerance &&
                    Math.Abs(v1.y - v2.y) < Tolerance &&
                    Math.Abs(v1.z - v2.z) < Tolerance &&
                    Math.Abs(v1.w - v2.w) < Tolerance;
        }

        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector4 otherVector)
            {
                return this == otherVector;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode() ^ w.GetHashCode();
        }


        public float Dot(Vector4 v2)
        {
            return (x * v2.x) + (y * v2.y) + (z * v2.z) + (w * v2.w);
        }

        public float GetAngleBetweenVectors(Vector4 other)
        {

            Vector4 a = GetNormalised();
            Vector4 b = other.GetNormalised();

            //Get dot product
            float d = a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;

            //Get the angle between vectors in radians
            return (float)Math.Acos(d);
        }

        public Vector4 Cross(Vector4 v2)
        {
            return new Vector4
            (
                y * v2.z - z * v2.y,
                z * v2.x - x * v2.z,
                x * v2.y - y * v2.x,
                w * v2.w - w * v2.w
            );
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public float MagnitudeSquared()
        {
            return (x * x + y * y + z * z + w * w);
        }

        public void Normalize()
        {
            float m = Magnitude();

            if (m > 0)
            {
                x /= m;
                y /= m;
                z /= m;
                w /= m;
            }
        }

        public Vector4 GetNormalised()
        {
            return (this / Magnitude());
        }


    }

}
