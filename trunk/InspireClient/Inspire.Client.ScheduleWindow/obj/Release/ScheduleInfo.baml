   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  2&clr-namespace:Inspire;assembly=InspireInspire  _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors {Sclr-namespace:DevComponents.WpfEditors.Primitives;assembly=DevComponents.WpfEditors#DevComponents.WpfEditors.Primitives I EInspire.Common, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullgDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.CommonInspire.Common.DragDropListBox X TInspire.Client.ScheduleWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Inspire.Client.ScheduleWindow.Converters(Inspire.Client.ScheduleWindow.Converters 0   *Inspire.Client.ScheduleWindow.ScheduleInfo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     :Inspire&clr-namespace:Inspire;assembly=Inspire     _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors     j
PrimitivesSclr-namespace:DevComponents.WpfEditors.Primitives;assembly=DevComponents.WpfEditors     `DragDropListBoxDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.Common     M
Converters6clr-namespace:Inspire.Client.ScheduleWindow.Converters     $��Stretch=�  � 	Resources     Inspire.DurationConverter   durationConverter$   Inspire.BoolToVisibleConverter  boolToVisibilityConverterG  AInspire.Client.ScheduleWindow.Converters.NoButtonWarningConverter  noButtonWarningConverterH  BInspire.Client.ScheduleWindow.Converters.RulesToMultiTextConverter  rulesToMultiTextConverterC  =Inspire.Client.ScheduleWindow.Converters.RulesToTextConverter  rulesToTextConverter  toolTipTextBoxBinding � DataContext �� Path �� Self �� RelativeSource  ScheduledSlideContext m� Icon ! DateTimeInputControlTemplate1 �� 
TargetType,  &DevComponents.WpfEditors.DateTimeInput  SunkenBackground 	 
ListBorder �� Padding7  1DevComponents.WpfEditors.Primitives.DateTimeGroup  Name:  4DevComponents.WpfEditors.Primitives.EditorInputGroup	   IsEmpty
   IsUserInput5	  /DevComponents.WpfEditors.Primitives.EditorGroup 	  FocusedItem 
 LBStyle �� 
TargetType �� Property �� Value ��Name �� CornerRadius  	Highlight 
 Shadow J� SnapsToDevicePixels �� Triggers P� Property P� Value  TouchLinksStyle �� Triggers �� Binding �� ElementName �� Value  DisplayMenu  HideTouchButton  	MainColor �� Color � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  �� KeyTime! �� Value" p� KeyTime# p� Value$ �Name% J� RenderTransformOrigin& �� ScaleX' �� ScaleY( �� AngleX) �� AngleY* �� Angle+ T� X, T� Y- J� Opacity  
EffectBlur. J� Effect  
BlackColor  ControlColor/ �� EndPoint0 �� 
StartPoint1 � Color2 � Offset3 J� OpacityMask3
  -System.Windows.Media.Effects.DropShadowEffect4 
  Color5 
  Opacity6 
  
BlurRadius7 ��Name8 N� ExitActions9 ��Name  HoverOff: N� EnterActions  HoverOn  
PressedOff  	PressedOn  DisabledForegroundBrush  	HidePanel  SleepHidePanel  
NoMixBrush  NormalModeBrush  RandomizeBrush  IntersperseBrush   ContinuousBrush ! DefaultBrush " 
DailyBrush # WeekDayBrush $ WeeklyBrush % MonWedFriBrush & TuesThursBrush ' MonthlyBrush ( YearlyBrush ) 
SleepBrush * DisplayLabel + WeekCheckBox , CheckBoxFocusVisual - NormalBrush . NormalBorderBrush; R� KeyTime  System.Windows.Visibility<   Hidden= R� Value>   Visible? �� 
Background@ �� BulletA ��Name / 
GlyphBrushB F�NameC �� Stretch 0 ThreeStateOff 1 ThreeStateOnD ]� 
ConditionsE �� PropertyF �� Value 2 	CheckedOn 3 
CheckedOff 4 DisabledBackgroundBrushG �� 
TargetName 5 DisabledBorderBrush 6 TimeControls 7 SlideTemplate 8 
ForegroundH �� 	ConverterI �� Mode 9 SlideDataTemplate : 	TextBrushJ � ToolTip ; SelectedSlideDataTemplateK � ContextMenuL �� TextAlignmentM  NameN   FormatO   CustomFormatP   ShowDropDownQ   AllowEmptyStateR   Value&    Inspire.Commands.InspireCommands!S   ConfigureTransitionCommand"T   ConfigureTouchscreenButtons < SlideTemplateUsingTriggersU ��NameV �� TriggersW �� ModeX �� AncestorType��%h9  &	        &	      &	 
     &	      &	      &	      &	 `     &	 �     7  7 	 &	
 I    7 	 7��7  7  7  &	 �    &	 q    &	 �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 �    &	 �    &	 d    &	 -    &	 �    &	 �    &	  �    &	! R    &	"     &	# �    &	$ �    &	% v    &	& @    &	' 
    &	( �    &	) �    &	* e    &	+       7 , 7 - 7 . 7  7  7  7 / 7 / 7  7  7 0 7 1 7 2 7 3 7  7  7  7  7 4 7 5 &	6 �,    &	7 �-    7 8 7 8 7 8 7   &	9 �/    7 : 7   7  7  &	; #2    7  7 : 7  7  7  7  7  &	< �6    7 9 7 ;           _�  �� $ PlacementTarget�# Z .���� ���� $
 Text��� 
���   �.@�m� -   $��Remove Slide��
���   � �� $+��%ScheduledSlidePanel/Images/Remove.png��$��16��$��16���� "  .R��� 8��  8�� $��1q�$ 1,1,1,1q�._�  $ PART_InputGroup��	 . 
 .   Z� �� " ��.���  � ��8   ��  � ��$ 1q���  � ��8  ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$ Center=���  � �� �� " ��.R�� .+��� $ Bd��8�� $ 4���� $ Hl��8�� $��0,0,0,1q�$ 4���� $ Sh��8�� $��0,1,0,0q�$ 4���� $��0,2,0,0q�|�.  #��z��.���� # z  P�  �@��
IsGrouping . . ���  � �� .  �� " ��.���  � y�$ 	Collapsed=� ��  �� $
 Text�$ cbSchedType�� Touchscreen.a���  � y�$ Visible=��� ���	#FF000000.@�m� -   $��Remove Display�����	#FF000000 �� $!��Resources/Images/Remove.png��$��16��$��16���� " ��.���  � y�$ 	Collapsed=���  � �� �� 8   ��  � ��$ 14(���  � ��$ Center=���  � ��$ Center=���  � �� �� " �� ���� HoverOn .��U� $ 00:00:00X�$ 
HoverLayer��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q�U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.1000000��$ -4Q��� HoverOff .��U� $ 00:00:00X�$ 
HoverLayer��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.3000000��$ -2Q��� 	PressedOn .���� $ 00:00:00X�$ BottomWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $  00:00:00.1000000��$! 	#7FFFFFFF��U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.1000000��$ 2Q�r� $ 00:00:00X�$ Shadow��$ (FrameworkElement.Margin)�.	��� $" 00:00:00.1000000��$# 0,2,0,0q��� $ 00:00:00X�$ TopWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $  00:00:00.1000000��$! 	#19FDFDFD���� 
PressedOff .���� $ 00:00:00X�$ BottomWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $  00:00:00.3000000��$! 	#19FFFFFF��U� $ 00:00:00X�$
 Grid��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $ 00:00:00.3000000��$ -2Q�r� $ 00:00:00X�$ Shadow��$ (FrameworkElement.Margin)�.	��� $" 00:00:00.3000000��$# 0,2,0,-2q��� $ 00:00:00X�$ TopWhite��$N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $  00:00:00.3000000��$! 	#99FDFDFD��.R�� $
$ Grid��$% 0.5,0.5&�$��4,4,4,4q�z�V� .~��� $& 1Q�$' 1Q��� $( 0Q�$) 0Q��� $* 0Q�T� $+ 0Q�$, -2Q�.+��� $ Shadow��$ 4,4,4,4��$	- 0.5Q�$��0,2,0,-2q�8.  ���� 8  �� $ 	BaseLayer��$ 4,4,4,4������ 8  �� $ EdgeCurveLayer��$ 4,4,4,4������ $/ 	0.994,0.5&�$0 0.01,0.5&�.��� $1 	#00000000��$2 0Q�� $1 	#00000000��$2 1Q�� $1 	#19000000��$2 0.203Q�� $1 	#19000000��$
2 0.81Q�� $1 	#33000000��$	2 0.5Q��� $ BottomWhite��$ 4,4,4,4��3 �� $/ 	0.995,0.5&�$0 0.01,0.5&�.��� $1 	#00000000��$2 0Q�� $1 	#00000000��$2 1Q�� $1 	#FF000000��$2 0.548Q����� $/ 	0.5,0.971&�$0 	0.5,0.036&�.��� $1 	#00000000��$2 0Q�� $1 	#19FFFFFF��$2 1Q�� $1 	#0C808080��$
2 0.49Q��� $ TopWhite��$ 4,4,4,4��3 �� $/ 	0.991,0.5&�$0 0.01,0.5&�.��� $1 	#00000000��$2 0Q�� $1 	#00060606��$2 1Q�� $1 	#D8020202��$
2 0.49Q����� $/ 	0.5,0.971&�$0 	0.5,0.029&�.��� $1 	#99FDFDFD��$2 0Q�� $1 	#00FFFFFF��$2 1Q�� $1 	#4CFDFDFD��$2 0.513Q��� $ 
HoverLayer��$ 4,4,4,4��$- 0Q�$��1,1,1,1q���Z� ���� 8  ._��� $ 
HoverInner��$ 3,3,3,3��$��1,1,1,1q����� 8  �� $ DefaultLayer��$��1,1,1,1q�$ 4,4,4,4��$- 0Q�. 
  84  $
5 0.65Q�$6 10Q����� 8  �� $7 contentPresenter��#��z��#��z����. $��4,-2,4,2q�. 
  84  $5 0Q� P�  �@J�IsKeyboardFocused . P�  �@J�IsMouseOver . 8 �� $9 HoverOff_BeginStoryboard��8��	 : �� $9 HoverOn_BeginStoryboard��8��
 P�  � �� . 8 �� $ 9 PressedOff_BeginStoryboard��8�� : �� $9 PressedOn_BeginStoryboard��8�� P�  � {� . P�  � {� .  . ��� 8   � �� ��  �� $
 Text�$ cbSchedType�� Touchscreen.a���  � y�$ Visible=��� " ��.���  � y�$ Visible=� ��  �� $ SelectedIndex�$ cbSchedType�� 8.a���  � y�$ 	Collapsed=��� " ��.���  � y�$ Visible=� ��  �� $ SelectedIndex�$ cbSchedType�� 8.a���  � y�$ 	Collapsed=���  �� $ SelectedIndex�$ cbSchedType�� 9.a���  � y�$ 	Collapsed=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $
4 Blue�� ��  �� $ SelectedIndex�$ cbPlaybackMode�� 1.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $
4 Blue�� ��  �� $ SelectedIndex�$ cbPlaybackMode�� 0.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $
4 Blue�� ��  �� $ SelectedIndex�$ cbPlaybackMode�� 2.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $
4 Blue�� ��  �� $ SelectedIndex�$ cbPlaybackMode�� 3.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 0.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $
4 Blue�� ��  �� $ SelectedIndex�$ cbSchedType�� 8.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 1.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 2.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 5.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 3.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 4.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 6.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 SeaGreen�� ��  �� $ SelectedIndex�$ cbSchedType�� 7.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=���  �@J�Effect 
  $4 Black�� ��  �� $ SelectedIndex�$ cbSchedType�� 9.a���  � y�$ Visible=��� " ��.���  � ��
 �������  � y�$ 	Collapsed=� ��  �� $ Items.Count�$ 
lvDisplays�� 0.a���  � y�$ Visible=��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��$
 Bold"���  � �� �� " �� ���� HoverOn .��U� $ 00:00:00X�$ contentPresenter��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q�U� $ 00:00:00X�$ Hover��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$	 0.8Q��� HoverOff .��U� $ 00:00:00X�$ contentPresenter��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�U� $ 00:00:00X�$ Hover��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� 	PressedOn �� 
PressedOff �� 	CheckedOn .��U� $ 00:00:00X�$
 path��$ (FrameworkElement.Width)�.\��� $ 00:00:00.1000000��$ 11Q�U� $ 00:00:00X�$
 path��$ (FrameworkElement.Height)�.\��� $ 00:00:00.1000000��$ 10Q��� 
CheckedOff .��U� $ 00:00:00X�$
 path��$ (FrameworkElement.Width)�.\��� $ 00:00:00.2000000��$ 0Q�U� $ 00:00:00X�$
 path��$ (FrameworkElement.Height)�.\��� $ 00:00:00.2000000��$ 0Q��� ThreeStateOn .��U� $ 00:00:00X�$ 
ThreeState��$ (FrameworkElement.Width)�.\��� $ 00:00:00.1000000��$ 9Q�U� $ 00:00:00X�$ 
ThreeState��$ (FrameworkElement.Height)�.\��� $ 00:00:00.1000000��$ 9Q�T� $ 00:00:00X�$
 path��$ (UIElement.Visibility)�..�i� $; 00:00:00.1000000��#= Z< �� ThreeStateOff .��U� $ 00:00:00X�$ 
ThreeState��$ (FrameworkElement.Width)�.\��� $ 00:00:00.3000000��$ 0Q�U� $ 00:00:00X�$ 
ThreeState��$ (FrameworkElement.Height)�.\��� $ 00:00:00.3000000��$ 0Q�T� $ 00:00:00X�$
 path��$ (UIElement.Visibility)�..�i� $; 00:00:00.3000000��#= Z> .R��� 
? ���� @ � $��13��$��13��.+��� $ Shadow��$��	0,0,-2,-2q�$
- 0.25Q�8.  ���� 8  �� $ 
MainBorder��$��2,2,2,2q�$ 2,2,2,2�����	#72000000���� 8  ._��� $A 
ThreeState��$y�Visible=�8�� $��1,1,1,1q�$��0��$��0���� $ Shade��$ 2,2,2,2��$	- 0.1Q�$��1,1,1,1q����� $/ 	1.292,0.5&�$0 
-0.545,0.5&�.��� $1 	#FF000000��$2 1Q�� $1 	#FFFFFFFF��$2 0.006Q�F� $
B path��$
C Fill=�8�� $��2��$��11��1�����9��z�?��Q ��P�m	@�� Q�� GER��(@	$��1.577,0.134,-0.013,2.866q�$��10���� $ Hover��$- 0Q�$��2,2,2,2q�$ 2,2,2,2������ 8  ._��� $7 contentPresenter����. $��5,0,0,0q�. 
  84 	 $5 0Q� ]� 8 �� $#9 ThreeStateOff_BeginStoryboard��8��
 : �� $"9 ThreeStateOn_BeginStoryboard��8�� D �� E �@d�IsThreeStateF . �� E �@d�	IsChecked$
F TrueY�P�  �@d�	IsChecked$ falseY�8 �� $9 CheckedOn_BeginStoryboard��8�� : �� $ 9 CheckedOff_BeginStoryboard��8�� P�  �@J�IsMouseOver . 8 �� $9 HoverOff_BeginStoryboard��8�� : �� 8�� P�  � �� . 8 �� $ 9 PressedOff_BeginStoryboard��8�� : �� $9 PressedOn_BeginStoryboard��8�� P�  � {� .  . ��� 8  $G 
MainBorder�� � ���� 8  $G 
MainBorder�� � ����  � �� �� $ White����  � y�$ 	Collapsed=� ��  �� $ SelectedIndex�$ cbSchedType�� 5.a���  � y�$ Visible=��� "  .���  � y�$ Visible=� ��  �� $ 	IsChecked�$ cbAllDay�� True.a���  � y�$ 	Collapsed=���  �� $ 	IsChecked�$ cbAllDay��	 False.a���  � y�$ Visible=��� .R��� $	��500��
�������$��1q�$��Stretch=����� $ lbSlideInfoSlides��$ ActualWidth�._�� .+�� $
��Left=�$��5q�$��45��$��35��.+��� $��Center=����� *	ThumbNail+�� 8��  $��14(�$��75,0,0,0q����� *Name+�� 8�� $
��Left=�$	��345��$��25��$
��Wrap=�$��CharacterEllipsis=�$��
80,20,0,10q����� *Description+�� 8�� $��20(�$��0,0,20,0q�$��Right=�$��Center=����� *
Duration+8H  $I OneWay=��� .R��� -   
�������$��1q�$��Stretch=����	#01000000._�� .+�� $
��Left=�$��5q�$��45��$��35��.+��� $��Center=����� *	ThumbNail+�� $��14(�$
��Bold"�$��75,0,0,0q����� *Name+�� $��13(�8��  $
��Left=�$	��345��$��25��$
��Wrap=�$��CharacterEllipsis=�$��
80,20,0,10q����� *Description+�� $��20(�$��0,0,24,0q�$��Right=�$��Center=����� *
Duration+8H  $I OneWay=��� 8�� $��20��$��20��$��Right=�$��Center=�$��0,0,2,0q�._��� $"��Resources/Images/warning.png��$1J +Slide contains buttons that are not linked.��y��� *	Buttons+8H  �� .R��� -   
�������$��1q�$��Stretch=�8K   ���	#01000000._�� .+��� $
��Left=�$��5q�$	��127��$	��120������ *	ThumbNail+�� $	��280��$��CharacterEllipsis=�$
L Left=�$��16(�$
��Bold"�$��	140,0,0,0q�$
��Left=����� *Name+�� $��13(�8�� $
��Left=�$	��290��$��55��$
��Wrap=�$��CharacterEllipsis=�$��140,20,0,30q����� *Description+�� $��Bottom=�$
��Left=�$��	140,0,0,3q����� *Rules+$I OneWay=�8H  J �� *Rules+$I OneWay=�8H    $M dtiDuration��
���   �$��24(�$��	0,10,10,0q�$��Right=�$J Duration��$	��Top=�$N Custom=�$O HH:mm:ss��P .  Q .  R �� *
Duration+�� $��
Transition��$��90��$��30��$��Right=�$��Bottom=�$��0,0,8,44q�#��ZS J �� *
Transition+�� 8�� $��Buttons��$$J Configure touchscreen buttons.��$��90��$��30��$��Right=�$��Bottom=�$��8q�#��ZT {��� *HasTouchElements+�� 8�� $��20��$��20��$��Right=�$��Bottom=�$��	0,0,98,14q�._��� $"��Resources/Images/warning.png��$1J +Slide contains buttons that are not linked.��y��� *	Buttons+8H  �� .R��� $U 
theControl��|�.  8��  V �� $
 True�� ��  �� $W FindAncestor=�"X ��$ 
IsSelected�.a��� $G 
theControl��8   � ��.��]� .+��� $	��285��$	��Top=�$��Disabled=�$
��Auto=�.��� .+�   Inspire.InfoTextBox  -   Y  Name$Y txtSchedName��
�������Z   TextBoxInfo$$Z Enter the Name of the Schedule��$��Center=�$��25��$��108,15,157,0q�$	��Top=��� -   $��lblSchedName��$��25��$
��Left=�$��9,19,0,0q�
�������$
��Bold"�$	��Top=�$	��104��.��Schedule Name:�� -   $��lblSchedType��$��25��$
��Left=�$��	15,54,0,0q�
�������$
��Bold"�$��Center=�$	��Top=�$	��109��.��Schedule Type:�� #��[ [ �� Orientation$[ 
Horizontal=�$��25��$��	14,86,0,0q�$	��Top=�$
��Left=�$	��554��.+��� -   $��lblWhen��$��1��
�������$
��Bold"�$��5,0,5,0q�$��Center=�.��When:  -	   $M dpStart��#��[ $��1��$��1��$N Short=�
�������$��0,0,5,0q�$��25��$	��110��  -
   $M tpStart��#��[ #��[6 $��2��$��1��$N 	ShortTime=�P .  $��25��$	��Top=�$
��Left=�$��80���� -   $��lblto��$��3��$��1��
�������$
��Bold"�$��5,0,5,0q�$��Center=�.��to  -   $M tpEnd��#��[ #��[6 $��4��$��1��$N 	ShortTime=�P .  $��0,0,5,0q�$��25��$��80��  -   $M dpEnd��#��[ $��5��$��1��
�������$��0,0,5,0q�$��25��$	��110���� -   \ ��Name$\ cbAllDay��$��6��$��1��$��25��$J Play All Day��$��Center=�
�������$��91��.��	All Day�� -   ] ��Name$] 
lvDisplays��#��[
 $��
6,161,6,40q�^ J� 	AllowDrop^ . $��84��$	��Top=����� .R��� $[ 
Horizontal=�#K [ .+��� $��24��$��24��$	��3,0q�$3��-ScheduleTreeView\Resources\Images\Display.ico���� ���� *DisplayName+���� .R�� $	��140��_ � Orientation$_ Vertical=�` K� IsItemsHost` . �� -   $��lblDragDisplays��$��29��$��149,191,158,0q�$��Center=�$	��Top=�#��[* a J� IsHitTestVisiblea .  $��Italic$�$- .8Q�
�������$	��283��.��20Drag Displays Here To Create A Schedule For Them�� -   $��lblDisplays��$
��Left=�$��
10,142,0,0q�
�������$
��Bold"�$��67��$��23��$	��Top=�.��	Displays:�� -   $��btnSave��$��31��$��	0,0,146,3q�   Inspire.ButtonImageb   Image$b Resources/Images/Ok16.png��$��Bottom=�$	��128��c   SaveScheduleCommand#��Zc $��Right=�.��Save�� -   $��	btnUpdate��$��31��$��	0,0,146,3q�$b Resources/Images/Ok16.png��$��Bottom=�$	��128��d   UpdateScheduleCommand#��Zd $y�	Collapsed=�$��Right=�.��Update�� -   $��	btnCancel��$��31��$��Right=�$��0,0,10,3q�$#b Resources/Images/Cancel16.png��$��Bottom=�$	��128��e   CancelScheduleCommand#��Ze .��Cancel�� -   $��cbSchedType��$VJ PHover the mouse over the item in the list to see a description of schedule type.��f �� SelectedIndex$f 0��$��
109,50,0,0q�$��30��$	��Top=�$
��Left=�$	��202��.@��� $rJ lContinuous schedules play non-stop from the start time on the start date until the end time on the end date.��.��
Continuous�� $ZJ TThe Default presentation will play on the display when no other schedule is playing.��.��Daily�� $qJ kEvery weekday will play the schedule every day of the week from the start time each day until the end time.��.��Every weekday (Mon-Fri)�� $�J �Mon, Wed, Frid, will play the schedule on Monday, Wednesday and Friday from the choosen start date to the end date from the start time each day until the end time.��.��Every Mon., Wed., and Fri.�� $�J �Tues. Thurs. will play the schedule on Tues. and Thurs. from the choosen start date to the end date from the start time each day until the end time.��.��Every Tues., and Thurs.�� $�J �Weekly will play the schedule every day choosen every week from the start date to the end date from the start time each day until the end time.��.��Weekly�� $qJ kMonthly will play the schedule every month on the date choosen from the start time each until the end time.��.��	Monthly�� $kJ eYearly will play the schedule once a year on the date choosen from the start time until the end time.��.��Yearly�� $ZJ TThe Default presentation will play on the display when no other schedule is playing.��.��	Default�� $sJ mTouchscreen schedules play non-stop from the start time on the start date until the end time on the end date.��.��Touchscreen�� $[ 
Horizontal=�$��20��$��	6,116,0,0q�$	��578��$	��Top=�$
��Left=�.+��� -   $��	ckbSunday��$��18��#��[+ $
��Left=�$��2q�$	��Top=�$��65��.��Sunday�� -   $��	ckbMonday��$��18��#��[+ $
��Left=�$��2q�$	��Top=�$��68��.��Monday�� -   $��
ckbTuesday��#��[+ $
��Left=�$��2q�$��68��$��18��$	��Top=�.��	Tuesday�� -   $��ckbWednesday��#��[+ $��2q�$��18��$	��Top=�$
��Left=�$��85.333��.��	Wednesday�� -   $��ckbThursday��#��[+ $��2q�$��18��$	��Top=�$
��Left=�$��75��.��
Thursday�� -   $��	ckbFriday��#��[+ $��2q�$��18��$	��Top=�$
��Left=�$��61.333��.��Friday�� -   $��ckbSaturday��#��[+ $��2q�$��18��$	��Top=�.��
Saturday�� -   g ��Name$g tbPlaybackDesc��#J [ $
L Left=�$
��Left=�$��5,247,279,0q�$��12(�$
��Wrap=�$��Center=�#��� - $��Test Description��$	��306��$��38���� -   $��lblPlaybackMode��$��
321,55,0,0q�$
��Left=�
�������$
��Bold"�$��96��$��25��$	��Top=�.��Playback Mode:�� -   $��cbPlaybackMode��$\J VHover over the items in the list to see a description of the different playback modes.��$f 0��$
��Left=�$��166.29��$��30��$	��Top=�$��
418,48,0,0q�.@��� ${J uNormal will play the slides in the order they are layed out. Interspersed or randomized slides will mix in with them.��.��Normal�� $�J �Do not mix will keep the group of slides together on playback. Interspersed and Randomized slides will not mix with these slides.��.��
Do not mix�� $pJ jRandomize Mode will randomly shuffle slides together with other schedules other than Do not Mix Schedules.��.��	Randomize�� $oJ iIntersperse slides will distribute evenly on every other slide in other schedules that are set to Normal.��.��Intersperse�� -    $��cbIsTouchScreenSched��$y�	Collapsed=�$��Touchscreen Schedule��$��18��$
��Bold"�
�������$��	0,142,6,0q�$	��162��$	��Top=�$��Right=�� -!   ^ . .+��� -"   $] lbSlideInfoSlides�� = 	DarkBrush#��� = ^ . $��Stretch=�$��Stretch=�$��Stretch=�#��[< 3  -Inspire.Common.DragDropListBox.DragDropHelperh   DragDropTemplate#h [7 i   IsDragSourcei . j   IsDropTargetj . ��Z� �� -#   $A DropGrabber��
���   �$	- .05Q�a . $y�	Collapsed=�