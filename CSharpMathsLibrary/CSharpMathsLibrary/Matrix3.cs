using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public struct Matrix3
    {
        //Column major
        public float m00, m10, m20;
        public float m01, m11, m21;
        public float m02, m12, m22;


        public Matrix3(float _m00, float _m01, float _m02,
               float _m10, float _m11, float _m12,
               float _m20, float _m21, float _m22)
        {
            m00 = _m00; m01 = _m01; m02 = _m02;
            m10 = _m10; m11 = _m11; m12 = _m12;
            m20 = _m20; m21 = _m21; m22 = _m22;
        }

        public Matrix3(float uniformScale)
        {
            m00 = m11 = m22 = uniformScale;
            m01 = m02 = m10 = m12 = m20 = m21 = 0;
        }

        public static Vector3 operator *(Matrix3 M, Vector3 V)
        {
            return new Vector3(
                M.m00 * V.x + M.m10 * V.y + M.m20 * V.z,
                M.m01 * V.x + M.m11 * V.y + M.m21 * V.z,
                M.m02 * V.x + M.m12 * V.y + M.m22 * V.z);
        }

        public static Matrix3 operator *(Matrix3 M1, Matrix3 M2)
        {
            return new Matrix3(
                M1.m00 * M2.m00 + M1.m10 * M2.m01 + M1.m20 * M2.m02,
                M1.m01 * M2.m00 + M1.m11 * M2.m01 + M1.m21 * M2.m02,
                M1.m02 * M2.m00 + M1.m12 * M2.m01 + M1.m22 * M2.m02,
                M1.m00 * M2.m10 + M1.m10 * M2.m11 + M1.m20 * M2.m12,
                M1.m01 * M2.m10 + M1.m11 * M2.m11 + M1.m21 * M2.m12,
                M1.m02 * M2.m10 + M1.m12 * M2.m11 + M1.m22 * M2.m12,
                M1.m00 * M2.m20 + M1.m10 * M2.m21 + M1.m20 * M2.m22,
                M1.m01 * M2.m20 + M1.m11 * M2.m21 + M1.m21 * M2.m22,
                M1.m02 * M2.m20 + M1.m12 * M2.m21 + M1.m22 * M2.m22);
        }

        public void SetRotateX(float radians)
        {
            m00 = 1; m10 = 0; m20 = 0;
            m01 = 0; m11 = (float)Math.Cos(radians); m21 = -(float)Math.Sin(radians);
            m02 = 0; m12 = (float)Math.Sin(radians); m22 = (float)Math.Cos(radians);
        }

        public void SetRotateY(float radians)
        {
            m00 = (float)Math.Cos(radians); m10 = 0; m20 = (float)Math.Sin(radians);
            m01 = 0; m11 = 1; m21 = 0;
            m02 = -(float)Math.Sin(radians); m12 = 0; m22 = (float)Math.Cos(radians);
        }

        public void SetRotateZ(float radians)
        {
            m00 = (float)Math.Cos(radians); m10 = -(float)Math.Sin(radians); m20 = 0;
            m01 = (float)Math.Sin(radians); m11 = (float)Math.Cos(radians); m21 = 0;
            m02 = 0; m12 = 0; m22 = 1;
        }

        public void SetTranslation(float translationX, float translationY)
        {
            m20 = translationX;
            m21 = translationY;
        }
    }
}
