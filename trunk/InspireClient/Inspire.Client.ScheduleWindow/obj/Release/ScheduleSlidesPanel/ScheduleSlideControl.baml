   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  I EInspire.Common, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullgDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.CommonInspire.Common.DragDropListBox ! Inspire.Client.ScheduleWindowK   EInspire.Client.ScheduleWindow.ScheduleSlidePanel.ScheduleSlideControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Nd@http://schemas.microsoft.com/expression/interactivedesigner/2006     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :Inspire&clr-namespace:Inspire;assembly=Inspire     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     `DragDropListBoxDclr-namespace:Inspire.Common.DragDropListBox;assembly=Inspire.Common     ���	#FF111111  J� CommandBindings  )  #System.Windows.Input.CommandBinding  -   &    Inspire.Commands.InspireCommands   RefreshSlidesCommand   Command# Z  � 	Resources    Inspire.InspireApp   inspApp �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key	 g� 	BeginTime
 �� 
TargetName �� TargetProperty O� KeyTime O� Value J� SnapsToDevicePixels ��Name �� Color ��Name J� Opacity J� Effect3  -System.Windows.Media.Effects.DropShadowEffect  	MainColor   Color   Opacity   
BlurRadius   ShadowDepth �� Triggers :� RoutedEvent ��Name  SelectedOff  
SelectedOn N� ExitActions  HoverSelectedOff N� EnterActions  HoverSelectedOn ]� 
Conditions �� Property �� Value  HoverOff  HoverOn  P� Property! P� Value 	 DisabledForegroundBrush 
 
WhiteColor" �� Triggers  SlideTemplate2# � ColumnDefinitions$ � RowDefinitions% �� Orientation  	Highlight& �� Path' � ToolTip(   	Direction) �� TextAlignment* �� TextWrapping+ �� BitmapScalingMode, J� IsHitTestVisible- �� Mode. �� NotifyOnTargetUpdated/ �� Triggers0 �� Value1 �� Binding2 �� 
TargetName��%C  &	        '��      7  7  7  7  7  7  7  7  7  7  7  7  7 	 7 
 7  7 
 7 
 &	 �
    7  7  7  7  7  7  7    �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " �� ���� HoverOn .��U� $	 00:00:00X�$
 contentPresenterHover��$ (UIElement.Opacity)�.\��� $ 00:00:00.2000000��$ 1Q�U� $	 00:00:00X�$
 contentPresenterHover��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.2000000��$ 1Q��� HoverOff .��U� $	 00:00:00X�$
 contentPresenterHover��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� 
SelectedOn .��U� $	 00:00:00X�$
 contentPresenter��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q�U� $	 00:00:00X�$
 Selected��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� SelectedOff .��U� $	 00:00:00X�$
 Selected��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�U� $	 00:00:00X�$
 contentPresenter��$3 -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� HoverSelectedOn .��U� $	 00:00:00X�$
 contentPresenterSelected��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� HoverSelectedOff .��U� $	 00:00:00X�$
 contentPresenterSelected��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�.R��  . $��	10,0,10,0q�.+��� $ Border����Z� �� $ Selected��$��1,1,1,1q����� $ Black���� $ contentPresenterHover��$��2q�$��Center=�$ 0Q�   8   $ 1Q�$ 10Q�$ 0Q��� $ contentPresenterSelected��$��2q�$��Center=�$ 0Q�   8  $ 1Q�$ 10Q�$ 0Q��� $ contentPresenter��$��2q�$��Center=�   8  $ 0Q�$ 4Q�$ 0Q� :� $ FrameworkElement.Loaded��.[��� $' !LoadedSelectedOff_BeginStoryboard��8�� :� $ ListBoxItem.Selected��.[��� $# LBISelectedOn_BeginStoryboard��8�� :� $ ListBoxItem.Unselected��.[��� $$ LBISelectedOff_BeginStoryboard��8�� ]�  �� $&  HoverSelectedOff_BeginStoryboard��8��  �� $% HoverSelectedOn_BeginStoryboard��8��  ��  �@��
IsSelected . ��  �@J�IsMouseOver . ]�  ��  �@J�IsMouseOver . ��  �@��
IsSelected .   �� $ HoverOff_BeginStoryboard��8��  �� 8��	 P�   �@��
IsSelected! .  �� $! SelectedOff_BeginStoryboard��8��
  �� $  SelectedOn_BeginStoryboard��8�� P�   � {�! .  . ��� 8   � ����  � �� �� 8  " P�   �@��
IsSelected! . . ���  � �� �� 8  ��  � ��
 ���� ]�  ��  �@J�IsMouseOver . ��  �@��
IsSelected . ./���  � �� �� 8  ]�  ��  �@��
IsSelected . ��  �@J�IsMouseOver . ./���  � �� �� 8  �� .R��� $ PART_SlideControl2��
������ ._�� $��95��
������ # �� $	��100 ��� $��90 ��� $	��44* �$ �� $��15 ��� $��20 ��� $	��50* �.+��� $��0,2,2,0q�
������ $% 
Horizontal=�$��0��$��1��$��2��$��Right=�.+��� 8��  $��9(�(�� 8�� $��9(����� $& HResolution��� 8�� $��9(�x�� 8�� $��9(����� $& VResolution��� 8�� $��9(�)�� $	��110��8�� $��CharacterEllipsis=�$
��Left=�$��12(�$��1��$��1��$��2��' �� $
& Name����� $
& Name�   $ 1Q�$	( 270Q�$ Black���� $	��130��$	��100��8�� $��CharacterEllipsis=�
������ $
��Wrap=�|�.  $
) Left=�$
��Left=�$��12(�$��1��$��2��$��2����Z� ���� $& Description�   $ 1Q�$	( 270Q�$ Black��' � $	��200��.+��� $
* Wrap=�$��0q�
������ ��Z� ���� $& Description��� $��0��$��0��$��3��$��Center=�$+ 
LowQuality=�$��90��$��90��, .  ���� $& 	ThumbNail�$- OneWay=�. .    $ 0Q�/ �� $
0 true��1 �� *
IsSaving+.a��� $2 PART_SlideControl2�� � y�$ 	Collapsed=��� $0 false��1 �� *
IsOnline+.a��� $2 PART_SlideControl2�� � y�$ 	Collapsed=�.��]� ��. .+��� -   $��
btnRefresh��$��Bottom=�$��30��$
��Left=�#��Z $��Refresh Slides��   Inspire.ButtonImage3   Image$3 Images\Refresh.png��$   Inspire.InnerGlowBorderControl  $	��Top=�4   InnerGlowColor$4 	#ff000000��5   InnerGlowSize$5 9,10,9,0q�6   InnerGlowOpacity$	6 0.7Q�$��0,0,0,0q����	#FF111111���	#FF333333$��2,2,2,2q�7   CornerRadius$7 5,5,5,5��.��� $��0,0,0,0q����� 8 �� EndPoint$&8  127.499000549316,154.52799987793&�9 �� 
StartPoint$9 117.924003601074,149&�: � MappingMode$: Absolute=�; � SpreadMethod$; Repeat=�.��� < � Color$< 	#00000000��� $< 	#00000000��= � Offset$= 1Q�� $< 	#00000000��$= 0.498Q�� $< 	#00000000��$= 0.55500000715255737Q�� $< 	#FF000000��$= 0.527999997138977Q�.+�� $��0,0,0,0q����� $'8 !119.947998046875,156.550994873047&�$'9 !125.474998474121,146.977005004883&�$: Absolute=�$; Repeat=�.��� $< 	#00000000��� $< 	#00000000��$= 1Q�� $< 	#00000000��$= 0.498Q�� $< 	#00000000��$= 0.55500000715255737Q�� $< 	#FF000000��$= 0.527999997138977Q�.+��� -   > ��Name$> SlideWrapPanel��
������ $��1,0,1,1q�? �� SelectionMode$? Single=�3  -Inspire.Common.DragDropListBox.DragDropHelper@   DragDropTemplate#@ [ A   IsDragSourceA . B   IsDropTargetB .  ��Z� ���� C �� DataType   Inspire.Slide"C  .R��� $ PART_SlideControl��
������ ._�� -   $��95��
������ # �� $	��100 ��� $��90 ��� $	��44* �$ �� $��15 ��� $��20 ��� $	��50* �.+��� $��0,2,2,0q�
������ $% 
Horizontal=�$��0��$��1��$��2��$��Right=�.+��� #��[ $��9(�(�� #��[ $��9(����� $& HResolution��� #��[ $��9(�x�� #��[ $��9(����� $& VResolution��� #��[ $��9(�)�� $	��110��$��CharacterEllipsis=�$
��Left=�$��12(�$��1��$��1��$��2��' �� $
& Name����� $
& Name�   $ 1Q�$	( 270Q�$ Black���� $	��130��$	��100��#��[ $��CharacterEllipsis=�
������ $
��Wrap=�|�.  $
) Left=�$
��Left=�$��12(�$��1��$��2��$��2����Z� ���� $& Description�   $ 1Q�$	( 270Q�$ Black��' � $	��200��.+��� $
* Wrap=�$��0q�
������ ��Z� ���� $& Description��� $��0��$��0��$��3��$��Center=�$+ 
LowQuality=�$��90��$��90��, .  ���� $& 	ThumbNail�$- OneWay=�. .    $ 0Q�/ �� $
0 true��1 �� *
IsSaving+.a��� $2 PART_SlideControl�� � y�$ 	Collapsed=��� $0 false��1 �� *
IsOnline+.a��� $2 PART_SlideControl�� � y�$ 	Collapsed=����� .R�$� 
������ 