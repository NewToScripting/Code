   M S B A M L   `   `   `  ����  Inspire.Client.Designer=    7Inspire.Client.Designer.DesignPropertyPanel.SaveControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��124��5      $��66��6   .��5b      � -   5          �Name$  
LayoutRoot��5b       � 	Resources 5c   
   3  -System.Windows.Media.Effects.DropShadowEffect   	BluredDot   Color   
BlurRadius   ShadowDepth��%D   &	          5d      $ Green��65   $ 10Q�6C   $ 0Q�6S   5e      .+�5r   
   �� -   5        $��content��5r       J� Opacity$ 0Q�6   $��Center=�6+   $��3,0,0,0q�6H    � Triggers 5s      :� 5t       :� RoutedEvent$ Image.Loaded��6   .[�5u      �� .��5v      �� -   5         ��Name$ rotation��5v   %   .��5w      W� 		 W� To$	 1X�6.   
 g� Duration$
 0:0:1D�65    �� 
TargetName$ content��5x   )    �� TargetProperty$ Opacity�5y   )   W� 5z       W� From$ 0X�6.   $		 359X�67   $
 0:0:5D�6@    g� RepeatBehavior$ Forever��6Q   $ angle��5{   )   $ Angle�5|   )   5}      5~      5      ��5�      H� 5�       H� Drawing 5�      I� 5�      .��5�      �  � Brush
 ����  � Geometry 5�   "   �� 5�   &    �� Rect$ 0,0,1,1�68   5�      I� 5�       I� 	Transform 5�   "   �� 5�   &   -   5        	angle�� �� Angle$ 0Q�5�   E    �� CenterX$	 0.5Q�6O    �� CenterY$	 0.5Q�6]   .��5�   "   � 
 � Pen 5�   &   >� 5�   *    >� Brush
 � � � >� 	Thickness$	 0.1Q�6<    5�   &   B� 5�   *   .��5�   .   E�  E� 
StartPoint$ 0.9,0.5&�69   .��5�   2   ��  �� Point$ 0.5,0.1&�6=    �� RotationAngle$ 90Q�6M    �� SweepDirection$ 	Clockwise=�6`    �� 
IsLargeArc .  �� Size$ 0.4,0.4��6�   5�   /   5�   +   5�   #   � 5�   "   
 � � � 5�   &   B� 5�   *   .��5�   .   E� $ 0.5,0&�69   .��5�   2   ��   �� Point$  0.7,0.1&�6>   �� 5�   2   $  0.5,0.2&�6>   5�   /   5�   +   5�   #   5�      5�      5�      5�      �� 5�   
   $��47,25,29,15q�6   
�������! J� Effect#! [  6<   $��Saving��6`   5�      5�      