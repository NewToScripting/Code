   M S B A M L   `   `   `  ���� _  [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors  B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire ! Inspire.Client.ScheduleWindowH   BInspire.Client.ScheduleWindow.ScheduledSlidePanel.SlideControlItem   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors     :Inspire&clr-namespace:Inspire;assembly=Inspire     $	��144��$	��108��  � 	Resources    Inspire.DurationConverter   durationConverter  ScheduleSlideContext m� Icon��%�   &	        &	        �� 
���   �.@�m� -   $��Remove Slide��
���   � �� $��Images/Remove.png��$��16��$��16��.��� -    �Name$ 
LayoutRoot��$	��103��$	��140�� � ContextMenu# [  � ToolTip �� ._��� .+��� $
��Bold"�����  �� Path$
 Name��� $��5,0,0,0q����� $ Description��� $�� ��$
��Bold"��� $��Duration��$
��Bold"���  �� Orientation$ 
Horizontal=�.+��� $��Hours: ���� $
��Bold"����� $ Duration.Hour��� $��
 Minutes: ���� $
��Bold"����� $ Duration.Minute��� $��
 Seconds: ���� $
��Bold"����� $ Duration.Second�.+��� $��1,1,1,1q� �� CornerRadius$ 5,5,5,5��$��0,0,20,0q�����  �� EndPoint$ 0.5,1&�	 �� 
StartPoint$	 0.5,0&�.��� 
 � Color$
 	#99000000�� � Offset$ 1Q�� $
 	#99202020��$ 0.902Q�� $
 	#99090909��$ 0.073Q�� $
 	#FFB1B0B0��$ 0.496Q�� $
 	#FFB1B0B0��$ 0.482Q�� $
 	#99626262��$ 0.522Q����� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFFFFFFF��$ 0Q�� $
 	#FFD9D9D9��$ 0Q�� $
 	#FF000000��$ 0.198Q�� $
 	#FF474747��$
 0.57Q�� $
 	#FF8C8C8C��$ 0.071Q�._�� $	��129��$	��100�� J� RenderTransformOrigin$ 0.5,0.5&� � ColumnDefinitions �� $
��124* ��� $	��10* �z�V� .~���  �� ScaleX$ 1Q� �� ScaleY$ 1Q���  �� AngleX$ 0Q� �� AngleY$ 0Q���  �� Angle$ 0Q�T�  T� X$ 0Q� T� Y$ 0Q�.+��� -    ��Name$ imgSlideImage��$��3,3,5,20q� �� BitmapScalingMode$ 
LowQuality=� J� IsHitTestVisible .  $��Center=����� $ 	ThumbNail� �� Mode$ OneWay=� �� NotifyOnTargetUpdated .  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  �� $��Bottom=�$��3q�$��55��$
��Left=�.��	Duration:�� -    ��Name$ 
tbDuration��$
��Bold"�  
GlyphBrush#��[ $��12(�$��2q� �� TextAlignment$ Center=�$��Right=�$��Bottom=�$��65��$��15������ *
Duration+ �� 	Converter# [  $ OneWay=��� -    ��Name$ btnTransition��$��Right=�$��24��  SlideTransitionButtonStyle#��[ $��
0,40,-8,40q�.���� $��16��$��16��$ ��Images/SlideTransition.png��$
��Fill=�