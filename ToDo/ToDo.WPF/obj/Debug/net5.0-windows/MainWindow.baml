   M S B A M L   `   `   `  ����C  ?ToDo.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToDo.WPF.ControlsToDo.WPF.Controls  5      #clr-namespace:ToDo.WPFToDo.WPF  5      E'clr-namespace:ToDo.WPF.State.NavigatorsToDo.WPF.State.Navigators  5	      9!clr-namespace:ToDo.WPF.ViewModelsToDo.WPF.ViewModels  5
          ToDo.WPF.MainWindow   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4controlsclr-namespace:ToDo.WPF.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ToDo.WPF     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      7nav'clr-namespace:ToDo.WPF.State.Navigators     5	      8
viewmodels!clr-namespace:ToDo.WPF.ViewModels     5
        � Title$  GetDone��5      $	��800��5      $	��450��5       J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��5      (   "ToDo.WPF.State.Navigators.ViewType   Home �� CommandParameter# Z 5       �� Command 5      �� *UpdateCurrentViewModelCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   ��5      �� 5       �� 
TargetType" �6    �� Triggers 5      �� 5      	 �� Binding	 6&   �� *
IsLoggedIn+
 �� Value	
 False6E   .a�5       ��  �� Property � y� �� Value$ 	Collapsed=�6;   5!      �� 5"      	 6&   �� *
IsLoggedIn+
 True6E   .a�5#      ��  � y�$ Visible=�6;   �� 5$       � ��$	 200��66   5%      5'      .+�5)      %   ToDo.WPF.Controls.NavigationBar  5*      �� 5,   
   $��1��6   ��6)   �� *CurrentViewModel+52      53      