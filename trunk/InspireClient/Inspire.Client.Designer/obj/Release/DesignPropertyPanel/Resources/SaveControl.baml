   M S B A M L   `   `   `  ����   Inspire.Client.Designer=    7Inspire.Client.Designer.DesignPropertyPanel.SaveControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $	��124��$��66��.��� -     �Name$  
LayoutRoot�� � 	Resources 3  -System.Windows.Media.Effects.DropShadowEffect   	BluredDot   Color   
BlurRadius   ShadowDepth��%,   &	          $ Green��$ 10Q�$ 0Q�.+��� -   $��content�� J� Opacity$ 0Q�$��Center=�$��3,0,0,0q� � Triggers :�  :� RoutedEvent$ Image.Loaded��.[��� .���� -    ��Name$ rotation��.��W� 		 W� To$	 1X�
 g� Duration$
 0:0:1D� �� 
TargetName$ content�� �� TargetProperty$ Opacity�W�  W� From$ 0X�$		 359X�$
 0:0:5D� g� RepeatBehavior$ Forever��$ angle��$ Angle���H�  H� Drawing I� .���  � Brush
 ����  � Geometry ��  �� Rect$ 0,0,1,1�I�  I� 	Transform �� -   	angle�� �� Angle$ 0Q� �� CenterX$	 0.5Q� �� CenterY$	 0.5Q�.��� 
 � Pen >�  >� Brush
 � � � >� 	Thickness$	 0.1Q� B� .��E�  E� 
StartPoint$ 0.9,0.5&�.����  �� Point$ 0.5,0.1&� �� RotationAngle$ 90Q� �� SweepDirection$ 	Clockwise=� �� 
IsLargeArc .  �� Size$ 0.4,0.4��� 
 � � � B� .��E� $ 0.5,0&�.����   �� Point$  0.7,0.1&��� $  0.5,0.2&��� $��47,25,29,15q�
�������! J� Effect#! [  $��Saving��