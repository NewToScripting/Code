   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5   E    	MapModule   MapModule.PropertyPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     6E     � 	Resources  5         StandardPanel �� 
TargetType �� Property �� Value��%\   &	        �� 5   
   " �6&   .�5      ��  � y�$ Visible=�6+   6=   5      5      .��5	      �� -   5         ��Name$
 grid��5	   �   $��	0,0,-15,0q�6     SunkenBackground#��[ 6)   $��Right=�6X    J� RenderTransformOrigin$ 0.5,0.5&�6t   $	��260��6�   z�5
      V� 5   
   .~�5      ��  �� ScaleX$ 1Q�6    �� ScaleY$ 1Q�6(   �� 5       �� AngleX$ 0Q�6   	 �� AngleY$	 0Q�6'   �� 5      
 �� Angle$
 0Q�6   T� 5       T� X$ 0Q�6!    T� Y$ 0Q�6'   5      ._�5   
   �� $��5q�6   $��Stretch=�6    #��[ 6>   .+�5         Inspire.PropertyBase  -   5        $��propBase��5   #   $��5,5,10,5q�63   9� 5      $��General Properties��6    9� 
IsExpanded . .��5      � #��[  6    � ColumnDefinitions 5      �� 5      $	��110 �6#   �� 5      $	��90* �6#   .+�5      ��  �� Orientation$ Vertical=�6   $��0��60   .+�5      �� -   5        $��txtWidth��5   /   $��25��6   $��5q�6$   $	��Top=�6?   
�������$��Right=�6j   $��Center=�6�   $��Right=�6�   $��44.64��6�   .��6�   
Opacity:6�   5      �� 5      $��1��6   .+�5       �� -   5        $��
mapOpacity��5    4   $��1��6   $��5q�6)    � Minimum$ 0Q�6F    � Maximum$ 1Q�6R   $��25��6�    � Value 6^   ��  �� Path$ 
MapOpacity� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5!      5"      5#      5$      5%      5&      