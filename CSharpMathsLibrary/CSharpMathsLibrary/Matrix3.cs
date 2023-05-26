using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMathsLibrary
{
    struct Matrix3
    {
        public Vector3 xAxis;
        public Vector3 yAxis;
        public Vector3 zAxis;

        public Matrix3(float _m00, float _m10, float _m20,
                   float _m01, float _m11, float _m21,
                   float _m02, float _m12, float _m22)
        {
            xAxis = new Vector3(_m00, _m10, _m20);
            yAxis = new Vector3(_m01, _m11, _m21);
            zAxis = new Vector3(_m02, _m12, _m22);
        }

        public Matrix3(Vector3 X, Vector3 Y, Vector3 Z)
        {
            xAxis = new Vector3(X.x, X.y, X.z);
            yAxis = new Vector3(Y.x, Y.y, Y.z);
            zAxis = new Vector3(Z.x, Z.y, Z.z);
        }

        public Matrix3(float uniformScale)
        {
            xAxis = new Vector3(uniformScale, 0, 0);
            yAxis = new Vector3(0, uniformScale, 0);
            zAxis = new Vector3(0, 0, uniformScale);
        }

        public static Vector3 operator *(Matrix3 M, Vector3 V)
        {
            return new Vector3(
                M.xAxis.x * V.x + M.xAxis.y * V.y + M.xAxis.z * V.z,
                M.yAxis.x * V.x + M.yAxis.y * V.y + M.yAxis.z * V.z,
                M.zAxis.x * V.x + M.zAxis.y * V.y + M.zAxis.z * V.z);
        }

        public static Matrix3 operator *(Matrix3 M1, Matrix3 M2)
        {
            return new Matrix3(
                M1 * M2.xAxis,
                M1 * M2.yAxis,
                M1 * M2.zAxis);
        }

        public void setRotateX(float radians)
        {
            xAxis = new Vector3(1, 0, 0);
            yAxis = new Vector3(0, (float)Math.Cos(radians), -(float)Math.Sin(radians));
            zAxis = new Vector3(0, (float)Math.Sin(radians), (float)Math.Cos(radians));
        }

        public void setRotateY(float radians)
        {
            xAxis = new Vector3((float)Math.Cos(radians), 0, (float)Math.Sin(radians));
            yAxis = new Vector3(0, 1, 0);
            zAxis = new Vector3(-(float)Math.Sin(radians), 0, (float)Math.Cos(radians));
        }

        public void setRotateZ(float radians)
        {
            xAxis = new Vector3((float)Math.Cos(radians), -(float)Math.Sin(radians), 0);
            yAxis = new Vector3((float)Math.Sin(radians), (float)Math.Cos(radians), 0);
            zAxis = new Vector3(0, 0, 1);
        }
    }
}
