   M S B A M L   `   `   `  ����C  ?ToDo.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToDo.WPF.ControlsToDo.WPF.Controls  5      E'clr-namespace:ToDo.WPF.State.NavigatorsToDo.WPF.State.Navigators  5      U QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5	      9!clr-namespace:ToDo.WPF.ViewModelsToDo.WPF.ViewModels  5
      #    ToDo.WPF.Controls.TaskSummary   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ToDo.WPF.Controls     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      7nav'clr-namespace:ToDo.WPF.State.Navigators     5      <sys,clr-namespace:System;assembly=System.Runtime     5	      8
viewmodels!clr-namespace:ToDo.WPF.ViewModels     5
        J� InputBindings  5      �� 5   
   
 �� Key$	 Esc��5      (   "ToDo.WPF.State.Navigators.ViewType   Home �� CommandParameter# Z 5       �� Command 5      �� *UpdateCurrentViewModelCommand+5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��5      $��10q�5      $
��Left=�5      $��30(�5         BrushActivated#��[  5      ��5      �� *SelectedTask+ �� UpdateSourceTrigger$ PropertyChanged=�� 5!   
   $��1��6   .+�5"      �� -   5         ��Name$ TaskViewBox��5#      $��Disabled=�5%      $��Visible=�5&       %� 
ScrollUnit$ Pixel=�5(      ��5$      �� *Tasks+	 �� SelectedIndex	 5'      �� *SelectedTask+
 �� Mode$
 TwoWay=�$ PropertyChanged=�  5)      �� 5*      $ Enter��6!    6-   �� *UpdateTaskCommand+�� 5+      $ Delete��6!    6.   �� *DeleteTaskCommand+�� 5,      $ Enter��5-         Task# Z 5/       �� 	Modifiers$
 Ctrlf�50       5.      �� *UpdateCurrentViewModelCommand+50       � ContextMenu 52      �� 53      .@�54      m� $��	Duplicate��6L    m� Command 6#   �� *DuplicateTaskCommand+6L   m� 55      $��Delete��6I    6#   �� *DeleteTaskCommand+6I   56      ��58      �� 59      .R�5:      � $��0��6$   .+�5;      �� $��0��5<   !   $	��Top=�5=   !    d� 	IsChecked 5>   !   �� *IsCompleted+$ PropertyChanged=� � LayoutTransform 5?   "   �� 5@   &    �� ScaleX$ 2Q�65    �� ScaleY$ 2Q�6@   5B      � 5C      $	��350��6#    5D   "   �� 5E   &   $��2* �64   �� 5F   &   $��* �64   .+�5H   "   �� $��0��5I   %   $	��5,0q�5J   %   
������ $��0q�5L   %   $��18(�5M   %   $��SemiBold"�5N   %    �� TextWrapping$
 Wrap=�5P   %   ��5O   %   �� *Header+$ PropertyChanged=�5P   %   �� 5Q   "   $��1��5R   %   $��50��5S   %   $	��5,0q�5T   %   
������ $��0q�5V   %   $��12(�5W   %   $
 Wrap=�5Y   %   ��5X   %   �� *Description+$ PropertyChanged=�5Y   %   5Z      � 5[      $	��120��6#   .+�5\   "   �� $	��Top=�5]   %   $��18(�5^   %   ��5_   %   �� *
Category+$ PropertyChanged=�5`      � 5a      $	��120��6#   .+�5b   "   o� $	��Top=�6'   
������ .@�5c   &   m� ��6/   �� *
Deadline+$ PropertyChanged=�.@�5d   *   &   System.Windows.Controls.Calendar     FirstDayOfWeek$ Monday=�63      SelectedDate 6K   �� *
Deadline+$ PropertyChanged=�5e   '   5f   #   5g      � 5h      $
��auto��5i   !   $��Right=�5j   !   $	��Top=�5k   !   .+�5l   "   �� $��35��6(   ��63   �� *PriorityStatus+5m      5o      5p      5r      5�      5�      5�      