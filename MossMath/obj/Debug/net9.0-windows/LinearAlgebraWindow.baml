   M S B A M L   `   `   `  ����G  CMossMath_New, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MossMathMossMath  5   	   "    MossMath.LinearAlgebraWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MossMath     5   	     � Title$4  .Системи Лінійних Рівнянь��5   	   $	��450��6*   $	��800��67    � Icon$ /Assets/app.ico��5	   	   .��5
      � ��5   	   �� 5       �� ImageSource$ /Assets/background.png��6    j� Stretch$
 Fill=�6>    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��Матриця:��6   $��10q�6%   $��0��61   $��0��6>   �� 5      -   5         ��Name$ MatrixTextBox��5      $	��200��6*   $	��100��66   $+��%5.8,3.8,3.2;2.5,-7.8,3.3;6.5,-7.1,9.8��6C   $��10q�6p   $��0��6|   $��1��6�    �� TextWrapping$
 Wrap=�6�   �� 5   
   $��Вектор:��6   $��10q�6#   $��1��6/   $��0��6<   �� 5   
   -   5        $ VectorTextBox��5      $	��200��6)   $��30��65   $��4.5,7.1,6.1��6A   $��10q�6T   $��1��6`   $��1��6m   �� 5   
   $��Метод:��6   $��10q�6"   $��2��6.   $��0��6;   �� 5      -   5         ��Name$ MethodComboBox��5      $	��200��6,   $��10q�68   $��2��6D   $��1��6Q   	 �� SelectedIndex$	 0��6a   .@�5      �� $��Метод Крамера��6   �� 5       $��Метод Гауса��6   �� 5!      $��Метод Зейделя��6   5"      �� 5#   
   -   5        $��Обчислити��5#      $
��Left=�6%   $��10q�6@   $��3��6L   $��1��6Y   $	��Top=�6i   6�   5$      5%      