   M S B A M L   `   `   `  ���� R  NInspire.Client.Designer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Inspire.Client.Designer.DesignPropertyPanel+Inspire.Client.Designer.DesignPropertyPanel  B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands H    BInspire.Client.DesignWindow.DesignPropertyPanel.DesignSlideControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Nd@http://schemas.microsoft.com/expression/interactivedesigner/2006     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     YDesignPropertyPanel9clr-namespace:Inspire.Client.Designer.DesignPropertyPanel     :Inspire&clr-namespace:Inspire;assembly=Inspire     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     ���	#FF111111  J� CommandBindings  )  #System.Windows.Input.CommandBinding  -   &   Inspire.Commands.InspireCommands   DeleteSlideCommand   Command# Z   -      UploadSlideToServer# Z   -      RefreshSlidesCommand# Z  � 	Resources    SlideContextMenu m� Command m� Icon �� 
TargetType	 �� Property
 �� Value �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value J� SnapsToDevicePixels ��Name �� Color ��Name J� Opacity J� Effect3  -System.Windows.Media.Effects.DropShadowEffect  	MainColor   Color   Opacity   
BlurRadius   ShadowDepth �� Triggers :� RoutedEvent ��Name  SelectedOff  
SelectedOn N� ExitActions  HoverSelectedOff  N� EnterActions  HoverSelectedOn! ]� 
Conditions" �� Property# �� Value  HoverOff  HoverOn$ P� Property% P� Value 	 DisabledForegroundBrush 
 
WhiteColor& �� Triggers��%i  &	        '�� �     7  7  7  7  7  7  7  7  7  7  7  7  7 	 7 
 7  7 
 7 
 �� ���	#FF000000.@�m� $��Delete Slide��# Z ���	#FF000000 �� $��Images/Remove.png��$��16��$��16��m� $��Upload to Server��# Z ���	#FF000000 �� $��Images/Upload24.png��$��20��$��20���� " ��.��� 	 �@J�SnapsToDevicePixels
 . �� 	 �@�OverridesDefaultStyle
 . �� 	 � ��

 ���� �� 	 � ��
 �� " �� ���� HoverOn .��U� $ 00:00:00X�$ contentPresenterHover��$ (UIElement.Opacity)�.\��� $ 00:00:00.2000000��$ 1Q�U� $ 00:00:00X�$ contentPresenterHover��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.2000000��$ 1Q��� HoverOff .��U� $ 00:00:00X�$ contentPresenterHover��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� 
SelectedOn .��U� $ 00:00:00X�$ contentPresenter��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q�U� $ 00:00:00X�$ Selected��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� SelectedOff .��U� $ 00:00:00X�$ Selected��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�U� $ 00:00:00X�$ contentPresenter��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� HoverSelectedOn .��U� $ 00:00:00X�$ contentPresenterSelected��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� HoverSelectedOff .��U� $ 00:00:00X�$ contentPresenterSelected��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�.R��  . $��	10,0,10,0q�.+��� $ Border����Z� �� $ Selected��$��1,1,1,1q����� $ Black���� $ contentPresenterHover��$��2q�$��Center=�$ 0Q�   8   $ 1Q�$ 10Q�$ 0Q��� $ contentPresenterSelected��$��2q�$��Center=�$ 0Q�   8  $ 1Q�$ 10Q�$ 0Q��� $ contentPresenter��$��2q�$��Center=�   8  $ 0Q�$ 4Q�$ 0Q� :� $ FrameworkElement.Loaded��.[��� $' !LoadedSelectedOff_BeginStoryboard��8�� :� $ ListBoxItem.Selected��.[��� $# LBISelectedOn_BeginStoryboard��8�� :� $ ListBoxItem.Unselected��.[��� $$ LBISelectedOff_BeginStoryboard��8�� ]�  �� $&  HoverSelectedOff_BeginStoryboard��8��   �� $% HoverSelectedOn_BeginStoryboard��8�� ! �� " �@��
IsSelected# . �� " �@J�IsMouseOver# . ]� ! �� " �@J�IsMouseOver# . �� " �@��
IsSelected# .   �� $ HoverOff_BeginStoryboard��8��   �� 8��	 P� $ �@��
IsSelected% .  �� $! SelectedOff_BeginStoryboard��8��
   �� $  SelectedOn_BeginStoryboard��8�� P� $ � {�% .  . ��� 8
  	 � ��P� $ �@J�IsMouseOver% . . ��� 	 � ��

 � � ��� 	 � ��
 �� 8  & P� $ �@��
IsSelected% . . ��� 	 � ��
 �� 8  ]� ! �� " �@J�IsMouseOver# . �� " �@��
IsSelected# . ./��� 	 � ��
 �� 8  ]� ! �� " �@��
IsSelected# . �� " �@J�IsMouseOver# . ./��� 	 � ��
 �� 8  .��]� ��. .+��� -   $��
btnRefresh��$��Bottom=�$��30��$
��Left=�#��Z $��Refresh Slides��  Inspire.ButtonImage'   Image$' Images\Refresh.png��$  Inspire.InnerGlowBorderControl  $	��Top=�(   InnerGlowColor$( 	#ff000000��)   InnerGlowSize$) 9,10,9,0q�*   InnerGlowOpacity$	* 0.7Q�$��0,0,0,0q����	#FF111111���	#FF333333$��2,2,2,2q�+   CornerRadius$+ 5,5,5,5��.��� $��0,0,0,0q����� , �� EndPoint$&,  127.499000549316,154.52799987793&�- �� 
StartPoint$- 117.924003601074,149&�. � MappingMode$. Absolute=�/ � SpreadMethod$/ Repeat=�.��� 0 � Color$0 	#00000000��� $0 	#00000000��1 � Offset$1 1Q�� $0 	#00000000��$1 0.498Q�� $0 	#00000000��$1 0.55500000715255737Q�� $0 	#FF000000��$1 0.527999997138977Q�.+�� $��0,0,0,0q����� $', !119.947998046875,156.550994873047&�$'- !125.474998474121,146.977005004883&�$. Absolute=�$/ Repeat=�.��� $0 	#00000000��� $0 	#00000000��$1 1Q�� $0 	#00000000��$1 0.498Q�� $0 	#00000000��$1 0.55500000715255737Q�� $0 	#FF000000��$1 0.527999997138977Q�.+�  Inspire.Filter  -   2  Name$2 DesignerSlideFilter��$��Search:��  Inspire.Slide3   NameSearchStrategy4   SearchStrategy#4 Z3 .���� -   5 ��Name$5 DesignSlideWrapPanel��$��1,0,1,1q�6 �� SelectionMode$6 Single=�
������ ��Z� ���� 7 �� DataType"7  .R��� -   
������ 8 � ContextMenu#8 [  ._�� $��95��9 � ColumnDefinitions9 �� $	��100 ��� $��90 ��� $	��44* �: � RowDefinitions: �� $��15 ��� $��20 ��� $	��50* �.+��� ; ��Name$; PART_OfflineControl��$y�	Collapsed=�$��0,0,2,2q�< �� Orientation$< 
Horizontal=�$��Bottom=�$��2��$��1��$��2��$��Right=�.+�� $��0,0,2,0q�$��10��$��10��.+�A� 
���  ��A� = A�Name$= RefractionLayer����
� > 
� GradientOrigin$> 0.496,1.052&�? �� RelativeTransform? V� .~��� @ �� CenterX$	@ 0.5Q�A �� CenterY$	A 0.5Q�B �� ScaleX$	B 1.5Q�C �� ScaleY$	C 1.5Q�T� D T� X$
D 0.02Q�E T� Y$	E 0.3Q�.��� $1 1Q�$0 	#00000000��� $	1 0.4Q�$0 	#FFFFFFFF��F� F F�Name$F ReflectionLayer��$	��Top=�G �� Stretch$
G Fill=�z��� $	C 0.5Q���B� .��E� H E� IsClosedH . I E� 
StartPoint$I 98.999,45.499&�.���� J �� Point1$J 98.999,54.170&�K �� Point2$K 89.046,52.258&�L �� Point3$L 85.502,51.029&��� M A� IsSmoothJoinM . $J 75.860,47.685&�$K 69.111,45.196&�$L 50.167,45.196&��� $J 30.805,45.196&�$K 20.173,47.741&�$L 10.665,51.363&��� M . $J 7.469,52.580&�$K 1.000,53.252&�$L 1.000,44.999&��� $J 1.000,39.510&�$K 0.884,39.227&�$L 2.519,34.286&��� M . $J 9.106,14.370&�$K 27.875,0&�$
L 50,0&��� $J 72.198,0&�$K 91.018,14.466&�$L 97.546,34.485&��� M . $J 99.139,39.369&�$K 98.999,40.084&�$L 98.999,45.499&���
� $> 0.498,0.526&�? V� .~��� $	@ 0.5Q�$	A 0.5Q�$B 1Q�$C 1.997Q�T� $D 0Q�$	E 0.5Q�.��� $1 1Q�$0 	#FFFFFFFF��� $
1 0.85Q�$0 	#92FFFFFF��� $1 0Q�$0 	#00000000����   	Highlight#��[ $��9(�	Offline�� $��0,2,2,0q�$< 
Horizontal=�$��0��$��1��$��2��$��Right=�.+��� #��[ $��9(�(�� #��[ $��9(����� N �� Path$N HResolution��� #��[ $��9(�x�� #��[ $��9(����� $N VResolution��� #��[ $��9(�)�� $	��110��$
��Left=�$��CharacterEllipsis=�$��12(�$��1��$��1��$��2��O � ToolTipO �� $
N Name����� $
N Name�   $ 1Q�P   	Direction$	P 270Q�$ Black���� $	��130��$��80��#��[ $��0q�
������ Q �� TextWrapping$
Q Wrap=�|�.  R �� 
IsReadOnlyR . $
��Left=�$
��Left=�$��12(�$��1��$��2��$��2����Z� ���� $N Description�.��   $ 1Q�$	P 270Q�$ Black��.��O � $	��200��.+��� $
Q Wrap=�$��0q�
������ ��Z� ���� $N Description�.���� $��0��$��0��$��3��$��Center=�S �� BitmapScalingMode$S 
LowQuality=�$��90��$��90��T J� IsHitTestVisibleT .  ���� $N 	ThumbNail�U �� Mode$U OneWay=�V �� NotifyOnTargetUpdatedV .    $ 0Q�=   7Inspire.Client.Designer.DesignPropertyPanel.SaveControl  W  Name$W PART_SaveControl��$��0��$��2��$��3��$��20,0,0,0q�$y�	Collapsed=�X �� TriggersX �� Y �� Value$
Y true��Z �� BindingZ �� *
IsSaving+.a��� [ �� 
TargetName$[ PART_SaveControl��	 � y�$
 Visible=��� $Y false��Z �� *
IsOnline+.a��� $[ PART_OfflineControl��	 � y�$
 Visible=����� .R�$� 