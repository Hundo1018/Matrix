using Microsoft.VisualStudio.TestTools.UnitTesting;
using HundoMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundoMatrix.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void GetRowVectorAtTest()
        {
            double[] vs = new double[3] { 0, 1, 2 };

            Matrix matrix = new Matrix(new double[,] { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } });
            Matrix temp = matrix.SetRowVectorAt(0, vs);
            double[] exp = temp.GetRowVectorAt(0);
            CollectionAssert.AreEqual(vs, exp);
        }

        [TestMethod()]
        public void GetColumnVectorAtTest()
        {
            double[] vs = new double[3] { 0, 1, 2 };
            Matrix matrix = new Matrix(vs);
            CollectionAssert.AreEqual(vs, matrix.GetColumnVectorAt(0));
        }

        [TestMethod()]
        public void SetRowVectorAtTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TransposeTest()
        {
            double[,] vs = new double[3, 2]
            {
                { 0, 1 },
                { 2, 3 },
                { 4, 5 }
            };
            double[,] expected = new double[2, 3]
            {
                {0,2,4 },
                {1,3,5 }
            };
            Matrix matrix = new Matrix(vs);
            CollectionAssert.AreEqual(expected, matrix.Transpose().Value);
            //CollectionAssert.AreEqual(expected, matrix.Transpose().Transpose().Transpose().Value);
        }

        [TestMethod()]
        public void TransposeTest2()
        {
            double[,] vs = new double[2, 3]
           {
                { 0, 1 ,2},
                { 3, 4, 5 },
           };
            double[,] expected = new double[3, 2]
            {
                { 0, 3 },
                { 1, 4 },
                { 2, 5 }
            };
            Matrix matrix = new Matrix(vs);
            double[,] actual = matrix.Transpose().Value;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeterminantTest()
        {
            Matrix matrix = new Matrix(new double[,] { { 2, 6, 3 }, { 1, 0, 2 }, { 5, 8, 4 } });
            Assert.AreEqual(28, matrix.Determinant());
        }


        /// <summary>
        /// 行列式
        /// </summary>
        [TestMethod("行列式+單位矩陣")]
        public void DeterminantTest2()
        {
            Assert.AreEqual(1, Matrix.Identity(3).Determinant());
        }


        /// <summary>
        /// 行列式
        /// </summary>
        [TestMethod("行列式=0")]
        public void DeterminantTest3()
        {
            Assert.AreEqual(0, new Matrix(new double[,] { { 1, 2, 1 }, { 2, 14, 2 }, { 3, 5, 3 } }).Determinant());
        }

        [TestMethod()]
        public void IdentityTest()
        {
            Matrix matrix = Matrix.Identity(3);
            CollectionAssert.AreEqual(new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }, matrix);
        }

        /// <summary>
        /// 增廣矩陣測試
        /// </summary>
        [TestMethod()]
        public void AugmentedTest()
        {
            Matrix matrix1 = new Matrix(2, 2)
            {
                Value = new double[,] {
                { 0, 1 },
                { 2, 3 }
            }
            };
            Matrix matrix2 = new Matrix(2, 2)
            {
                Value = new double[,] {
                { 2, 3 },
                { 4, 5 }
            }
            };
            Matrix matrix3 = new Matrix(2, 4)
            {
                Value = new double[,] {
                { 0,1,2,3},
                { 2,3,4,5}
            }
            };
            Matrix result = matrix1.Augmented(matrix2);
            Assert.AreEqual(matrix3, result);
        }

        [TestMethod()]
        public void AdjugateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InverseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ManhattanDistanceTest()
        {
            Matrix matrix = new Matrix(new double[] { 0, 0 });
            Matrix matrix1 = new Matrix(new double[] { 3, 4 });
            Assert.AreEqual(7, matrix.ManhattanDistance(matrix1));
        }

        [TestMethod()]
        public void EuclideanDistanceTest()
        {
            Matrix matrix = new Matrix(new double[] { 0, 0 });
            Matrix matrix1 = new Matrix(new double[] { 3, 4 });
            Assert.AreEqual(5, matrix.EuclideanDistance(matrix1));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Matrix matrix = new Matrix(new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            string actual = matrix.ToString();
            string expect = "0,1,2,\r\n3,4,5,\r\n6,7,8,\r\n";
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Matrix matrix, matrix1;
            matrix = new Matrix(1, 1);
            matrix1 = new Matrix(1, 1);
            Assert.AreEqual(matrix, matrix1);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Matrix matrix = new Matrix(1, 1);
            Matrix matrix1 = new Matrix(1, 1);
            Dictionary<Matrix, int> keyValuePairs = new Dictionary<Matrix, int>();
            keyValuePairs.Add(matrix, 0);
            keyValuePairs.Add(matrix1, 1);
            Assert.AreEqual(keyValuePairs[matrix1], 1);
        }

        [TestMethod()]
        public void MatrixTest()
        {
            Matrix matrix = new Matrix(2, 3);
            Matrix matrix1 = new Matrix(2, 3);
            CollectionAssert.AreEqual(matrix, matrix1);
        }

        [TestMethod()]
        public void MatrixTest1()
        {
            Matrix matrix = new Matrix(2, 3);
            Matrix matrix1 = new Matrix(matrix);
            CollectionAssert.AreEqual(matrix, matrix1);
        }




        /// <summary>
        /// GetN
        /// </summary>
        [TestMethod]
        public void GetNTest()
        {
            double[,] vs = new double[1, 2] { { 1, 2 } };
            Matrix matrix = new Matrix(vs);

            Assert.AreEqual(1, matrix.N);
        }

        /// <summary>
        /// GetM
        /// </summary>
        [TestMethod]
        public void GetMTest()
        {
            double[,] vs = new double[1, 2] { { 1, 2 } };
            Matrix matrix = new Matrix(vs);

            Assert.AreEqual(2, matrix.M);
        }

        /// <summary>
        /// 矩陣乘法
        /// </summary>
        [TestMethod("矩陣乘法")]
        public void MulTest()
        {
            // 0 1
            // 2 3
            // 4 5
            Matrix matrix1 = new Matrix() { Value = new double[3, 2] { { 0, 1 }, { 2, 3 }, { 4, 5 } } };
            // 0 1 2
            // 3 4 5
            Matrix matrix2 = new Matrix() { Value = new double[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } } };
            // 0*0+1*3  
            //
            //
            Matrix nMatrix = matrix1 * matrix2;
            Matrix Excepted = new Matrix()
            {
                Value = new double[3, 3]
                {
                    {3,4,5 },
                    {9,14,19 },
                    {15,24,33 }
                }
            };
            Assert.AreEqual(Excepted, nMatrix);
        }

        /// <summary>
        /// 矩陣乘法
        /// </summary>
        [TestMethod("矩陣乘法2")]
        public void MulTest2()
        {
            // 1 0 2
            // -1 3 1
            Matrix matrix1 = new Matrix()
            {
                Value = new double[2, 3]
            {
                { 1, 0, 2 }, { -1, 3, 1 }
            }
            };
            // 3 1
            // 2 1
            // 1 0
            Matrix matrix2 = new Matrix()
            {
                Value = new double[3, 2]
            {
                { 3, 1 },
                { 2, 1 },
                { 1, 0 }
            }
            };
            Matrix nMatrix = matrix1 * matrix2;
            Matrix Excepted = new Matrix()
            {
                Value = new double[2, 2]
                {
                    {5,1 },
                    {4,2 },
                }
            };
            Assert.AreEqual(Excepted, nMatrix);
        }

    }
}