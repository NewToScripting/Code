   M S B A M L   `   `   `  ����U  QInfragistics.ToyBox, Version=1.0.2570.22297, Culture=neutral, PublicKeyToken=nullV>clr-namespace:Infragistics.ToyBox;assembly=Infragistics.ToyBoxInfragistics.ToyBox  5   K   B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire 6�   D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands 6�   X TInspire.Client.ScheduleWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Inspire.Client.ScheduleWindow.Converters(Inspire.Client.ScheduleWindow.Converters 6  8   2Inspire.Client.ScheduleWindow.TouchScreenScheduler   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      QToyBox>clr-namespace:Infragistics.ToyBox;assembly=Infragistics.ToyBox     6K   :Inspire&clr-namespace:Inspire;assembly=Inspire     6�   DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     6�   M
Converters6clr-namespace:Inspire.Client.ScheduleWindow.Converters     6     	DarkBrush#���   5        � 	Resources  5        Inspire.DurationConverter  durationConverter+  %Inspire.ReverseBoolToVisibleConverter   revBoolToVisibilityConverter$  Inspire.BoolToVisibleConverter  boolToVisibilityConverterJ  DInspire.Client.ScheduleWindow.Converters.NullEmptyToVisibleConverter  nullEmptyToVisibleConverter  SlideDataTemplate �� 	Converter  	TextBrush �� Mode  SelectedSlideDataTemplate �� TextAlignment � ToolTip  HideTouchButton �� 
TargetType �� Property �� Value 	 	MainColor �� Color	 �� 
TargetType
 � 	Resources 
 Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� KeyTime �� Value p� KeyTime p� Value �Name J� RenderTransformOrigin �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y ��Name �� CornerRadius J� Opacity  
EffectBlur  J� Effect  
BlackColor  ControlColor! �� EndPoint" �� 
StartPoint# � Color$ � Offset% J� OpacityMask3  -System.Windows.Media.Effects.DropShadowEffect&   Color'   Opacity(   
BlurRadius) ��Name* �� Triggers+ P� Property, P� Value- N� ExitActions. ��Name  HoverOff/ N� EnterActions  HoverOn  
PressedOff  	PressedOn  DisabledForegroundBrush  TouchScreenButtonTemplate0 �� Orientation1 ��Name��%�#  &	       &	      &	 &     &	 9     &	 L     7  7  &	 �    7  7  &	 �    7 	 7  7  7  7 	 7 	 7 	 7 	 7 	 7  7  7  7  7  &	 �    7  7 	 7 	 7    5   
   6$     5	   
   60     5
   
   6)     5   
   61   �� 5   
   .R�5      �� 
�������$��1q�6(   $��Stretch=�6<   ._�5      � $��0,8,0,0q�6   .+�5      � $
��Left=�6   $��5q�66   $��45��6A   $��35��6O   .+�5      �� $��0,5,0,0q�6    $��Center=�61   ��6N   �� *	ThumbNail+�� 5      $��0,5,0,0q�6    $��Center=�61   $ ��Resources/Images/Alert.png��6N   y�6r   �� *SlideToGuid+8   5      �� 5      $
��Bold"�6<   $��14(�6N   $��65,0,0,0q�6\   ��6    �� *
ButtonName+6\   �� 5      8�� $
��Left=�6c   $	��345��6~   $��25��6�   $
��Wrap=�6�   $��CharacterEllipsis=�6�   $��
70,20,0,50q�6�   ��6    �� *	SlideName+6�   �� 5      $��20(�6G   $��5q�6U   $��Right=�6`   $	��Top=�6|   ��6    �� *
Duration+$ OneWay=�6|   �� 5      $
��Link��6   $��20(�6,   $��5q�6:   $��Right=�6E   $��Bottom=�6a   5      5      5      �� 5   
   .R�5      �� 
�������$��1q�6(   $��Stretch=�6<   ._�5      � $��0,8,0,0q�6   .+�5      � $
��Left=�6   $��5q�66   $��45��6A   $��35��6O   .+�5      �� $��Center=�6    ��6=   �� *	ThumbNail+5       �� 5!      $	��280��6<   $��CharacterEllipsis=�6K   $
 Left=�6l   $
��Bold"�6�   $��16(�6�   $��	140,0,0,0q�6�   $
��Left=�6�   ��6    �� *
ButtonName+6�   �� 5"      8��  $��13(�6c   $
��Left=�6q   $	��300��6�   $��55��6�   $
��Wrap=�6�   $��CharacterEllipsis=�6�   $��140,20,0,30q�6�   ��6    �� *	SlideName+6�   �� 5#      $ Duration��6u   $	��Top=�6�   $��24(�6�   $��	0,10,10,0q�6�   $��Right=�6�   ��6    �� *
Duration+8  $ OneWay=�6�   5$      5%      5&      �� 5(   
   " ��6(   .�5)      ��  � �� 5*      �� 5+      8   6&   5-      �� 5.       � ��$ 14(�6)   �� 50       � ��$ Center=�64   �� 52       � ��$ Center=�62   �� 54       � �� 55      �� 56      "	 ��6&   
 57      ���� 58      HoverOn
 .��59   "   U� $ 00:00:00X�6@   $ 
HoverLayer��6U   $ (UIElement.Opacity)�6x   .\�5:   &   �� $ 00:00:00.1000000��6;   $ 1Q�6V   5;   #   U� 5<   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5=   &   �� $ 00:00:00.1000000��6;   $ -4Q�6V   5>   #   5?      �� 5@      HoverOff
 .��5A   "   U� $ 00:00:00X�6@   $ 
HoverLayer��6U   $ (UIElement.Opacity)�6x   .\�5B   &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5C   #   U� 5D   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5E   &   �� $ 00:00:00.3000000��6;   $ -2Q�6V   5F   #   5G      �� 5H      	PressedOn
 .��5I   "   �� $ 00:00:00X�6?   $ BottomWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6x   .g�5J   &   �� $ 00:00:00.1000000��6:   $ 	#7FFFFFFF��6U   5K   #   U� 5L   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5M   &   �� $ 00:00:00.1000000��6;   $ 2Q�6V   5N   #   r� 5O   "   $ 00:00:00X�6C   $ Shadow��6X   $ (FrameworkElement.Margin)�6w   .	�5P   &   �� $ 00:00:00.1000000��6>   $ 0,2,0,0q�6Y   5Q   #   �� 5R   "   $ 00:00:00X�6?   $ TopWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6u   .g�5S   &   �� $ 00:00:00.1000000��6:   $ 	#19FDFDFD��6U   5T   #   5U      �� 5V      
PressedOff
 .��5W   "   �� $ 00:00:00X�6?   $ BottomWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6x   .g�5X   &   �� $ 00:00:00.3000000��6:   $ 	#19FFFFFF��6U   5Y   #   U� 5Z   "   $ 00:00:00X�6@   $
 Grid��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6r   .\�5[   &   �� $ 00:00:00.3000000��6;   $ -2Q�6V   5\   #   r� 5]   "   $ 00:00:00X�6C   $ Shadow��6X   $ (FrameworkElement.Margin)�6w   .	�5^   &   �� $ 00:00:00.3000000��6>   $ 0,2,0,-2q�6Y   5_   #   �� 5`   "   $ 00:00:00X�6?   $ TopWhite��6T   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6u   .g�5a   &   �� $ 00:00:00.3000000��6:   $ 	#99FDFDFD��6U   5b   #   5c      5d      .R�5e      � $
 Grid��6   $ 0.5,0.5&�6-   $��4,4,4,4q�6M   z�5f      V� 5g   "   .~�5h   &   �� $ 1Q�65   $ 1Q�6@   �� 5i   &   $ 0Q�64   $ 0Q�6?   �� 5j   &   $ 0Q�66   T� 5k   &   $ 0Q�69   $ -2Q�6?   5l   #   .+�5o      �� $ Shadow��6<   $ 4,4,4,4��6%   $	 0.5Q�6L   $��0,2,0,-2q�6Z   8   ��5p   "   �� 5q   &   8  66   5s      �� 5u      $ 	BaseLayer��6<   $ 4,4,4,4��6%   ��5v   "   �� 5w   &   8  66   5y      �� 5z      $ EdgeCurveLayer��6<   $ 4,4,4,4��6%   ��5{   "   �� 5|   &   $! 	0.994,0.5&�6:   $" 0.01,0.5&�6O   .��5}   *   � $# 	#00000000��67   $$ 0Q�6I   � 5~   *   $# 	#00000000��67   $$ 1Q�6I   � 5   *   $# 	#19000000��67   $$ 0.203Q�6I   � 5�   *   $# 	#19000000��67   $
$ 0.81Q�6I   � 5�   *   $# 	#33000000��67   $	$ 0.5Q�6I   5�   '   5�      �� 5�      $ BottomWhite��6<   $ 4,4,4,4��6%   % 5�   "   �� 5�   &   $! 	0.995,0.5&�6:   $" 0.01,0.5&�6O   .��5�   *   � $# 	#00000000��67   $$ 0Q�6I   � 5�   *   $# 	#00000000��67   $$ 1Q�6I   � 5�   *   $# 	#FF000000��67   $$ 0.548Q�6I   5�   '   ��5�   "   �� 5�   &   $! 	0.5,0.971&�6:   $" 	0.5,0.036&�6O   .��5�   *   � $# 	#00000000��67   $$ 0Q�6I   � 5�   *   $# 	#19FFFFFF��67   $$ 1Q�6I   � 5�   *   $# 	#0C808080��67   $
$ 0.49Q�6I   5�   '   5�      �� 5�      $ TopWhite��6<   $ 4,4,4,4��6%   % 5�   "   �� 5�   &   $! 	0.991,0.5&�6:   $" 0.01,0.5&�6O   .��5�   *   � $# 	#00000000��67   $$ 0Q�6I   � 5�   *   $# 	#00060606��67   $$ 1Q�6I   � 5�   *   $# 	#D8020202��67   $
$ 0.49Q�6I   5�   '   ��5�   "   �� 5�   &   $! 	0.5,0.971&�6:   $" 	0.5,0.029&�6O   .��5�   *   � $# 	#99FDFDFD��67   $$ 0Q�6I   � 5�   *   $# 	#00FFFFFF��67   $$ 1Q�6I   � 5�   *   $# 	#4CFDFDFD��67   $$ 0.513Q�6I   5�   '   5�      �� 5�      $ 
HoverLayer��6<   $ 4,4,4,4��6%   $ 0Q�6P   $��1,1,1,1q�6\   ��6v   Z� ��5�   "   �� 5�   &   8  66   ._�5�   "   �� $ 
HoverInner��6Z   $ 3,3,3,3��6)   $��1,1,1,1q�6@   ��5�   &   �� 5�   *   8  6:   5�   #   5�      �� 5�      $ DefaultLayer��6%   $��1,1,1,1q�6;   $ 4,4,4,4��6U   $ 0Q�6l     5�   "     5�   &   8&  $
' 0.65Q�6Z   $( 10Q�6i   ��5�   "   �� 5�   &   8  66   5�      �� 5�      $) contentPresenter��6�   #��z��6/   #��z��6r   ��. $��4,-2,4,2q�6�     5�   "     5�   &   8&  $' 0Q�6[   5�      5�      * 5�      P� 5�      + �@J�IsKeyboardFocused, . 6C   P� 5�      + �@J�IsMouseOver, . - 5�   "   �� 5�   &   $. HoverOff_BeginStoryboard��6]   8��	 / 5�   "   �� 5�   &   $. HoverOn_BeginStoryboard��6\   8��
 5�      P� 5�      + � ��, . - 5�   "   �� 5�   &   $ . PressedOff_BeginStoryboard��6_   8�� / 5�   "   �� 5�   &   $. PressedOn_BeginStoryboard��6^   8�� 5�      P� 5�      + � {�, . 6;   P� 5�      + � {�, .  . �5�   "   �� 8   � ��6?   5�      5�      5�      5�      �� 5�   
   .R�5�      �� 
�������$��1q�6(   $��Stretch=�6<   ���	#01000000._�5�      � .+�5�      �� $
��Left=�6   $��5q�67   $	��115��6B   $	��100��6Q   ��6^   �� *	ThumbNail+�� 5�      $��5q�6   $��80��6'   $��80��62   $ Button not Linked.��6>   $
��Left=�6[   $ ��Resources/Images/Alert.png��6v   y�6�   �� *SlideToGuid+8   �� 5�      $0 
Horizontal=�6!   $��	135,5,5,5q�6:   $
��Left=�6M   .+�5�      �� $��Button Name: ��6$   $
 Left=�69   $��15(�6N   ��5�      �� 5�   "   8  62   5�      �� 5�      $
��Bold"�6@   $��CharacterEllipsis=�6R   $
 Left=�6s   $��15(�6�   ��6$   �� *
ButtonName+6�   5�      �� 5�      $0 
Horizontal=�6!   $��140,30,0,30q�6:   $
��Left=�6O   .+�5�      �� $��15(�6$   $��Navigates to: ��62   ��5�      �� 5�   "   8  62   5�      �� 5�      $
��Bold"�6?   $��15(�6Q   $��55��6_   $
��Wrap=�6n   $��CharacterEllipsis=�6�   ��6$   �� *	SlideName+6�   5�      �� 5�      $1 dtiDuration��6�   $��20(�6G   $��	0,10,10,0q�6U   $��Right=�6h   $ Duration��6�   $	��Top=�6�   ��6    �� *
Duration+$ OneWay=�6�   �� 5�      -   5        $
��Link��5�      8�� $��20(�6U   $	��100��6c   $��Right=�6o   $��Bottom=�6�   6�   5�      5�      5�      5      .��5     ]� .+�5  
   � $	��Top=�6   .+�5     � $
��Left=�6   $��24,5,0,0q�6.   $��Bottom=�6@   $	��190��6[   .+�5     �� -   5        2 ��Name$2 imgTouchscreenSlide��5     $��0��65   $��0,0,0,61q�6B   $	��120��6q   $	��187��6�   $��Center=�6�   $��Bottom=�6�   ��6T   �� *	ThumbNail+6�   #   Infragistics.ToyBox.Reflector  5     $��1��6\   $��0,0,0,0q�6i   $	��187��6z   $��60��6�   $��Bottom=�6�   $��Center=�6�   3   ReflectionTarget3 6   �� 4 �� ElementName$4 imgTouchscreenSlide��5     5     �� 5     $
 Left=�6   $��16(�6C   $
��Bold"�6Q     
Foreground#���  6c   $��CharacterEllipsis=�6�   $��231,12,28,0q�6�   $��55��6�   $	��Top=�6�   ��6-   �� *Name+6�   ,� 5	     $��
231,36,0,0q�6'   $	��124��6;   $	��Top=�6�   y�6H   �� 5 �� Path$5 HasTouchElements�# [ .��5
     /� .T�5     J� 
�������$��18(�63   .*�6A   .*�5     �� $�There are (��6    �� 5     �6   �� $5 Buttons.Count�$ OneTime=� �� 5     $��{) button(s) located on this slide. Click the Link button(s) below to choose the slides that the buttons should navigate to.��6   5     5     5     �� 5     $ Right=�6~   $0��*There were no buttons found on this slide.��6�   $��17(�6�   $
��Bold"�6�   #���  6�   $��Right=�6  $	��Top=�6,  $��	0,50,0,10q�6D  y�6   �� $5 HasTouchElements�# [ 6D  �� 5     $��Buttons��6   $��16(�6'   $
��Bold"�65   #���  6G   $��CharacterEllipsis=�6q   $��16,0,0,0q�6�   $��25��6�   $��Bottom=�6�   $
��Left=�6�   �� 5     -   5        $��btnSave��5  j   $��31��6   $��	0,0,146,3q�6!     Inspire.ButtonImage6   Image$6 Resources/Images/Ok16.png��64   $��Bottom=�6y   $	��128��6�   $��Right=�6�   $
��Save��6�   &   Inspire.Commands.InspireCommands$7   SaveTouchscreenButtonsCommand#��Z7 6�   �� 5     -   5        $��	btnCancel��5  �   $��31��6   $��Right=�6!   $��0,0,10,3q�6=   $#6 Resources/Images/Cancel16.png��6O   $��Bottom=�6�   $	��128��6�   $��Cancel��6�   &8   CancelTouchscreenButtonsCommand#��Z8 6�   5     �� 5  
   -   5        9 ��Name$9 lbTouchscreenSlides��5     $��Bottom=�6/   #���   6X   $��Stretch=�6�   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   ��6G   Z� 5     5     5     