using System;
using System.Windows;
using MossMath;
using System.Windows.Controls;

namespace MossMath
{
    public partial class IntegrationWindow : Window
    {
        public IntegrationWindow()
        {
            InitializeComponent();
        }

         private void Button_Click(object sender, RoutedEventArgs e)
        {
           try
           {
                // 1. Зчитування вхідних даних з текстових полів
                string functionString = FunctionTextBox.Text;
                string lowerLimitString = LowerLimitTextBox.Text;
                string upperLimitString = UpperLimitTextBox.Text;
                string nString = NTextBox.Text;

                // 2. Перетворення вхідних даних
               double a = 0;
                double b = 0;
                int n = 0;
                 try{
                    a = ParseNumber(lowerLimitString);
                     b = ParseNumber(upperLimitString);
                     n = int.Parse(nString);
                 }
                 catch(Exception ex)
                 {
                      MessageBox.Show($"Помилка при вводі меж інтегрування або розбиття: {ex.Message}", "Помилка");
                       return;
                   }


                 // 3. Визначення обраного методу
                  if (MethodComboBox.SelectedItem is ComboBoxItem selectedItem)
                  {
                         string selectedMethod = selectedItem.Content.ToString();

                    // 4. Виклик відповідного методу
                    double result = 0;
                     Func<double, double> function = null;

                    if (functionString == "x*x*x-2*x-5") function = x => x*x*x-2*x-5;
                    else if (functionString == "x*x*x-3*x-1") function = x => x*x*x-3*x-1;
                    else if (functionString == "Math.Exp(Math.Sin(x))") function = x => Math.Exp(Math.Sin(x));
                     else
                         {
                            try{
                            function = x => (double)new System.Data.DataTable().Compute(functionString.Replace("x",x.ToString()), null);
                            }catch (Exception ex)
                             {
                                 MessageBox.Show($"Помилка при обчисленні функції: {ex.Message}", "Помилка");
                                  return;
                              }
                         }
                       
                     try
                     {
                        if (selectedMethod == "Метод прямокутників")
                        {
                            result = Integration.Rectangles(function, a, b, n);
                           }
                        else if (selectedMethod == "Метод трапецій")
                           {
                             result = Integration.Trapezoids(function, a, b, n);
                            }
                        else if(selectedMethod == "Метод Сімпсона (парабол)")
                           {
                             result = Integration.Simpson(function, a, b, n);
                            }
                            // 5. Виведення результату
                        MessageBox.Show($"x = {result:F10}", "Результат");
                     }
                    catch (ArgumentException ex)
                        {
                         MessageBox.Show($"Помилка при обчисленні інтеграла: {ex.Message}", "Помилка");
                         return;
                      }

                   }else
                   {
                      MessageBox.Show("Потрібно вибрати метод обчислення.", "Помилка");
                    }
            }
             catch (FormatException ex)
             {
                MessageBox.Show($"Помилка формату вводу: {ex.Message}", "Помилка");
             }
        }
        private double ParseNumber(string numberString)
        {
            if(numberString == "Math.PI/2")
              {
                   return Math.PI / 2;
                }
          object result;
           try
            {
                result = new System.Data.DataTable().Compute(numberString, null);
            }
           catch (Exception ex)
           {
            throw new Exception($"Не вдалось обчислити вираз '{numberString}'. {ex.Message}", ex);
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
           throw new Exception($"Неможливо перетворити результат на double.");
        }
    }
}