   M S B A M L   `   `   `  ����R  NInspire.Client.Designer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Inspire.Client.Designer.DragCanvas.Thumbs)Inspire.Client.Designer.DragCanvas.Thumbs  5      B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands 5      W0clr-namespace:Inspire.Client.Designer.DragCanvas"Inspire.Client.Designer.DragCanvas  5      L3clr-namespace:Inspire.MediaObjects;assembly=InspireInspire.MediaObjects 5      A%clr-namespace:Inspire.Client.DesignerInspire.Client.Designer  6^   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089>    8Inspire.Client.Designer.DragCanvas.DoubleFormatConverter   doubleFormatConverter ' #ResizeNotificationDecoratorTemplate  �� 
TargetType J� SnapsToDevicePixels �� Stretch �� Padding �� Path �� 	Converter � LayoutTransform �� Angle �� CenterX	 �� CenterY;   5Inspire.Client.Designer.DragCanvas.Thumbs.RotateThumb
 �� 
TargetType �� Property �� Value  DesignerItemContextMenu  ContextTemplate&   Inspire.Commands.InspireCommands   
CutCommand m� Command  
Office2007 m� Icon   CopyCommand   PasteCommand   DeleteCommand   BringToFrontCommand   BringForwardCommand   SendToBackCommand   SendBackwardCommand   Rotate90RightCommand   Rotate90LeftCommand   FlipVerticalCommand   FlipHorizontalCommand   FitToSlideCommand   AddReflectionCommand  RotateDecoratorTemplate � Cursor  ResizeDecoratorTemplate J� Opacity;   5Inspire.Client.Designer.DragCanvas.Thumbs.ResizeThumb  DragThumbTemplate9   3Inspire.Client.Designer.DragCanvas.Thumbs.DragThumb.  (Inspire.MediaObjects.DesignControlHolder � DataContext  �� RelativeSource! ��Name" �� Triggers# ^� 
Conditions$ �� Binding% �� Value& �� AncestorType' �� Mode( �� UpdateSourceTrigger) �� 
TargetName/  )Inspire.MediaObjects.DesignContentControl* � ContextMenu+ ��Name,   ContentStyle-   ContentBackground.   CornerRadius/ �� CornerRadius0 ��Name1 J� Clip2 � RowDefinitions3 J� IsHitTestVisible4   GlassOpacity5 
� Center6 
� GradientOrigin7 
� RadiusY8 
� RadiusX9 � Color: � Offset;   ContentZIndex< K� ZIndex=   InnerGlowOpacity> �� 
StartPoint? �� EndPoint�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      =s7clr-namespace:Inspire.Client.Designer.DragCanvas.Thumbs  5      <Commands/clr-namespace:Inspire.Commands;assembly=Inspire  5      ?
DragCanvas0clr-namespace:Inspire.Client.Designer.DragCanvas  5      DMediaObjects3clr-namespace:Inspire.MediaObjects;assembly=Inspire  5      2Designer%clr-namespace:Inspire.Client.Designer  6^   %�-  &	        &	      7   7   '  �    &	     7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 3    &	 �    &	 �    '  	    7  7  7  '  �    7  7     5      6'   �� 5
      "  ��6N   .R�5      �  . .+�5      F� 
�������$��1��5      $��10��5      $��Bottom=�5      $��-2,0,-2,-15q�5      $
 Fill=�5      =����        �    ��� �    @KL � ��@KL � ��    � ����� 	5      �� 5      
�������$ 3,0,3,0q�5      
���   �$��	0,0,0,-18q�5      $��Center=�5      $��Bottom=�5      ��5   $   �� $ Width�8   5      F� 5      
�������$��1��5      $��10��5      $��Right=�5      $��0,-2,-15,-2q�5      $
 Fill=�5      =����@KL     �@KL  ���        р��     �     ��р��  ��	5       �� 5!      
�������
���   �$ 3,0,3,0q�5$      $��	0,0,-18,0q�5%      $��Right=�5&      $��Center=�5'      ��5!   $   �� $ Height�8   5(      �� 5)      $ 90Q�6"   $ 1Q�6-   $		 0.5Q�69   5+      5,      5-      �� 50      "
  6   .�51   
   ��  �@J�RenderTransformOrigin$ 0.5,0.5&�62   �� 52   
    �@�Cursor$
 Hand��6#   �� 53   
    � �� 54      �� 55      "   6"   .R�56      � $��30��6   $��30��6&   .+�57      F� ���	#AAD0D0DD$
 Fill=�60   7���Ѐ�� ��� ������������р�����р�� ��	6?   58      59      5;      5<      �� 5>      8��  .@�5?   
   m� $	��Cut��6   # Z 6    8�� $��3,0,0,0q�6}    5@      �� 5A      $��Images/Cut16.png��6   $��16��62   5C      m� 5D   
   $
��Copy��6   # Z 6!   8�� $��3,0,0,0q�6    5E      �� 5F      $��Images\Copy16.png��6   $��16��63   5H      m� 5I   
   $��Paste��6   # Z 6"   8�� $��3,0,0,0q�6�    5J      �� 5K      $��Images\Paste16.png��6   $��16��64   5M      m� 5N   
   $��Remove��6   # Z 6#   8�� $��3,0,0,0q�6�    5O      �� 5P      $��Images\Remove.png��6   $��16��63   5R      �� 5S   
   m� 5U   
   $��Bring To Front��6   $��3,0,0,0q�6+   8��  5V      �� 5W      $��Images\BringToFront.png��6   $��16��69   .@�5Y      m� $��Bring To Front��6   8�� # Z 6S    5Z      �� 5[      $��Images\BringToFront.png��6   $��16��6=   5]      m� 5^      $��Bring Forward��6   8�� # Z 6R    5_      �� 5`      $��Images\BringForward.png��6   $��16��6=   5b      5c      m� 5e   
   $��Send To Back��6   8�� # Z 6M    5f      �� 5g      $��Images\SendToBack.png��6   $��16��67   .@�5i      m� $��Send To Back��6   8��	 # Z 6Q    5j      �� 5k      $��Images\SendToBack.png��6   $��16��6;   5m      m� 5n      $��Send Backward��6   8��
 # Z 6R    5o      �� 5p      $��Images\SendBackward.png��6   $��16��6=   5r      5s      �� 5t   
   m� 5v   
   $��Rotate��6   $��3,0,0,0q�6#   8��  5w      �� 5x      $��Images\Rotate16.png��6   $��16��65   .@�5z      m� $��Rotate Right 90º��6   8�� # Z 6U    5{      �� 5|      $��Images\Rotate16.png��6   $��16��69   5~      m� 5      $��Rotate Left 90º��6   8�� # Z 6T    5�      �� 5�      $��Images\RotateLeft16.png��6   $��16��6=   5�      5�      m� 5�   
   $
��Flip��6   $��3,0,0,0q�6!   8��  5�      �� 5�      $��Images\FlipVertical16.png��6   $��16��6;   .@�5�      m� $��Flip Vertical��6   8�� # Z 6R    5�      �� 5�      $��Images\FlipVertical16.png��6   $��16��6?   5�      m� 5�      $��Flip Horizontalº��6   8�� # Z 6U    5�      �� 5�      $��Images\FlipHorizontal.png��6   $��16��6?   5�      5�      �� 5�   
   m� 5�   
   $��Fit to Slide��6   # Z 6)   8�� $��3,0,0,0q�6�    5�      �� 5�      $��Images\FitToCanvas16.png��6   $��16��6:   5�      m� 5�   
   $��Add Reflection��6   # Z 6+   8�� $��3,0,0,0q�6�   5�      �� 5�      "  ��66   .R�5�   
   � .+�5�        $��-18,-18,0,0q�6   $	��Top=�61   $
��Left=�6I   $ Images/rotate.cur��6d     5�      $��0,-18,-18,0q�6   $	��Top=�61   $��Right=�6I   $ Images/rotate.cur��6e   z�5�      �� 5�      $ 90Q�6&   5�        5�      $��0,0,-18,-18q�6   $��Bottom=�61   $��Right=�6L   $ Images/rotate.cur��6h   z�5�      �� 5�      $	 180Q�6&   5�        5�      $��-18,0,0,-18q�6   $��Bottom=�61   $
��Left=�6L   $ Images/rotate.cur��6g   z�5�      �� 5�      $	 270Q�6&   5�      5�      5�      �� 5�      "  ��66   .R�5�   
   �� 
���   �$��1q�6%   ._�5�   
   �  . $ 0Q�6*   .+�5�        $��5��6   $ SizeNS��6'   $��0 -4 0 0q�67    . $	��Top=�5�      $��Stretch=�6.     5�      $��5��6   $ SizeWE��6&   $��-4 0 0 0q�66    . $��Stretch=�5�      $
��Left=�62     5�      $��5��6   $ SizeWE��6&   $��0 0 -4 0q�66    . $��Stretch=�5�      $��Right=�62     5�      $��5��6   $ SizeNS��6'   $��0 0 0 -4q�67    . $��Bottom=�5�      $��Stretch=�61     5�      $��7��6   $��7��6&   $ SizeNWSE��61   $��	-6 -6 0 0q�6C    . $	��Top=�5�      $
��Left=�6.     5�      $��7��6   $��7��6&   $ SizeNESW��61   $��	0 -6 -6 0q�6C    . $	��Top=�5�      $��Right=�6.     5�      $��7��6   $��7��6&   $ SizeNESW��61   $��	-6 0 0 -6q�6C    . $��Bottom=�5�      $
��Left=�61     5�      $��7��6   $��7��6&   $ SizeNWSE��61   $��	0 0 -6 -6q�6C    . $��Bottom=�5�      $��Right=�61   5�      6   5�      �� 5�      "   60   .R�5�   
   �� 
������ 6   5�      �� 5�      "
  6   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    �@J�RenderTransformOrigin$ 0.5,0.5&�62   �� 5�   
    �@ 
IsSelected . 6'   �� 5�   
    �@ IsLocked .  6%   �� 5�   
    � �� 5�      �� 5�      "   6"   .R�5�      �  6   ��   �� *TemplatedParent+.+�5�      �� $��PART_RotateDecorator��6"   8��  $y�	Collapsed=�6r   �� 5�      $! PART_ResizeDecorator��6"   8�� $y�	Collapsed=�6t   �� 5�      $&!  PART_ResizeNotificationDecorator��6"   8�� $y�	Collapsed=�6�   �� 5�      #��z��6+   #��z��6p   5�      " 5�      ^� 5�      # 5�      �� 5�   "   $ 69   ��   �� *Self+$ 
IsSelected�% true6,   69   �� 5�   "   $ 6:   ��   �� *Self+$ IsLocked�	% false6,   6:   �� 5�   "   $ 6:   ��   �� *Self+$ IsRotatable�	% false6,   6:   �� 5�   "   $ 6:   ��   �� *FindAncestor+$& Designer:DesignWindowL�$ 	IsPlaying�$' OneWay=�$( PropertyChanged=�	% false6,   6:   .0�5�      �� $) PART_ResizeDecorator��6%    � y�$ Visible=�6]   �� 5�      $&)  PART_ResizeNotificationDecorator��6%    � y�$ Visible=�6i   5�      ^� 5�      # 5�      �� 5�   "   $ 69   ��   �� *Self+$ 
IsSelected�% true6,   69   �� 5�   "   $ 6:   ��   �� *Self+$ IsLocked�	% false6,   6:   �� 5�   "   $ 69   ��   �� *Self+$ IsRotatable�% true6,   69   �� 5�   "   $ 6:   ��   �� *FindAncestor+$& Designer:DesignWindowL�$ 	IsPlaying�$' OneWay=�$( PropertyChanged=�	% false6,   6:   .0�5�      �� $) PART_ResizeDecorator��6%    � y�$ Visible=�6]   �� 5�      $) PART_RotateDecorator��6%    � y�$ Visible=�6]   �� 5�      $&)  PART_ResizeNotificationDecorator��6%    � y�$ Visible=�6i   5�      5�      5�      5�      �� 5�      "
  6   .�5   
   ��  �@J�SnapsToDevicePixels . 60   �� 5  
    �@J�RenderTransformOrigin$ 0.5,0.5&�62   �� 5  
    �@ ClipContent . 6(   �� 5  
    �@ GlassOpacity$ 0Q�6)   �� 5  
    �@ ContentZIndex$ 0��6*   �� 5  
    � �� 5     �� 5	     "   6"   .R�5
     � 8*    6   ��   �� *TemplatedParent+.+�5     �� $+ PART_StyleBorder��6!   #��z, 6;   ._�5     �� $+ PART_Border��5  !   #��z- 5  !   #/ z. 5     #��z��5     #��z��5     ._�5     �� $ 0 PART_TopLeftContentControl��6-   $��Stretch=�5  -   $��Stretch=�6K   $��Stretch=�6g   $��Stretch=�6�   1 5  "   �� 5  &   PART_TopLeftClip��68   .��5  "   �� $!0 PART_TopRightContentControl��61   $��Stretch=�5  -   $��Stretch=�6K   $��Stretch=�6g   $��Stretch=�6�   1 5  &   �� 5  *   PART_TopRightClip��6<   .��5"  &   �� $$0 PART_BottomRightContentControl��65   $��Stretch=�5#  1   $��Stretch=�6O   $��Stretch=�6k   $��Stretch=�6�   1 5$  *   �� 5%  .   PART_BottomRightClip��6@   .��5(  *   �� $#0 PART_BottomLeftContentControl��69   $��Stretch=�5)  5   $��Stretch=�6S   $��Stretch=�6o   $��Stretch=�6�   1 5*  .   �� 5+  2   PART_BottomLeftClip��6D   .��5.  .   � 2 5/  2   �� 50  6   $��* �6D   �� 51  6   $��* �6D   .+�53  6   �� 3 .  $��2��6Y   $��0��6j   �� 54  6   3 .  # z4 6V   $��1��6   $��1��6�   $��0q�6�   ��55     
� 56     $5 0.5,1.2&�6$   $6 0.5,1.2&�65   $7 1.122Q�6N   $
8 0.50Q�6^   .��57     � $9 	#66FCFCFC��6   � 58     $: 1Q�6   59     5:  $     5;  6   $��PART_DragDecorator��6B   $��0��6\   $��2��6i   8�� $ SizeAll��6�   �� 5<  6   3 . $��0��6_   #��z��6l   #��z��6�   #< z; 6�   $��2��6  �� 5>  6   $+ PART_LeftGlow��6=   $��2��6T   $��0��6e   3 .  $< 0��6�   # z= 5?  %   $
��Left=�5@  %   $��Stretch=�6@   $��10��5A  %   ��5B  "   �� 5C  &   $> 0, 0.5&�6:   $? 1, 0.5&�6N   .��5D  *   � $: 0Q�67   $9 	#ff000000��6B   PART_LeftGlowStop0��6T   � 5E  *   $: 1Q�67   $9 	#00000000��6B   PART_LeftGlowStop1��6T   5F  '   5H     �� 5I     $+ PART_TopGlow��6%   $��2��6;   $��0��6L   3 .  $< 0��6r   # z= 5J  %   $��Stretch=�5K  %   $	��Top=�6C   $��10��5L  %   ��5M  "   �� 5N  &   $> 0.5, 0&�6:   $? 0.5, 1&�6N   .��5O  *   � $: 0Q�67   $9 	#ff000000��6B   PART_TopGlowStop0��6T   � 5P  *   $: 1Q�67   $9 	#00000000��6B   PART_TopGlowStop1��6T   5Q  '   5S     �� 5T     $+ PART_RightGlow��6%   $��2��6=   $��0��6N   3 .  $< 0��6t   # z= 5U  %   $��Right=�5V  %   $��Stretch=�6A   $��10��5W  %   ��5X  "   �� 5Y  &   $> 1, 0.5&�6:   $? 0, 0.5&�6N   .��5Z  *   � $: 0Q�67   $9 	#ff000000��6B   PART_RightGlowStop0��6T   � 5[  *   $: 1Q�67   $9 	#00000000��6B   PART_RightGlowStop1��6T   5\  '   5^     �� 5_     $+ PART_BottomGlow��6%   $��2��6>   $��0��6O   3 .  $< 0��6u   # z= 5`  %   $��Stretch=�5a  %   $��Bottom=�6C   $��10��5b  %   ��5c  "   �� 5d  &   $> 0.5, 1&�6:   $? 0.5, 0&�6N   .��5e  *   � $: 0Q�67   $9 	#ff000000��6B   PART_BottomGlowStop0��6T   � 5f  *   $: 1Q�67   $9 	#00000000��6B   PART_BottomGlowStop1��6T   5g  '   5i     �� 5k  6   3 .  # z4 6V   $��0��6�   $��1��6�   ��5l  6   �� 5m  :   $> 0.5,0&�6N   $? 0.5,1&�6a   .��5n  >   � $9 	#ffffffff��6K   $: 0Q�6]   � 5o  >   $9 	#C4ffffff��6K   $
: 0.05Q�6]   � 5p  >   $9 	#54ffffff��6K   $: 1Q�6]   5q  ;   5s  3   5t  3   5v  +   5x  '   5z  #   5|     5}     5~     5     5�     5�     5�     5�     