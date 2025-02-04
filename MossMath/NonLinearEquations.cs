using System;

namespace MossMath
{
    public class NonLinearEquations
    {
         public static double Bisection(Func<double, double> function, double a, double b, double tolerance = 1e-6, int maxIterations = 100)
        {
            if (function(a) * function(b) >= 0)
            {
                throw new ArgumentException("Функція має мати різні знаки на кінцях проміжку.");
            }

            double c = a;
           for(int i = 0; i < maxIterations; i++)
            {
              c = (a + b)/2;
             if (Math.Abs(function(c)) < tolerance)
             {
                return c;
              }
                if(function(c) * function(a) < 0)
                    b = c;
                else
                    a = c;
            }
           throw new ArgumentException("Метод не збігається.");
        }

        public static double Newton(Func<double, double> function, Func<double, double> derivative, double initialGuess, double tolerance = 1e-6, int maxIterations = 100)
        {
           double x = initialGuess;
            for(int i = 0; i < maxIterations; i++){
                double fx = function(x);
                 if (Math.Abs(fx) < tolerance)
                {
                 return x;
                }
               double dfx = derivative(x);
                 if(dfx == 0){
                   throw new ArgumentException("Похідна дорівнює нулю.");
                }
                 double newX = x - fx / dfx;
                 if(Math.Abs(newX-x) < tolerance)
                    {
                      return newX;
                    }
               x = newX;
            }
            throw new ArgumentException("Метод не збігається.");
        }
    
        public static double Secant(Func<double, double> function, double x0, double x1, double tolerance = 1e-6, int maxIterations = 100)
        {
            double fx0 = function(x0);
            double fx1 = function(x1);
            double x2 = x1;
             for(int i = 0; i < maxIterations; i++){
                 if(Math.Abs(fx1) < tolerance)
                   {
                      return x1;
                   }
               if(fx1 == fx0){
                     throw new ArgumentException("Різниця функцій дорівнює нулю.");
                 }
               x2 = x1 - fx1 * (x1-x0)/(fx1-fx0);
               if(Math.Abs(x2 - x1) < tolerance)
                {
                  return x2;
                }
                x0 = x1;
                 fx0 = fx1;
                x1 = x2;
                fx1 = function(x2);

            }
            throw new ArgumentException("Метод не збігається.");
       }
    }
}