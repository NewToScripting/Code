   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  ! Inspire.Client.ScheduleWindow;   5Inspire.Client.ScheduleWindow.TouchscreenSlideChooser   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire       � Title$  Touchscreen Slide Chooser��$	��500��$	��700�� � WindowStartupLocation$ CenterScreen=�   	DarkBrush#���    � 	Resources    Inspire.DurationConverter  durationConverter  TouchscreenSlideTemplate �� TextAlignment ��Name � ToolTip �� Mode  HideTouchButton �� 
TargetType �� Property	 �� Value  	MainColor
 �� Color �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� KeyTime �� Value p� KeyTime p� Value �Name J� RenderTransformOrigin �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y ��Name  �� CornerRadius! J� Opacity  
EffectBlur" J� Effect  
BlackColor  ControlColor# �� EndPoint$ �� 
StartPoint% � Color& � Offset' J� OpacityMask3  -System.Windows.Media.Effects.DropShadowEffect(   Color)   Opacity*   
BlurRadius+ ��Name, �� Triggers- P� Property. P� Value/ N� ExitActions0 ��Name 	 HoverOff1 N� EnterActions 
 HoverOn  
PressedOff  	PressedOn  DisabledForegroundBrush��%�  &	       &	      &	 �    7  7  7  7  7  7  7  7  7  7 	 7 
 7  7  7    �� .R��� -   
�������$��1q�$��Stretch=����	#01000000._�� .+��� $
��Left=�$��5q�$	��115��$	��100������ *	ThumbNail+�� $	��280��$��CharacterEllipsis=�$
 Left=�$��16(�$��	140,0,0,0q�$
��Left=����� *Name+�� $
��Left=�$	��290��$��55��$
��Wrap=�$��CharacterEllipsis=�$��140,20,0,30q����� *Description+�� $ dtiDuration��$��20(�$��	0,10,10,0q�$��Right=�$ Duration��$	��Top=����� *
Duration+$ OneWay=��� " ��.���  � ��	 �� 8
   ��  � ��$	 14(���  � ��$	 Center=���  � ��$	 Center=���  � ��	 �� " �� ���� HoverOn .��U� $ 00:00:00X�$ 
HoverLayer��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q�U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.1000000��$ -4Q��� HoverOff .��U� $ 00:00:00X�$ 
HoverLayer��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.3000000��$ -2Q��� 	PressedOn .���� $ 00:00:00X�$ BottomWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $ 00:00:00.1000000��$ 	#7FFFFFFF��U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.1000000��$ 2Q�r� $ 00:00:00X�$ Shadow��$ (FrameworkElement.Margin)�.	��� $ 00:00:00.1000000��$ 0,2,0,0q��� $ 00:00:00X�$ TopWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $ 00:00:00.1000000��$ 	#19FDFDFD���� 
PressedOff .���� $ 00:00:00X�$ BottomWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $ 00:00:00.3000000��$ 	#19FFFFFF��U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.3000000��$ -2Q�r� $ 00:00:00X�$ Shadow��$ (FrameworkElement.Margin)�.	��� $ 00:00:00.3000000��$ 0,2,0,-2q��� $ 00:00:00X�$ TopWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $ 00:00:00.3000000��$ 	#99FDFDFD��.R�� $
 Grid��$ 0.5,0.5&�$��4,4,4,4q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ 0Q�$ -2Q�.+��� $ Shadow��$  4,4,4,4��$	! 0.5Q�$��0,2,0,-2q�8"  ���� 8
  �� $ 	BaseLayer��$  4,4,4,4������ 8
  �� $ EdgeCurveLayer��$  4,4,4,4������ $# 	0.994,0.5&�$$ 0.01,0.5&�.��� $% 	#00000000��$& 0Q�� $% 	#00000000��$& 1Q�� $% 	#19000000��$& 0.203Q�� $% 	#19000000��$
& 0.81Q�� $% 	#33000000��$	& 0.5Q��� $ BottomWhite��$  4,4,4,4��' �� $# 	0.995,0.5&�$$ 0.01,0.5&�.��� $% 	#00000000��$& 0Q�� $% 	#00000000��$& 1Q�� $% 	#FF000000��$& 0.548Q����� $# 	0.5,0.971&�$$ 	0.5,0.036&�.��� $% 	#00000000��$& 0Q�� $% 	#19FFFFFF��$& 1Q�� $% 	#0C808080��$
& 0.49Q��� $ TopWhite��$  4,4,4,4��' �� $# 	0.991,0.5&�$$ 0.01,0.5&�.��� $% 	#00000000��$& 0Q�� $% 	#00060606��$& 1Q�� $% 	#D8020202��$
& 0.49Q����� $# 	0.5,0.971&�$$ 	0.5,0.029&�.��� $% 	#99FDFDFD��$& 0Q�� $% 	#00FFFFFF��$& 1Q�� $% 	#4CFDFDFD��$& 0.513Q��� $ 
HoverLayer��$  4,4,4,4��$! 0Q�$��1,1,1,1q���Z� ���� 8
  ._��� $ 
HoverInner��$  3,3,3,3��$��1,1,1,1q����� 8
  �� $ DefaultLayer��$��1,1,1,1q�$  4,4,4,4��$! 0Q�"   8(  $
) 0.65Q�$* 10Q����� 8
  �� $+ contentPresenter��#��z��#��z����. $��4,-2,4,2q�"   8(  $) 0Q�, P� - �@J�IsKeyboardFocused. . P� - �@J�IsMouseOver. . / �� $0 HoverOff_BeginStoryboard��8��	 1 �� $0 HoverOn_BeginStoryboard��8��
 P� - � ��. . / �� $ 0 PressedOff_BeginStoryboard��8�� 1 �� $0 PressedOn_BeginStoryboard��8�� P� - � {�. . P� - � {�. .  . ��� 8	   � ��.��� .+��� -   #��[ $��Clear Link ��$	��100��$��10,10,10,10q�$	��Top=�$��Right=��� $
 Left=�$��28(�$
��Bold"�  
Foreground#���  $��CharacterEllipsis=�$��32,12,177,0q�$��55��$	��Top=����� *
ButtonName+�� $
 Left=�$:��4(Choose the slide that the button will navigate to.)��$��16(�#���  $��CharacterEllipsis=�$��293,67,12,0q�$��22��$	��Top=��� -   2 ��Name$2 lbTouchscreenSlides��$��Bottom=�#���   $��Stretch=�$��Stretch=�$��Stretch=�#��[ $��0,91,0,0q���Z� 