using System;

namespace MathClasses
{
    public struct Matrix4
    {

        public float m00, m10, m20, m30;
        public float m01, m11, m21, m31;
        public float m02, m12, m22, m32;
        public float m03, m13, m23, m33;

        public Matrix4(float _m00, float _m01, float _m02, float _m03,
               float _m10, float _m11, float _m12, float _m13,
               float _m20, float _m21, float _m22, float _m23,
               float _m30, float _m31, float _m32, float _m33)
        {
            m00 = _m00; m10 = _m10; m20 = _m20; m30 = _m30;
            m01 = _m01; m11 = _m11; m21 = _m21; m31 = _m31;
            m02 = _m02; m12 = _m12; m22 = _m22; m32 = _m32;
            m03 = _m03; m13 = _m13; m23 = _m23; m33 = _m33;
        }

        public Matrix4(float uniformScale)
        {
            m00 = m11 = m22 = m33 = uniformScale;
            m01 = m02 = m03 = m10 = m12 = m13 = m20 = m21 = m23 = m30 = m31 = m32 = 0;
        }

        public static Vector4 operator *(Matrix4 M, Vector4 V)
        {
            return new Vector4(
                M.m00 * V.x + M.m10 * V.y + M.m20 * V.z + M.m30 * V.w,
                M.m01 * V.x + M.m11 * V.y + M.m21 * V.z + M.m31 * V.w,
                M.m02 * V.x + M.m12 * V.y + M.m22 * V.z + M.m32 * V.w,
                M.m03 * V.x + M.m13 * V.y + M.m23 * V.z + M.m33 * V.w);
        }


        public static Matrix4 operator *(Matrix4 M1, Matrix4 M2)
        {
            return new Matrix4(
                M1.m00 * M2.m00 + M1.m10 * M2.m01 + M1.m20 * M2.m02 + M1.m30 * M2.m03,
                M1.m01 * M2.m00 + M1.m11 * M2.m01 + M1.m21 * M2.m02 + M1.m31 * M2.m03,
                M1.m02 * M2.m00 + M1.m12 * M2.m01 + M1.m22 * M2.m02 + M1.m32 * M2.m03,
                M1.m03 * M2.m00 + M1.m13 * M2.m01 + M1.m23 * M2.m02 + M1.m33 * M2.m03,

                M1.m00 * M2.m10 + M1.m10 * M2.m11 + M1.m20 * M2.m12 + M1.m30 * M2.m13,
                M1.m01 * M2.m10 + M1.m11 * M2.m11 + M1.m21 * M2.m12 + M1.m31 * M2.m13,
                M1.m02 * M2.m10 + M1.m12 * M2.m11 + M1.m22 * M2.m12 + M1.m32 * M2.m13,
                M1.m03 * M2.m10 + M1.m13 * M2.m11 + M1.m23 * M2.m12 + M1.m33 * M2.m13,

                M1.m00 * M2.m20 + M1.m10 * M2.m21 + M1.m20 * M2.m22 + M1.m30 * M2.m23,
                M1.m01 * M2.m20 + M1.m11 * M2.m21 + M1.m21 * M2.m22 + M1.m31 * M2.m23,
                M1.m02 * M2.m20 + M1.m12 * M2.m21 + M1.m22 * M2.m22 + M1.m32 * M2.m23,
                M1.m03 * M2.m20 + M1.m13 * M2.m21 + M1.m23 * M2.m22 + M1.m33 * M2.m23,

                M1.m00 * M2.m30 + M1.m10 * M2.m31 + M1.m20 * M2.m32 + M1.m30 * M2.m33,
                M1.m01 * M2.m30 + M1.m11 * M2.m31 + M1.m21 * M2.m32 + M1.m31 * M2.m33,
                M1.m02 * M2.m30 + M1.m12 * M2.m31 + M1.m22 * M2.m32 + M1.m32 * M2.m33,
                M1.m03 * M2.m30 + M1.m13 * M2.m31 + M1.m23 * M2.m32 + M1.m33 * M2.m33
            );
        }

        public void SetRotateX(float radians)
        {
            m00 = 1; m10 = 0; m20 = 0; m30 = 0;
            m01 = 0; m11 = (float)Math.Cos(radians); m21 = (float)-Math.Sin(radians); m31 = 0;
            m02 = 0; m12 = (float)Math.Sin(radians); m22 = (float)Math.Cos(radians); m32 = 0;
            m03 = 0; m13 = 0; m23 = 0; m33 = 1;
        }

        public void SetRotateY(float radians)
        {
            m00 = (float)Math.Cos(radians); m10 = 0; m20 = (float)Math.Sin(radians); m30 = 0;
            m01 = 0; m11 = 1; m21 = 0; m31 = 0;
            m02 = (float)-Math.Sin(radians); m12 = 0; m22 = (float)Math.Cos(radians); m32 = 0;
            m03 = 0; m13 = 0; m23 = 0; m33 = 1;
        }

        public void SetRotateZ(float radians)
        {
            m00 = (float)Math.Cos(radians); m10 = (float)-Math.Sin(radians); m20 = 0; m30 = 0;
            m01 = (float)Math.Sin(radians); m11 = (float)Math.Cos(radians); m21 = 0; m31 = 0;
            m02 = 0; m12 = 0; m22 = 1; m32 = 0;
            m03 = 0; m13 = 0; m23 = 0; m33 = 1;
        }
    }
}
