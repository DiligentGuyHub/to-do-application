   M S B A M L   `   `   `  ����J  FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components  5      C ?ToDo.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ToDo.WPF.ConvertersToDo.WPF.Converters 5      /clr-namespace:ToDo.WPF.ViewsToDo.WPF.Views 5      9!clr-namespace:ToDo.WPF.ViewModelsToDo.WPF.ViewModels 5
          ToDo.WPF.Views.AccountView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     5      8
converters!clr-namespace:ToDo.WPF.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ToDo.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      8
viewmodels!clr-namespace:ToDo.WPF.ViewModels     5
        � 	Resources  5         BooleanToVisibility2  ,ToDo.WPF.Converters.RoleValueToBoolConverter  RoleValueToBoolConverter�� 5   
   %:   &	        &	      �� 5      6+     5      62   5      .��5      �� $��1��6   .��5   
   �   BrushBackgroundReversed#��[ 6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��5      $��10,10q�5        BrushActivated#��[ 5      $��0,0,0,2q�5      ._�5       ��  �� Padding$ 0,0,0,10q�5!      $��48(�5"      $��Профиль��5#      5$      � 5%      $��1��6    5&      �� 5'      $
��auto �6$   �� 5(      $
��auto �6$   �� 5)      $
��auto �6$   �� 5*      $
��auto �6$   �� 5+      $
��auto �6$   .+�5-      �� $��1��5.      #��[ 5/      $��0,0,0,2q�50      ._�51      � $��10q�6    � IsSharedSizeScope$
 True��6'    52      �� 53      $
��auto �6,   �� 54      $
��auto �6,   �� 55      $
��auto �6,   �� 56      $
��auto �6,   �� 57      $
��auto �6,   �� 58      $
��auto �6,    � ColumnDefinitions 5:      �� 5;      $
��auto �6/   �� 5<      $	��260 �6/   .+�5>      �� $��0��5?      $��0��5@      $
��10,5q�5A      $��16(�5B      $��
Почта��5C      �� 5D      $��0��5E      $��1��5F      $
��10,5q�5G      $��16(�5H      ��5I      �� *CurrentUser.Email+�� 5J      $��1��5K      $��0��5L      $
��10,5q�5M      $��16(�5N      $��
Логин��5O      �� 5P      $��1��5Q      $��1��5R      $
��10,5q�5S      $��16(�5T      ��5U      �� *CurrentUser.Username+�� 5V      $��2��5W      $��0��5X      $
��10,5q�5Y      $��16(�5Z      $)��#Права пользователя��5[      �� 5\      $��2��5]      $��1��5^      $
��10,5q�5_      
������ $��16(�5a      ${�False��5b      ��5c      �� *CurrentUser.Role+�� 5d      $��3��5e      $��0��5f      $
��10,5q�5g      $��16(�5h      $%��Дата регистрации��5i      �� 5j      $��3��5k      $��1��5l      $
��10,5q�5m      
������ $��16(�5o      ${�False��5p      ��5q      �� *CurrentUser.DateJoined+�� 5r      $��4��5s      $��2��5t      $
��10,5q�5u        
BrushHover#��[ 5v      $��Обновить��5y      $��16(�5z        BrushForeground#��[ 5{      ��5w      �� *UpdateAccountCommand+��5x      �� *CurrentUser+5{      5|      5}      �� 5~      $��2��5      #��[ 5�      $��0,0,0,2q�5�      ._�5�      � $��10,10q�6   $
 True��6*    5�      �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   �� 5�      $
��auto �6,    5�      �� 5�      $
��auto �6/   �� 5�      $
��auto �6/   .+�5�      �� $��0��5�      $��0��5�      $
��10,5q�5�      $��16(�5�      $'��!Предыдущий пароль��5�      4   .PasswordBoxMVVM.Components.BindablePasswordBox  5�      $��0��5�      $��1��5�      $	��200��5�      $
��10,5q�5�      $��16(�5�      $��SemiBold"�5�         Password 5�      �� *PreviousPassword+ �� UpdateSourceTrigger$ PropertyChanged=��� 5�      $��1��5�      $��0��5�      $
��10,5q�5�      $��16(�5�      $��Новый пароль��5�        5�      $��1��5�      $��1��5�      $
��10,5q�5�      $��16(�5�      $��SemiBold"�5�       5�      �� *UpdatedPassword+$ PropertyChanged=��� 5�      $��2��5�      $��0��5�      $
��10,5q�5�      $��16(�5�      $0��*Повторите новый пароль��5�        5�      $��2��5�      $��1��5�      $
��10,5q�5�      $��16(�5�      $��SemiBold"�5�       5�      �� *ConfirmationPassword+$ PropertyChanged=��� 5�      $��3��5�      $��2��5�      $
��10,5q�5�      #��[ 5�      $!��Сменить пароль��5�      $��16(�5�      #��[ 5�      ��5�      �� *ChangePasswordCommand+5�      5�      5�      �� 5�      $��3��5�      $��2��5�      $��10,0,0,0q�5�      $��16(�5�      $��SemiBold"�5�      #��[ 5�       � DataContext 5�      �� *ResultMessageViewModel+��5�      �� *	Message+y�5�      �� *
HasMessage+ �� 	Converter# [  �� 5�      $��4��5�      $��2��5�      $��10,0,0,0q�5�      $��16(�5�      $��SemiBold"�5�        
BrushError#��[ 5�       5�      �� *ErrorMessageViewModel+��5�      �� *	Message+y�5�      �� *
HasMessage+# [  �� 5�      $��5��5�      $
{�True��5�      y�5�      �� *CurrentUser.Role+# [ ._�5�      �� 	 �� Orientation$	 Vertical=�6!   .+�5�      &   System.Windows.Controls.DataGrid  
   AutoGenerateColumns$
 False��6#   ��6?   �� *Users+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логин��6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
Username+$ PropertyChanged=�6w     5�   "   $ 
Почта��6t    65   �� *Email+$ PropertyChanged=�6t     5�   "   $) #Права пользователя��6s    65   �� *Role+$ PropertyChanged=�6s     5�   "   $% Дата регистрации��6y    65   �� *
DateJoined+$ PropertyChanged=�6y   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�   "   $ Статус��6y    69   �� *Status+$ PropertyChanged=�6y   5�      �� 5�      #��[ 5�      $��Обновить��5�      #��[ 5�      ��5�      �� *UpdateAllAccountsCommand+��5�      �� *Users+5�      5�      5�      5�      5�      5�      5�      