   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5      e aActiproSoftware.Ribbon.Wpf30, Version=4.5.477.0, Culture=neutral, PublicKeyToken=36ff2196ab5654b9�dclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Controls;assembly=ActiproSoftware.Ribbon.Wpf300ActiproSoftware.Windows.Controls.Ribbon.Controls 6E   �[clr-namespace:ActiproSoftware.Windows.Controls.Ribbon;assembly=ActiproSoftware.Ribbon.Wpf30'ActiproSoftware.Windows.Controls.Ribbon 6�   ^ ZDevComponents.WpfRibbon, Version=5.8.0.6, Culture=neutral, PublicKeyToken=2037e151916410e7bFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbonDevComponents.WpfRibbon 6&   FlightInfoModule$   FlightInfoModule.PropertyPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      yControlsdclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Controls;assembly=ActiproSoftware.Ribbon.Wpf30     6E   nRibbon[clr-namespace:ActiproSoftware.Windows.Controls.Ribbon;assembly=ActiproSoftware.Ribbon.Wpf30     6�   \	WpfRibbonFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbon     6&  .��5      �� -   5          ��Name$
  grid��5   �   $��	0,0,-15,0q�6      SunkenBackground#��[  6    $��Right=�6O    J� RenderTransformOrigin$ 0.5,0.5&�6k   $	��260��6�   z�5   
   V� 5      .~�5	      ��  �� ScaleX$ 1Q�6!    �� ScaleY$ 1Q�6,   �� 5
       �� AngleX$ 0Q�6     �� AngleY$ 0Q�6+   �� 5       �� Angle$ 0Q�6"   T� 5       T� X$ 0Q�6%    T� Y$ 0Q�6+   5      ._�5   
   �� $��5q�6   $��Stretch=�6    #��[  6>   .+�5         Inspire.PropertyBase  -   5        $��propBase��5   #   $��5,5,10,5q�63   9� 5      	 9� 
IsExpanded	 . $��2��6)   $	��236��66   $��0,5,0,5q�6B   $#��Flight Information Properties��6S   .��5      � 
 � ColumnDefinitions
 5      �� 5      $	��120 �6+   �� 5      $
��130* �6+   .+�5      ��  �� Orientation$ Vertical=�6!   $��0��68   .+�5      �� $��25��6    $��5q�6,   $	��Top=�67   
�������$��Right=�6b   $��Center=�6�   $��Right=�6�   .��6�   Airport Code:6�   �� 5      $��25��6    $��5q�6,   $	��Top=�67   
�������$��Right=�6b   $��Center=�6�   $��Right=�6�   .��6�   Style:6�   �� 5      $��25��6    $��5q�6,   $	��Top=�67   
�������$��Right=�6b   $��Center=�6�   $��Right=�6�   .��6�   
Animation:6�   �� 5      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Show Header:6�   �� 5      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Name (No Image):6�   �� 5      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Touchscreen:6�   �� 5      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Seconds Per Page:6�   �� 5      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Row Height:6�   �� 5       $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Background Color 1:6�   �� 5!      $��5q�6    $��Right=�6,   $��25��6O   $	��Top=�6[   
�������$��Center=�6�   $��Right=�6�   .��6�   Background Color 2:6�   �� 5"      -   5        $��lblAdvanceSlide��5"       $��2,5,0,0q�67   $��28��6H   $	��Top=�6T   $��Right=�6s   .��6�   Advance after loops:6�   �� 5#      -   5        $��lblNumLoops��5#   +   $��5q�6    $��28��6>   $	��Top=�6J   $��Right=�6i   .��6�   Number of loops:6�   5$      �� 5%      $��1��6!   .+�5&      �� -   5        $��tbAirportCode��5&   e   $��Center=�6"   $��5q�6z   $��25��6�   $	��Top=�6�   �� 5'      -   5         ��Name$ 
cbRowStyle��5'   #   $	��Top=�67   $��5q�6O   $��25��6Z    �� Text 6f   �� *Content.Content.FlightStyle+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5)      -   5        $ cbPanelAnimation��5)   #   $	��Top=�6=   $��5q�6U   $��25��6`    6l   �� * Content.Content.PanelAnimation+$ OneWay=�$ PropertyChanged=�6�   �� 5*      -   5         ��Name$ cbShowHeader��5*   #   $	��Top=�6�   $��5q�6�   $��25��6�    d� 	IsChecked 69   �� *31Content.Content.Content.FlightTemplate.ShowHeader+$ TwoWay=�$ PropertyChanged=�6�   �� 5+      -	   5        $ cbShowNameInsteadOfImage��5+   #    � ToolTip$V PShows Airline Name instead of image. A save is required for this to take affect.��6E   $	��Top=�6  $��5q�65  $��25��6@   6�   �� *64Content.Content.FlightRequest.ShowNameInsteadOfImage+$ TwoWay=�$ PropertyChanged=�6@  �� 5,      -
   5        $ cbTouchscreen��5,   #   {�.  $	��Top=�6�   $��5q�6�   $��25��6�    6L   �� *'%Content.Content.Content.IsTouchscreen+$ OneWay=�$ PropertyChanged=�6�   �� 5-      -   5        $��tbSecondsPerPage��5-   �   $��Center=�6"   $��5q�6�   $��25��6�   $	��Top=�6�   ��6D   �� * Content.Content.SecondsPerPage+$ TwoWay=�$ PropertyChanged=�6�   �� 5.      -   5        $��tbRowHeight��5.   �   $��Center=�6"   $��5q�6�   $��25��6�   $	��Top=�6�   ��6D   �� *53Content.Content.Content.FlightTemplate.FlightHeight+$ TwoWay=�$ PropertyChanged=�6�   �� 5/      $
��Left=�6!   $��1q�6<   
���   �  CheckerBrush#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�50      �� -   5         ��Name$ btnBg1Color��50   (   $��20��6=   $��20��6H   $
��Left=�6r   ��6�   Z� ��6�   ��  �� Path$= 7Content.Content.Content.FlightTemplate.BackgroundColor1�$ OneWay=�$ PropertyChanged=�51      �� 52      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�53      �� -   5        $ btnBg2Color��53   (   $��20��6=   $��20��6H   $
��Left=�6r   ��6�   Z� ��6�   �� $= 7Content.Content.Content.FlightTemplate.BackgroundColor2�$ OneWay=�$ PropertyChanged=�54      �� 55      -   5        $��cbAdvanceSlide��55   .   $��5q�6#   $
��Left=�6�   $��Bottom=�6�   $��13��6�   $��13��6�    6D   �� *Content.Content.AdvanceOnEnd+$ TwoWay=�$ PropertyChanged=�6�   �� 56      -   5        $��cbLoops��56   .   $��5q�6#   $
��23.5��6�   $��36��6�   $��Bottom=�6�   $
��Left=�6�    6=   �� *#!Content.Content.AdvanceAfterLoops+$ TwoWay=�$ PropertyChanged=�.@�57      �� $��1��6+   �� 58      $��2��6+   �� 59      $��3��6+   �� 5:      $��4��6+   �� 5;      $��5��6+   �� 5<      $��6��6+   �� 5=      $��7��6+   �� 5>      $��8��6+   5?      5@      5A      5B      9� 5C      	 .  $��2��6*   $	��236��67   $��0,5,0,5q�6C   $��Header Properties��6T   .��5D      � 
 5E      �� 5F      $	��120 �6+   �� 5G      $
��130* �6+   .+�5I      �� $ Vertical=�6!   $��0��68   .+�5J      �� $��25��6    $��5q�6,   $	��Top=�67   
�������$��Right=�6b   $��Center=�6�   $��Right=�6�   .��6�   Background Color:6�   �� 5K      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   	Height:6�   �� 5L      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Size:6�   �� 5M      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Font Color:6�   �� 5N      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Type:6�   5O      �� 5P      $��1��6!   .+�5Q      �� $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5R      �� -   5        $ btnHdrBgColor��5R   (   $��20��6?   $��20��6J   $
��Left=�6t   ��6�   Z� ��6�   �� $= 7Content.Content.Content.FlightTemplate.HeaderBackground�$ OneWay=�$ PropertyChanged=�5S      �� 5T      $��Center=�6"   $��25��6�   $	��Top=�6�   $��5q�6�   ��6D   �� $9 3Content.Content.Content.FlightTemplate.HeaderHeight�$ TwoWay=�$ PropertyChanged=�6�   �� 5U      $��Center=�6"   $��5q�6�   $��25��6�   $	��Top=�6�   ��6D   �� $; 5Content.Content.Content.FlightTemplate.HeaderFontSize�$ TwoWay=�$ PropertyChanged=�6�   �� 5V      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5W      �� -   5        $ btnHdrFontColor��5W   (   $��20��6A   $��20��6L   $
��Left=�6v   ��6�   Z� ��6�   �� $= 7Content.Content.Content.FlightTemplate.HeaderForeground�$ OneWay=�$ PropertyChanged=�5X      I  CActiproSoftware.Windows.Controls.Ribbon.Controls.FontFamilyComboBox  5Y      -   5          Name$ cbHeaderFontStyle��5Y   6     FontComboBox#��[ 6�     	TextBrush#��[ 6   $	��Top=�62  $��5q�6J  $��25��6U   �� SelectedValue 6Q   �� $= 7Content.Content.Content.FlightTemplate.HeaderFontFamily�$ TwoWay=�$ PropertyChanged=�6U  5Z      5[      5\      9� 5]      	 .  $��2��6*   $	��236��67   $��0,5,0,5q�6C   $��Airline Field Properties��6T   .��5^      � 
 5_      �� 5`      $	��120 �6+   �� 5a      $
��130* �6+   .+�5c      �� $ Vertical=�6!   $��0��68   .+�5d      �� $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Width:6�   �� 5e      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Font Color:6�   �� 5f      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Type:6�   5g      �� 5h      $��1��6!   .+�5i      �� -   5        $��Center=�5i   "   $��25��6�   $	��Top=�6�   $��5q�6
  ��6f   �� $= 7Content.Content.Content.FlightTemplate.FlightImageWidth�$ TwoWay=�$ PropertyChanged=�6
  �� 5j      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5k      �� -   5        $ btnAirlineNameFontColor��5k   (   $��20��6I   $��20��6T   $
��Left=�6~   ��6�   Z� ��6�   �� $B <Content.Content.Content.FlightTemplate.AirlineNameForeground�$ OneWay=�$ PropertyChanged=�5l        5m      -   5        $ cbAirlineNameFontStyle��5m   6   $	��Top=�6�   $��5q�6�   $��25��6  #��[ 6  #��[ 69   6V   �� $B <Content.Content.Content.FlightTemplate.AirlineNameFontFamily�$ TwoWay=�$ PropertyChanged=�69  5n      5o      5p      9� 5q      	 .  $��2��6*   $	��236��67   $��0,5,0,5q�6C   $"��Destination Field Properties��6T   .��5r      � 
 5s      �� 5t      $	��120 �6+   �� 5u      $
��130* �6+   .+�5w      �� $ Vertical=�6!   $��0��68   .+�5x      �� $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Width:6�   �� 5y      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Size:6�   �� 5z      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Font Color:6�   �� 5{      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Type:6�   5|      �� 5}      $��1��6!   .+�5~      �� -   5        $��Center=�5~   "   $��25��6�   $	��Top=�6�   $��5q�6  ��6f   �� $A ;Content.Content.Content.FlightTemplate.DestinationCityWidth�$ TwoWay=�$ PropertyChanged=�6  �� 5      -   5        $��Center=�5   "   $��5q�6�   $��25��6�   $	��Top=�6  ��6f   �� $D >Content.Content.Content.FlightTemplate.DestinationCityFontSize�$ TwoWay=�$ PropertyChanged=�6  �� 5�      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5�      �� -   5        $! btnDestinationCityFontColor��5�   (   $��20��6M   $��20��6X   $
��Left=�6�   ��6�   Z� ��6�   �� $F @Content.Content.Content.FlightTemplate.DestinationCityForeground�$ OneWay=�$ PropertyChanged=�5�        5�      -   5        $  cbDestinationCityFontStyle��5�   6   $	��Top=�6�   $��5q�6  $��25��6  #��[ 6  #��[ 6A   6Z   �� $F @Content.Content.Content.FlightTemplate.DestinationCityFontFamily�$ TwoWay=�$ PropertyChanged=�6A  5�      5�      5�      9� 5�      	 .  $��2��6*   $	��236��67   $��0,5,0,5q�6C   $#��Arrival Time Field Properties��6T   .��5�      � 
 5�      �� 5�      $	��120 �6+   �� 5�      $
��130* �6+   .+�5�      �� $ Vertical=�6!   $��0��68   .+�5�      �� $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Width:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Size:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Font Color:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Type:6�   5�      �� 5�      $��1��6!   .+�5�      �� -   5        $��Center=�5�   "   $��25��6�   $	��Top=�6�   $��5q�6  ��6f   �� $J DContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureWidth�$ TwoWay=�$ PropertyChanged=�6  �� 5�      -   5        $��Center=�5�   "   $��5q�6�   $��25��6  $	��Top=�6  ��6f   �� $M GContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureFontSize�$ TwoWay=�$ PropertyChanged=�6  �� 5�      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5�      �� -   5        $/ )btnScheduleArrivalDepartureWidthFontColor��5�   (   $��20��6[   $��20��6f   $
��Left=�6�   ��6�   Z� ��6�   �� $O IContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureForeground�$ OneWay=�$ PropertyChanged=�5�        5�      -   5        $. (cbScheduleArrivalDepartureWidthFontStyle��5�   6   #��[ 6  #��[ 6)  $	��Top=�6[  $��5q�6s  $��25��6~   6h   �� $O IContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureFontFamily�$ TwoWay=�$ PropertyChanged=�6~  5�      5�      5�      9� 5�      	 .  $��2��6*   $	��236��67   $��0,5,0,5q�6C   $��Status Field Properties��6T   .��5�      � 
 5�      �� 5�      $	��120 �6+   �� 5�      $
��130* �6+   .+�5�      �� $ Vertical=�6!   $��0��68   .+�5�      �� $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Width:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Size:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Font Color:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Type:6�   5�      �� 5�      $��1��6!   .+�5�      �� -   5        $��Center=�5�   "   $��25��6�   $	��Top=�6�   $��5q�6  ��6f   �� $8 2Content.Content.Content.FlightTemplate.StatusWidth�$ TwoWay=�$ PropertyChanged=�6  �� 5�      -    5        $��Center=�5�   "   $��5q�6�   $��25��6�   $	��Top=�6�   ��6f   �� $; 5Content.Content.Content.FlightTemplate.StatusFontSize�$ TwoWay=�$ PropertyChanged=�6�   �� 5�      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5�      �� -!   5        $ btnStatusFontColor��5�   (   $��20��6D   $��20��6O   $
��Left=�6y   ��6�   Z� ��6�   �� $= 7Content.Content.Content.FlightTemplate.StatusForeground�$ OneWay=�$ PropertyChanged=�5�        5�      -"   5        $ cbStatusFontStyle��5�   6   #��[ 6�   #��[ 6   $	��Top=�62  $��5q�6J  $��25��6U   6Q   �� $= 7Content.Content.Content.FlightTemplate.StatusFontFamily�$ TwoWay=�$ PropertyChanged=�6U  5�      5�      5�      9� 5�      	 .  $��2��6*   $	��236��67   $��0,5,0,5q�6C   $$��Flight Number Field Properties��6T   .��5�      � 
 5�      �� 5�      $	��120 �6+   �� 5�      $
��130* �6+   .+�5�      �� $ Vertical=�6!   $��0��68   .+�5�      �� $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Width:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Size:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Font Color:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Type:6�   5�      �� 5�      $��1��6!   .+�5�      �� -#   5        $��Center=�5�   "   $��25��6�   $	��Top=�6�   $��5q�6  ��6f   �� $> 8Content.Content.Content.FlightTemplate.FlightNumberWidth�$ TwoWay=�$ PropertyChanged=�6  �� 5�      -$   5        $��Center=�5�   "   $��5q�6�   $��25��6�   $	��Top=�6  ��6f   �� $A ;Content.Content.Content.FlightTemplate.FlightNumberFontSize�$ TwoWay=�$ PropertyChanged=�6  �� 5�      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5�      �� -%   5        $ btnFlightNumberFontColor��5�   (   $��20��6J   $��20��6U   $
��Left=�6   ��6�   Z� ��6�   �� $C =Content.Content.Content.FlightTemplate.FlightNumberForeground�$ OneWay=�$ PropertyChanged=�5�        5�      -&   5        $ cbFlightNumberFontStyle��5�   6   #��[ 6�   #��[ 6  $	��Top=�6>  $��5q�6V  $��25��6a   6W   �� $C =Content.Content.Content.FlightTemplate.FlightNumberFontFamily�$ TwoWay=�$ PropertyChanged=�6a  5�      5�      5�      9� 5�      	 .  $��2��6*   $	��236��67   $��0,5,0,5q�6C   $"��Flight Gate Field Properties��6T   .��5�      � 
 5�      �� 5�      $	��120 �6+   �� 5�      $
��130* �6+   .+�5�      �� $ Vertical=�6!   $��0��68   .+�5�      �� $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Width:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Size:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   Font Color:6�   �� 5�      $��5q�6    $��Right=�6+   $��25��6N   $	��Top=�6Z   
�������$��Center=�6�   $��Right=�6�   .��6�   
Font Type:6�   5�      �� 5�      $��1��6!   .+�5�      �� -'   5        $��Center=�5�   "   $��25��6�   $	��Top=�6�   $��5q�6	  ��6f   �� $< 6Content.Content.Content.FlightTemplate.FlightGateWidth�$ TwoWay=�$ PropertyChanged=�6	  �� 5�      -(   5        $��Center=�5�   "   $��5q�6�   $��25��6�   $	��Top=�6�   ��6f   �� $? 9Content.Content.Content.FlightTemplate.FlightGateFontSize�$ TwoWay=�$ PropertyChanged=�6�   �� 5�      $
��Left=�6!   $��1q�6<   
���   �#��[ 6d   $��22��6�   $��22��6�   $��Bottom=�6�   $��5q�6�   ._�5�      �� -)   5        $ btnFlightGateFontColor��5�   (   $��20��6H   $��20��6S   $
��Left=�6}   ��6�   Z� ��6�   �� $A ;Content.Content.Content.FlightTemplate.FlightGateForeground�$ OneWay=�$ PropertyChanged=�5�        5�      -*   5        $ cbFlightGateFontStyle��5�   6   #��[ 6�   #��[ 6  $	��Top=�6:  $��5q�6R  $��25��6]   6U   �� $A ;Content.Content.Content.FlightTemplate.FlightGateFontFamily�$ TwoWay=�$ PropertyChanged=�6]  5�      5�      5�      5�      5�      5�      