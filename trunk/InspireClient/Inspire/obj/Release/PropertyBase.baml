   M S B A M L   `   `   `  ���� H  DEffectLibrary, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:EffectLibrary;assembly=EffectLibraryEffectLibrary  B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:InspireInspire    Inspire.PropertyBase   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     LEffectLibrary2clr-namespace:EffectLibrary;assembly=EffectLibrary     )Inspireclr-namespace:Inspire       � 	Resources  #  Inspire.ColorToBrushConverter   clrToBrushConverter  TBBindStyle �� 
TargetType �� Property �� Value  
Foreground-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name  SunkenBackground �� CornerRadius  	Highlight 
 Shadow ��Name �� Triggers	 P� Property
 P� Value  DisabledForeground �� Triggers �� Binding �� Path �� RelativeSource �� Value  StandardPanel��%�  &	        &	      7  7  7  7  7  &	 v      �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��8   ��  �@ TabNavigation$
 None=���  �@�FocusVisualStyle Z� ��  � ��$	 100����  � ��$ 18����  �@J�	AllowDrop . ��  � �� �� " ��.R�� .+��� $ Bg��8�� $ 2���� $ Hl��8�� $��0,0,0,1q�$ 2���� $ Sh��8�� $��0,1,0,0q�$ 2���� $ PART_ContentHost��$��0,2,0,0q� P� 	 � {�
 .  . ��� 8   � ����  �@J�Opacity$
 0.75Q� ��  �� $ IsLoaded� �� *Self+ True.a���  �@��	UndoLimit$ 0���� " �.���  � y�$ Visible=�.���� .+�9� $��General Properties�� 9� 
IsExpanded . .��� #��[  � ColumnDefinitions �� $	��110 ��� $	��90* �.+���  �� Orientation$ Vertical=�$��0��.+��� -   $��txtWidth��$��25��$��5q�$	��Top=�
�������$��Right=�$��Center=�$��Right=�$��44.64��.��Width:�� -   $��	txtHeight��$��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�$��48.227��.��	Height:�� -   $��lblTop��$��5q�$��Right=�$��25��$	��Top=�
�������$��Center=�$��Right=�$��32.97��.��Top:�� -   $��txtTeft��$��5q�$��Right=�$��Right=�$��32.35��$��Center=�
�������$��25��.��Left:�� -   $��txtCornerRadius��$��5q�$��Right=�$��Right=�$��85��$��Center=�
�������$��25��.��Corner Radius:�� -   $��txtBorderThickness��$��5q�$��Right=�$��Right=�$��85��$��Center=�
�������$��25��.��Border Thickness:�� $��5q�$��Right=�$��Right=�$��85��$��Center=�
�������$��25��.��	Margin:�� -   $��
lblOpacity��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��
Opacity:�� -   $��lblBorderBrush��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��Border Color:�� -	   $��lblBackground��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��Background Color:�� -
   $��lblTouchScreenButton��$��25��$��0,5,0,5q�$��Right=�
�������$��Center=�$��Right=�.��Touchscreen Button:�� -   $��lblButtonName��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��Button Name:�� $��1��.+��� -   $��tbMain1��#��[ $��Center=�$��25��$	��Top=�$��5q����� $ (Width)� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $��tbMain2��#��[ $��Center=�$��5q�$��25��$	��Top=����� $ (Height)�$ TwoWay=�$ PropertyChanged=��� -   $��tbMain3��#��[ $��Center=�$��5q�$��25��$	��Top=����� $ (Canvas.Top)�$ TwoWay=�$ PropertyChanged=��� -   $��tbMain4��#��[ $��Center=�$��25��$��5q����� $ (Canvas.Left)�$ TwoWay=�$ PropertyChanged=��� -   $��tbMain5��#��[ $��Center=�$��25��$��5q����� $ (CornerRadius)�$ TwoWay=�$ PropertyChanged=��� -   $��tbMain6��#��[ $��Center=�$��25��$��5q����� $ (BorderThickness)�$ TwoWay=�$ PropertyChanged=��� -    ��Name$ tbMargin��#��[ $��Center=�$��25��$��5q����� $ (Margin)�$ TwoWay=�$ PropertyChanged=��� -   $��sliderOpacity��$��1��$��5q� � Minimum$ 0Q� � Maximum$ 1Q�$��25�� � Value �� $ 	(Opacity)�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��5q�$��1q�
���   �$��22��  CheckerBrush#��[ ._��� -    ��Name$ borderBackgroundButton��$��20��$��20��$
��Left=���Z� ���� $ BorderBrush�$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��5q�$��1q�
���   �$��22��#��[ ._��� -   $ backgroundButton��$��20��$��20��$
��Left=���Z� ���� $ ContentBackground�$ TwoWay=�$ PropertyChanged=��� -   $��	cbTScreen��$��Bottom=�$��25��$��5q� d� 	IsChecked �� $ (IsTouchEnabled)�$ TwoWay=�$ PropertyChanged=��� -   $��	tbBtnName��#��[ $��Center=�$��25��$��Center=�$��5q����� $ (ButtonName)�$ TwoWay=�$ PropertyChanged=�9� $��Glass Appearance�� . .��� #��[  �� $��70 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� -   $��	txtZIndex��$��25��$��5q�$	��Top=�
�������$��Right=�$��Center=�$��Right=�$��44.64��.��
Z-Index:�� -   $��lblGlassOpacity��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��
Opacity:�� $��1��.+��� -   $��tbZIndex��#��[ $��Center=�$��25��$	��Top=�$��5q����� $ (ContentZIndex)�$ TwoWay=�$ PropertyChanged=��� -   $��sliderGlassOpacity��$��1��$��5q�$ 0Q�$ 1Q�$��25�� �� $ (GlassOpacity)�$ TwoWay=�$ PropertyChanged=�9� $��	InnerGlow�� . .��� #��[  �� $��70 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� -   $��lblInnerGlowSize��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��Size:�� -   $��lblInnerGlowOpacity��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��
Opacity:�� -   $��lblInnerGlowColor��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��Color:�� $��1��.+��� -   $��tbInnerGlowSize��#��[ $��Center=�$��25��$��5q����� $ (InnerGlowSize)�$ TwoWay=�$ PropertyChanged=��� -    $��sliderInnerGlowOpacity��$��1��$��5q�$ 0Q�$ 1Q�$��25�� �� $ (InnerGlowOpacity)�$ TwoWay=�$ PropertyChanged=��� -!   $
��Left=�$��5q�$��1q�
���   �$��22��#��[ ._��� -"   $ innerGlowButton��$��20��$��20��$
��Left=���Z� ���� $ (InnerGlowColor)� �� 	Converter# [  $ OneWay=�9� $��	Transform�� . .��� #��[  �� $��70 ��� $
��130* �.+��� $ Vertical=�$��0��.+��� -#   $��lblSkewX��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��	Skew X:�� -$   $��lblSkewY��$��25��$��5q�$��Right=�
�������$��Center=�$��Right=�.��	Skew Y:�� $��1��.+��� -%   $��sliderSkewX��$��1��$��5q� � LargeChange$ 5Q�$ 65Q�$	 -65Q� � SmallChange$	 0.5Q�$��25�� � ToolTip �� $ Value�$ OneWay=� �� *Self+�� -&   $��sliderSkewY��$��1��$��5q�$ 5Q�$ 65Q�$	 -65Q�$	 0.5Q�$��25�� �� $ Value�$ OneWay=� �� *Self+"   EffectLibrary.EffectSelector  -'   $��effectSelector��$��3,0,0,0q�