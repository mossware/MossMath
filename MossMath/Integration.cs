using System;

namespace MossMath
{
    public class Integration
    {
        public static double Rectangles(Func<double, double> function, double a, double b, int n = 100)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Кількість ітерацій має бути більша за 0.");
            }
            double h = (b - a) / n;
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                result += function(a + (i + 0.5) * h) * h;
            }
            return result;
        }

        public static double Trapezoids(Func<double, double> function, double a, double b, int n = 100)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Кількість ітерацій має бути більша за 0.");
            }
            double h = (b - a) / n;
            double result = (function(a) + function(b)) / 2;
            for (int i = 1; i < n; i++)
            {
                result += function(a + i * h);
            }
            return result * h;
        }

         public static double Simpson(Func<double, double> function, double a, double b, int n = 100)
        {
            if (n <= 0 || n % 2 != 0)
            {
                throw new ArgumentException("Кількість ітерацій має бути парним числом, більшим за 0.");
            }

            double h = (b - a) / n;
            double result = function(a) + function(b);
           for (int i = 2; i < n; i += 2)
            {
                result += 2 * function(a + i * h);
            }
              for (int i = 1; i < n; i += 2)
            {
                result += 4 * function(a + i * h);
            }

            return result * h / 3;
        }
    }
}