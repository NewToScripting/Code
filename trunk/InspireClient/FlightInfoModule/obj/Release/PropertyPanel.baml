   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  e aActiproSoftware.Ribbon.Wpf30, Version=4.5.477.0, Culture=neutral, PublicKeyToken=36ff2196ab5654b9�dclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Controls;assembly=ActiproSoftware.Ribbon.Wpf300ActiproSoftware.Windows.Controls.Ribbon.Controls �[clr-namespace:ActiproSoftware.Windows.Controls.Ribbon;assembly=ActiproSoftware.Ribbon.Wpf30'ActiproSoftware.Windows.Controls.Ribbon ^ ZDevComponents.WpfRibbon, Version=5.8.0.6, Culture=neutral, PublicKeyToken=2037e151916410e7bFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbonDevComponents.WpfRibbon  FlightInfoModule$   FlightInfoModule.PropertyPanel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     yControlsdclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Controls;assembly=ActiproSoftware.Ribbon.Wpf30     nRibbon[clr-namespace:ActiproSoftware.Windows.Controls.Ribbon;assembly=ActiproSoftware.Ribbon.Wpf30     \	WpfRibbonFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbon     .���� -     ��Name$
  grid��$��	0,0,-15,0q�   SunkenBackground#��[  $��Right=� J� RenderTransformOrigin$ 0.5,0.5&�$	��260��z�V� .~���  �� ScaleX$ 1Q� �� ScaleY$ 1Q���  �� AngleX$ 0Q� �� AngleY$ 0Q���  �� Angle$ 0Q�T�  T� X$ 0Q� T� Y$ 0Q�._��� $��5q�$��Stretch=�#��[  .+�   Inspire.PropertyBase  -   $��propBase��$��5,5,10,5q�9� 	 9� 
IsExpanded	 . $��2��$	��236��$��0,5,0,5q�$#��Flight Information Properties��.��� 
 � ColumnDefinitions
 �� $	��120 ��� $
��130* �.+���  �� Orientation$ Vertical=�$��0��.+��� $��25��$��5q�$	��Top=�
�������$��Right=�$��Center=�$��Right=�.��Airport Code:�� $��25��$��5q�$	��Top=�
�������$��Right=�$��Center=�$��Right=�.��Style:�� $��25��$��5q�$	��Top=�
�������$��Right=�$��Center=�$��Right=�.��
Animation:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Show Header:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Name (No Image):�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Touchscreen:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Seconds Per Page:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Row Height:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Background Color 1:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Background Color 2:�� -   $��lblAdvanceSlide��$��2,5,0,0q�$��28��$	��Top=�$��Right=�.��Advance after loops:�� -   $��lblNumLoops��$��5q�$��28��$	��Top=�$��Right=�.��Number of loops:�� $��1��.+��� -   $��tbAirportCode��$��Center=�$��5q�$��25��$	��Top=��� -    ��Name$ 
cbRowStyle��$	��Top=�$��5q�$��25�� �� Text �� *Content.Content.FlightStyle+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $ cbPanelAnimation��$	��Top=�$��5q�$��25�� �� * Content.Content.PanelAnimation+$ OneWay=�$ PropertyChanged=��� -    ��Name$ cbShowHeader��$	��Top=�$��5q�$��25�� d� 	IsChecked �� *31Content.Content.Content.FlightTemplate.ShowHeader+$ TwoWay=�$ PropertyChanged=��� -	   $ cbShowNameInsteadOfImage�� � ToolTip$V PShows Airline Name instead of image. A save is required for this to take affect.��$	��Top=�$��5q�$��25�� �� *64Content.Content.FlightRequest.ShowNameInsteadOfImage+$ TwoWay=�$ PropertyChanged=��� -
   $ cbTouchscreen��{�.  $	��Top=�$��5q�$��25�� �� *'%Content.Content.Content.IsTouchscreen+$ OneWay=�$ PropertyChanged=��� -   $��tbSecondsPerPage��$��Center=�$��5q�$��25��$	��Top=����� * Content.Content.SecondsPerPage+$ TwoWay=�$ PropertyChanged=��� -   $��tbRowHeight��$��Center=�$��5q�$��25��$	��Top=����� *53Content.Content.Content.FlightTemplate.FlightHeight+$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �  CheckerBrush#��[ $��22��$��22��$��Bottom=�$��5q�._��� -    ��Name$ btnBg1Color��$��20��$��20��$
��Left=���Z� ����  �� Path$= 7Content.Content.Content.FlightTemplate.BackgroundColor1�$ OneWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -   $ btnBg2Color��$��20��$��20��$
��Left=���Z� ���� $= 7Content.Content.Content.FlightTemplate.BackgroundColor2�$ OneWay=�$ PropertyChanged=��� -   $��cbAdvanceSlide��$��5q�$
��Left=�$��Bottom=�$��13��$��13�� �� *Content.Content.AdvanceOnEnd+$ TwoWay=�$ PropertyChanged=��� -   $��cbLoops��$��5q�$
��23.5��$��36��$��Bottom=�$
��Left=� �� *#!Content.Content.AdvanceAfterLoops+$ TwoWay=�$ PropertyChanged=�.@��� $��1���� $��2���� $��3���� $��4���� $��5���� $��6���� $��7���� $��8��9� 	 .  $��2��$	��236��$��0,5,0,5q�$��Header Properties��.��� 
 �� $	��120 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� $��25��$��5q�$	��Top=�
�������$��Right=�$��Center=�$��Right=�.��Background Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��	Height:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Size:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Font Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Type:�� $��1��.+��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -   $ btnHdrBgColor��$��20��$��20��$
��Left=���Z� ���� $= 7Content.Content.Content.FlightTemplate.HeaderBackground�$ OneWay=�$ PropertyChanged=��� $��Center=�$��25��$	��Top=�$��5q����� $9 3Content.Content.Content.FlightTemplate.HeaderHeight�$ TwoWay=�$ PropertyChanged=��� $��Center=�$��5q�$��25��$	��Top=����� $; 5Content.Content.Content.FlightTemplate.HeaderFontSize�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -   $ btnHdrFontColor��$��20��$��20��$
��Left=���Z� ���� $= 7Content.Content.Content.FlightTemplate.HeaderForeground�$ OneWay=�$ PropertyChanged=�I  CActiproSoftware.Windows.Controls.Ribbon.Controls.FontFamilyComboBox  -     Name$ cbHeaderFontStyle��  FontComboBox#��[   	TextBrush#��[ $	��Top=�$��5q�$��25�� �� SelectedValue �� $= 7Content.Content.Content.FlightTemplate.HeaderFontFamily�$ TwoWay=�$ PropertyChanged=�9� 	 .  $��2��$	��236��$��0,5,0,5q�$��Airline Field Properties��.��� 
 �� $	��120 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Width:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Font Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Type:�� $��1��.+��� -   $��Center=�$��25��$	��Top=�$��5q����� $= 7Content.Content.Content.FlightTemplate.FlightImageWidth�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -   $ btnAirlineNameFontColor��$��20��$��20��$
��Left=���Z� ���� $B <Content.Content.Content.FlightTemplate.AirlineNameForeground�$ OneWay=�$ PropertyChanged=�  -   $ cbAirlineNameFontStyle��$	��Top=�$��5q�$��25��#��[ #��[  �� $B <Content.Content.Content.FlightTemplate.AirlineNameFontFamily�$ TwoWay=�$ PropertyChanged=�9� 	 .  $��2��$	��236��$��0,5,0,5q�$"��Destination Field Properties��.��� 
 �� $	��120 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Width:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Size:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Font Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Type:�� $��1��.+��� -   $��Center=�$��25��$	��Top=�$��5q����� $A ;Content.Content.Content.FlightTemplate.DestinationCityWidth�$ TwoWay=�$ PropertyChanged=��� -   $��Center=�$��5q�$��25��$	��Top=����� $D >Content.Content.Content.FlightTemplate.DestinationCityFontSize�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -   $! btnDestinationCityFontColor��$��20��$��20��$
��Left=���Z� ���� $F @Content.Content.Content.FlightTemplate.DestinationCityForeground�$ OneWay=�$ PropertyChanged=�  -   $  cbDestinationCityFontStyle��$	��Top=�$��5q�$��25��#��[ #��[  �� $F @Content.Content.Content.FlightTemplate.DestinationCityFontFamily�$ TwoWay=�$ PropertyChanged=�9� 	 .  $��2��$	��236��$��0,5,0,5q�$#��Arrival Time Field Properties��.��� 
 �� $	��120 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Width:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Size:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Font Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Type:�� $��1��.+��� -   $��Center=�$��25��$	��Top=�$��5q����� $J DContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureWidth�$ TwoWay=�$ PropertyChanged=��� -   $��Center=�$��5q�$��25��$	��Top=����� $M GContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureFontSize�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -   $/ )btnScheduleArrivalDepartureWidthFontColor��$��20��$��20��$
��Left=���Z� ���� $O IContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureForeground�$ OneWay=�$ PropertyChanged=�  -   $. (cbScheduleArrivalDepartureWidthFontStyle��#��[ #��[ $	��Top=�$��5q�$��25�� �� $O IContent.Content.Content.FlightTemplate.ScheduleArrivalDepartureFontFamily�$ TwoWay=�$ PropertyChanged=�9� 	 .  $��2��$	��236��$��0,5,0,5q�$��Status Field Properties��.��� 
 �� $	��120 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Width:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Size:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Font Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Type:�� $��1��.+��� -   $��Center=�$��25��$	��Top=�$��5q����� $8 2Content.Content.Content.FlightTemplate.StatusWidth�$ TwoWay=�$ PropertyChanged=��� -    $��Center=�$��5q�$��25��$	��Top=����� $; 5Content.Content.Content.FlightTemplate.StatusFontSize�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -!   $ btnStatusFontColor��$��20��$��20��$
��Left=���Z� ���� $= 7Content.Content.Content.FlightTemplate.StatusForeground�$ OneWay=�$ PropertyChanged=�  -"   $ cbStatusFontStyle��#��[ #��[ $	��Top=�$��5q�$��25�� �� $= 7Content.Content.Content.FlightTemplate.StatusFontFamily�$ TwoWay=�$ PropertyChanged=�9� 	 .  $��2��$	��236��$��0,5,0,5q�$$��Flight Number Field Properties��.��� 
 �� $	��120 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Width:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Size:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Font Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Type:�� $��1��.+��� -#   $��Center=�$��25��$	��Top=�$��5q����� $> 8Content.Content.Content.FlightTemplate.FlightNumberWidth�$ TwoWay=�$ PropertyChanged=��� -$   $��Center=�$��5q�$��25��$	��Top=����� $A ;Content.Content.Content.FlightTemplate.FlightNumberFontSize�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -%   $ btnFlightNumberFontColor��$��20��$��20��$
��Left=���Z� ���� $C =Content.Content.Content.FlightTemplate.FlightNumberForeground�$ OneWay=�$ PropertyChanged=�  -&   $ cbFlightNumberFontStyle��#��[ #��[ $	��Top=�$��5q�$��25�� �� $C =Content.Content.Content.FlightTemplate.FlightNumberFontFamily�$ TwoWay=�$ PropertyChanged=�9� 	 .  $��2��$	��236��$��0,5,0,5q�$"��Flight Gate Field Properties��.��� 
 �� $	��120 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Width:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Size:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��Font Color:�� $��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�.��
Font Type:�� $��1��.+��� -'   $��Center=�$��25��$	��Top=�$��5q����� $< 6Content.Content.Content.FlightTemplate.FlightGateWidth�$ TwoWay=�$ PropertyChanged=��� -(   $��Center=�$��5q�$��25��$	��Top=����� $? 9Content.Content.Content.FlightTemplate.FlightGateFontSize�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��1q�
���   �#��[ $��22��$��22��$��Bottom=�$��5q�._��� -)   $ btnFlightGateFontColor��$��20��$��20��$
��Left=���Z� ���� $A ;Content.Content.Content.FlightTemplate.FlightGateForeground�$ OneWay=�$ PropertyChanged=�  -*   $ cbFlightGateFontStyle��#��[ #��[ $	��Top=�$��5q�$��25�� �� $A ;Content.Content.Content.FlightTemplate.FlightGateFontFamily�$ TwoWay=�$ PropertyChanged=�