using System;
using System.Windows;
using MossMath;
using System.Windows.Controls;

namespace MossMath
{
    public partial class LinearAlgebraWindow : Window
    {
        public LinearAlgebraWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. Зчитування вхідних даних з текстових полів
                string matrixString = MatrixTextBox.Text;
                string vectorString = VectorTextBox.Text;

                // 2. Розбір рядків та перетворення у матрицю та вектор
                double[,] matrix = ParseMatrix(matrixString);
                double[] vector = ParseVector(vectorString);

                 // 3. Визначення обраного методу
                 if (MethodComboBox.SelectedItem is ComboBoxItem selectedItem)
                  {
                         string selectedMethod = selectedItem.Content.ToString();
                            // 4. Виклик відповідного методу
                             double[] result = null;
                              if(selectedMethod == "Метод Крамера")
                                  {
                                      result = LinearAlgebra.Cramer(matrix, vector);
                                  } else if (selectedMethod == "Метод Гауса")
                                  {
                                    result = LinearAlgebra.Gauss(matrix, vector);
                                    }
                                   else if(selectedMethod == "Метод Зейделя")
                                    {
                                       result = LinearAlgebra.Seidel(matrix, vector);
                                     }
                                // 5. Виведення результату
                                   MessageBox.Show($"x1 = {result[0]:F10}, x2 = {result[1]:F10}, x3 = {result[2]:F10}", "Результат");
                    }
                    else
                    {
                        MessageBox.Show("Потрібно вибрати метод обчислення.", "Помилка");
                    }

            }
             catch (ArgumentException ex)
             {
                  MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
             }
             catch (FormatException ex)
             {
                MessageBox.Show($"Помилка формату вводу: {ex.Message}", "Помилка");
             }
            catch (Exception ex)
            {
                MessageBox.Show($"Невідома помилка: {ex.Message}", "Помилка");
             }

        }
        private double[,] ParseMatrix(string matrixString)
        {
            string[] rows = matrixString.Split(';');
            int rowCount = rows.Length;
            if (rowCount == 0) throw new FormatException("Матриця не може бути пуста");
            int colCount = rows[0].Split(',').Length;
            double[,] matrix = new double[rowCount, colCount];
           
            for (int i = 0; i < rowCount; i++)
            {
                string[] cols = rows[i].Split(',');
                if(cols.Length != colCount) throw new FormatException($"Кількість стовпців у рядку {i+1} не співпадає");
                for (int j = 0; j < colCount; j++)
                {
                    if (!double.TryParse(cols[j], out double val))
                    {
                        throw new FormatException($"Не вдалося перетворити \"{cols[j]}\" на число.");
                    }
                    matrix[i, j] = val;
                }
            }
            return matrix;
        }
        private double[] ParseVector(string vectorString)
         {
            string[] cols = vectorString.Split(',');
            int colCount = cols.Length;
             if (colCount == 0) throw new FormatException("Вектор не може бути пустим.");

            double[] vector = new double[colCount];
            for (int i = 0; i < colCount; i++)
             {
                if (!double.TryParse(cols[i], out double val))
                   {
                    throw new FormatException($"Не вдалося перетворити \"{cols[i]}\" на число.");
                   }
                   vector[i] = val;
             }
          return vector;
         }
    }
}