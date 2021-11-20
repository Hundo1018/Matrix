using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Matrix
{
    public class Matrix:ICollection
    {

        /// <summary>
        /// [n,m]
        /// </summary>
        public double[,] Value { get; set; }

        /// <summary>
        /// 取得數值
        /// </summary>
        /// <param name="nIndex">row</param>
        /// <param name="mIndex">column</param>
        /// <returns></returns>
        public double this[int nIndex, int mIndex]
        {
            get => Value[nIndex, mIndex];
            set => Value[nIndex, mIndex] = value;
        }

        /// <summary>
        /// 取得Row的數量
        /// </summary>
        public int N { get => Value.GetLength(0); }

        /// <summary>
        /// 取得Column的數量
        /// </summary>
        public int M { get => Value.GetLength(1); }

        public int Count => ((ICollection)Value).Count;

        public bool IsSynchronized => Value.IsSynchronized;

        public object SyncRoot => Value.SyncRoot;


        /// <summary>
        /// 取得Row向量
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double[] GetRowVectorAt(int index)
        {
            int c = M;
            double[] vector = new double[c];
            for (int i = 0; i < c; i++)
            {
                vector[i] = Value[index, i];
            }
            return vector;
        }

        /// <summary>
        /// 取得Column向量
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double[] GetColumnVectorAt(int index)
        {
            int r = N;
            double[] vector = new double[r];
            for (int i = 0; i < r; i++)
            {
                vector[i] = Value[i, index];
            }
            return vector;
        }

        /// <summary>
        /// 設定某一個Row的數值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Matrix SetRowVectorAt(int index, double[] vector)
        {
            Matrix newMatrix = new Matrix(this);
            for (int m = 0; m < M; m++)
            {
                newMatrix[index, m] = vector[m];
            }
            return newMatrix;
        }

        /// <summary>
        /// 矩陣轉置
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            int rowLength = N;
            int columnLength = M;
            Matrix newMatrix = new Matrix(columnLength, rowLength);
            for (int m = 0; m < columnLength; m++)
            {
                for (int n = 0; n < rowLength; n++)
                {
                    newMatrix[m, n] = this[n, m];
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// 取得行列式
        /// </summary>
        /// <returns></returns>
        public double Determinant()
        {
            double det = 0;
            //起點
            for (int i = 0; i < M; i++)
            {
                double tempPlus = this[0, i];
                double tempMinus = this[0, i];
                //垂直位移量
                for (int j = 1; j < N; j++)
                {
                    tempPlus *= this[j, Circular(i + j, M)];
                    tempMinus *= this[j, Circular(i - j, M)];
                }
                det = det + tempPlus - tempMinus;
            }
            return det;
        }

        /// <summary>
        /// 陣列用循環索引值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int Circular(int i, int max)
        {
            int index = i % max;
            return index < 0 ? max + index : index;
        }


        /// <summary>
        /// 取得單位矩陣
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Matrix Identity(int n)
        {
            Matrix matrix = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1;
            }
            return matrix;
        }

        [Obsolete("尚未實作")]
        /// <summary>
        /// 合併成增廣矩陣
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public Matrix Augmented(Matrix matrix)
        {
            throw new NotImplementedException();
            int rDim = N;
            int newM = M + matrix.M;
            Matrix newMatrix = new Matrix(rDim, newM);
            for (int row = 0; row < rDim; row++)
            {
                double[] newRow = GetRowVectorAt(row).Concat(matrix.GetRowVectorAt(row)).ToArray();
                for (int column = 0; column < newM; column++)
                {
                    //TODO: newMatrix[row, column] = ;
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// 伴隨矩陣
        /// </summary>
        /// <returns></returns>
        [Obsolete("尚未實作")]
        public Matrix Adjugate()
        {
            return Determinant() * Identity(N);
        }

        /// <summary>
        /// 反矩陣
        /// </summary>
        /// <returns></returns>
        [Obsolete("尚未實作")]
        public Matrix Inverse()
        {
            throw new NotImplementedException();

        }


        #region 矩陣運算

        /// <summary>
        /// 純量乘法
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            Matrix nMatrix = new Matrix(matrix);
            for (int i = 0; i < matrix.M; i++)
            {
                for (int j = 0; j < matrix.N; j++)
                {
                    nMatrix[j, i] *= scalar;
                }
            }
            return nMatrix;
        }
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            Matrix nMatrix = new Matrix(matrix);
            for (int i = 0; i < matrix.M; i++)
            {
                for (int j = 0; j < matrix.N; j++)
                {
                    nMatrix[j, i] *= scalar;
                }
            }
            return nMatrix;
        }

        /// <summary>
        /// 高斯消去法
        /// </summary>
        /// <returns></returns>
        [Obsolete("尚未實作")]
        private Matrix GaussianElimination()
        {
            throw new NotImplementedException();
            //三個操作:交換 伸縮 取代
            //找pivot
            for (int pivot = 0; pivot < N; pivot++)
            {
                //如果是0
                if(this[pivot,pivot]==0)
                {

                    //找可以交換的
                }
            }
            for (int r = 0; r < N; r++)
            {

            }
            for (int c = 0; c < M; c++)
            {

            }
        }
        #endregion

        /// <summary>
        /// 轉換成字串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";
            for (int r = 0; r < M; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    str += this[r, c].ToString() + ',';
                }
                str += "\r\n";
            }
            return str;
        }

        public void CopyTo(Array array, int index)
        {
            Value.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return Value.GetEnumerator();
        }


        #region 建構子

        /// <summary>
        /// 建立ColumnVector
        /// </summary>
        /// <param name="vs"></param>
        public Matrix(double[] vs)
        {
            Value = new double[vs.Length, 1];
            for (int i = 0; i < vs.Length; i++)
            {
                Value[i, 0] = vs[i];
            }
        }
        
        /// <summary>
        /// 建立Matrix
        /// </summary>
        /// <param name="vs"></param>
        public Matrix(double[,] vs)
        {
            Value = vs;
        }

        /// <summary>
        /// 複製Matrix
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(Matrix matrix)
        {
            Value = new double[matrix.N, matrix.M];
            for (int c = 0; c < matrix.M; c++)
            {
                for (int r = 0; r < matrix.N; r++)
                {
                    Value[r, c] = matrix[r, c];
                }
            }
        }

        /// <summary>
        /// 建立一個n*m矩陣
        /// </summary>
        /// <param name="n">橫數Row</param>
        /// <param name="m">縱數Column</param>
        public Matrix(int n, int m)
        {
            Value = new double[n, m];
        }

        /// <summary>
        /// 建立一個n*n矩陣
        /// </summary>
        /// <param name="n"></param>
        public Matrix(int n):this(n,n)
        {
        }
        
        public Matrix()
        {

        }
        #endregion
    
    
    }
}