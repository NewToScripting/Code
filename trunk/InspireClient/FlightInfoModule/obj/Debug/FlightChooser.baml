   M S B A M L   `   `   `  ����  FlightInfoModule$    FlightInfoModule.FlightChooser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��456��5      $	��830��6      WindowBackgroundBrush#��[  6'     � WindowStartupLocation$  CenterScreen=�6[   .��5      �  � ColumnDefinitions 5	   
   �� 5
      $
��305* �6   �� 5      $
��503* �6    � RowDefinitions 5   
   �� 5      $
��387* �6   �� 5      $	��63* �6   .+�5   
   �� $%��Single Panel Flight Information��6    �� TextAlignment$ Center=�6;   $��16(�6R   
�������$
��Bold"�6s   $��5q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5        $!��resources/images/single.png��5      $��67,40,64,10q�65   $��Center=�6J   $��Center=�6g   $	��309��6�   $	��174��6�    5        5      5      �� 5   
   $%��Double Panel Flight Information��6   $��1��6;   $ Center=�6K   $��16(�6b   
�������$
��Bold"�6�   $��5q�6�    5        5      5      �� 5    
   -   5        $!��Resources/images/double.png��5       $��20q�65   $��0��6A   $��1��6N   $��Center=�6^   $��Center=�6{    5!        5"      5$      �� 5%   
   $��Right=�6    �� Orientation$ 
Horizontal=�61   $��1��6J   $��1��6W   .+�5&      �� -   5        $��Cancel��5&      $	��150��6&   $��6q�62   6=   5'      5(      5)      