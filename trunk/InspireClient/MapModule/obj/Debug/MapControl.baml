   M S B A M L   `   `   `  ����U  QInfoStrat.VE.Windows7Touch, Version=2.2.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:InfoStrat.VE.Windows7Touch;assembly=InfoStrat.VE.Windows7TouchInfoStrat.VE.Windows7Touch  5   K   B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire 6�   H DTransitionals, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:Transitionals.Controls;assembly=TransitionalsTransitionals.Controls 6�   D @MapModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MapModule	MapModule 62  a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 6\  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows 5   �      MapModule.MapControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      fWindows7TouchLclr-namespace:InfoStrat.VE.Windows7Touch;assembly=InfoStrat.VE.Windows7Touch     6K   :Inspire&clr-namespace:Inspire;assembly=Inspire     6�   PControls;clr-namespace:Transitionals.Controls;assembly=Transitionals     6�   -	MapModuleclr-namespace:MapModule     62  oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     6\  Jsw;clr-namespace:System.Windows;assembly=PresentationFramework     5   �   -   5          � 	Resources  5      3   -InfoStrat.VE.Windows7Touch.Win7TouchVEPushPin �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 W� To	 g� Duration
 �� 
TargetName �� TargetProperty g� 	BeginTime ��Name �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle �� CenterX �� CenterY T� X T� Y �� CornerRadius J� Opacity J� RenderTransformOrigin � RowDefinitions �� 
StartPoint �� EndPoint � Color � Offset �� Path  MapModule.DynamicMarker  MapModule.DynamicMarker    	TouchDown!   	MouseDown"   SelectedTemplate#   Title$ J� Effect3  -System.Windows.Media.Effects.DropShadowEffect%   ShadowDepth&   
BlurRadius   CheckBoxStroke' �� Color  CheckRadioFocusVisual( �� StrokeDashArray) J� SnapsToDevicePixels  RadioButtonStyle1* �� Triggers+ P� Property, P� Value  ButtonFocusVisual  ButtonNormalBackground  ButtonNormalBorder  ButtonStyle1+  %Microsoft.Windows.Themes.ButtonChrome-  Name.   BorderBrush/ �� IsDefaulted0   RenderDefaulted1 J� IsMouseOver2   RenderMouseOver3   RenderPressed4   
Background5 �� 
TargetName��%�  '        &	  �    &	     &	 �    7   7  &	 �    &	 W    &	 K    &	 n    7  7  7  �� 5   
   "  6   .�5	      ��  � �� 5
      �� 5      "  6&   .R�5      ��  5        5   "   
SizeStates��. 5   &     
Normal��65     5   &   
State1��. 5   .   �� .��5   2   W� $ 1X�6B   $	 	0:00:00.2D�6I   $
 myContentPresenter��6^   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6�   W� 5   2   $	 1.2X�6B   $	 	0:00:00.2D�6K   $
 myContentPresenter��6`   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6�   W� 5   2   $ 1X�6B   $	 	0:00:00.2D�6I   $
 myContentPresenter��6^   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6�   W� 5   2   $	 1.2X�6B   $	 	0:00:00.2D�6K   $
 myContentPresenter��6`   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6�   W� 5   2   $ 0X�6B   $	 	0:00:00.2D�6I   $
 myContentPresenter��6^   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6�   W� 5   2   $	 -10X�6B   $	 	0:00:00.2D�6K   $
 myContentPresenter��6`   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6�   W� 5   .   $ 0X�6>   $	 	0:00:00.2D�6E   $
 myContentPresenter��6Z   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6�   W� 5   .   $	 -10X�6>   $	 	0:00:00.2D�6G   $
 myContentPresenter��6\   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6�   W� 5    .   $ 0X�6>   $	 	0:00:00.0D�6E   $
 myText��6Z   $ (UIElement.Opacity)�6y   W� 5!   2   $	 100X�6B   $	 	0:00:00.2D�6K   $ 
00:00:00.4X�6`   $
 myText��6w   $ (UIElement.Opacity)�6�   5"   /   5#   '     5$   &   
State2��. 5%   .   �� .��5,   2   W� $	 1.2X�6B   $	 	0:00:00.2D�6K   $
 myContentPresenter��6`   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6�   W� 5-   2   $ 1X�6B   $	 	0:00:00.2D�6I   $ 
00:00:00.4X�6^   $
 myContentPresenter��6u   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6�   W� 5.   2   $	 1.2X�6B   $	 	0:00:00.2D�6K   $
 myContentPresenter��6`   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6�   W� 5/   2   $ 1X�6B   $	 	0:00:00.2D�6I   $ 
00:00:00.4X�6^   $
 myContentPresenter��6u   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6�   W� 50   2   $	 -10X�6B   $	 	0:00:00.2D�6K   $
 myContentPresenter��6`   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6�   W� 51   2   $ 0X�6B   $	 	0:00:00.2D�6I   $
 myContentPresenter��6^   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6�   W� 52   .   $	 -10X�6>   $	 	0:00:00.2D�6G   $
 myContentPresenter��6\   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6�   W� 53   .   $ 0X�6>   $	 	0:00:00.2D�6E   $
 myContentPresenter��6Z   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6�   W� 54   .   $	 100X�6>   $	 	0:00:00.0D�6G   $
 myText��6\   $ (UIElement.Opacity)�6{   W� 55   2   $ 0X�6B   $	 	0:00:00.2D�6I   $
 myText��6^   $ (UIElement.Opacity)�6}   5:   /   5;   '   5<   #   .+�5>   "   �� $ myContentPresenter��6-   z�5?   &   V� 5@   *   ~�5B   2   �� $ 1Q�6A   $ 1Q�6L   �� 5C   2   $ 0Q�6@   $ 0Q�6K   �� 5D   2   $ 0Q�6B   $ 0Q�6L   $ 0Q�6X   T� 5E   2   $ 0Q�6E   $ 0Q�6K   5G   +   .+�5I   "   �� $��myText��5L      $ 5,5,5,5��5J      $��2,2,2,2q�5K      $ 0Q�5L   !   ���	#CB020202
�������$ 0.5,0.5&�5N      ._�5O   &   �  5P   *   �� 5Q   .   �� 5R   .   .+�5T   *   �� $��0��61   $ 4,4,0,0��6>   ��5U   .   �� 5V   2   $ 0.5,0&�6F   $ 0.5,1&�6Y   .��5W   6   � $ 	#08FFFFFF��6C   $ 0Q�6U   � 5X   6   $ 	#3FFFFFFF��6C   $ 1Q�6U   5Y   3   5[   +   �� 5\   *   $��2��64   $��Center=�6E   $��	10,5,10,5q�6`   $
��Bold"�6s   
���������6�   �� $
 Name�5]   '   5^   #     5_   "     DynamicMarker_TouchDown6:   ! DynamicMarker_MouseDown6^   " 6�   �� $ CategoryStyle�# 6�   �� $ LocationName�$ 5`   &     5a   "   $% 3Q�63   $& 6Q�6C   5c      5d      5e      5f      5h      5i      �� 5k      $' #8E8F8F��6+   �� 5l   "   .�5m   2   ��  � �� 5n   B   �� 5o   R   .R�5p   b   �� 
���   �$	( 1 2R�6{   $��1��6�   $��14,0,0,0q�6�   ) . 6�   5q   S   5s   3   5t   #   �� 5u   "   " 	�6B   .�5v   2   ��  � ��# � ��6O   �� 5w   2    � �� �	#B2F4F4F46O   �� 5x   2    � ��8   6P   �� 5y   2    � ��$ 1q�6T   �� 5z   2    � �� 5{   B   �� 5|   R   " 	�6b   .R�5}   b   �� #��z��6i   $ 10��6�   ._�5~   r   �� $��Center=�6�   $��10q�6�   $��Center=�6�   ��. 6�   5   c   * 5�   b   P� 5�   r   + � ��, . . �5�   �   �� 8   �@�FocusVisualStyle6�   �� 5�   �    � ��$ 4,0,0,0q�6�   5�   s   P� 5�   r   + � {�, .  . �5�   �   �� # � ��6�    � ��5�   s   P� 5�   r   + �@d�	IsChecked$
, trueY�6�   . �5�   �   ��  � ��
 ��  �6�   �� 5�   �    � ��
 �����6�   5�   s   5�   S   5�   3   5�   #   �� 5�   
   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� 
���   �$	( 1 2R�63   $��1��6I   $��2q�6]   ) . 6h   5�      5�      5�      �� 5�   
   $	 0,1&�6=   $	 0,0&�6L   .��5�      � $ #F3F3F3��6   $ 0Q�6+   � 5�      $ #EBEBEB��6   $	 0.5Q�6+   � 5�      $ #DDDDDD��6   $	 0.5Q�6+   � 5�      $ #CDCDCD��6   $ 1Q�6+   5�      �� 5�   
   $' 	#FF707070��65   �� 5�   
   " ��6%   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��$ 1q�60   �� 5�       � ��# � ��6+   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��$ 1q�6(   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�        $- Chrome��6@   ) . #. z��6k   #0 z/ 6�   #2 z1 6�   #3 z��6�   4 5�      �� 5�   "   $	 0,1&�66   $	 0,0&�6E   .��5�   &   � $ 	#19F3F3F3��63   $ 0Q�6E   � 5�   &   $ 	#4CEBEBEB��63   $	 0.5Q�6E   � 5�   &   $ 	#33DDDDDD��63   $	 0.5Q�6E   � 5�   &   $ 	#19CDCDCD��63   $ 1Q�6E   5�   #   ._�5�      �� #��z��6/   #��z��6r   #��z��6�   #) z) 6�   ��. 6  5�      * 5�      P� 5�      + �@J�IsKeyboardFocused, . . �5�   "   �� $5 Chrome��6D    �@ RenderDefaulted . 6X   5�      P� 5�      + �@d�	IsChecked$
, trueY�6H   . �5�   "   �� $5 Chrome��6B    �@ RenderPressed . 6V   5�      P� 5�      + � {�, .  . �5�   "   ��  � �� �#ADADAD6?   5�      5�      5�      5�      5�      .��5�      ]� -   5        6 ]�Name$6 PART_DockPanel��5�      ��. .+�5�   
   �� -   5        $ PART_SearchButton��5�      $
��Left=�60   $	��500��6K   $��Bottom=�6W   $	��100��6�   7 �� Orientation$7 
Horizontal=�6�     BarelyVisible#���  6�   .+�5�      �� $��30,0,0,0q�6   $!��Resources/Images/search.png��6&   $��80��6K   $ 1.221,0.013&�6V   �� 5�      $��	31,3,0,13q�6   $
��Wrap=�6,   $��Search��6@   $	��288��6N   $��60(�6Z   $
��Bold"�6h   
�������$��Center=�6�   $ 5�        5�      $% 3Q�6   $& 8Q�6.   5�      5�      .	  (Transitionals.Controls.TransitionElement	  5�   
   -   5        8 	 Name$8 PART_CategoryHolder��5�   ;   $
��Left=�6%   $	��500��6X   $��Stretch=�6d   � 5�   
   .+�5�      (� 9 (� Stretch$9 UniformToFill=�6   $��Center=�6.   $��Center=�6I   .��5�      �� -   5        : ��Name$: 	mapHolder��5�   #   5�      �� 5�      -   5        $ PART_MapMode��5�      $��0,11.556,9,0q�61   $	��Top=�6G   $��48��6_   $7 
Horizontal=�6k   $��Right=�6�   $��277.778��6�   .+�5�      	� -   5        ; 	�Name$; tglArial��5�      $
��Bold"�60   < 	� 	GroupName$< mapView��6B   = d� 	IsChecked$
= TrueY�6o   $��80��6�   $��5q�6�   #���  6�   $��Aerial��6�   	� 5�      -   5        $; 	tglHybrid��5�      $
��Bold"�61   $< mapView��6C   $��80��6p   #���  6{   $��5q�6�   $��Hybrid��6�   	� 5�      -	   5        $; tglRoad��5�      $
��Bold"�6/   $< mapView��6Z   $��80��6n   #���  6y   $��5q�6�   $
��Road��6�   5�      �� 5�      -
   5        $ PART_ZoomControls��5�      $��Right=�64   $��Bottom=�6P   $��10q�6k   .+�5�      �� -   5        
�������$��40��5�   A   $��Center=�6M   $
��Bold"�6q   $��25(�6�   $��Center=�6�   $��40��6�   #��[ 6�   .��6�   +6�   �� 5�      -   5        
�������$��40��5�   B   $��Center=�6N   $
��Bold"�6r   $��25(�6�   $��5q�6�   $��Center=�6�   $��40��6�   #��[ 6�   .��6�   -6�   5�      	  5�      -   5        $8 detailsHolder��5�   9   $��1��6)   $
��Left=�6P   $	��600��6k   $	��Top=�6w   $��10q�6�   5�      5�      5�      