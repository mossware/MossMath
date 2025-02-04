using System;

namespace MossMath
{
    public class LinearAlgebra
    {
        public static double[] Cramer(double[,] matrix, double[] vector)
        {
            int n = vector.Length;
            if (matrix.GetLength(0) != n || matrix.GetLength(1) != n)
            {
                throw new ArgumentException("Розміри матриці та вектора несумісні.");
            }

            double detA = Determinant(matrix);
            if (detA == 0)
            {
                throw new ArgumentException("Система не має унікального розв'язку.");
            }

            double[] result = new double[n];
            for (int i = 0; i < n; i++)
            {
                double[,] tempMatrix = (double[,])matrix.Clone();
                for (int j = 0; j < n; j++)
                {
                    tempMatrix[j, i] = vector[j];
                }
                result[i] = Determinant(tempMatrix) / detA;
            }

            return result;
        }

        private static double Determinant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1)
            {
                return matrix[0, 0];
            }
            if (n == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            double det = 0;
            for (int i = 0; i < n; i++)
            {
                det += Math.Pow(-1, i) * matrix[0, i] * Determinant(GetSubmatrix(matrix, 0, i));
            }
            return det;
        }

        private static double[,] GetSubmatrix(double[,] matrix, int rowToRemove, int colToRemove)
        {
            int n = matrix.GetLength(0);
            double[,] submatrix = new double[n - 1, n - 1];
            int subRow = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == rowToRemove) continue;
                int subCol = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == colToRemove) continue;
                    submatrix[subRow, subCol] = matrix[i, j];
                    subCol++;
                }
                subRow++;
            }
            return submatrix;
        }

        public static double[] Gauss(double[,] matrix, double[] vector)
        {
            int n = vector.Length;
            if (matrix.GetLength(0) != n || matrix.GetLength(1) != n)
            {
                throw new ArgumentException("Розміри матриці та вектора несумісні.");
            }

            double[,] augmentedMatrix = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    augmentedMatrix[i, j] = matrix[i, j];
                }
                augmentedMatrix[i, n] = vector[i];
            }
            for (int k = 0; k < n; k++)
             {
                // Пошук максимального елементу в стовпчику
                int maxRow = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(augmentedMatrix[i, k]) > Math.Abs(augmentedMatrix[maxRow, k]))
                    {
                        maxRow = i;
                    }
                }
                   
                 if (maxRow != k)
                    {
                           for (int j = k; j <= n; j++)
                           {
                            double temp = augmentedMatrix[k, j];
                            augmentedMatrix[k, j] = augmentedMatrix[maxRow, j];
                            augmentedMatrix[maxRow, j] = temp;
                           }
                    }
                   if (augmentedMatrix[k, k] == 0)
                        {
                           throw new ArgumentException("Система не має унікального рішення.");
                        }
                    
               for (int i = k+1; i < n; i++)
                {
                    double factor = augmentedMatrix[i, k] / augmentedMatrix[k, k];
                    for (int j = k; j <= n; j++)
                    {
                         augmentedMatrix[i, j] -= factor * augmentedMatrix[k, j];
                    }
                }
            }
             double[] result = new double[n];
             for (int i = n-1; i >= 0; i--)
            {
               result[i] = augmentedMatrix[i, n];
               for (int j = i + 1; j < n; j++)
                {
                  result[i] -= augmentedMatrix[i, j] * result[j];
                }
                 result[i] /= augmentedMatrix[i, i];
              }
             return result;
        }
public static double[] Seidel(double[,] matrix, double[] vector, double tolerance = 1e-6, int maxIterations = 1000)
        {
            int n = vector.Length;
            if (matrix.GetLength(0) != n || matrix.GetLength(1) != n)
            {
                throw new ArgumentException("Розміри матриці та вектора несумісні.");
            }

            double[] result = new double[n];
             double[] previousResult = new double[n];
             for(int i = 0; i < n; i++){
                result[i] = 0;
                previousResult[i] = 0;
             }
             for (int iteration = 0; iteration < maxIterations; iteration++)
                {
                bool converged = true;
                for (int i = 0; i < n; i++)
                   {
                     double sum = 0;
                     for(int j = 0; j < n; j++){
                        if(j!=i)
                            sum += matrix[i,j] * result[j];
                     }
                     double newResult = (vector[i] - sum)/ matrix[i,i];
                     if (Math.Abs(newResult - result[i]) > tolerance)
                        {
                        converged = false;
                     }
                      previousResult[i] = result[i];
                       result[i] = newResult;

                }
                  if (converged)
                     {
                        return result;
                     }
                }
            throw new ArgumentException("Ітерації не збіглися.");

        }
    }
}