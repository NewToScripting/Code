   M S B A M L   `   `   `  ����  EffectLibrary-    'EffectLibrary.PropertyGrids.MagnifyGrid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��10 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��Right=�6   $��5q�60   $��Radii X:��6;   $��0��6K   $��1��6X   6j   �� 5   
   -   5         ��Name$ radiiX��5      $��2q�6   $��0��6m   $��3��6z    � Minimum$ 0Q�5       � Maximum$ 1Q�5       � SmallChange$	 .05Q�5       � Value 5   ,   �� *Radii.Width+5      �� 5   
   $��Right=�6   $��5q�60   $��Radii Y:��6;   $��2��6K   $��1��6X   6j   �� 5   
   -   5        $ radiiY��5      $��2q�6   $��2��6n   $��3��6{   $ 0Q�5      $ 1Q�5      $	 .05Q�5       5   ,   �� *Radii.Height+5      �� 5"   
   $��Right=�6   $��5q�60   $��	Center X:��6;   $��3��6L   $��1��6Y   6k   �� 5#   
   -   5        $ centerX��5#      $��2q�6   $��3��6l   $��3��6y   $ 0Q�5$      $ 1Q�5%      $	 .05Q�5&       5#   -   �� *
Center.X+5&      �� 5)   
   $��Right=�6   $��5q�60   $��	Center Y:��6;   $��4��6L   $��1��6Y   6k   �� 5*   
   -   5        $ centerY��5*      $��2q�6   $��4��6l   $��3��6y   $ 0Q�5+      $ 1Q�5,      $	 .05Q�5-       5*   -   �� *
Center.Y+5-      �� 50   
   $��Right=�6   $��5q�60   $��Shrink Factor:��6;   $��5��6Q   $��1��6^   6p   �� 51   
   -   5        $ shrinkFactor��51      $��2q�6   $��5��6R   $��3��6_   $ 0Q�52      $ 1Q�53      $	 0.1Q�54       51   2   �� *ShrinkFactor+54      56      57      