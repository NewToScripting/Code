   M S B A M L   `   `   `  ���� a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  D @MapModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MapModule	MapModule B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire !   MapModule.SubCategorySlider   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     -	MapModuleclr-namespace:MapModule     :Inspire&clr-namespace:Inspire;assembly=Inspire       � 	Resources     RatingItemNetflixStyle �� 
TargetType  Inspire.RatingItem �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard F�Name	 �� Stretch
 �� StrokeLineJoin J� Opacity J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth  Inspire.LinearClipper   DisplayValue  Inspire.Clipper   RatioVisible   ExpandDirection ��Name � Cursor  subCategoryTemplate ��Name �� Orientation �� TextAlignment  RoundedButtonStyle  Inspire.Rating   	ItemCount   
IsReadOnly   Value 
� Center 
� GradientOrigin � Color � Offset  alternatingWithTriggers �� Triggers P� Property  P� Value  ButtonFocusVisual! �� StrokeDashArray" J� SnapsToDevicePixels  ButtonNormalBackground# �� EndPoint$ �� 
StartPoint  ButtonNormalBorder% �� Color  ButtonStyle1+	   %Microsoft.Windows.Themes.ButtonChrome& 	 Name' 	  BorderBrush( �� IsDefaulted) 	  RenderDefaulted* J� IsMouseOver+ 	  RenderMouseOver, 	  RenderPressed- 	  
Background. �� Triggers/ �� 
TargetName��%�  &	        &	     7  7   &	     &	 �    &	     &	 �    &	 �    7  7  7  �� "  .���  � �� �	#FF545454��  � �� �� "  .R�� $��20��$��20��#��z��   CommonStates��.   
Normal��  	MouseOver��. ��   Pressed��. ��   Disabled��  ReadOnly��  FocusStates��.   Focused��. ��   	Unfocused��  
FillStates��.   	Empty��  Partial��  
Filled��.+��� ���	#02FFFFFF$��0q�F� $ DefaultRatingItem��
�������$
	 Fill=�$
 Round=�$	��0.6��$��Stretch=�$ 1Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FF969696   $ 	#FFC4C4C4��$ 1Q�  # z $ Right=�.��F� #��z��$
	 Fill=�$
 Round=�$��Stretch=�$ 1Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��Z� F� $ MouseOverRatingItem��$
	 Fill=�$
 Round=�$��Stretch=�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	���	#FFFFCB00$ 0Q���Z�    F� $ MouseOverHighlight�����	#FFFFFFFF$
	 Fill=�$
 Round=�$��Stretch=�$ 0Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	��Z� F� $ FocusRatingItem��$
	 Fill=����	#FF6DBDD1$
 Round=�$
��0.01��$��Stretch=�$ 0Q�k�������     �@�#�� р���ٮ �{�=�hѷVr������� YO_�ẽ��@����59�_�Y"@�h�    �ٮ �?� #�� 	�� $ Content��# z $
��Left=�#��z��#��z��#��z���� .R��� $ PART_SubCatTemplate��._�� $��111.903��.+��� $��Right=�$��33.903��$��0,-4,5.696,0q�$ 
Horizontal=�$	��Top=�.+��� 
�������$��14(�$ Center=�$��Distance��$��0,8,7,5.073q�$��Stretch=�$��Stretch=��� $��0q�$��14.667(�$
��Bold"�$��WrapWithOverflow=�$��Center=�
�������$
��Auto��$��Center=����� *LocationDistance+�� 
�������$��14(�$ Center=�$��miles��$��4,8.756,0,4.317q�$��Stretch=�$��Stretch=��� -   $��Get Directions��$��16(�8��  $��Right=�$��0,47.278,17,23.793q�$��123.203��  8�� $ 5��$��30.83��$��Bottom=�$��Right=�
������  . $	��112��$��	0,0,220,3q� �� *
UserRating+��
� $ 0.548,0.475&�$ 0.484,0.537&�.��� $ 	#FFA8B100��$ 1Q�� $ 	#FFF7CC00��� $ 	#FFFAE500��$ 0.043Q��� $��8,8,164.203,0q�$��18.667(�$
��Bold"�$��NoWrap=�
�������$��40.903��$	��Top=�$��Stretch=�$��CharacterEllipsis=����� *LocationName+�� $��Right=�$��24.83��$��0,0,184.204,4q�$ 
Horizontal=�$��Bottom=�.+��� 
�������$��13.333(�$ Center=�$��(��$��0,0,-7,0q�$��Stretch=�$��Center=�$��21.303���� 
�������$��14.667(�$ Center=�$��0q�$��Stretch=�$��Center=�$��21.303��$
��Bold"����� *RatingCount+�� 
�������$��13.333(�$ Center=�$��)��$��-8,0,0,0q�$��Stretch=�$��Center=�$��21.303���� 
�������$��16(�$ Center=�$��31,55.278,0,31.793q�$
��Left=�$��Stretch=����� *PhoneNumber+�� " ��.���  � ��
 ��  � P�  �@��AlternationIndex$  0��. ���  � ��
 ���� P�  �@��AlternationIndex$  1��. ���  � �� �	#49FFFFFF�� .���  � �� �� .R��� 
���   �$	! 1 2R�$��1��$��2q�" . �� $	# 0,1&�$	$ 0,0&�.��� $ #F3F3F3��$ 0Q�� $ #EBEBEB��$	 0.5Q�� $ #DDDDDD��$	 0.5Q�� $ #CDCDCD��$ 1Q��� $% 	#FF707070���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�	  $& Chrome��" . #' z��#) z( #+ z* #, z��- �� $	# 0,1&�$	$ 0,0&�.��� $ 	#19F3F3F3��$ 0Q�� $ 	#4CEBEBEB��$	 0.5Q�� $ 	#33DDDDDD��$	 0.5Q�� $ 	#19CDCDCD��$ 1Q�._��� #��z��#��z��#��z��#" z" ��. . P�  �@J�IsKeyboardFocused  . . ��� $/ Chrome�� �@	 RenderDefaulted . P�  �@d�	IsChecked$
  trueY�. ��� $/ Chrome�� �@	 RenderPressed . P�  � {�  .  . ���  � �� �#ADADAD.��� .+��� 
�������$��1q�._�� .+��� -   0 ��Name$0 ICSubCategories��   SemiTransparentBlackBrushKey#��[ $��1q�#��[ 1 �� AlternationCount$1 2��$��Stretch=�$��10,107,10,97q�#��[ $��Disabled=���Z� ���� 2 �� Mode$2 OneWay=����� .R��� $ Vertical=�
  Inspire.LoadingControl
  -   3 
 Name$3 loadingControl��
�������$��10,120,10,70q��� $ 
Horizontal=�$��10q�$	��Top=�.+�(� $��10q�$��64��$��64��.��  MapModule.DynamicMarker  -   4  Name$4 catStyle��5   SelectedTemplate5 �� 6 �� Path$6 MarkerPin.CategoryStyle�7   Title7 �� $6 LocationName�(� $��	5,10,5,10q�$��56��$
��Left=�$	��390��.���� -   8 ��Name$8 
tbCategory��$��30(�$
��Left=�$��CharacterEllipsis=�$��Center=�$��Italic$�$��15,10,10,10q�$
��Bold"�
��������� $�Sample ���� $�Category���� -   $��
10,0,10,10q�
�������$
��Back��$��Bottom=�$��75��$
��Bold"�#���  $��32(�