   M S B A M L   `   `   `  ���� I  EInspire.Common, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullgDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.CommonInspire.Common.DragDropListBox  ! Inspire.Client.ScheduleWindowM   GInspire.Client.ScheduleWindow.ScheduledSlidePanel.ScheduledSlideControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2006     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     `DragDropListBoxDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.Common     $	��115��$��Stretch=�  � 	Resources  ��%    ����  �� ImageSource$ Images/singlestrip.bmp�� j� Stretch$
 Fill=� j� TileMode$
 Tile=� j� Viewport$ 0,0,180,120� j� ViewportUnits$ Absolute=�.��� -    �Name$ 	SlideGrid��$	��100�� J� SnapsToDevicePixels .  J� 	AllowDrop . 3   -Inspire.Common.DragDropListBox.DragDropHelper	   IsDropTarget	 . 
 � ColumnDefinitions
 �� $��22 ��� $	��100��$��* ��� $��22 �     LBStyle �� 
TargetType �� Property �� Value �� Orientation  ListBoxTemplateDrag � 	Resources��%�   &	        &	 Q     �� " ��.���  � �� �� .R��� $ 
Horizontal=�$	��Top=�$
��Left=���  ���� '��       " ��.���  � ��$ 50����  � ��$ 5q�.+��� -    ��Name$ border�����	#FF666666$��1,1,1,1q� �� CornerRadius$ 5,5,5,5��$��0,0,0,0q����� -   TransparentBrush�� �� EndPoint$ 0.697,0.976&� �� 
StartPoint$ 0.277,0.197&�.���  � Color$ 	#D8333333�� � Offset$ 0Q�� $ 	#FF000000��$ 1Q��� -   $��btnSlideLeft��$��0����  J� IsHitTestVisible .    
GlyphBrush#��[ $��	7,53,0,37q�$��2��$
��Left=�$��16��.��<�� -    ��Name$ ScheduledSlidePanel��
������  . #��[   .    DragDropTemplate# [    IsDragSource . 	 . $��Disabled=�$��Disabled=�$��1���� -    ��Name$ DropGrabber��
���   � J� Opacity$	 .05Q� . $��1��$y�	Collapsed=�� -   $ PART_No_Slide_Grid��$��1��$ 0Q����	#C1000000$��Stretch=�.+�� $��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 15Q�   	Direction$	 300Q�
 �� �� .+��� $��0��$��Images/fail.png��$��32��$
��Left=�$��10q��� $��1��$��16(�$
��Bold"�
�������$��Center=�$��Center=� �� TextAlignment$ Center=�$
��Wrap=�'%Edit a Schedule to Modify the Slides.�� -   $��btnSlideRight��$��2����  .  #��[ $��2��$��
7,52,-2,37q�.��>