   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  Q MFlightInfoModule.Proxy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:FlightInfoModule.Proxy;assembly=FlightInfoModule.ProxyFlightInfoModule.Proxy a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  FlightInfoModule#   FlightInfoModule.AirlinePanel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :Inspire&clr-namespace:Inspire;assembly=Inspire     VProxyDclr-namespace:FlightInfoModule.Proxy;assembly=FlightInfoModule.Proxy     oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero       J� IsHitTestVisible  .  � 	Resources $   Inspire.NullToVisibleConverter   nullToVisibleConverter&    Inspire.NullToCollapsedConverter  nullToCollapsedConverter  GlassBorderStyle �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset3  -System.Windows.Media.Effects.DropShadowEffect	   
BlurRadius
   ShadowDepth   Opacity  BtnClearStyle �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius J� Opacity �� Triggers P� Property P� Value �� 
TargetName  ButtonOverBackground  ButtonPressedBackground  ScrollTemplate �Name � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll ��Name � Cursor* �� #ComputedVerticalScrollBarVisibility4  .System.Windows.Automation.AutomationProperties    AutomationId! �� ScrollableHeight" � Maximum# � Minimum$ �� ViewportHeight% �� ViewportSize  TouchScrollBar& � Value' �� Mode( �� RelativeSource,) �� %ComputedHorizontalScrollBarVisibility* �� ScrollableWidth+ �� Orientation, �� ViewportWidth  VerticalScrollBarBackground 	 ScrollBarDisabledBackground- �� Color 
 ScrollBarButtonTop  ScrollBarButtonBottom  VerticalScrollBarPageButton  ScrollBarThumb ! HorizontalScrollBarBackground ! HorizontalScrollBarPageButton. ]�Name/ J� IsMouseOver0 ]� DecreaseRepeatButton1 �� PageUpCommand2 ]� IncreaseRepeatButton3 �� PageDownCommand4 ]� Thumb+  %Microsoft.Windows.Themes.ScrollChrome5   ScrollGlyph6 �� LineUpCommand7 �� LineDownCommand8 �� Triggers9 �� LineLeftCommand: �� PageLeftCommand; �� PageRightCommand< �� LineRightCommand= �� DataType$  FlightInfoModule.Proxy.Airline  airlineTemplate> �� TextAlignment? �� 	Converter@ �� BitmapScalingModeA �� NotifyOnTargetUpdated��%�  &	        &	      &	 
     &	     &	 2    &	 �    &		 b    &	
 u    &	 �    &	 �	    &	 �
    &	     &	 �    &	 Z    7  7  7  7  7 
 7  7 	 7  7 
 7  7  7  7  7 	 &	 �    7  7  7   7      �� " ��.���  � ��$ 2q���  �@��CornerRadius$ 10,10,10,10����  � �� �� $ 0.75,1&�$ 0.25,0&�.��� $ 	#33FFFFFF��$ 0Q�� $ 	#C0FFFFFF��$ 0.287Q�� $ 	#4011322D��$ 0.683Q�� $ 	#33FFFFFF��$ 1Q���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#5811322D��$ 0Q�� $ 	#3EFFFFFF��$
 0.25Q�� $ 	#FFFFFFFF��$	 0.5Q�� $ 	#3EFFFFFF��$
 0.75Q�� $ 	#BFFFFFFF��$ 1Q���  �@J�Effect   $	 3Q�$
 3Q�$	 0.5Q��� " ��.���  � ��
 ���� ��  � ��$ 0q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� .+��� $ Chrome�� . #��z��#��z��#��z��$ 2��$ 0Q��� # z #��z��#��z��#��z����.  P�  �@J�IsMouseOver . . ��� $ Chrome�� �@J�Opacity$ 1Q��� $ Chrome��# �   � ��P�  � �� . . ��� $ Chrome�� �@J�Opacity$ 1Q��� $ Chrome��# �   � ��P�  � {� .  . ���  � �� �#ADADAD�� " ��.R�� $
 Grid��
������  �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $ Corner��#��� ��$��1��$��1���� $! PART_ScrollContentPresenter��#��z��$��0��$��0��#��z��#��z��# z�� .   .  �� $ PART_VerticalScrollBar�����	#0CDADADA$ Arrow��#y�z $��1��$��0��$  VerticalScrollBar��#" z! $# 0Q�#% z$ #���  $	 0.6Q�& �� *VerticalOffset+$' OneWay=�( �� *TemplatedParent+�� $ PART_HorizontalScrollBar��$ Arrow��#y�z) $��0��$��1��$  HorizontalScrollBar��#" z* $# 0Q�$+ 
Horizontal=�#% z, & �� *HorizontalOffset+$' OneWay=�( �� *TemplatedParent+�� $	 1,0&�$	 0,0&�.��� $ #E1E1E1��$ 0Q�� $ #EDEDED��$
 0.20Q�� $ #EDEDED��$
 0.80Q�� $ #E3E3E3��$ 1Q��� $- #F4F4F4���� " ��.���  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� ���	#7F000000$ 	15,15,0,0��._�� .+��� $
��Bold"�$��Center=�$��Center=�$��35(�+�� $
��Bold"�$��1,1,0,0q�
�������$��Center=�$��Center=�$��35(�+�� " ��.���  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� ���	#7F000000$ 	0,0,15,15��._�� .+��� $
��Bold"�$��0,0,0,10q�$��Center=�$��Center=�$��35(�-�� $
��Bold"�$��1,1,0,10q�
�������$��Center=�$��Center=�$��35(�-�� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� #��z��#��z��#��z���� " n�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � �� �� " n�.R��� ���	#99EBEBEC�� $	 0,1&�$	 0,0&�.��� $ #E1E1E1��$ 0Q�� $ #EDEDED��$
 0.20Q�� $ #EDEDED��$
 0.80Q�� $ #E3E3E3��$ 1Q��� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� #��z��#��z��#��z���� " ��.���  � ��8   ��  �@��IsPressAndHoldEnabled .  ��  �@��IsFlicksEnabled .  ��  � ��# � ����  � ��$ 50����  � ��# � r���  � �� �� " ��.R��� $��10q�$ .6Q�$ 10��._�� $ Bg�� . #��z�� �� $��50 ��� $��0.00001* ��� $��40 �.+�]� $. 
PART_Track��#{�z/ $��1����. 0 �� ���	#7F0000008�� #��Z1 2 �� ���	#7F0000008�� #��Z3 4 n� 8�� ���	#FF807171�� 8�� #{�z/ $5 UpArrow=�#��Z6 �� 8�� #{�z/ $��2��$5 	DownArrow=�#��Z7  P�  � {� .  . ��� $ Bg��8   � ��8 P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��# � ����  � ��# � ����  � ��8  ��  � �� �� " ��.R�� $ Bg�� . #��z�� �� #��� ���� $��0.00001* ��� #��� ��.+��� 8�� #{�z/ $5 	LeftArrow=�#��Z9 ]� $. 
PART_Track��#{�z/ $��1��0 �� 8��	 #��Z: 2 �� 8��
 #��Z; 4 n� 8�� $5 HorizontalGripper=��� 8�� #{�z/ $��2��$5 
RightArrow=�#��Z<  P�  � {� .  . ��� $ Bg��8   � ���� "=  .R��� -   
������ 
������ $��20q�$	��200��8��  .���� 8�� ._��   .  .+��� $��8q�$��22(�
�������$> Center=�$��Center=�y��� *
ImageUrl+8?  ���� *Name+�� $@ 
LowQuality=�$��15q�y��� *
ImageUrl+8?  ���� *
ImageUrl+$' OneWay=�A . .��� .+��� $
��Auto=�#���  .���� -   B ��Name$B 
lvAirlines��C � IsSharedSizeScopeC . #��[ ���� .R�� 