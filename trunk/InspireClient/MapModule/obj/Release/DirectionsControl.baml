   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows  	MapModule!   MapModule.DirectionsControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :Inspire&clr-namespace:Inspire;assembly=Inspire     Jsw;clr-namespace:System.Windows;assembly=PresentationFramework       � 	Resources     dirItemTemplate ��Name �� CornerRadius � RowDefinitions J� Opacity �� RelativeTransform �� ScaleX �� ScaleY �� AngleX	 �� AngleY
 �� Angle T� X T� Y � Color � Offset �� EndPoint �� 
StartPoint  RatingItemNetflixStyle �� 
TargetType   Inspire.RatingItem �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty O� KeyTime O� Value �� KeyTime �� Value F�Name �� Stretch  �� StrokeLineJoin! J� Effect3  -System.Windows.Media.Effects.DropShadowEffect"   Color#   ShadowDepth   Inspire.LinearClipper$   DisplayValue   Inspire.Clipper%   RatioVisible&   ExpandDirection' ��Name( � Cursor��%�  &	        &	 �    �� .R�� .+��� $��65,0,0,0q�$��21.333(�$
��Wrap=����� *	Direction+�� $ border��$	��Top=�$
��Left=�
�������$��5q�$ 20��$��50��$
��47.6������ *Brush+._��  �� $��0.507* ��� $��0.493* �.+��� $
 glow��$ 0Q�$��Stretch=�$
��Auto��$��2��$ 4,4,4,4����
�  V� .~��� $ 1.702Q�$ 2.243Q��� $ 0Q�$	 0Q��� $
 0Q�T� $ -0.368Q�$ -0.152Q�.��� $ 	#B28DBDFF��$ 0Q�� $ 	#008DBDFF��$ 1Q��� $��2��$
��Bold"�$��20(�$��Center=�$��Center=�
����������� *
ItemNumber+�� $ shine��$��Stretch=�$��0,0,0,0q�$
��Auto��$ 4,4,0,0������ $ 0.494,0.889&�$ 0.494,0.028&�.��� $ 	#99FFFFFF��$ 0Q�� $ 	#33FFFFFF��$ 1Q��� "  .���  � �� �	#FF545454��  � �� �� "  .R�� $��20��$��20��#��z��   CommonStates��.   
Normal��  	MouseOver��. �� .��U� $ MouseOverRatingItem��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q�U� $ MouseOverHighlight��$ (UIElement.Opacity)�.\��� $ 00:00:00��$
 0.36Q��� $ MouseOverHighlight��$* $(Shape.Fill).(SolidColorBrush.Color)�.g��� $ 00:00:00��$ 	#FFFFFFFF��U� $ MouseOverRatingItem��$6 0(UIElement.Effect).(DropShadowEffect.BlurRadius)�.\�n� $ 00:00:00��$ 4Q�U� $ MouseOverRatingItem��$7 1(UIElement.Effect).(DropShadowEffect.ShadowDepth)�.\�n� $ 00:00:00��$ 1Q��� $ MouseOverRatingItem��$1 +(UIElement.Effect).(DropShadowEffect.Color)�.g�p� $ 00:00:00��$ 	#FF3A3A3A��  Pressed��. ��   Disabled��  ReadOnly��  FocusStates��.   Focused��. ��   	Unfocused��  
FillStates��.   	Empty��  Partial��  
Filled��.+��� ���	#02FFFFFF$��0q�F� $ DefaultRatingItem��
�������$
 Fill=�$  Round=�$	��0.6��$��Stretch=�$ 1Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FF969696!   $" 	#FFC4C4C4��$# 1Q�  #% z$ $& Right=�.��F� #��z��$
 Fill=�$  Round=�$��Stretch=�$ 1Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��Z� F� $ MouseOverRatingItem��$
 Fill=�$  Round=�$��Stretch=�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FFFFCB00$ 0Q���Z� !   F� $ MouseOverHighlight�����	#FFFFFFFF$
 Fill=�$  Round=�$��Stretch=�$ 0Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��Z� F� $ FocusRatingItem��$
 Fill=����	#FF6DBDD1$  Round=�$
��0.01��$��Stretch=�$ 0Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	�� $' Content��#( z( $
��Left=�#��z��#��z��#��z��.���� $��1q�
�������._�� .+��� $��Right=�$��26��$��0,138,24.351,0q�) �� Orientation$) 
Horizontal=�$	��Top=�.+�   Inspire.Rating  -   *  Name$* PART_RatingControl��#��[ +   	ItemCount$+ 5��$
��Left=�$	��103��
������ , J� IsHitTestVisible, .  -   Value- �� *
UserRating+��
� . 
� Center$. 0.548,0.475&�/ 
� GradientOrigin$/ 0.484,0.537&�.��� $ 	#FFA8B100��$ 1Q�� $ 	#FFF7CC00��� $ 	#FFFAE500��$ 0.043Q��� -   0 ��Name$0 PART_NumOfRatings��$
��Left=�$��0q�$) 
Horizontal=�.+��� 
�������$��16(�1 �� TextAlignment$1 Center=�$��(��$��0,0,-7,0q�$��Stretch=�$��Center=�$��21.303���� 
�������$��16(�$1 Center=�$��0q�$��Stretch=�$��Center=�$��21.303��$
��Bold"����� *RatingCount+�� 
�������$��16(�$1 Center=�$��)��$��-8,0,0,0q�$��Stretch=�$��Center=�$��21.303���� $��64��$��
20,6,132,0q�$
��Wrap=�$��Directions:��$ .7Q�$	��Top=�
�������$��48(�$
��Bold"�$��Italic$�$	��536��(� $��20,70,132,0q�$	��536��$��30��$	��Top=�.���� 
�������$��22(�$
��Bold"�$
��Wrap=����� *LocationName+ 	   Inspire.ScrollPanelWrapper	  $��20,216,27,91q�$��Disabled=�.���� -   2 ��Name$2 lbDirections��3 �� SelectedIndex$3 -1��
������ 
�������$��Stretch=�#��[  $��Disabled=�$��1q���Z� ���� 4 �� Mode$4 OneWay=����� .R��� $) Vertical=�
   Inspire.LoadingControl
  -   5 
 Name$5 loadingControl��
��������� -   $��
10,0,10,10q�
�������$
��Back��$��Bottom=�$��75��$
��Bold"�  TransparentButton#���  $��48(��� -   6 ��Name$6 PART_PrintButton��$y�	Collapsed=�$��Right=�$	��134��$��Resources/Print.png��$
��Fill=�$	��Top=�$	��134���� $��21.333(�
�������$��20,106,197,0q�$
��Wrap=�$	��Top=����� *Address.FormattedAddress+�� $��Right=�$��28.373��$��0,181.626,27,0q�$) 
Horizontal=�$	��Top=�.+��� 
�������$��0,0,10,-0.001q�$��21.333(�$
��Wrap=�$��Distance���� 
�������$��0,0,10,-0.001q�$��21.333(�$
��Wrap=�$
��Bold"����� *LocationDistance+�� 
�������$��0,0,0,-0.001q�$��21.333(�$
��Wrap=�$��miles���� 
�������$��24(�$
��Wrap=�$��727-544-5453��$��353,15.5,177.5,843q�$
��Bold"�