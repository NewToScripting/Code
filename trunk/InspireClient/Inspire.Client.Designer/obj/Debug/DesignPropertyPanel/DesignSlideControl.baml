   M S B A M L   `   `   `  ����R  NInspire.Client.Designer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Inspire.Client.Designer.DesignPropertyPanel+Inspire.Client.Designer.DesignPropertyPanel  5      B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire 5      D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands 5      H    BInspire.Client.DesignWindow.DesignPropertyPanel.DesignSlideControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Nd@http://schemas.microsoft.com/expression/interactivedesigner/2006     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      YDesignPropertyPanel9clr-namespace:Inspire.Client.Designer.DesignPropertyPanel     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5      ���	#FF111111  J� CommandBindings  5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5        &   Inspire.Commands.InspireCommands   DeleteSlideCommand   Command# Z 5
      6y     5   
   -   5           UploadSlideToServer# Z 5      6�     5   
   -   5           RefreshSlidesCommand# Z 5      6}    � 	Resources 5         SlideContextMenu m� Command m� Icon �� 
TargetType	 �� Property
 �� Value �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value J� SnapsToDevicePixels ��Name �� Color ��Name J� Opacity J� Effect3  -System.Windows.Media.Effects.DropShadowEffect  	MainColor   Color   Opacity   
BlurRadius   ShadowDepth �� Triggers :� RoutedEvent ��Name  SelectedOff  
SelectedOn N� ExitActions  HoverSelectedOff  N� EnterActions  HoverSelectedOn! ]� 
Conditions" �� Property# �� Value  HoverOff  HoverOn$ P� Property% P� Value 	 DisabledForegroundBrush 
 
WhiteColor& �� Triggers��%  &	        '�� �    7  7  7  7  7  7  7  7  7  7  7  7  7 	 7 
 7  7 
 7 
 �� 5   
   ���	#FF000000.@�5      m� $��Delete Slide��6   # Z 6-   ���	#FF000000 5      �� 5      $��Images/Remove.png��6   $��16��5      $��16��5      5      m� 5      $��Upload to Server��6   # Z 61   ���	#FF000000 5      �� 5      $��Images/Upload24.png��6   $��20��5      $��20��5      5      5      �� 5C   
   " ��6'   .�5D      �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5E      	 �@�OverridesDefaultStyle
 . 66   �� 5F      	 � ��

 ���� 6+   �� 5G      	 � ��
 5H      �� 5I      " ��6&    5J      ���� 5K      HoverOn .��5L   "   U� $ 00:00:00X�6@   $ contentPresenterHover��6U   $ (UIElement.Opacity)�6�   .\�5M   &   �� $ 00:00:00.2000000��6;   $ 1Q�6V   5N   #   U� 5O   "   $ 00:00:00X�6@   $ contentPresenterHover��6U   $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�6�   .\�5P   &   �� $ 00:00:00.2000000��6;   $ 1Q�6V   5Q   #   5R      �� 5S      HoverOff .��5T   "   U� $ 00:00:00X�6@   $ contentPresenterHover��6U   $ (UIElement.Opacity)�6�   .\�5U   &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5V   #   5W      �� 5X      
SelectedOn .��5Y   "   U� $ 00:00:00X�6@   $ contentPresenter��6U   $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�6~   .\�5Z   &   �� $ 00:00:00.1000000��6;   $ 1Q�6V   5[   #   U� 5\   "   $ 00:00:00X�6@   $ Selected��6U   $ (UIElement.Opacity)�6v   .\�5]   &   �� $ 00:00:00.1000000��6;   $ 1Q�6V   5^   #   5_      �� 5`      SelectedOff .��5a   "   U� $ 00:00:00X�6@   $ Selected��6U   $ (UIElement.Opacity)�6v   .\�5b   &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5c   #   U� 5d   "   $ 00:00:00X�6@   $ contentPresenter��6U   $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�6~   .\�5e   &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5f   #   5g      �� 5h      HoverSelectedOn .��5i   "   U� $ 00:00:00X�6@   $ contentPresenterSelected��6U   $ (UIElement.Opacity)�6�   .\�5j   &   �� $ 00:00:00.1000000��6;   $ 1Q�6V   5k   #   5l      �� 5m      HoverSelectedOff .��5n   "   U� $ 00:00:00X�6@   $ contentPresenterSelected��6U   $ (UIElement.Opacity)�6�   .\�5o   &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5p   #   5q      5r      .R�5s      �  . $��	10,0,10,0q�6;   .+�5u      �� $ Border��6%   ��65   Z� �� 5v      $ Selected��6%   $��1,1,1,1q�68   ��5x   "   �� 5y   &   $ Black��66   5�      �� 5�      $ contentPresenterHover��6:   $��2q�6/   $��Center=�6Y   $ 0Q�6�    5�   "     5�   &   8   $ 1Q�6Z   $ 10Q�6f   $ 0Q�6v   5�      �� 5�      $ contentPresenterSelected��6:   $��2q�6/   $��Center=�6\   $ 0Q�6�    5�   "     5�   &   8  $ 1Q�6Z   $ 10Q�6f   $ 0Q�6v   5�      �� 5�      $ contentPresenter��6:   $��2q�6/   $��Center=�6T    5�   "     5�   &   8  $ 0Q�6Z   $ 4Q�6f   $ 0Q�6u   5�      5�       5�      :� 5�      $ FrameworkElement.Loaded��6+   .[�5�   "   �� $' !LoadedSelectedOff_BeginStoryboard��62   8�� 6]   5�      :� 5�      $ ListBoxItem.Selected��6+   .[�5�   "   �� $# LBISelectedOn_BeginStoryboard��62   8�� 6Y   5�      :� 5�      $ ListBoxItem.Unselected��6+   .[�5�   "   �� $$ LBISelectedOff_BeginStoryboard��62   8�� 6Z   5�      ]� 5�       5�   "   �� 5�   &   $&  HoverSelectedOff_BeginStoryboard��6e   8��   5�   "   �� 5�   &   $% HoverSelectedOn_BeginStoryboard��6d   8�� ! 5�   "   �� 5�   &   " �@��
IsSelected# . 6O   �� 5�   &   " �@J�IsMouseOver# . 6G   5�      ]� 5�      ! 5�   "   �� 5�   &   " �@J�IsMouseOver# . 6G   �� 5�   &   " �@��
IsSelected# .  6O    5�   "   �� 5�   &   $ HoverOff_BeginStoryboard��66   8�� 6X     5�   "   �� 5�   &   8��	 66   5�      P� 5�      $ �@��
IsSelected% .  5�   "   �� 5�   &   $! SelectedOff_BeginStoryboard��66   8��
 6[     5�   "   �� 5�   &   $  SelectedOn_BeginStoryboard��66   8�� 6Z   5�      P� 5�      $ � {�% .  . �5�   "   �� 8
  	 � ��6?   5�      P� 5�      $ �@J�IsMouseOver% . . �5�   "   �� 	 � ��

 � � �6?   5�      5�      5�      �� 5�      	 � ��
 5�      �� 5�      8  6&   5�      & 5�      P� 5�      $ �@��
IsSelected% . . �5�      �� 	 � ��
 5�      �� 5�      8  6.   5�      5�      ]� 5�      ! 5�      �� 5�      " �@J�IsMouseOver# . 6;   �� 5�      " �@��
IsSelected# . 6C   ./�5�      �� 	 � ��
 5�      �� 5�      8  6.   5�      5�      ]� 5�      ! 5�      �� 5�      " �@��
IsSelected# . 6C   �� 5�      " �@J�IsMouseOver# . 6;   ./�5�      �� 	 � ��
 5�      �� 5�      8  6.   5�      5�      5�      5�      .��5�      ]� ��. .+�5�   
   �� -   5        $��
btnRefresh��5�      $��Bottom=�6#   $��30��6;   $
��Left=�6G   #��Z 6i   $��Refresh Slides��6�     Inspire.ButtonImage'   Image$' Images\Refresh.png��6�   $  Inspire.InnerGlowBorderControl  5�   
   $	��Top=�6)   (   InnerGlowColor$( 	#ff000000��6>   )   InnerGlowSize$) 9,10,9,0q�6Z   *   InnerGlowOpacity$	* 0.7Q�6s   $��0,0,0,0q�5�   '   ���	#FF111111���	#FF333333$��2,2,2,2q�6g   +   CornerRadius$+ 5,5,5,5��6�   .��5�      � $��0,0,0,0q�6   ��5�      �� 5�      , �� EndPoint$&,  127.499000549316,154.52799987793&�6*   - �� 
StartPoint$- 117.924003601074,149&�6V   . � MappingMode$. Absolute=�6x   / � SpreadMethod$/ Repeat=�6�   .��5�      � 0 � Color$0 	#00000000��6'   � 5�      $0 	#00000000��6'   1 � Offset$1 1Q�69   � 5�      $0 	#00000000��6'   $1 0.498Q�69   � 5�      $0 	#00000000��6'   $1 0.55500000715255737Q�69   � 5      $0 	#FF000000��6'   $1 0.527999997138977Q�69   5     .+�5     � $��0,0,0,0q�6   ��5     �� 5     $', !119.947998046875,156.550994873047&�6.   $'- !125.474998474121,146.977005004883&�6[   $. Absolute=�6�   $/ Repeat=�6�   .��5     � $0 	#00000000��6+   � 5     $0 	#00000000��6+   $1 1Q�6=   � 5     $0 	#00000000��6+   $1 0.498Q�6=   � 5	     $0 	#00000000��6+   $1 0.55500000715255737Q�6=   � 5
     $0 	#FF000000��6+   $1 0.527999997138977Q�6=   5     .+�5       Inspire.Filter  -   5        2  Name$2 DesignerSlideFilter��5  6   $��Search:��6%     Inspire.Slide3   NameSearchStrategy4   SearchStrategy#4 Z3 6S   .��5     �� -   5        5 ��Name$5 DesignSlideWrapPanel��5  "   $��1,0,1,1q�6@   6 �� SelectionMode$6 Single=�6Z   
������ ��6q   Z� ��5     �� 5     7 �� DataType"7  6+   .R�5  "   �� -   5        
������ 8 � ContextMenu#8 [  5  B   ._�5  &   � $��95��6+   9 � ColumnDefinitions9 5  *   �� 5  .   $	��100 �6?   �� 5  .   $��90 �6?   �� 5  .   $	��44* �6?   : � RowDefinitions: 5  *   �� 5  .   $��15 �6<   �� 5  .   $��20 �6<   �� 5  .   $	��50* �6<   .+�5  *   �� ; ��Name$; PART_OfflineControl��65   $y�	Collapsed=�6R   $��0,0,2,2q�6i   < �� Orientation$< 
Horizontal=�6z   $��Bottom=�6�   $��2��6�   $��1��6�   $��2��6�   $��Right=�6�   .+�5  .   � $��0,0,2,0q�63   $��10��6D   $��10��6O   .+�5   2   A� 
���  ��6:   A� 5"  2   = A�Name$= RefractionLayer��6:   ��5#  6   
� 5$  :   > 
� GradientOrigin$> 0.496,1.052&�6N   ? �� RelativeTransform? 5%  >   V� 5&  B   .~�5'  F   �� @ �� CenterX$	@ 0.5Q�6U   A �� CenterY$	A 0.5Q�6c   B �� ScaleX$	B 1.5Q�6q   C �� ScaleY$	C 1.5Q�6~   T� 5(  F   D T� X$
D 0.02Q�6Y   E T� Y$	E 0.3Q�6b   5)  C   .��5+  >   � $1 1Q�6K   $0 	#00000000��6V   � 5,  >   $	1 0.4Q�6K   $0 	#FFFFFFFF��6X   5-  ;   5/  3   F� 51  2   F F�Name$F ReflectionLayer��67   $	��Top=�6P   G �� Stretch$
G Fill=�6h   z�52  6   �� 53  :   $	C 0.5Q�6I   ��55  6   B� 56  :   .��57  >   E� H E� IsClosedH . I E� 
StartPoint$I 98.999,45.499&�6Y   .��58  B   �� J �� Point1$J 98.999,54.170&�6P   K �� Point2$K 89.046,52.258&�6g   L �� Point3$L 85.502,51.029&�6~   �� 59  B   M A� IsSmoothJoinM . $J 75.860,47.685&�5;  %   $K 69.111,45.196&�5<  %   $L 50.167,45.196&�5=  %   �� 5>  B   $J 30.805,45.196&�6P   $K 20.173,47.741&�6g   $L 10.665,51.363&�6~   �� 5?  B   M . $J 7.469,52.580&�5A  %   $K 1.000,53.252&�5B  %   $L 1.000,44.999&�5C  %   �� 5D  B   $J 1.000,39.510&�6P   $K 0.884,39.227&�6f   $L 2.519,34.286&�6|   �� 5E  B   M . $J 9.106,14.370&�5G  %   $K 27.875,0&�5H  %   $
L 50,0&�5I  %   �� 5J  B   $J 72.198,0&�6P   $K 91.018,14.466&�6b   $L 97.546,34.485&�6y   �� 5K  B   M . $J 99.139,39.369&�5M  %   $K 98.999,40.084&�5N  %   $L 98.999,45.499&�5O  %   5P  ?   5Q  ;   ��5S  6   
� 5T  :   $> 0.498,0.526&�6N   ? 5U  >   V� 5V  B   .~�5W  F   �� $	@ 0.5Q�5X  (   $	A 0.5Q�5Y  (   $B 1Q�5Z  (   $C 1.997Q�5[  (   T� 5\  F   $D 0Q�6Y   $	E 0.5Q�6_   5]  C   .��5_  >   � $1 1Q�6K   $0 	#FFFFFFFF��6V   � 5`  >   $
1 0.85Q�6K   $0 	#92FFFFFF��6Y   � 5a  >   $1 0Q�6K   $0 	#00000000��6V   5b  ;   5d  3   5f  /   �� 5g  .     	Highlight#��[ 68   $��9(�6`   	Offline6v   5h  +   �� 5i  *   $��0,2,2,0q�65   $< 
Horizontal=�6F   $��0��6_   $��1��6l   $��2��6|   $��Right=�6�   .+�5j  .   �� #��[ 68   $��9(�6`   (6p   �� 5k  .   #��[ 68   $��9(�6`   ��6m   �� N �� Path$N HResolution��� 5l  .   #��[ 68   $��9(�6`   x6p   �� 5m  .   #��[ 68   $��9(�6`   ��6m   �� $N VResolution��� 5n  .   #��[ 68   $��9(�6`   )6p   5o  +   �� 5q  *   $	��110��64   $
��Left=�6@   $��CharacterEllipsis=�6y   $��12(�6�   $��1��6�   $��1��6�   $��2��6�   O � ToolTipO 6[   �� $
N Name���6�   �� $
N Name� 5r  .     5s  2   $ 1Q�5t  5   P   	Direction$	P 270Q�5u  5   $ Black��5v  5   5y  +   �� 5{  *   $	��130��62   $��80��6>   #��[ 6J   $��0q�6s   
������ Q �� TextWrapping$
Q Wrap=�6�   |�.  R �� 
IsReadOnlyR . $
��Left=�6�   $
��Left=�6  $��12(�6&  $��1��64  $��2��6D  $��2��6X  ��6�   Z� ��6e  �� $N Description�.��6�   5|  .     5}  2   $ 1Q�5~  !   $	P 270Q�5  !   $ Black��5�  !   .��5�  >   O 5�  .   � 5�  2   $	��200��67   .+�5�  6   �� $
Q Wrap=�6>   $��0q�6R   
������ ��6   Z� ��6�   �� $N Description�5�  3   .��5�  ?   5�  +   �� 5�  *   $��0��60   $��0��6@   $��3��6M   $��Center=�6^   S �� BitmapScalingMode$S 
LowQuality=�6�   $��90��6�   $��90��6�   T J� IsHitTestVisibleT .  ��6{   �� $N 	ThumbNail�U �� Mode$U OneWay=�V �� NotifyOnTargetUpdatedV .  5�  .     5�  6   $ 0Q�6G   5�  +   =   7Inspire.Client.Designer.DesignPropertyPanel.SaveControl  5�  *   W  Name$W PART_SaveControl��6J   $��0��6d   $��2��6t   $��3��6�   $��20,0,0,0q�6�   $y�	Collapsed=�6�   5�  '   5�  #   X �� TriggersX 5�  "   �� 5�  &   Y �� Value$
Y true��6O   Z �� BindingZ 62   �� *
IsSaving+.a�5�  *   �� [ �� 
TargetName$[ PART_SaveControl��6W   	 � y�$
 Visible=�6G   6W   5�  '   �� 5�  &   $Y false��6O   Z 62   �� *
IsOnline+.a�5�  *   �� $[ PART_OfflineControl��6W   	 � y�$
 Visible=�6G   6W   5�  '   5�     ��5�     �� 5�     .R�5�  "   $� 5�     5�     5�     5�     5�     5�     5�     5�     