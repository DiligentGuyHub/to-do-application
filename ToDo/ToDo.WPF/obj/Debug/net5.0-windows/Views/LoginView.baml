   M S B A M L   `   `   `  ����J  FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components  5      C ?ToDo.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ToDo.WPF.ViewsToDo.WPF.Views 5      9!clr-namespace:ToDo.WPF.ViewModelsToDo.WPF.ViewModels 5
         ToDo.WPF.Views.LoginView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      (localclr-namespace:ToDo.WPF.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      2
viewmodels!clr-namespace:ToDo.WPF.ViewModels  5
      ��5      �� 5   
     �� ImageSource$+  %/Resources/Backgrounds/night-view.jpg��6    j� Stretch$ UniformToFill=�6I    � 	Resources 5         BooleanToVisibility�� 5   
   %   &	        �� 5      6+   5      .��5      ��  �� Padding$ 25q�5   	   $��Center=�5   	   $��Center=�5   	   ��5   
   �� 5       �� Opacity$	 0.8Q�6    �� Color$ Black��6,   ._�5    
   �  � IsSharedSizeScope$
 True��6    � RowDefinitions 5!      �� 5"      $
��auto �6    �� 5#      $
��auto �6    �� 5$      $
��auto �6    �� 5%      $
��auto �6    .+�5(      �� $��0��5)      $��Center=�5*      $��48(�5+        BrushForeground#��[ 5,      $��Get Done��5-      �� 5.      $��1��5/      $��Center=�50      $��16(�51      #��[ 52      $ ��Your tasks - your business��53      � 55      $��2��6   $
��0,20q�6     56      �� 57      $
��auto �6$   �� 58      $
��auto �6$   �� 59      $
��auto �6$   �� 5:      $
��auto �6$   .+�5=      � $��0��6   $
��5,10q�6$    � ColumnDefinitions 5>      �� 5?      $
��auto �6+   	 z� SharedSizeGroup$	 Label��68   �� 5@      $	��300 �6+   .+�5C      �� $��0��5D      $��16(�5E      #��[ 5F      $��
Логин��5G      �� 5H      $��1��5I      $
��20,0q�5J      #��[ 5K      $��0,0,0,2q�5L      ._�5M      �� 
������ 
������ $��14(�5P      #��[ 5Q      ��5R      �� *
Username+
 �� UpdateSourceTrigger$
 PropertyChanged=�5S      5T      � 5V      $��1��6   $
��5,10q�6$    5W      �� 5X      $
��auto �6+   $	 Label��68   �� 5Y      $	��300 �6+   .+�5\      �� $��0��5]      $��16(�5^      #��[ 5_      $��Пароль��5`      �� 5a      $��1��5b      $
��20,0q�5c      #��[ 5d      $��0,0,0,2q�5e      ._�5f      4   .PasswordBoxMVVM.Components.BindablePasswordBox  $��1��5g      $��1��5h      
������ 
������ $��14(�5k      #��[ 5l         Password 5m      �� *
Password+5n      5o      �� 5q      $��2��5r      $��2��5s      $	��380��5t      $
��0,10q�5u      $	��0,5q�5v      $��Center=�5w      
������ $��
Войти��5z      $��16(�5{      #��[ 5|       �� 	IsDefault$
 True��5}      ��5y      �� *LoginCommand+��5~      �� 5      $	 0.8Q�6*   $ #004771��68   5�      �� 5�      $��3��5�      $	��380��5�      $��Center=�5�      
������ 
������ $%��Еще нет аккаунта?��5�      $��16(�5�      #��[ 5�      ��5�      �� *ViewRegisterCommand+5�      5�      �� 5�      $��3��5�      $��10,0,0,0q�5�      $��Center=�5�      $��16(�5�      $��SemiBold"�5�        
BrushError#��[ 5�       � DataContext 5�      �� *ErrorMessageViewModel+��5�      �� *	Message+y�5�      �� *
HasMessage+ �� 	Converter# [  5�      5�      5�      