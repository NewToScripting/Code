   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows  5   K   B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire 6�    	MapModule&    MapModule.InspireLocationDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      @d2http://schemas.microsoft.com/expression/blend/2008      5      Jsw;clr-namespace:System.Windows;assembly=PresentationFramework      6K   :Inspire&clr-namespace:Inspire;assembly=Inspire      6�     � 	Resources  5         RatingItemNetflixStyle �� 
TargetType  Inspire.RatingItem �� Property �� Value �� 
TargetType'   !System.Windows.VisualStateManager   VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard �� 
TargetName	 �� TargetProperty
 O� KeyTime O� Value �� KeyTime �� Value F�Name �� Stretch �� StrokeLineJoin J� Opacity J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth  Inspire.LinearClipper   DisplayValue  Inspire.Clipper   RatioVisible   ExpandDirection ��Name � Cursor��%�  &	        �� 5   
   "  6/   .�5      ��  � �� �	#FF5454546,   �� 5	       � �� 5
      �� 5      "  6&   .R�5      � $��20��6   $��20��6+   #��z��66    5        5   "   CommonStates��. 5   &     
Normal��65     5   &   	MouseOver��. 5   *   �� .��5   .   U� $ MouseOverRatingItem��6L   $	 (UIElement.Opacity)�6x   .\�5   2   �� $
 00:00:00��6G   $ 1Q�6Z   5   /   U� 5   .   $ MouseOverHighlight��6L   $	 (UIElement.Opacity)�6w   .\�5   2   �� $
 00:00:00��6G   $
 0.36Q�6Z   5   /   �� 5   .   $ MouseOverHighlight��6K   $*	 $(Shape.Fill).(SolidColorBrush.Color)�6v   .g�5   2   �� $ 00:00:00��6F   $ 	#FFFFFFFF��6Y   5   /   U� 5   .   $ MouseOverRatingItem��6M   $6	 0(UIElement.Effect).(DropShadowEffect.BlurRadius)�6y   .\�5   2   n� $
 00:00:00��6I   $ 4Q�6\   5   /   U� 5   .   $ MouseOverRatingItem��6L   $7	 1(UIElement.Effect).(DropShadowEffect.ShadowDepth)�6x   .\�5   2   n� $
 00:00:00��6I   $ 1Q�6\   5    /   �� 5!   .   $ MouseOverRatingItem��6K   $1	 +(UIElement.Effect).(DropShadowEffect.Color)�6w   .g�5"   2   p� $ 00:00:00��6H   $ 	#FF3A3A3A��6[   5#   /   5$   +   5%   '     5&   &   Pressed��. 5'   *   �� 5(   '     5)   &   Disabled��65     5*   &   ReadOnly��65   5+   #     5,   "   FocusStates��. 5-   &     Focused��. 5.   *   �� 5/   '     50   &   	Unfocused��65   51   #     52   "   
FillStates��. 53   &     	Empty��65     54   &   Partial��65     55   &   
Filled��65   56   #   .+�58      �� ���	#02FFFFFF$��0q�6<   F� 59      $ DefaultRatingItem��6#   
�������$
 Fill=�6K   $ Round=�6Z   $	��0.6��6q   $��Stretch=�6�   $ 1Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FF969696 5:   "     5;   &   $ 	#FFC4C4C4��67   $ 1Q�6I   5=        5>      # z 64   $ Right=�6b   .��5?   "   F� #��z��6'   $
 Fill=�6K   $ Round=�6l   $��Stretch=�6�   $ 1Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��6Z   Z� 6�   5@      F� 5A      $ MouseOverRatingItem��6#   $
 Fill=�6@   $ Round=�6a   $��Stretch=�6x   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FFFFCB00$ 0Q�6H  ��6O   Z�  5B   "     5C   &   5E      F� 5F      $ MouseOverHighlight��6#   ���	#FFFFFFFF$
 Fill=�6P   $ Round=�6q   $��Stretch=�6�   $ 0Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��6_   Z� 6�   F� 5G      $ FocusRatingItem��6#   $
 Fill=�6<   ���	#FF6DBDD1$ Round=�6^   $
��0.01��6u   $��Stretch=�6�   $ 0Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	6�   �� 5H      $ Content��6/   # z 6@   $
��Left=�6b   #��z��6}   #��z��6�   #��z��6�   5I      5J      5L      5M      5N      .��5O      � $	��558��6   $��200.5��6   .+�5P   
   �� 
�������$��1q�6%    �� CornerRadius$ 5��69   ���	#C0000000._�5Q      � .+�5R      �� -   5        ���	#01000000$��Right=�5R   0   $	��Top=�6L   $��50��6d   $��50��6o   ._�5S      �� $��24��6   $��24��6'   $#��Resources/Images/Cancel24.png��63   5T      �� 5U      
�������$��9,6,44,0q�6Z   $
��Bold"�6l   $��22(�6~   $��48��6�   $	��Top=�6�   ��6/   �� *LocationName+ �� Mode$ OneWay=�6�   �� 5V      
�������$��18(�63   $��21,59,44,83q�6s   $
��Wrap=�6�   ��6A   �� *LocationDescription+$ OneWay=�6�   �� 5W      
�������$��48,0,215,35q�6Y   $��22(�6n   $��44��6|   $��Bottom=�6�   ��6/   �� *PhoneNumber+$ OneWay=�6�   �� 5X      $
��Left=�6   $��28��68   $��13,0,0,0q�6D    �� Orientation$ 
Horizontal=�6V   $��Bottom=�6o   .+�5Y      �� 
�������$��15(�60    �� TextAlignment$ Center=�6>   $��Distance��6U   $��0,0,0,6q�6e   $��68��6v   �� 5Z      
�������$��16(�60   $��8,1,0,0q�6m   $
��Bold"�6~   ��6>   �� *LocationDistance+$ OneWay=�6~   �� 5[      
�������$��15(�60   $ Center=�6>   $��miles��6U   $��12,0,0,6q�6b   5\      �� 5]      $��Right=�6   $��29��69   $��0,0,15,5q�6E   $ 
Horizontal=�6W   $��Bottom=�6p   .+�5`        Inspire.Rating  -   5          Name$ PART_RatingControl��5`   "   #��[  6>      	ItemCount$ 5��6�   
������ $��0,0,0,3q�6�     J� IsHitTestVisible  .  !   Value! 6{   �� *
UserRating+$ OneWay=���5a      
� 5b      " 
� Center$" 0.548,0.475&�62   # 
� GradientOrigin$# 0.484,0.537&�6G   .��5c   "   � $ � Color$$ 	#FFA8B100��6/   % � Offset$% 1Q�6A   � 5d      $$ 	#FFF7CC00��6#   � 5e      $$ 	#FFFAE500��6#   $% 0.043Q�65   5f      5h      �� 5i      -   5        & ��Name$& PART_NumOfRatings��5i      $��0,3,0,-1q�69   $ 
Horizontal=�6K   .+�5j      �� 
�������$��18.667(�61   $ Center=�6D   $��(��6[   $��0,0,-7,0q�6d   $��Stretch=�6v   $��Stretch=�6�   $��21.303��6�   �� 5k      
�������$��18.667(�61   $ Center=�6C   $��0q�6�   $��Stretch=�6�   $��Stretch=�6�   $��21.303��6�   $
��Bold"�6�   ��6Z   �� *RatingCount+$ OneWay=�6�   �� 5l      
�������$��18.667(�61   $ Center=�6C   $��)��6Z   $��-8,0,0,0q�6c   $��Stretch=�6u   $��Stretch=�6�   $��21.303��6�   5m      5n      5p      5q      5r      5s      