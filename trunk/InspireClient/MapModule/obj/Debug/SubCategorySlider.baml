   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5   K   D @MapModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MapModule	MapModule 6�   B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire 6�   !   MapModule.SubCategorySlider   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     6K   -	MapModuleclr-namespace:MapModule     6�   :Inspire&clr-namespace:Inspire;assembly=Inspire     6�     � 	Resources  5         RatingItemNetflixStyle �� 
TargetType  Inspire.RatingItem �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard F�Name	 �� Stretch
 �� StrokeLineJoin J� Opacity J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth  Inspire.LinearClipper   DisplayValue  Inspire.Clipper   RatioVisible   ExpandDirection ��Name � Cursor  subCategoryTemplate ��Name �� Orientation �� TextAlignment  RoundedButtonStyle  Inspire.Rating   	ItemCount   
IsReadOnly   Value 
� Center 
� GradientOrigin � Color � Offset  alternatingWithTriggers �� Triggers P� Property  P� Value  ButtonFocusVisual! �� StrokeDashArray" J� SnapsToDevicePixels  ButtonNormalBackground# �� EndPoint$ �� 
StartPoint  ButtonNormalBorder% �� Color  ButtonStyle1+	   %Microsoft.Windows.Themes.ButtonChrome& 	 Name' 	  BorderBrush( �� IsDefaulted) 	  RenderDefaulted* J� IsMouseOver+ 	  RenderMouseOver, 	  RenderPressed- 	  
Background. �� Triggers/ �� 
TargetName��%�  &	        &	 �    7  7   &	 �    &	 �    &	 ~    &	 r    &	 �    7  7  7  �� 5   
   "  6/   .�5      ��  � �� �	#FF5454546,   �� 5	       � �� 5
      �� 5      "  6&   .R�5      � $��20��6   $��20��6+   #��z��66    5        5   "   CommonStates��. 5   &     
Normal��62     5   &   	MouseOver��. 5   *   �� 5$   +   5%   '     5&   &   Pressed��. 5'   *   �� 5(   '     5)   &   Disabled��62     5*   &   ReadOnly��62   5+   #     5,   "   FocusStates��. 5-   &     Focused��. 5.   *   �� 5/   '     50   &   	Unfocused��62   51   #     52   "   
FillStates��. 53   &     	Empty��62     54   &   Partial��62     55   &   
Filled��62   56   #   .+�58      �� ���	#02FFFFFF$��0q�6<   F� 59      $ DefaultRatingItem��6#   
�������$
	 Fill=�6K   $
 Round=�6Z   $	��0.6��6q   $��Stretch=�6�   $ 1Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FF969696 5:   "     5;   &   $ 	#FFC4C4C4��67   $ 1Q�6I   5=        5>      # z 64   $ Right=�6b   .��5?   "   F� #��z��6'   $
	 Fill=�6K   $
 Round=�6l   $��Stretch=�6�   $ 1Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��6Z   Z� 6�   5@      F� 5A      $ MouseOverRatingItem��6#   $
	 Fill=�6@   $
 Round=�6a   $��Stretch=�6x   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FFFFCB00$ 0Q�6H  ��6O   Z�  5B   "     5C   &   5E      F� 5F      $ MouseOverHighlight��6#   ���	#FFFFFFFF$
	 Fill=�6P   $
 Round=�6q   $��Stretch=�6�   $ 0Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��6_   Z� 6�   F� 5G      $ FocusRatingItem��6#   $
	 Fill=�6<   ���	#FF6DBDD1$
 Round=�6^   $
��0.01��6u   $��Stretch=�6�   $ 0Q�6�   k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	6�   �� 5H      $ Content��6/   # z 6@   $
��Left=�6b   #��z��6}   #��z��6�   #��z��6�   5I      5J      5L      5M      �� 5O   
   .R�5P      �� $ PART_SubCatTemplate��6   ._�5Q      � $��111.903��6   .+�5R      �� $��Right=�6   $��33.903��67   $��0,-4,5.696,0q�6G   $ 
Horizontal=�6]   $	��Top=�6v   .+�5S      �� 
�������$��14(�6.   $ Center=�6<   $��Distance��6S   $��0,8,7,5.073q�6c   $��Stretch=�6x   $��Stretch=�6�   �� 5T      $��0q�6   $��14.667(�6&   $
��Bold"�68   $��WrapWithOverflow=�6J   $��Center=�6j   
�������$
��Auto��6�   $��Center=�6�   ��6�   �� *LocationDistance+6�   �� 5U      
�������$��14(�6.   $ Center=�6<   $��miles��6S   $��4,8.756,0,4.317q�6`   $��Stretch=�6y   $��Stretch=�6�   5V      �� 5W      -   5        $��Get Directions��5W      $��16(�66   8��  $��Right=�6�   $��0,47.278,17,23.793q�6�   $��123.203��6�     5X      8�� $ 5��6y   $��30.83��6�   $��Bottom=�6�   $��Right=�6�   
������  . $	��112��6�   $��	0,0,220,3q�6   6\   �� *
UserRating+��5Y      
� 5Z      $ 0.548,0.475&�6&   $ 0.484,0.537&�6;   .��5[      � $ 	#FFA8B100��6    $ 1Q�62   � 5\      $ 	#FFF7CC00��6    � 5]      $ 	#FFFAE500��6    $ 0.043Q�62   5^      5`      �� 5a      $��8,8,164.203,0q�6   $��18.667(�61   $
��Bold"�6C   $��NoWrap=�6U   
�������$��40.903��6�   $	��Top=�6�   $��Stretch=�6�   $��CharacterEllipsis=�6�   ��6~   �� *LocationName+6�   �� 5b      $��Right=�6   $��24.83��67   $��0,0,184.204,4q�6F   $ 
Horizontal=�6]   $��Bottom=�6v   .+�5c      �� 
�������$��13.333(�6.   $ Center=�6@   $��(��6W   $��0,0,-7,0q�6`   $��Stretch=�6r   $��Center=�6�   $��21.303��6�   �� 5d      
�������$��14.667(�67   $ Center=�6I   $��0q�6}   $��Stretch=�6�   $��Center=�6�   $��21.303��6�   $
��Bold"�6�   ��6`   �� *RatingCount+6�   �� 5e      
�������$��13.333(�6.   $ Center=�6@   $��)��6W   $��-8,0,0,0q�6`   $��Stretch=�6r   $��Center=�6�   $��21.303��6�   5f      �� 5g      
�������$��16(�63   $ Center=�6A   $��31,55.278,0,31.793q�6u   $
��Left=�6�   $��Stretch=�6�   ��6X   �� *PhoneNumber+6�   5h      5i      5j      �� 5l   
   " ��60   .�5m      ��  � ��
 ��  �6+    5n      P� 5o       �@��AlternationIndex$  0��6>   . �5p      ��  � ��
 ���� 63   5q      P� 5r       �@��AlternationIndex$  1��6>   . �5s      ��  � �� �	#49FFFFFF63   5t      5v      �� 5x   
   .�5y      ��  � �� 5z      �� 5{      .R�5|      �� 
���   �$	! 1 2R�63   $��1��6I   $��2q�6]   " . 6h   5}      5      5�      �� 5�   
   $	# 0,1&�6=   $	$ 0,0&�6L   .��5�      � $ #F3F3F3��6   $ 0Q�6+   � 5�      $ #EBEBEB��6   $	 0.5Q�6+   � 5�      $ #DDDDDD��6   $	 0.5Q�6+   � 5�      $ #CDCDCD��6   $ 1Q�6+   5�      �� 5�   
   $% 	#FF707070��65   �� 5�   
   " ��6%   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��$ 1q�60   �� 5�       � ��# � ��6+   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��$ 1q�6(   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      	  $& Chrome��6@   " . #' z��6k   #) z( 6�   #+ z* 6�   #, z��6�   - 5�      �� 5�   "   $	# 0,1&�66   $	$ 0,0&�6E   .��5�   &   � $ 	#19F3F3F3��63   $ 0Q�6E   � 5�   &   $ 	#4CEBEBEB��63   $	 0.5Q�6E   � 5�   &   $ 	#33DDDDDD��63   $	 0.5Q�6E   � 5�   &   $ 	#19CDCDCD��63   $ 1Q�6E   5�   #   ._�5�      �� #��z��6/   #��z��6r   #��z��6�   #" z" 6�   ��. 6  5�      . 5�      P� 5�       �@J�IsKeyboardFocused  . . �5�   "   �� $/ Chrome��6D    �@	 RenderDefaulted . 6X   5�      P� 5�       �@d�	IsChecked$
  trueY�6H   . �5�   "   �� $/ Chrome��6B    �@	 RenderPressed . 6V   5�      P� 5�       � {�  .  . �5�   "   ��  � �� �#ADADAD6?   5�      5�      5�      5�      5�      .��5�      � .+�5�   
   �� 
�������$��1q�6(   ._�5�      � .+�5�      �� -   5        0 ��Name$0 ICSubCategories��5�   <     SemiTransparentBlackBrushKey#��[ 6   $��1q�6�   #��[ 6�   1 �� AlternationCount$1 2��6�   $��Stretch=�6�   $��10,107,10,97q�6&  #��[ 6U  $��Disabled=�6�  ��6  Z� ��6�  �� 2 �� Mode$2 OneWay=���5�      �� 5�      .R�5�      �� $ Vertical=�6)   5�      5�      
  Inspire.LoadingControl
  5�      -   5        3 
 Name$3 loadingControl��5�   )   
�������$��10,120,10,70q�6T   5�      5�      �� 5�   
   $ 
Horizontal=�6   $��10q�6.   $	��Top=�6:   .+�5�   
   (� $��10q�6   $��64��6   $��64��6)   .��5�        MapModule.DynamicMarker  -   5        4  Name$4 catStyle��5�   &   5   SelectedTemplate5 68   �� 6 �� Path$6 MarkerPin.CategoryStyle�7   Title7 6r   �� $6 LocationName�5�      (� 5�      $��	5,10,5,10q�6   $��56��6)   $
��Left=�65   $	��390��6P   .��5�      �� -   5        8 ��Name$8 
tbCategory��5�   &   $��30(�6   $
��Left=�6:   $��CharacterEllipsis=�6U   $��Center=�6v   $��Italic$�6�   $��15,10,10,10q�6�   $
��Bold"�6�   
��������� 6�   $�Sample ��6�   �� 6�   $�Category��6�   6  5�      5�      �� 5�   
   -   5        $��
10,0,10,10q�5�      
�������$
��Back��6M   $��Bottom=�6\   $��75��6w   $
��Bold"�6�   #���  6�   $��32(�6�   5�      5�      