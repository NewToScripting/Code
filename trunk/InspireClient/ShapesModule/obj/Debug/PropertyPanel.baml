   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5       ShapesModule    ShapesModule.PropertyPanel   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      .��5      �� -   5          ��Name$
  grid��5   �   $��	0,0,-15,0q�6      SunkenBackground#��[  6    $��Right=�6O    J� RenderTransformOrigin$ 0.5,0.5&�6k   $	��260��6�   z�5   
   V� 5      .~�5      ��  �� ScaleX$ 1Q�6!    �� ScaleY$ 1Q�6,   �� 5	       �� AngleX$ 0Q�6     �� AngleY$ 0Q�6+   �� 5
       �� Angle$ 0Q�6"   T� 5       T� X$ 0Q�6%    T� Y$ 0Q�6+   5      	 J� BitmapEffect	 5   
   �� 5      
 �� 
BevelWidth$
 3Q�6     �� EdgeProfile$ BulgedUp=�5       �� Relief$ .1Q�6,   ._�5      �� $��5q�6   $��Stretch=�6   #��[  6:   .+�5   
      Inspire.PropertyBase  -   5        $��propBase��5      $��5,5,10,5q�6/   9� 5   
    9� 
IsExpanded . $��2��6%   $	��236��62   $��0,5,0,5q�6>   $��Shape Properties��6O   .��5      �  � ColumnDefinitions 5      �� 5      $	��120 �6#   �� 5      $
��130* �6#   .+�5      ��  �� Orientation$ Vertical=�6   $��0��60   .+�5      �� -   5        $��	txtHeight��5   #   $��5q�6   $��Right=�64   $��25��6W   $	��Top=�6c   
�������$��Center=�6�   $��Right=�6�   .��6�   Border Size:6�   �� 5      -   5        $��lblColor��5   #   $��5q�6   $��Right=�63   $��25��6V   $	��Top=�6b   
�������$��Center=�6�   $��Right=�6�   .��6�   Border Color:6�   �� 5      -   5        $��lblBakColor��5   #   $��5q�6   $��Right=�66   $��25��6Y   $	��Top=�6e   
�������$��Center=�6�   $��Right=�6�   .��6�   Background Color:6�   5      �� 5       $��1��6   .+�5!      �� -   5        $��textBox3��5!   �   $��Center=�6   $��5q�6�   $��25��6�   $	��Top=�6�   ��6<   ��  �� Path$! Content.Content.BorderWidth� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5#      $
��Left=�6   $��1q�64   
���   �  CheckerBrush#��[ 6\   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5$      �� -   5         ��Name$ btnFontColor��5$       $��20��66   $��20��6A   $
��Left=�6p   ��6�   Z� ��6�   �� $! Content.Content.BorderColor�$ TwoWay=�$ PropertyChanged=�5%      �� 5&      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5'      �� -   5        $ btnBakColor��5'   (   $��20��6=   $��20��6H   $
��Left=�6|   ��6�   Z� ��6�   �� $% Content.Content.BackgroundColor�$ TwoWay=�$ PropertyChanged=�5(      5)      5*      5+      5,      5-      5.      