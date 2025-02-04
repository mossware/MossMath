using System;
using System.Windows;
using MossMath;

namespace MossMath
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
          private void LinearAlgebraButton_Click(object sender, RoutedEventArgs e)
        {
                LinearAlgebraWindow linearAlgebraWindow = new LinearAlgebraWindow();
                linearAlgebraWindow.Show();
        }
         private void NonLinearEquationsButton_Click(object sender, RoutedEventArgs e)
        {
             NonLinearEquationsWindow nonLinearEquationsWindow = new NonLinearEquationsWindow();
                nonLinearEquationsWindow.Show();
        }

        private void IntegrationButton_Click(object sender, RoutedEventArgs e)
        {
             IntegrationWindow integrationWindow = new IntegrationWindow();
                integrationWindow.Show();
        }
    }
}