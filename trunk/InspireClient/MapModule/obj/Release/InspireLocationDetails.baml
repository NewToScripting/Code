   M S B A M L   `   `   `  ���� \  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows  B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  	MapModule&    MapModule.InspireLocationDetails   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      @d2http://schemas.microsoft.com/expression/blend/2008      Jsw;clr-namespace:System.Windows;assembly=PresentationFramework      :Inspire&clr-namespace:Inspire;assembly=Inspire        � 	Resources     RatingItemNetflixStyle �� 
TargetType  Inspire.RatingItem �� Property �� Value �� 
TargetType'   !System.Windows.VisualStateManager   VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard �� 
TargetName	 �� TargetProperty
 O� KeyTime O� Value �� KeyTime �� Value F�Name �� Stretch �� StrokeLineJoin J� Opacity J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth  Inspire.LinearClipper   DisplayValue  Inspire.Clipper   RatioVisible   ExpandDirection ��Name � Cursor��%�  &	        �� "  .���  � �� �	#FF545454��  � �� �� "  .R�� $��20��$��20��#��z��   CommonStates��.   
Normal��  	MouseOver��. �� .��U� $ MouseOverRatingItem��$	 (UIElement.Opacity)�.\��� $
 00:00:00��$ 1Q�U� $ MouseOverHighlight��$	 (UIElement.Opacity)�.\��� $
 00:00:00��$
 0.36Q��� $ MouseOverHighlight��$*	 $(Shape.Fill).(SolidColorBrush.Color)�.g��� $ 00:00:00��$ 	#FFFFFFFF��U� $ MouseOverRatingItem��$6	 0(UIElement.Effect).(DropShadowEffect.BlurRadius)�.\�n� $
 00:00:00��$ 4Q�U� $ MouseOverRatingItem��$7	 1(UIElement.Effect).(DropShadowEffect.ShadowDepth)�.\�n� $
 00:00:00��$ 1Q��� $ MouseOverRatingItem��$1	 +(UIElement.Effect).(DropShadowEffect.Color)�.g�p� $ 00:00:00��$ 	#FF3A3A3A��  Pressed��. ��   Disabled��  ReadOnly��  FocusStates��.   Focused��. ��   	Unfocused��  
FillStates��.   	Empty��  Partial��  
Filled��.+��� ���	#02FFFFFF$��0q�F� $ DefaultRatingItem��
�������$
 Fill=�$ Round=�$	��0.6��$��Stretch=�$ 1Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FF969696   $ 	#FFC4C4C4��$ 1Q�  # z $ Right=�.��F� #��z��$
 Fill=�$ Round=�$��Stretch=�$ 1Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��Z� F� $ MouseOverRatingItem��$
 Fill=�$ Round=�$��Stretch=�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FFFFCB00$ 0Q���Z�    F� $ MouseOverHighlight�����	#FFFFFFFF$
 Fill=�$ Round=�$��Stretch=�$ 0Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��Z� F� $ FocusRatingItem��$
 Fill=����	#FF6DBDD1$ Round=�$
��0.01��$��Stretch=�$ 0Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	�� $ Content��# z $
��Left=�#��z��#��z��#��z��.��� $	��558��$��200.5��.+��� 
�������$��1q� �� CornerRadius$ 5�����	#C0000000._�� .+��� -   ���	#01000000$��Right=�$	��Top=�$��50��$��50��._��� $��24��$��24��$#��Resources/Images/Cancel24.png���� 
�������$��9,6,44,0q�$
��Bold"�$��22(�$��48��$	��Top=����� *LocationName+ �� Mode$ OneWay=��� 
�������$��18(�$��21,59,44,83q�$
��Wrap=����� *LocationDescription+$ OneWay=��� 
�������$��48,0,215,35q�$��22(�$��44��$��Bottom=����� *PhoneNumber+$ OneWay=��� $
��Left=�$��28��$��13,0,0,0q� �� Orientation$ 
Horizontal=�$��Bottom=�.+��� 
�������$��15(� �� TextAlignment$ Center=�$��Distance��$��0,0,0,6q�$��68���� 
�������$��16(�$��8,1,0,0q�$
��Bold"����� *LocationDistance+$ OneWay=��� 
�������$��15(�$ Center=�$��miles��$��12,0,0,6q��� $��Right=�$��29��$��0,0,15,5q�$ 
Horizontal=�$��Bottom=�.+�  Inspire.Rating  -     Name$ PART_RatingControl��#��[     	ItemCount$ 5��
������ $��0,0,0,3q�  J� IsHitTestVisible  .  !   Value! �� *
UserRating+$ OneWay=���
� " 
� Center$" 0.548,0.475&�# 
� GradientOrigin$# 0.484,0.537&�.��� $ � Color$$ 	#FFA8B100��% � Offset$% 1Q�� $$ 	#FFF7CC00��� $$ 	#FFFAE500��$% 0.043Q��� -   & ��Name$& PART_NumOfRatings��$��0,3,0,-1q�$ 
Horizontal=�.+��� 
�������$��18.667(�$ Center=�$��(��$��0,0,-7,0q�$��Stretch=�$��Stretch=�$��21.303���� 
�������$��18.667(�$ Center=�$��0q�$��Stretch=�$��Stretch=�$��21.303��$
��Bold"����� *RatingCount+$ OneWay=��� 
�������$��18.667(�$ Center=�$��)��$��-8,0,0,0q�$��Stretch=�$��Stretch=�$��21.303��