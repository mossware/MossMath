   M S B A M L   `   `   `  ����G  CMossMath_New, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MossMathMossMath  5   	        MossMath.IntegrationWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MossMath     5   	     � Title$/  )Чисельне інтегрування��5   	   $	��450��6'   $	��800��64    � Icon$ /Assets/app.ico��5	   	    � 	Resources 5
         MyBackground �� ImageSource j� Stretch��%J   &	        �� 5   
   $ /Assets/background.png��6*   $
 Fill=�6O   5      .��5      � #��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Функція:��6   $��10q�6$   $��0��60   $��0��6=   �� 5   
   -   5         ��Name$ FunctionTextBox��5      $	��200��6+   $	��100��67   $��Math.Exp(Math.Sin(x))��6D   $��10q�6a   $��0��6m   $��1��6z    �� TextWrapping$
 Wrap=�6�   �� 5   
   $��Нижня межа:��6   $��10q�6'   $��1��63   $��0��6@   �� 5   
   -   5        $ LowerLimitTextBox��5      $	��100��6-   $��30��69   $��0��6E   $��10q�6N   $��1��6Z   $��1��6g   �� 5   
   $��Верхня межа:��6   $��10q�6(   $��1��64   $��3��6A   �� 5    
   -   5        $ UpperLimitTextBox��5       $	��100��6-   $��30��69   $��	Math.PI/2��6E   $��10q�6V   $��1��6b   $��4��6o   �� 5!   
   $��Розбиття:��6   $��10q�6%   $��2��61   $��0��6>   �� 5"   
   -   5        $ NTextBox��5"      $	��100��6$   $��30��60   $	��100��6<   $��10q�6G   $��2��6S   $��1��6`   �� 5#   
   $��Метод:��6   $��10q�6"   $��3��6.   $��0��6;   �� 5$   
   -   5        	 ��Name$	 MethodComboBox��5$      $	��200��6+   $��10q�67   $��3��6C   $��1��6P   
 �� SelectedIndex$
 0��6`   .@�5%      �� $+��%Метод прямокутників��6   �� 5&      $!��Метод трапецій��6   �� 5'      $2��,Метод Сімпсона (парабол)��6   5(      �� 5)   
   -   5        $��Обчислити��5)      $
��Left=�6%   $��10q�6@   $��4��6L   $��1��6Y   $	��Top=�6i   6�   5*      5+      