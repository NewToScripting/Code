   M S B A M L   `   `   `  ���� U  QInfragistics.ToyBox, Version=1.0.2570.22297, Culture=neutral, PublicKeyToken=nullV>clr-namespace:Infragistics.ToyBox;assembly=Infragistics.ToyBoxInfragistics.ToyBox  B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands X TInspire.Client.ScheduleWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Inspire.Client.ScheduleWindow.Converters(Inspire.Client.ScheduleWindow.Converters 8   2Inspire.Client.ScheduleWindow.TouchScreenScheduler   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     QToyBox>clr-namespace:Infragistics.ToyBox;assembly=Infragistics.ToyBox     :Inspire&clr-namespace:Inspire;assembly=Inspire     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     M
Converters6clr-namespace:Inspire.Client.ScheduleWindow.Converters        	DarkBrush#���     � 	Resources    Inspire.DurationConverter  durationConverter+  %Inspire.ReverseBoolToVisibleConverter   revBoolToVisibilityConverter$  Inspire.BoolToVisibleConverter  boolToVisibilityConverterJ  DInspire.Client.ScheduleWindow.Converters.NullEmptyToVisibleConverter  nullEmptyToVisibleConverter  SlideDataTemplate �� 	Converter  	TextBrush �� Mode  SelectedSlideDataTemplate �� TextAlignment � ToolTip  HideTouchButton �� 
TargetType �� Property �� Value 	 	MainColor �� Color	 �� 
TargetType
 � 	Resources 
 Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� KeyTime �� Value p� KeyTime p� Value �Name J� RenderTransformOrigin �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y ��Name �� CornerRadius J� Opacity  
EffectBlur  J� Effect  
BlackColor  ControlColor! �� EndPoint" �� 
StartPoint# � Color$ � Offset% J� OpacityMask3  -System.Windows.Media.Effects.DropShadowEffect&   Color'   Opacity(   
BlurRadius) ��Name* �� Triggers+ P� Property, P� Value- N� ExitActions. ��Name  HoverOff/ N� EnterActions  HoverOn  
PressedOff  	PressedOn  DisabledForegroundBrush  TouchScreenButtonTemplate0 �� Orientation1 ��Name��%�  &	       &	      &	 
     &	      &	      7  7  &	 Z    7  7  &	 X    7 	 7  7  7  7 	 7 	 7 	 7 	 7 	 7  7  7  7  7  &	 �    7  7 	 7 	 7          �� .R��� 
�������$��1q�$��Stretch=�._�� $��0,8,0,0q�.+�� $
��Left=�$��5q�$��45��$��35��.+��� $��0,5,0,0q�$��Center=����� *	ThumbNail+�� $��0,5,0,0q�$��Center=�$ ��Resources/Images/Alert.png��y��� *SlideToGuid+8   �� $
��Bold"�$��14(�$��65,0,0,0q����� *
ButtonName+�� 8�� $
��Left=�$	��345��$��25��$
��Wrap=�$��CharacterEllipsis=�$��
70,20,0,50q����� *	SlideName+�� $��20(�$��5q�$��Right=�$	��Top=����� *
Duration+$ OneWay=��� $
��Link��$��20(�$��5q�$��Right=�$��Bottom=��� .R��� 
�������$��1q�$��Stretch=�._�� $��0,8,0,0q�.+�� $
��Left=�$��5q�$��45��$��35��.+��� $��Center=����� *	ThumbNail+�� $	��280��$��CharacterEllipsis=�$
 Left=�$
��Bold"�$��16(�$��	140,0,0,0q�$
��Left=����� *
ButtonName+�� 8��  $��13(�$
��Left=�$	��300��$��55��$
��Wrap=�$��CharacterEllipsis=�$��140,20,0,30q����� *	SlideName+�� $ Duration��$	��Top=�$��24(�$��	0,10,10,0q�$��Right=����� *
Duration+8  $ OneWay=��� " ��.���  � �� �� 8   ��  � ��$ 14(���  � ��$ Center=���  � ��$ Center=���  � �� �� "	 ��
 ���� HoverOn
 .��U� $ 00:00:00X�$ 
HoverLayer��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q�U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.1000000��$ -4Q��� HoverOff
 .��U� $ 00:00:00X�$ 
HoverLayer��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.3000000��$ -2Q��� 	PressedOn
 .���� $ 00:00:00X�$ BottomWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $ 00:00:00.1000000��$ 	#7FFFFFFF��U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.1000000��$ 2Q�r� $ 00:00:00X�$ Shadow��$ (FrameworkElement.Margin)�.	��� $ 00:00:00.1000000��$ 0,2,0,0q��� $ 00:00:00X�$ TopWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $ 00:00:00.1000000��$ 	#19FDFDFD���� 
PressedOff
 .���� $ 00:00:00X�$ BottomWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $ 00:00:00.3000000��$ 	#19FFFFFF��U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.3000000��$ -2Q�r� $ 00:00:00X�$ Shadow��$ (FrameworkElement.Margin)�.	��� $ 00:00:00.3000000��$ 0,2,0,-2q��� $ 00:00:00X�$ TopWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $ 00:00:00.3000000��$ 	#99FDFDFD��.R�� $
 Grid��$ 0.5,0.5&�$��4,4,4,4q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ 0Q�$ -2Q�.+��� $ Shadow��$ 4,4,4,4��$	 0.5Q�$��0,2,0,-2q�8   ���� 8  �� $ 	BaseLayer��$ 4,4,4,4������ 8  �� $ EdgeCurveLayer��$ 4,4,4,4������ $! 	0.994,0.5&�$" 0.01,0.5&�.��� $# 	#00000000��$$ 0Q�� $# 	#00000000��$$ 1Q�� $# 	#19000000��$$ 0.203Q�� $# 	#19000000��$
$ 0.81Q�� $# 	#33000000��$	$ 0.5Q��� $ BottomWhite��$ 4,4,4,4��% �� $! 	0.995,0.5&�$" 0.01,0.5&�.��� $# 	#00000000��$$ 0Q�� $# 	#00000000��$$ 1Q�� $# 	#FF000000��$$ 0.548Q����� $! 	0.5,0.971&�$" 	0.5,0.036&�.��� $# 	#00000000��$$ 0Q�� $# 	#19FFFFFF��$$ 1Q�� $# 	#0C808080��$
$ 0.49Q��� $ TopWhite��$ 4,4,4,4��% �� $! 	0.991,0.5&�$" 0.01,0.5&�.��� $# 	#00000000��$$ 0Q�� $# 	#00060606��$$ 1Q�� $# 	#D8020202��$
$ 0.49Q����� $! 	0.5,0.971&�$" 	0.5,0.029&�.��� $# 	#99FDFDFD��$$ 0Q�� $# 	#00FFFFFF��$$ 1Q�� $# 	#4CFDFDFD��$$ 0.513Q��� $ 
HoverLayer��$ 4,4,4,4��$ 0Q�$��1,1,1,1q���Z� ���� 8  ._��� $ 
HoverInner��$ 3,3,3,3��$��1,1,1,1q����� 8  �� $ DefaultLayer��$��1,1,1,1q�$ 4,4,4,4��$ 0Q�    8&  $
' 0.65Q�$( 10Q����� 8  �� $) contentPresenter��#��z��#��z����. $��4,-2,4,2q�    8&  $' 0Q�* P� + �@J�IsKeyboardFocused, . P� + �@J�IsMouseOver, . - �� $. HoverOff_BeginStoryboard��8��	 / �� $. HoverOn_BeginStoryboard��8��
 P� + � ��, . - �� $ . PressedOff_BeginStoryboard��8�� / �� $. PressedOn_BeginStoryboard��8�� P� + � {�, . P� + � {�, .  . ��� 8   � ���� .R��� 
�������$��1q�$��Stretch=����	#01000000._�� .+��� $
��Left=�$��5q�$	��115��$	��100������ *	ThumbNail+�� $��5q�$��80��$��80��$ Button not Linked.��$
��Left=�$ ��Resources/Images/Alert.png��y��� *SlideToGuid+8   �� $0 
Horizontal=�$��	135,5,5,5q�$
��Left=�.+��� $��Button Name: ��$
 Left=�$��15(����� 8  �� $
��Bold"�$��CharacterEllipsis=�$
 Left=�$��15(����� *
ButtonName+�� $0 
Horizontal=�$��140,30,0,30q�$
��Left=�.+��� $��15(�$��Navigates to: ������ 8  �� $
��Bold"�$��15(�$��55��$
��Wrap=�$��CharacterEllipsis=����� *	SlideName+�� $1 dtiDuration��$��20(�$��	0,10,10,0q�$��Right=�$ Duration��$	��Top=����� *
Duration+$ OneWay=��� -   $
��Link��8�� $��20(�$	��100��$��Right=�$��Bottom=�.��]� .+�� $	��Top=�.+�� $
��Left=�$��24,5,0,0q�$��Bottom=�$	��190��.+��� -   2 ��Name$2 imgTouchscreenSlide��$��0��$��0,0,0,61q�$	��120��$	��187��$��Center=�$��Bottom=����� *	ThumbNail+#   Infragistics.ToyBox.Reflector  $��1��$��0,0,0,0q�$	��187��$��60��$��Bottom=�$��Center=�3   ReflectionTarget3 �� 4 �� ElementName$4 imgTouchscreenSlide���� $
 Left=�$��16(�$
��Bold"�  
Foreground#���  $��CharacterEllipsis=�$��231,12,28,0q�$��55��$	��Top=����� *Name+,� $��
231,36,0,0q�$	��124��$	��Top=�y��� 5 �� Path$5 HasTouchElements�# [ .��/� .T�J� 
�������$��18(�.*�.*��� $�There are (�� �� ��� $5 Buttons.Count�$ OneTime=� �� $��{) button(s) located on this slide. Click the Link button(s) below to choose the slides that the buttons should navigate to.���� $ Right=�$0��*There were no buttons found on this slide.��$��17(�$
��Bold"�#���  $��Right=�$	��Top=�$��	0,50,0,10q�y��� $5 HasTouchElements�# [ �� $��Buttons��$��16(�$
��Bold"�#���  $��CharacterEllipsis=�$��16,0,0,0q�$��25��$��Bottom=�$
��Left=��� -   $��btnSave��$��31��$��	0,0,146,3q�  Inspire.ButtonImage6   Image$6 Resources/Images/Ok16.png��$��Bottom=�$	��128��$��Right=�$
��Save��&   Inspire.Commands.InspireCommands$7   SaveTouchscreenButtonsCommand#��Z7 �� -   $��	btnCancel��$��31��$��Right=�$��0,0,10,3q�$#6 Resources/Images/Cancel16.png��$��Bottom=�$	��128��$��Cancel��&8   CancelTouchscreenButtonsCommand#��Z8 �� -   9 ��Name$9 lbTouchscreenSlides��$��Bottom=�#���   $��Stretch=�$��Stretch=�$��Stretch=�#��[ ��Z� 