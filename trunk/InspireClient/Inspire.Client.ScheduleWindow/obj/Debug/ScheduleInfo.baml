   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  5      2&clr-namespace:Inspire;assembly=InspireInspire  5      _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors 5      {Sclr-namespace:DevComponents.WpfEditors.Primitives;assembly=DevComponents.WpfEditors#DevComponents.WpfEditors.Primitives 5      I EInspire.Common, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullgDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.CommonInspire.Common.DragDropListBox 6l   X TInspire.Client.ScheduleWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Inspire.Client.ScheduleWindow.Converters(Inspire.Client.ScheduleWindow.Converters 6�   0   *Inspire.Client.ScheduleWindow.ScheduleInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors     5      j
PrimitivesSclr-namespace:DevComponents.WpfEditors.Primitives;assembly=DevComponents.WpfEditors     5      `DragDropListBoxDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.Common     6l   M
Converters6clr-namespace:Inspire.Client.ScheduleWindow.Converters     6�   $��Stretch=�6    � 	Resources  5	         Inspire.DurationConverter   durationConverter$   Inspire.BoolToVisibleConverter  boolToVisibilityConverterG  AInspire.Client.ScheduleWindow.Converters.NoButtonWarningConverter  noButtonWarningConverterH  BInspire.Client.ScheduleWindow.Converters.RulesToMultiTextConverter  rulesToMultiTextConverterC  =Inspire.Client.ScheduleWindow.Converters.RulesToTextConverter  rulesToTextConverter  toolTipTextBoxBinding � DataContext �� Path �� Self �� RelativeSource  ScheduledSlideContext m� Icon ! DateTimeInputControlTemplate1 �� 
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
ForegroundH �� 	ConverterI �� Mode 9 SlideDataTemplate : 	TextBrushJ � ToolTip ; SelectedSlideDataTemplateK � ContextMenuL �� TextAlignmentM  NameN   FormatO   CustomFormatP   ShowDropDownQ   AllowEmptyStateR   Value&    Inspire.Commands.InspireCommands!S   ConfigureTransitionCommand"T   ConfigureTouchscreenButtons < SlideTemplateUsingTriggersU ��NameV �� TriggersW �� ModeX �� AncestorType��%w[  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 �     &	 �    7  7 	 &	
 ]    7 	 7��7  7  7  &	 Q    &	 5    &	     7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 �    &	 �    &	 /!    &	 �"    &	 �#    &	 F%    &	  �&    &	! (    &	" [)    &	# �*    &	$ ,    &	% u-    &	& �.    &	' 10    &	( �1    &	) �2    &	* H4    &	+ N5    7 , 7 - 7 . 7  7  7  7 / 7 / 7  7  7 0 7 1 7 2 7 3 7  7  7  7  7 4 7 5 &	6 �I    &	7 \K    7 8 7 8 7 8 7   &	9 ,N    7 : 7   7  7  &	; �Q    7  7 : 7  7  7  7  7  &	< 5X    7 9 7 ;   5   
   6$     5   
   6)     5   
   6.     5   
   6/     5   
   6*   _� 5   
    5   
   �� $ PlacementTarget�# Z .��5      �� ��6   �� $
 Text�5      �� 5   
   
���   �.@�5      m� -   5        $��Remove Slide��5      
���   � 5      �� 5      $+��%ScheduledSlidePanel/Images/Remove.png��6   $��16��5      $��16��5      5      5      �� 5!      "  6D   .R�5"      �� 8��  8�� $��1q�6n   $ 1,1,1,1q�6�   ._�5#        $ PART_InputGroup��6+   	 . 
 .   6g   Z� 5$      5%      �� 5'   
   " ��6    .�5)      ��  � ��8   6,   �� 5*       � ��$ 1q�60   �� 5+       � ��8  6+   �� 5,       � ��$
 Auto=�6K   �� 5-       � ��$
 Auto=�6I   �� 5.       � �� . 6>   �� 5/       � ��$ Center=�69   �� 50       � �� 51      �� 52      " ��6&   .R�53      � .+�54      �� $ Bd��6!   8�� $ 4��6\   �� 55      $ Hl��6%   8�� $��0,0,0,1q�6Z   $ 4��6t   �� 56      $ Sh��6%   8�� $��0,1,0,0q�6W   $ 4��6q   �� 57      $��0,2,0,0q�6+   |�.  #��z��6N   .��58   "   �� # z 61   59      5:       5;      P� 5<       �@��
IsGrouping . . �5=   "   ��  � �� .  6R   5>      5@      5B      5C      �� 5E   
   " ��6(   .�5F      ��  � y�$ 	Collapsed=�6+   6?    5G      �� 5H       6   �� $
 Text�$ cbSchedType�� Touchscreen6U   .a�5I      ��  � y�$ Visible=�6=   5J      5L      �� 5N   
   ���	#FF000000.@�5O      m� -   5        $��Remove Display��5O      ���	#FF000000 5P      �� 5Q      $!��Resources/Images/Remove.png��6   $��16��5R      $��16��5S      5U      5V      �� 5X   
   " ��6(   .�5Y      ��  � y�$ 	Collapsed=�6+   6?   �� 5Z       � �� 5[      �� 5\      8   6&   5^      �� 5_       � ��$ 14(�6)   �� 5a       � ��$ Center=�64   �� 5c       � ��$ Center=�62   �� 5e       � �� 5f      �� 5g      " ��6&    5h      ���� 5i      HoverOn .��5j   "   U� $ 00:00:00X�6@   $ 
HoverLayer��6U   $ (UIElement.Opacity)�6x   .\�5k   &   �� $ 00:00:00.1000000��6;   $ 1Q�6V   5l   #   U� 5m   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5n   &   �� $ 00:00:00.1000000��6;   $ -4Q�6V   5o   #   5p      �� 5q      HoverOff .��5r   "   U� $ 00:00:00X�6@   $ 
HoverLayer��6U   $ (UIElement.Opacity)�6x   .\�5s   &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5t   #   U� 5u   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5v   &   �� $ 00:00:00.3000000��6;   $ -2Q�6V   5w   #   5x      �� 5y      	PressedOn .��5z   "   �� $ 00:00:00X�6?   $ BottomWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6x   .g�5{   &   �� $  00:00:00.1000000��6:   $! 	#7FFFFFFF��6U   5|   #   U� 5}   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5~   &   �� $ 00:00:00.1000000��6;   $ 2Q�6V   5   #   r� 5�   "   $ 00:00:00X�6C   $ Shadow��6X   $ (FrameworkElement.Margin)�6w   .	�5�   &   �� $" 00:00:00.1000000��6>   $# 0,2,0,0q�6Y   5�   #   �� 5�   "   $ 00:00:00X�6?   $ TopWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6u   .g�5�   &   �� $  00:00:00.1000000��6:   $! 	#19FDFDFD��6U   5�   #   5�      �� 5�      
PressedOff .��5�   "   �� $ 00:00:00X�6?   $ BottomWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6x   .g�5�   &   �� $  00:00:00.3000000��6:   $! 	#19FFFFFF��6U   5�   #   U� 5�   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5�   &   �� $ 00:00:00.3000000��6;   $ -2Q�6V   5�   #   r� 5�   "   $ 00:00:00X�6C   $ Shadow��6X   $ (FrameworkElement.Margin)�6w   .	�5�   &   �� $" 00:00:00.3000000��6>   $# 0,2,0,-2q�6Y   5�   #   �� 5�   "   $ 00:00:00X�6?   $ TopWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6u   .g�5�   &   �� $  00:00:00.3000000��6:   $! 	#99FDFDFD��6U   5�   #   5�      5�      .R�5�      � $
$ Grid��6   $% 0.5,0.5&�6-   $��4,4,4,4q�6M   z�5�      V� 5�   "   .~�5�   &   �� $& 1Q�65   $' 1Q�6@   �� 5�   &   $( 0Q�64   $) 0Q�6?   �� 5�   &   $* 0Q�66   T� 5�   &   $+ 0Q�69   $, -2Q�6?   5�   #   .+�5�      �� $ Shadow��6<   $ 4,4,4,4��6%   $	- 0.5Q�6L   $��0,2,0,-2q�6Z   8.  ��5�   "   �� 5�   &   8  66   5�      �� 5�      $ 	BaseLayer��6<   $ 4,4,4,4��6%   ��5�   "   �� 5�   &   8  66   5�      �� 5�      $ EdgeCurveLayer��6<   $ 4,4,4,4��6%   ��5�   "   �� 5�   &   $/ 	0.994,0.5&�6:   $0 0.01,0.5&�6O   .��5�   *   � $1 	#00000000��67   $2 0Q�6I   � 5�   *   $1 	#00000000��67   $2 1Q�6I   � 5�   *   $1 	#19000000��67   $2 0.203Q�6I   � 5�   *   $1 	#19000000��67   $
2 0.81Q�6I   � 5�   *   $1 	#33000000��67   $	2 0.5Q�6I   5�   '   5�      �� 5�      $ BottomWhite��6<   $ 4,4,4,4��6%   3 5�   "   �� 5�   &   $/ 	0.995,0.5&�6:   $0 0.01,0.5&�6O   .��5�   *   � $1 	#00000000��67   $2 0Q�6I   � 5�   *   $1 	#00000000��67   $2 1Q�6I   � 5�   *   $1 	#FF000000��67   $2 0.548Q�6I   5�   '   ��5�   "   �� 5�   &   $/ 	0.5,0.971&�6:   $0 	0.5,0.036&�6O   .��5�   *   � $1 	#00000000��67   $2 0Q�6I   � 5�   *   $1 	#19FFFFFF��67   $2 1Q�6I   � 5�   *   $1 	#0C808080��67   $
2 0.49Q�6I   5�   '   5�      �� 5�      $ TopWhite��6<   $ 4,4,4,4��6%   3 5�   "   �� 5�   &   $/ 	0.991,0.5&�6:   $0 0.01,0.5&�6O   .��5�   *   � $1 	#00000000��67   $2 0Q�6I   � 5�   *   $1 	#00060606��67   $2 1Q�6I   � 5�   *   $1 	#D8020202��67   $
2 0.49Q�6I   5�   '   ��5�   "   �� 5�   &   $/ 	0.5,0.971&�6:   $0 	0.5,0.029&�6O   .��5�   *   � $1 	#99FDFDFD��67   $2 0Q�6I   � 5�   *   $1 	#00FFFFFF��67   $2 1Q�6I   � 5�   *   $1 	#4CFDFDFD��67   $2 0.513Q�6I   5�   '   5�      �� 5�      $ 
HoverLayer��6<   $ 4,4,4,4��6%   $- 0Q�6P   $��1,1,1,1q�6\   ��6v   Z� ��5�   "   �� 5�   &   8  66   ._�5�   "   �� $ 
HoverInner��6Z   $ 3,3,3,3��6)   $��1,1,1,1q�6@   ��5�   &   �� 5�   *   8  6:   5�   #   5�      �� 5�      $ DefaultLayer��6%   $��1,1,1,1q�6;   $ 4,4,4,4��6U   $- 0Q�6l   . 5�   "   
  5�   &   84  $
5 0.65Q�6Z   $6 10Q�6i   ��5�   "   �� 5�   &   8  66   5�      �� 5�      $7 contentPresenter��6�   #��z��6/   #��z��6r   ��. $��4,-2,4,2q�6�   . 5�   "   
  5�   &   84  $5 0Q�6[   5�      5�       5�      P� 5�       �@J�IsKeyboardFocused . 6C   P� 5�       �@J�IsMouseOver . 8 5�   "   �� 5�   &   $9 HoverOff_BeginStoryboard��6]   8��	 : 5�   "   �� 5�   &   $9 HoverOn_BeginStoryboard��6\   8��
 5�      P� 5�       � �� . 8 5�   "   �� 5�   &   $ 9 PressedOff_BeginStoryboard��6_   8�� : 5�   "   �� 5�   &   $9 PressedOn_BeginStoryboard��6^   8�� 5      P� 5      � {� . 6;   P� 5      � {� .  . �5  "   �� 8   � ��6?   5     5     5      5	     �� 5
      6   �� $
 Text�$ cbSchedType�� Touchscreen6U   .a�5     ��  � y�$ Visible=�6=   5     5     �� 5  
   " ��6"   .�5     ��  � y�$ Visible=�6+   6=    5     �� 5      6   �� $ SelectedIndex�$ cbSchedType�� 86^   .a�5     ��  � y�$ 	Collapsed=�6=   5     5     �� 5  
   " ��6'   .�5     ��  � y�$ Visible=�6+   6=    5     �� 5      6   �� $ SelectedIndex�$ cbSchedType�� 86^   .a�5     ��  � y�$ 	Collapsed=�6=   5     �� 5      6   �� $ SelectedIndex�$ cbSchedType�� 96^   .a�5      ��  � y�$ 	Collapsed=�6=   5!     5#     �� 5%  
   " ��6#   .�5&     ��  � ��
 �����6+   �� 5'      � y�$ 	Collapsed=�6+   6?   �� 5(      �@J�Effect 5)     
  5*     $
4 Blue��6'   5,      5-     �� 5.      6   �� $ SelectedIndex�$ cbPlaybackMode�� 16a   .a�5/     ��  � y�$ Visible=�6=   50     52     �� 54  
   " ��6(   .�55     ��  � ��
 �����6+   �� 56      � y�$ 	Collapsed=�6+   6?   �� 57      �@J�Effect 58     
  59     $
4 Blue��6'   5;      5<     �� 5=      6   �� $ SelectedIndex�$ cbPlaybackMode�� 06a   .a�5>     ��  � y�$ Visible=�6=   5?     5A     �� 5C  
   " ��6'   .�5D     ��  � ��
 �����6+   �� 5E      � y�$ 	Collapsed=�6+   6?   �� 5F      �@J�Effect 5G     
  5H     $
4 Blue��6'   5J      5K     �� 5L      6   �� $ SelectedIndex�$ cbPlaybackMode�� 26a   .a�5M     ��  � y�$ Visible=�6=   5N     5P     �� 5R  
   " ��6)   .�5S     ��  � ��
 �����6+   �� 5T      � y�$ 	Collapsed=�6+   6?   �� 5U      �@J�Effect 5V     
  5W     $
4 Blue��6'   5Y      5Z     �� 5[      6   �� $ SelectedIndex�$ cbPlaybackMode�� 36a   .a�5\     ��  � y�$ Visible=�6=   5]     5_     �� 5a  
   " ��6(   .�5b     ��  � ��
 �����6+   �� 5c      � y�$ 	Collapsed=�6+   6?   �� 5d      �@J�Effect 5e     
  5f     $4 SeaGreen��6'   5h      5i     �� 5j      6   �� $ SelectedIndex�$ cbSchedType�� 06^   .a�5k     ��  � y�$ Visible=�6=   5l     5n     �� 5p  
   " ��6%   .�5q     ��  � ��
 �����6+   �� 5r      � y�$ 	Collapsed=�6+   6?   �� 5s      �@J�Effect 5t     
  5u     $
4 Blue��6'   5w      5x     �� 5y      6   �� $ SelectedIndex�$ cbSchedType�� 86^   .a�5z     ��  � y�$ Visible=�6=   5{     5}     �� 5  
   " ��6#   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 SeaGreen��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 16^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6%   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 SeaGreen��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 26^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6$   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 SeaGreen��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 56^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6'   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 SeaGreen��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 36^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6'   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 SeaGreen��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 46^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6%   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 SeaGreen��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 66^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6$   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 SeaGreen��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 76^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6#   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?   �� 5�      �@J�Effect 5�     
  5�     $4 Black��6'   5�      5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 96^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   " ��6%   .�5�     ��  � ��
 �����6+   �� 5�      � y�$ 	Collapsed=�6+   6?    5�     �� 5�      6   �� $ Items.Count�$ 
lvDisplays�� 06[   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5  
   " ��6%   .�5     ��  �@J�SnapsToDevicePixels . 64   �� 5      �@�FocusVisualStyle8   61   �� 5      � ��8  6+   �� 5      � ��8  6,   �� 5      � ��$
 Bold"�6+   �� 5      � �� 5     �� 5     " ��6&    5     ���� 5     HoverOn .��5  "   U� $ 00:00:00X�6@   $ contentPresenter��6U   $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�6~   .\�5  &   �� $ 00:00:00.1000000��6;   $ 1Q�6V   5  #   U� 5  "   $ 00:00:00X�6@   $ Hover��6U   $ (UIElement.Opacity)�6s   .\�5  &   �� $ 00:00:00.1000000��6;   $	 0.8Q�6V   5   #   5!     �� 5"     HoverOff .��5#  "   U� $ 00:00:00X�6@   $ contentPresenter��6U   $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�6~   .\�5$  &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5%  #   U� 5&  "   $ 00:00:00X�6@   $ Hover��6U   $ (UIElement.Opacity)�6s   .\�5'  &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5(  #   5)     �� 5*     	PressedOn 6)   �� 5+     
PressedOff 6)   �� 5,     	CheckedOn .��5-  "   U� $ 00:00:00X�6@   $
 path��6U   $ (FrameworkElement.Width)�6r   .\�5.  &   �� $ 00:00:00.1000000��6;   $ 11Q�6V   5/  #   U� 50  "   $ 00:00:00X�6@   $
 path��6U   $ (FrameworkElement.Height)�6r   .\�51  &   �� $ 00:00:00.1000000��6;   $ 10Q�6V   52  #   53     �� 54     
CheckedOff .��55  "   U� $ 00:00:00X�6@   $
 path��6U   $ (FrameworkElement.Width)�6r   .\�56  &   �� $ 00:00:00.2000000��6;   $ 0Q�6V   57  #   U� 58  "   $ 00:00:00X�6@   $
 path��6U   $ (FrameworkElement.Height)�6r   .\�59  &   �� $ 00:00:00.2000000��6;   $ 0Q�6V   5:  #   5;     �� 5<     ThreeStateOn .��5=  "   U� $ 00:00:00X�6@   $ 
ThreeState��6U   $ (FrameworkElement.Width)�6x   .\�5>  &   �� $ 00:00:00.1000000��6;   $ 9Q�6V   5?  #   U� 5@  "   $ 00:00:00X�6@   $ 
ThreeState��6U   $ (FrameworkElement.Height)�6x   .\�5A  &   �� $ 00:00:00.1000000��6;   $ 9Q�6V   5B  #   T� 5C  "   $ 00:00:00X�6@   $
 path��6U   $ (UIElement.Visibility)�6r   ..�5D  &   i� $; 00:00:00.1000000��6=   #= Z< 6X   5E  #   5F     �� 5G     ThreeStateOff .��5H  "   U� $ 00:00:00X�6@   $ 
ThreeState��6U   $ (FrameworkElement.Width)�6x   .\�5I  &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5J  #   U� 5K  "   $ 00:00:00X�6@   $ 
ThreeState��6U   $ (FrameworkElement.Height)�6x   .\�5L  &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5M  #   T� 5N  "   $ 00:00:00X�6@   $
 path��6U   $ (UIElement.Visibility)�6r   ..�5O  &   i� $; 00:00:00.3000000��6=   #= Z> 6X   5P  #   5Q     5R     .R�5S     �� 
? ���� @ 5T     � 5U  "   $��13��6'   $��13��62   .+�5V  &   �� $ Shadow��6-   $��	0,0,-2,-2q�6=   $
- 0.25Q�6P   8.  ��5W  *   �� 5X  .   8  6>   5Z  '   �� 5[  &   $ 
MainBorder��6-   $��2,2,2,2q�6A   $ 2,2,2,2��6[   ���	#72000000��5\  *   �� 5]  .   8  6>   ._�5_  *   �� $A 
ThreeState��6l   $y�Visible=�64   8�� $��1,1,1,1q�6�   $��0��6�   $��0��6�   5`  '   �� 5a  &   $ Shade��6-   $ 2,2,2,2��6<   $	- 0.1Q�6S   $��1,1,1,1q�6a   ��5b  *   �� 5c  .   $/ 	1.292,0.5&�6B   $0 
-0.545,0.5&�6W   .��5d  2   � $1 	#FF000000��6?   $2 1Q�6Q   � 5e  2   $1 	#FFFFFFFF��6?   $2 0.006Q�6Q   5f  /   5h  '   F� 5i  &   $
B path��6s   $
C Fill=�6+   8�� $��2��6_   $��11��6�   1�����9��z�?��Q ��P�m	@�� Q�� GER��(@	$��1.577,0.134,-0.013,2.866q�6�   $��10��6�   �� 5j  &   $ Hover��69   $- 0Q�6-   $��2,2,2,2q�6H   $ 2,2,2,2��6b   ��5k  *   �� 5l  .   8  6>   5n  '   5o  #   ._�5q     �� $7 contentPresenter��6[   ��. $��5,0,0,0q�6J   . 5r  "   
  5s  &   84 	 $5 0Q�6Z   5u     5v      5w     ]� 5x     8 5y  "   �� 5z  &   $#9 ThreeStateOff_BeginStoryboard��6b   8��
 : 5|  "   �� 5}  &   $"9 ThreeStateOn_BeginStoryboard��6a   8�� D 5  "   �� 5�  &   E �@d�IsThreeStateF . 6H   �� 5�  &   E �@d�	IsChecked$
F TrueY�6E   5�     P� 5�      �@d�	IsChecked$ falseY�6;   8 5�  "   �� 5�  &   $9 CheckedOn_BeginStoryboard��6^   8�� : 5�  "   �� 5�  &   $ 9 CheckedOff_BeginStoryboard��6_   8�� 5�     P� 5�      �@J�IsMouseOver . 8 5�  "   �� 5�  &   $9 HoverOff_BeginStoryboard��66   8�� 6X   : 5�  "   �� 5�  &   8�� 66   5�     P� 5�      � �� . 8 5�  "   �� 5�  &   $ 9 PressedOff_BeginStoryboard��66   8�� 6Z   : 5�  "   �� 5�  &   $9 PressedOn_BeginStoryboard��66   8�� 6Y   5�     P� 5�      � {� .  . �5�  "   �� 8  $G 
MainBorder��6p    � ���� 5�  "   8  $G 
MainBorder��6m    � ��5�     5�     5�     �� 5�      � �� 5�     �� 5�     $ White��6&   5�     �� 5�      � y�$ 	Collapsed=�6+   6?    5�     �� 5�      6   �� $ SelectedIndex�$ cbSchedType�� 56^   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   "  6%   .�5�     ��  � y�$ Visible=�65   6G    5�     �� 5�      6   �� $ 	IsChecked�$ cbAllDay�� True6W   .a�5�     ��  � y�$ 	Collapsed=�6=   5�     �� 5�      6   �� $ 	IsChecked�$ cbAllDay��	 False6W   .a�5�     ��  � y�$ Visible=�6=   5�     5�     �� 5�  
   .R�5�     �� $	��500��6   
�������$��1q�67   $��Stretch=�6K   ��6i   �� $ lbSlideInfoSlides��$ ActualWidth�._�5�     � .+�5�     � $
��Left=�6   $��5q�66   $��45��6A   $��35��6O   .+�5�     �� $��Center=�6    ��6=   �� *	ThumbNail+5�     �� 5�     8��  $��14(�6_   $��75,0,0,0q�6m   ��6I   �� *Name+6m   �� 5�     8�� $
��Left=�6f   $	��345��6�   $��25��6�   $
��Wrap=�6�   $��CharacterEllipsis=�6�   $��
80,20,0,10q�6�   ��6I   �� *Description+6�   �� 5�     8�� $��20(�6�   $��0,0,20,0q�6�   $��Right=�6�   $��Center=�6�   ��6I   �� *
Duration+8H  $I OneWay=�6�   5�     5�     5�     �� 5�  
   .R�5�     �� -   5        
�������$��1q�5�  (   $��Stretch=�6<   ���	#01000000._�5�     � .+�5�     � $
��Left=�6   $��5q�66   $��45��6A   $��35��6O   .+�5�     �� $��Center=�6   ��69   �� *	ThumbNail+5�     �� 5�     $��14(�66   $
��Bold"�6D   $��75,0,0,0q�6V   ��6    �� *Name+6V   �� 5�     $��13(�6=   8��  $
��Left=�6s   $	��345��6�   $��25��6�   $
��Wrap=�6�   $��CharacterEllipsis=�6�   $��
80,20,0,10q�6�   ��6    �� *Description+6�   �� 5�     $��20(�6u   $��0,0,24,0q�6�   $��Right=�6�   $��Center=�6�   ��6    �� *
Duration+8H  $I OneWay=�6�   �� 5�     8�� $��20��6F   $��20��6Q   $��Right=�6]   $��Center=�6y   $��0,0,2,0q�6�   ._�5�     �� $"��Resources/Images/warning.png��6    $1J +Slide contains buttons that are not linked.��6G   y�6}   �� *	Buttons+8H  5�     5�     5�     5�     �� 5�  
   .R�5�     �� -   5        
�������$��1q�5�  (   $��Stretch=�6<   8K   ���	#01000000._�5�     � .+�5�     �� $
��Left=�6   $��5q�67   $	��127��6B   $	��120��6Q   ��6^   �� *	ThumbNail+�� 5�     $	��280��66   $��CharacterEllipsis=�6E   $
L Left=�6f   $��16(�6{   $
��Bold"�6�   $��	140,0,0,0q�6�   $
��Left=�6�   ��6    �� *Name+6�   �� 5�     $��13(�6=   8�� $
��Left=�6s   $	��290��6�   $��55��6�   $
��Wrap=�6�   $��CharacterEllipsis=�6�   $��140,20,0,30q�6�   ��6    �� *Description+6�   �� 5�     $��Bottom=�6    $
��Left=�6;   $��	140,0,0,3q�6V   ��6i   �� *Rules+$I OneWay=�8H  J 6�   �� *Rules+$I OneWay=�8H    5�     $M dtiDuration��6�   
���   �$��24(�6]   $��	0,10,10,0q�6k   $��Right=�6~   $J Duration��6�   $	��Top=�6�   $N Custom=�6�   $O HH:mm:ss��6�   P .  Q .  R 6/   �� *
Duration+6  �� 5�     $��
Transition��6   $��90��6Q   $��30��6\   $��Right=�6h   $��Bottom=�6�   $��0,0,8,44q�6�   #��ZS 6�   J 62   �� *
Transition+6�   �� 5�     8�� $��Buttons��6m   $$J Configure touchscreen buttons.��6   $��90��6�   $��30��6�   $��Right=�6�   $��Bottom=�6�   $��8q�6�   #��ZT 6  {�6   �� *HasTouchElements+6  �� 5�     8�� $��20��6F   $��20��6Q   $��Right=�6]   $��Bottom=�6y   $��	0,0,98,14q�6�   ._�5�     �� $"��Resources/Images/warning.png��6   $1J +Slide contains buttons that are not linked.��6B   y�6x   �� *	Buttons+8H  5�     5�     5�     5�     �� 5�  
   .R�5�     �� $U 
theControl��6   |�.  8��  6<   V 5�     �� 5�     $
 True��6�    6   ��  �� $W FindAncestor=�"X ��$ 
IsSelected�.a�5�     �� $G 
theControl��6   8   � ��6I   5�     5�     5�     .��5�     ]� .+�5�  
   �� $	��285��6   $	��Top=�6$   $��Disabled=�69   $
��Auto=�6`   .��5�  
   � .+�5�        Inspire.InfoTextBox  -   5        Y  Name$Y txtSchedName��5�  "   
�������Z   TextBoxInfo$$Z Enter the Name of the Schedule��6K   $��Center=�6x   $��25��6�   $��108,15,157,0q�6�   $	��Top=�6�   �� 5�     -   5        $��lblSchedName��5�  s   $��25��6   $
��Left=�6    $��9,19,0,0q�6;   
�������$
��Bold"�6`   $	��Top=�6�   $	��104��6�   .��6�   Schedule Name:6�   �� 5�     -   5        $��lblSchedType��5�  t   $��25��6   $
��Left=�6    $��	15,54,0,0q�6;   
�������$
��Bold"�6a   $��Center=�6�   $	��Top=�6�   $	��109��6�   .��6�   Schedule Type:6�   �� 5�     #��[ 6   [ �� Orientation$[ 
Horizontal=�6<   $��25��6U   $��	14,86,0,0q�6a   $	��Top=�6t   $
��Left=�6�   $	��554��6�   .+�5�     �� -   5        $��lblWhen��5�  K   $��1��6   
�������$
��Bold"�68   $��5,0,5,0q�6Z   $��Center=�6k   .��6�   When:6�     5      -	   5        $M dpStart��5   �   #��[ 6+   $��1��6e   $��1��6u   $N Short=�6�   
�������$��0,0,5,0q�6�   $��25��6�   $	��110��6�   6�     5     -
   5        $M tpStart��5  �   #��[ 6+   #��[6 6e   $��2��6�   $��1��6�   $N 	ShortTime=�6�   P .  $��25��6�   $	��Top=�6�   $
��Left=�6  $��80��6!  6.  �� 5     -   5        $��lblto��5  5   $��3��6   $��1��6(   
�������$
��Bold"�6U   $��5,0,5,0q�6g   $��Center=�6x   .��6�   to6�     5     -   5        $M tpEnd��5  �   #��[ 6+   #��[6 6e   $��4��6�   $��1��6�   $N 	ShortTime=�6�   P .  $��0,0,5,0q�6�   $��25��6�   $��80��6�   6	    5     -   5        $M dpEnd��5  �   #��[ 6+   $��5��6e   $��1��6u   
�������$��0,0,5,0q�6�   $��25��6�   $	��110��6�   6�   �� 5     -   5        \ ��Name$\ cbAllDay��5  D   $��6��6   $��1��6+   $��25��68   $J Play All Day��6V   $��Center=�6m   
�������$��91��6�   .��6�   	All Day6�   5     �� 5	     -   5        ] ��Name$] 
lvDisplays��5	  K   #��[
 6   $��
6,161,6,40q�67   ^ J� 	AllowDrop^ . $��84��6�   $	��Top=�6�   ��5
     �� 5     .R�5     �� $[ 
Horizontal=�6%   #K [ 6>   .+�5     �� $��24��6$   $��24��6/   $	��3,0q�6;   $3��-ScheduleTreeView\Resources\Images\Display.ico��6H   �� 5     ��6(   �� *DisplayName+5     5     ��5     �� 5     .R�5     � $	��140��6$   _ � Orientation$_ Vertical=�61   ` K� IsItemsHost` . 6H   5     5     �� 5     -   5        $��lblDragDisplays��5  7   $��29��6   $��149,191,158,0q�6    $��Center=�6N   $	��Top=�6k   #��[* 6�   a J� IsHitTestVisiblea .  $��Italic$�6�   $- .8Q�6�   
�������$	��283��6�   .��6  20Drag Displays Here To Create A Schedule For Them63  �� 5     -   5        $��lblDisplays��5  C   $
��Left=�6   $��
10,142,0,0q�6/   
�������$
��Bold"�6i   $��67��6{   $��23��6�   $	��Top=�6�   .��6�   	Displays:6�   �� 5     -   5        $��btnSave��5  j   $��31��6   $��	0,0,146,3q�6!      Inspire.ButtonImageb   Image$b Resources/Images/Ok16.png��64   $��Bottom=�6y   $	��128��6�   c   SaveScheduleCommand#��Zc 6�   $��Right=�6�   .��6�   Save6  �� 5     -   5        $��	btnUpdate��5  j   $��31��6   $��	0,0,146,3q�6!   $b Resources/Images/Ok16.png��64   $��Bottom=�6{   $	��128��6�   d   UpdateScheduleCommand#��Zd 6�   $y�	Collapsed=�6�   $��Right=�6�   .��6  Update6"  �� 5     -   5        $��	btnCancel��5  �   $��31��6   $��Right=�6!   $��0,0,10,3q�6=   $#b Resources/Images/Cancel16.png��6O   $��Bottom=�6�   $	��128��6�   e   CancelScheduleCommand#��Ze 6�   .��6  Cancel6  �� 5(     -   5        $��cbSchedType��5(  �   $VJ PHover the mouse over the item in the list to see a description of schedule type.��6   f �� SelectedIndex$f 0��6r   $��
109,50,0,0q�6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   $	��202��6�   .@�5)     �� $rJ lContinuous schedules play non-stop from the start time on the start date until the end time on the end date.��6   .��6�   
Continuous6�   �� 5*     $ZJ TThe Default presentation will play on the display when no other schedule is playing.��6   .��6~   Daily6�   �� 5+     $qJ kEvery weekday will play the schedule every day of the week from the start time each day until the end time.��6   .��6�   Every weekday (Mon-Fri)6�   �� 5,     $�J �Mon, Wed, Frid, will play the schedule on Monday, Wednesday and Friday from the choosen start date to the end date from the start time each day until the end time.��6   .��6�   Every Mon., Wed., and Fri.6�   �� 5-     $�J �Tues. Thurs. will play the schedule on Tues. and Thurs. from the choosen start date to the end date from the start time each day until the end time.��6   .��6�   Every Tues., and Thurs.6�   �� 5.     $�J �Weekly will play the schedule every day choosen every week from the start date to the end date from the start time each day until the end time.��6   .��6�   Weekly6�   �� 5/     $qJ kMonthly will play the schedule every month on the date choosen from the start time each until the end time.��6   .��6�   	Monthly6�   �� 50     $kJ eYearly will play the schedule once a year on the date choosen from the start time until the end time.��6   .��6�   Yearly6�   �� 51     $ZJ TThe Default presentation will play on the display when no other schedule is playing.��6   .��6~   	Default6�   �� 53     $sJ mTouchscreen schedules play non-stop from the start time on the start date until the end time on the end date.��6   .��6�   Touchscreen6�   55     �� 56     $[ 
Horizontal=�6   $��20��62   $��	6,116,0,0q�6>   $	��578��6Q   $	��Top=�6]   $
��Left=�6u   .+�57     �� -   5        $��	ckbSunday��57  o   $��18��6   #��[+ 6#   $
��Left=�6I   $��2q�6d   $	��Top=�6�   $��65��6�   .��6�   Sunday6�   �� 58     -   5        $��	ckbMonday��58  o   $��18��6   #��[+ 6#   $
��Left=�6I   $��2q�6d   $	��Top=�6�   $��68��6�   .��6�   Monday6�   �� 59     -   5        $��
ckbTuesday��59  c   #��[+ 6   $
��Left=�6=   $��2q�6X   $��68��6u   $��18��6�   $	��Top=�6�   .��6�   	Tuesday6�   �� 5:     -   5        $��ckbWednesday��5:  H   #��[+ 6   $��2q�6=   $��18��6\   $	��Top=�6h   $
��Left=�6�   $��85.333��6�   .��6�   	Wednesday6�   �� 5;     -   5        $��ckbThursday��5;  H   #��[+ 6   $��2q�6=   $��18��6[   $	��Top=�6g   $
��Left=�6   $��75��6�   .��6�   
Thursday6�   �� 5<     -   5        $��	ckbFriday��5<  H   #��[+ 6   $��2q�6=   $��18��6Y   $	��Top=�6e   $
��Left=�6}   $��61.333��6�   .��6�   Friday6�   �� 5=     -   5        $��ckbSaturday��5=  H   #��[+ 6   $��2q�6=   $��18��6[   $	��Top=�6g   .��6   
Saturday6�   5>     �� 5?     -   5        g ��Name$g tbPlaybackDesc��5?  }   #J [ 6   $
L Left=�6M   $
��Left=�6b   $��5,247,279,0q�6�   $��12(�6�   $
��Wrap=�6�   $��Center=�6�   #��� - 6�   $��Test Description��6  $	��306��6*  $��38��66  �� 5V     -   5        $��lblPlaybackMode��5V  h   $��
321,55,0,0q�6   $
��Left=�6(   
�������$
��Bold"�6V   $��96��6   $��25��6�   $	��Top=�6�   .��6�   Playback Mode:6�   �� 5W     -   5        $��cbPlaybackMode��5W  �   $\J VHover over the items in the list to see a description of the different playback modes.��6   $f 0��6x   $
��Left=�6�   $��166.29��6�   $��30��6�   $	��Top=�6�   $��
418,48,0,0q�6�   .@�5X     �� ${J uNormal will play the slides in the order they are layed out. Interspersed or randomized slides will mix in with them.��6   .��6�   Normal6�   �� 5Y     $�J �Do not mix will keep the group of slides together on playback. Interspersed and Randomized slides will not mix with these slides.��6   .��6�   
Do not mix6�   �� 5Z     $pJ jRandomize Mode will randomly shuffle slides together with other schedules other than Do not Mix Schedules.��6   .��6�   	Randomize6�   �� 5[     $oJ iIntersperse slides will distribute evenly on every other slide in other schedules that are set to Normal.��6   .��6�   Intersperse6�   5\     �� 5]     -    5        $��cbIsTouchScreenSched��5]  o   $y�	Collapsed=�6   $��Touchscreen Schedule��62   $��18��6Q   $
��Bold"�6]   
�������$��	0,142,6,0q�6�   $	��162��6�   $	��Top=�6�   $��Right=�6�   5c     5d     5e     � 5f  
   -!   5        ^ . .+�5g  
   �� -"   5        $] lbSlideInfoSlides��5g      = 	DarkBrush#��� = 6-   ^ . $��Stretch=�6x   $��Stretch=�6�   $��Stretch=�6�   #��[< 6�   3  -Inspire.Common.DragDropListBox.DragDropHelperh   DragDropTemplate#h [7 6  i   IsDragSourcei . j   IsDropTargetj . ��6V   Z� 5i     �� 5j  
   -#   5        $A DropGrabber��5j     
���   �$	- .05Q�66   a . $y�	Collapsed=�6\   5k     5l     5m     