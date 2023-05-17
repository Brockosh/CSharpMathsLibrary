namespace CSharpMathsLibrary
{
    public struct Vector3
    {

        //Still need to add cross and dot product.

        public float x;
        public float y;
        public float z;

        private const float Tolerance = 0.0001f;

        public Vector3(float xVal, float yVal, float zVal)
        {
            x = xVal;
            y = yVal;
            z = zVal;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 v1, float multiplicationValue)
        {
            return new Vector3(v1.x * multiplicationValue, v1.y * multiplicationValue, v1.z * multiplicationValue);
        }

        public static Vector3 operator *(float multiplicationValue, Vector3 v1)
        {
            return new Vector3(v1.x * multiplicationValue, v1.y * multiplicationValue, v1.z * multiplicationValue);
        }

        public static Vector3 operator /(Vector3 v1, float divisionValue)
        {
            return new Vector3(v1.x / divisionValue, v1.y / divisionValue, v1.z / divisionValue);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return Math.Abs(v1.x - v2.x) < Tolerance &&
                   Math.Abs(v1.y - v2.y) < Tolerance &&
                   Math.Abs(v1.z - v2.z) < Tolerance;
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3 otherVector)
            {
                return this == otherVector;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }

        Vector3 GetPerpendicularRH()
        {
            return new Vector3(-y, x, 0);
        }

        Vector3 GetPerpendicularLH()
        {
            return new Vector3(y, -x, 0);
        }

        public float Dot(Vector3 v2)
        {
            return (x * v2.x) + (y * v2.y) + (z * v2.z);
        }

        float GetAngleBetweenVectors(Vector3 other)
        {

            Vector3 a = GetNormalised();
            Vector3 b = other.GetNormalised();
            
            float d = a.x * b.x + a.y * b.y + a.z * b.z;
            
            return (float)Math.Acos(d);
        }

        public Vector3 Cross(Vector3 v2)
        {
            return new Vector3
            (
                y * v2.z - z * v2.y,
                z * v2.x - x * v2.z,
                x * v2.y - y * v2.x
            );
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public float MagnitudeSquared()
        {
            return (x * x + y * y + z * z);
        }

        public void Normalize()
        {
            float m = Magnitude();
            x *= m;
            y *= m;
            z *= m;
        }

        public Vector3 GetNormalised()
        {
            return (this / Magnitude());
        }


    }
}
