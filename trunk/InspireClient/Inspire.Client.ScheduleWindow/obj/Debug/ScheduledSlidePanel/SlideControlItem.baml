   M S B A M L   `   `   `  ����_  [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors  5      B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire 6^   ! Inspire.Client.ScheduleWindowH   BInspire.Client.ScheduleWindow.ScheduledSlidePanel.SlideControlItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     6^   $	��144��6�   $	��108��6�     � 	Resources  5        Inspire.DurationConverter   durationConverter  ScheduleSlideContext m� Icon��%�   &	        &	        5	   
   6$   �� 5   
   
���   �.@�5      m� -   5        $��Remove Slide��5      
���   � 5      �� 5      $��Images/Remove.png��6   $��16��5      $��16��5      5      5      5      .��5      � -   5         �Name$ 
LayoutRoot��5      $	��103��6   $	��140��6,    � ContextMenu# [ 68    � ToolTip 5   
   �� 5      ._�5      �� .+�5      �� $
��Bold"�6;   ��6    ��  �� Path$
 Name�6;   �� 5      $��5,0,0,0q�6B   ��6    �� $ Description�6B   �� 5       $�� ��6    $
��Bold"�6(   �� 5!      $��Duration��6    $
��Bold"�60   �� 5"       �� Orientation$ 
Horizontal=�6!   .+�5#      �� $��Hours: ��6$   �� 5$      $
��Bold"�6H   ��6$   �� $ Duration.Hour�6H   �� 5%      $��
 Minutes: ��6$   �� 5&      $
��Bold"�6J   ��6$   �� $ Duration.Minute�6J   �� 5'      $��
 Seconds: ��6$   �� 5(      $
��Bold"�6J   ��6$   �� $ Duration.Second�6J   5)      5+      5,      .+�5.   
   �� $��1,1,1,1q�6    �� CornerRadius$ 5,5,5,5��6+   $��0,0,20,0q�6B   ��5/      �� 50       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��51      � 
 � Color$
 	#99000000��6#    � Offset$ 1Q�65   � 52      $
 	#99202020��6#   $ 0.902Q�65   � 53      $
 	#99090909��6#   $ 0.073Q�65   � 54      $
 	#FFB1B0B0��6#   $ 0.496Q�65   � 55      $
 	#FFB1B0B0��6#   $ 0.482Q�65   � 56      $
 	#99626262��6#   $ 0.522Q�65   57      ��59      �� 5:      $ 0.5,1&�6&   $	 0.5,0&�67   .��5;      � $
 	#FFFFFFFF��6#   $ 0Q�65   � 5<      $
 	#FFD9D9D9��6#   $ 0Q�65   � 5=      $
 	#FF000000��6#   $ 0.198Q�65   � 5>      $
 	#FF474747��6#   $
 0.57Q�65   � 5?      $
 	#FF8C8C8C��6#   $ 0.071Q�65   5@      ._�5B      � $	��129��6   $	��100��6    J� RenderTransformOrigin$ 0.5,0.5&�6,    � ColumnDefinitions 5C      �� 5D      $
��124* �6'   �� 5E      $	��10* �6'   z�5G      V� 5H      .~�5I      ��  �� ScaleX$ 1Q�6)    �� ScaleY$ 1Q�64   �� 5J       �� AngleX$ 0Q�6(    �� AngleY$ 0Q�63   �� 5K       �� Angle$ 0Q�6*   T� 5L       T� X$ 0Q�6-    T� Y$ 0Q�63   5M      .+�5O      �� -   5         ��Name$ imgSlideImage��5O   *   $��3,3,5,20q�6    �� BitmapScalingMode$ 
LowQuality=�6�    J� IsHitTestVisible .  $��Center=�6�   ��6A   �� $ 	ThumbNail� �� Mode$ OneWay=� �� NotifyOnTargetUpdated .  J� Effect 5P      3  -System.Windows.Media.Effects.DropShadowEffect  5Q      5S      �� 5T      $��Bottom=�6   $��3q�63   $��55��6>   $
��Left=�6I   .��6e   	Duration:6p   �� 5U      -   5         ��Name$ 
tbDuration��5U      $
��Bold"�6�     
GlyphBrush#��[ 6�   $��12(�6�   $��2q�6�    �� TextAlignment$ Center=�6�   $��Right=�6�   $��Bottom=�6  $��65��6(  $��15��63  ��60   �� *
Duration+ �� 	Converter# [  $ OneWay=�63  5W      5X      �� 5Y   
   -   5         ��Name$ btnTransition��5Y   l   $��Right=�6   $��24��6-     SlideTransitionButtonStyle#��[ 68   $��
0,40,-8,40q�6�   .��5Z      �� $��16��6   $��16��6   $ ��Images/SlideTransition.png��6+   $
��Fill=�6O   5[      5\      5]      