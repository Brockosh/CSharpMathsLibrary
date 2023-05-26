using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMathsLibrary
{
    struct Matrix4
    {
        public Vector4 xAxis;
        public Vector4 yAxis;
        public Vector4 zAxis;
        public Vector4 wAxis;

        public Matrix4(float _m00, float _m10, float _m20, float _m30,
                       float _m01, float _m11, float _m21, float _m31,
                       float _m02, float _m12, float _m22, float _m32,
                       float _m03, float _m13, float _m23, float _m33)
        {
            xAxis = new Vector4(_m00, _m10, _m20, _m30);
            yAxis = new Vector4(_m01, _m11, _m21, _m31);
            zAxis = new Vector4(_m02, _m12, _m22, _m32);
            wAxis = new Vector4(_m03, _m13, _m23, _m33);
        }

        public Matrix4(Vector4 X, Vector4 Y, Vector4 Z, Vector4 W)
        {
            xAxis = new Vector4(X.x, X.y, X.z, X.w);
            yAxis = new Vector4(Y.x, Y.y, Y.z, Y.w);
            zAxis = new Vector4(Z.x, Z.y, Z.z, Z.w);
            wAxis = new Vector4(W.x, W.y, W.z, W.w);
        }

        public Matrix4(float uniformScale)
        {
            xAxis = new Vector4(uniformScale, 0, 0, 0);
            yAxis = new Vector4(0, uniformScale, 0, 0);
            zAxis = new Vector4(0, 0, uniformScale, 0);
            wAxis = new Vector4(0, 0, 0, 1);
        }

        public static Vector4 operator *(Matrix4 M, Vector4 V)
        {
            return new Vector4(
                M.xAxis.x * V.x + M.xAxis.y * V.y + M.xAxis.z * V.z + M.xAxis.w * V.w,
                M.yAxis.x * V.x + M.yAxis.y * V.y + M.yAxis.z * V.z + M.yAxis.w * V.w,
                M.zAxis.x * V.x + M.zAxis.y * V.y + M.zAxis.z * V.z + M.zAxis.w * V.w,
                M.wAxis.x * V.x + M.wAxis.y * V.y + M.wAxis.z * V.z + M.wAxis.w * V.w);
        }

        public static Matrix4 operator *(Matrix4 M1, Matrix4 M2)
        {
            return new Matrix4(
                M1 * M2.xAxis,
                M1 * M2.yAxis,
                M1 * M2.zAxis,
                M1 * M2.wAxis);
        }

        public void setRotateX(float radians)
        {
            xAxis = new Vector4(1, 0, 0, 0);
            yAxis = new Vector4(0, (float)Math.Cos(radians), -(float)Math.Sin(radians), 0);
            zAxis = new Vector4(0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0);
            wAxis = new Vector4(0, 0, 0, 1);
        }

        public void setRotateY(float radians)
        {
            xAxis = new Vector4((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0);
            yAxis = new Vector4(0, 1, 0, 0);
            zAxis = new Vector4(-(float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0);
            wAxis = new Vector4(0, 0, 0, 1);
        }

        public void setRotateZ(float radians)
        {
            xAxis = new Vector4((float)Math.Cos(radians), -(float)Math.Sin(radians), 0, 0);
            yAxis = new Vector4((float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0);
            zAxis = new Vector4(0, 0, 1, 0);
            wAxis = new Vector4(0, 0, 0, 1);
        }
    }
}
