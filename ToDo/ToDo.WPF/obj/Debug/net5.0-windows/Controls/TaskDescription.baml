   M S B A M L   `   `   `  ����C  ?ToDo.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ToDo.WPF.ConvertersToDo.WPF.Converters  5      5clr-namespace:ToDo.WPF.ControlsToDo.WPF.Controls  5      E'clr-namespace:ToDo.WPF.State.NavigatorsToDo.WPF.State.Navigators  5	      9!clr-namespace:ToDo.WPF.ViewModelsToDo.WPF.ViewModels  5
      '    !ToDo.WPF.Controls.TaskDescription   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      8
converters!clr-namespace:ToDo.WPF.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ToDo.WPF.Controls     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      7nav'clr-namespace:ToDo.WPF.State.Navigators     5	      8
viewmodels!clr-namespace:ToDo.WPF.ViewModels     5
        J� InputBindings  5      �� 5   
   
 �� Key$ Enter��6    �� Command 6!   �� *UpdateTaskCommand+�� 5   
   $ Delete��6    6"   �� *DeleteTaskCommand+�� 5   
   $	 Esc��5      (   "ToDo.WPF.State.Navigators.ViewType   Home �� CommandParameter# Z 5       5      �� *UpdateCurrentViewModelCommand+5      .��5      � .+�5   
   �� $��10q�6    �� Orientation$ Vertical=�6!   .+�5      ��    BrushActivated#��[  6   $��0,0,0,2q�6C   ._�5      �� $ 
Horizontal=�6   .+�5      �� $��0��5      $��Center=�5       d� 	IsChecked 5      �� *" SelectedTaskInstance.IsCompleted+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�	 � LayoutTransform	 5      �� 5       
 �� ScaleX$
 3Q�6-    �� ScaleY$ 3Q�68   5"      �� 5#      $��5q�5$      
������ $��0q�5&      $��36(�5'      $��SemiBold"�5(      ��5)      �� *SelectedTaskInstance.Header+$ PropertyChanged=�$ TwoWay=�5*      5+      �� 5,      #��[  6   $��0,0,0,2q�6C   ._�5-      �� $	��300��5.       �� AcceptsReturn$
 True��5/      
������ $��0q�51      $��18(�52       �� TextWrapping$
 Wrap=�54      ��53      �� *" SelectedTaskInstance.Description+$ PropertyChanged=�$ TwoWay=�54      55      �� 57      $��Hidden=�58       �� PanningMode$ HorizontalFirst=�59      $��Disabled=�5:      .��5;      �� #��[  6   $��0,0,0,0q�6G   ._�5<      �� $ 
Horizontal=�6!   .+�5=      �� $	��250��5>      $	��250��5?      
������ $��+��5B      $	��100(�5C      ��5A      �� *UploadImageCommand+��5D      �� 5E   "    �� Opacity$	 0.5Q�62     
ColorHover �� Color# [ 6@   5G      �� 5H      $
��True��5J      $��Visible=�5K       %� 
ScrollUnit$ Pixel=�5L      ��5I      �� *Images+$ PropertyChanged=���5M      �� 5N   "   .R�5O   &   �� $	��250��5P   )   $	��250��5Q   )   $��UniformToFill=�5S   )   ��5R   )   �� *Image+$ PropertyChanged=�5S   )   5T   #   ��5V      �� 5W   "   .R�5X   &   �  K� IsItemsHost$
 True��60    � Orientation$ 
Horizontal=�6C   5Y   #   5[      5\      5]      5_      �� 5`      #��[  6   $��0,0,0,0q�6C   ._�5a      �� $ 
Horizontal=�6   .+�5b      �� $	��250��5c      $��50��5d      $��Center=�5e      
������ $��Файл��5h      $��36(�5i      ��5g      �� *UploadFileCommand+��5j      �� 5k      $	 0.5Q�6.   # [ 6<   5m      �� 5n      $��Disabled=�5p      $ Pixel=�5q      ��5o      �� *Files+$ PropertyChanged=���5r      �� 5s      .R�5t   "   �� $	��250��5u   %   $��50��5v   %   $��24(�5w   %   ��5x   %   �� *
Filename+$ PropertyChanged=�5y      ��5{      �� 5|      .R�5}   "   � $
 True��6,   $ 
Horizontal=�6?   5~      5�      5�      5�      5�      5�      5�      