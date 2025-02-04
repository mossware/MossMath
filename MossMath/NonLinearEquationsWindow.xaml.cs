using System;
using System.Windows;
using MossMath;
using System.Windows.Controls;

namespace MossMath
{
    public partial class NonLinearEquationsWindow : Window
    {
        public NonLinearEquationsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. Зчитування вхідних даних з текстових полів
                string functionString = FunctionTextBox.Text;
                string intervalAString = IntervalATextBox.Text;
                string intervalBString = IntervalBTextBox.Text;
                string initialGuessString = InitialGuessTextBox.Text;

                // 2. Перетворення вхідних даних
                double a = double.Parse(intervalAString);
                double b = double.Parse(intervalBString);
                double initialGuess = double.Parse(initialGuessString);

                 // 3. Визначення обраного методу
                if (MethodComboBox.SelectedItem is ComboBoxItem selectedItem)
                  {
                         string selectedMethod = selectedItem.Content.ToString();

                    // 4. Виклик відповідного методу
                    double result = 0;
                    if (selectedMethod == "Метод половинного ділення")
                    {
                          Func<double, double> function = x => Eval(functionString, x);
                            if (function(a) * function(b) >= 0)
                            {
                              MessageBox.Show("Функція має мати різні знаки на кінцях проміжку.", "Помилка");
                             return;
                            }

                        result = NonLinearEquations.Bisection(function, a, b);
                    }
                    else if (selectedMethod == "Метод Ньютона")
                    {
                         Func<double, double> function = x => Eval(functionString, x);
                         Func<double, double> derivative = x => Derivative(functionString,x);
                       result = NonLinearEquations.Newton(function, derivative, initialGuess);
                    }
                   else if(selectedMethod == "Метод січних (хорд)")
                    {
                          Func<double, double> function = x => Eval(functionString, x);
                           result = NonLinearEquations.Secant(function, a, b);

                     }
                       // 5. Виведення результату
                          MessageBox.Show($"x = {result:F10}", "Результат");
                   }else
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
          private void MethodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             if (MethodComboBox.SelectedItem is ComboBoxItem selectedItem)
             {
                if(selectedItem.Content.ToString() == "Метод Ньютона")
                {
                    InitialGuessTextBox.Visibility = Visibility.Visible;
                    InitialGuessLabel.Visibility = Visibility.Visible;
                }
                else
                {
                     InitialGuessTextBox.Visibility = Visibility.Collapsed;
                     InitialGuessLabel.Visibility = Visibility.Collapsed;
                }
             }
        }
         private double Eval(string expression, double x)
        {
            var  expressionWithX = expression.Replace("x", x.ToString());
            object result;
            try
            {
                result = new System.Data.DataTable().Compute(expressionWithX, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при обчисленні виразу: {ex.Message}", "Помилка");
                return 0;
            }

            if (result is int intResult)
            {
                return (double)intResult;
            }
            if (result is double doubleResult)
            {
                 return doubleResult;
            }
             if (result is decimal decimalResult)
            {
                return (double)decimalResult;
            }
            MessageBox.Show($"Невідомий тип даних результату", "Помилка");
             return 0;
        }
        private double Derivative(string expression, double x, double h = 0.0001)
        {
         return (Eval(expression, x + h) - Eval(expression,x)) / h;
        }
    }
}