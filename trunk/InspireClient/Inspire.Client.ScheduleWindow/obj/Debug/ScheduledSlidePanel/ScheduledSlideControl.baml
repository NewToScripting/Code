   M S B A M L   `   `   `  ����I  EInspire.Common, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullgDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.CommonInspire.Common.DragDropListBox  5      ! Inspire.Client.ScheduleWindowM   GInspire.Client.ScheduleWindow.ScheduledSlidePanel.ScheduledSlideControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2006     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      `DragDropListBoxDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.Common     5      $	��115��5      $��Stretch=�6#     � 	Resources  5      ��%    5
      ��5      �� 5   
    �� ImageSource$ Images/singlestrip.bmp��6    j� Stretch$
 Fill=�6:    j� TileMode$
 Tile=�6I    j� Viewport$ 0,0,180,120�6Y    j� ViewportUnits$ Absolute=�6p   6�   .��5      � -   5         �Name$ 	SlideGrid��5      $	��100��6    J� SnapsToDevicePixels .  J� 	AllowDrop . 3   -Inspire.Common.DragDropListBox.DragDropHelper	   IsDropTarget	 . 
 � ColumnDefinitions
 5   
   �� 5      $��22 �6   6,   �� 5      $	��100��6   $��* �6.   6:   �� 5      $��22 �6   6,     5   
      LBStyle �� 
TargetType �� Property �� Value �� Orientation  ListBoxTemplateDrag � 	Resources��%p  &	        &	 �     �� 5      " ��6$   .�5      ��  � �� 5      �� 5      .R�5      �� $ 
Horizontal=�6)   $	��Top=�5      $
��Left=�5      5      5      5      �� 5!       5"      ���� 5#      '��       " ��6   .�5$      ��  � ��$ 50��63   �� 5%       � ��$ 5q�63   5&      5'      5)      5*      .+�5,   
   �� -   5         ��Name$ border��5,   �   ���	#FF666666$��1,1,1,1q�6)    �� CornerRadius$ 5,5,5,5��6C   $��0,0,0,0q�6v   ��5-      �� 5.      -   5        TransparentBrush�� �� EndPoint$ 0.697,0.976&�5.   @    �� 
StartPoint$ 0.277,0.197&�6W   .��5/      �  � Color$ 	#D8333333��6#    � Offset$ 0Q�65   � 50      $ 	#FF000000��6#   $ 1Q�65   51      53      �� 55   
   -   5        $��btnSlideLeft��55   !   $��0��6   57      �� 58   
    J� IsHitTestVisible .    
GlyphBrush#��[ 6)   $��	7,53,0,37q�6R   $��2��6e   $
��Left=�6y   $��16��6�   .��6�   <6�   �� 59   
   -   5         ��Name$ ScheduledSlidePanel��59   g   
������  . #��[  6F    .    DragDropTemplate# [ 6�      IsDragSource . 	 . $��Disabled=�6R  $��Disabled=�6�  $��1��6�  5=      �� 5?   
   -   5         ��Name$ DropGrabber��5?      
���   � J� Opacity$	 .05Q�66    . $��1��6\   $y�	Collapsed=�6l   � 5@   
   -   5        $ PART_No_Slide_Grid��5@   B   $��1��6   $ 0Q�6   ���	#C1000000$��Stretch=�6^   .+�5A   
   � $��Center=�6    J� Effect 5B      3  -System.Windows.Media.Effects.DropShadowEffect  5C         
BlurRadius$ 15Q�6#      	Direction$	 300Q�63   
 5E      �� 5F      �� 5G      .+�5I      �� $��0��6   $��Images/fail.png��6$   $��32��6=   $
��Left=�6H   $��10q�6c   �� 5J      $��1��6   $��16(�6(   $
��Bold"�66   
�������$��Center=�6[   $��Center=�6v    �� TextAlignment$ Center=�6�   $
��Wrap=�6�   '%Edit a Schedule to Modify the Slides.6�   5K      5L      �� 5N      -   5        $��btnSlideRight��5N      $��2��6   5P      �� 5Q   
    .  #��[ 6*   $��2��6S   $��
7,52,-2,37q�6c   .��6w   >6z   5R      5S      