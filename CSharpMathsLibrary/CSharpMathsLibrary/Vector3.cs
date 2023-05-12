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
    }
}
