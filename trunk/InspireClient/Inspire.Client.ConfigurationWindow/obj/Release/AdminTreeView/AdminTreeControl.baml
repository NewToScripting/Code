   M S B A M L   `   `   `  ���� I  EInspire.Common, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullcBclr-namespace:Inspire.Common.TreeViewModel;assembly=Inspire.CommonInspire.Common.TreeViewModel  B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands 2&clr-namespace:Inspire;assembly=InspireInspire & "Inspire.Client.ConfigurationWindowG   AInspire.Client.ConfigurationWindow.AdminTreeView.AdminTreeControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Nd@http://schemas.microsoft.com/expression/interactivedesigner/2006     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     \TreeViewModelBclr-namespace:Inspire.Common.TreeViewModel;assembly=Inspire.Common     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     :Inspire&clr-namespace:Inspire;assembly=Inspire     -   ���	#FF111111$	��250��  � 	Resources  ��%     J� CommandBindings )  #System.Windows.Input.CommandBinding  -   &   Inspire.Commands.InspireCommands   NewDisplayCommand   Command# Z   -      EditDisplayCommand# Z   -      DeleteDisplayCommand# Z   -      NewPropertyCommand# Z   -      EditPropertyCommand# Z   -      DeletePropertyCommand# Z   -   	   NewDisplayGroupCommand# Z	   -	   
   EditDisplayGroupCommand# Z
   -
       DeleteDisplayGroupCommand# Z   -      RefreshTreeCommand# Z .��]� ��. .+��� -   $��
btnRefresh��$��Bottom=�$��30��$
��Left=�#��Z $��Refresh Displays��  Inspire.ButtonImage   Image$" Resources\Images\Refresh.png��$  Inspire.InnerGlowBorderControl  $	��Top=�   InnerGlowColor$ 	#ff000000��   InnerGlowSize$ 	0,0,15,15q�   InnerGlowOpacity$	 0.7Q�$��0,0,0,0q����	#FF111111���	#FF333333$��2,2,2,2q�   CornerRadius$ 5,5,5,5��.��� $��0,0,0,0q�����  �� EndPoint$&  127.499000549316,154.52799987793&� �� 
StartPoint$ 117.924003601074,149&� � MappingMode$ Absolute=� � SpreadMethod$ Repeat=�.���  � Color$ 	#00000000��� $ 	#00000000�� � Offset$ 1Q�� $ 	#00000000��$ 0.498Q�� $ 	#00000000��$ 0.55500000715255737Q�� $ 	#FF000000��$ 0.527999997138977Q�.+�� $��0,0,0,0q����� $' !119.947998046875,156.550994873047&�$' !125.474998474121,146.977005004883&�$ Absolute=�$ Repeat=�.��� $ 	#00000000��� $ 	#00000000��$ 1Q�� $ 	#00000000��$ 0.498Q�� $ 	#00000000��$ 0.55500000715255737Q�� $ 	#FF000000��$ 0.527999997138977Q�.+�R� -    R�Name$ 	AdminTree��
������ $��Stretch=�$	��200��   TreeMenu � ContextMenu# [  ��Z� ���� *DisplayProperties+����  �� 
TargetType" Q�.���  �� Property �@Q�
IsExpanded �� Value �� *
IsExpanded+ �� Mode$ TwoWay=���  �@Q�
IsSelected �� *
IsSelected+$ TwoWay=���  � ��
 ���� ��  � �� ��  �� Path$  HorizontalContentAlignment� �� RelativeSource ��   �� AncestorType"  ����  � �� �� $ VerticalContentAlignment� �� "  ����  � ��$ 1,0,0,0q���  � �� �� ! �� 
TargetType"! Q�" � 	Resources"   HoverOn# g� 	BeginTime$ �� 
TargetName% �� TargetProperty& O� KeyTime' O� Value  HoverOff  
SelectedOn  SelectedOff  SelectedHoverOn  SelectedHoverOff��%f  &	       &	 t     &	 �     &	 s    &	 �    &	 �    �� .��U� $# 00:00:00X�$$ PART_HeaderHover��$% (UIElement.Opacity)�.\��� $& 00:00:00.1000000��$' 1Q��� .��U� $# 00:00:00X�$$ PART_HeaderHover��$% (UIElement.Opacity)�.\��� $& 00:00:00.3000000��$' 0Q��� .��U� $# 00:00:00X�$$ PART_Header��$3% -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $& 00:00:00.1000000��$	' 0.6Q��� .��U� $# 00:00:00X�$$ PART_Header��$3% -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $& 00:00:00.3000000��$' 0Q��� .��U� $# 00:00:00X�$$ PART_HeaderSelectedHover��$3% -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $& 00:00:00.1000000��$	' 0.6Q��� .��U� $# 00:00:00X�$$ PART_HeaderSelectedHover��$3% -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $& 00:00:00.3000000��$' 0Q�.R�� ( � ColumnDefinitions( �� $��19��$
��Auto ��� $
��Auto ��� $��* �) � RowDefinitions) �� $
��Auto ��� .+�d� * d�Name$* Expander�� # nuclearTreeViewItemToggleButton#��[ + �� 	ClickMode$+ Press=�, d� 	IsChecked, �� $ 
IsExpanded� �� *TemplatedParent+�� - ��Name$- Selection_Border��$��1��#��z��. �� Padding#. z��/ �� CornerRadius$/ 4,4,4,4��._�� $
��Auto��$
��Auto��$��2,0,2,0q�.+��� 0 ��Name$0 PART_Header��$��Stretch=�$��Header��$��0,1,0,1q�1 J� Effect1 3  -System.Windows.Media.Effects.DropShadowEffect    	MainColor2   Color#2 [ 3   Opacity$3 0Q�4   
BlurRadius$4 6Q�5   ShadowDepth$5 0Q��� $0 PART_HeaderHover��$��Stretch=�$��Header��6 J� Opacity$6 0Q�$��0,1,0,1q�1   #2 [ $5 0Q�$4 6Q��� $0 PART_HeaderSelectedHover��$��Stretch=�$��Header��$��0,1,0,1q�1   #2 [ $3 0Q�$5 0Q�$4 6Q��� $- border��$��0,0,-3.803,0q�$��1��$��1��$��1��$/ 4,4,4,4���� 7 ��Name$7 	ItemsHost��$��1��$��2��$��1��8 �� Triggers8 ]� 9 N� ExitActions9 �� : ��Name$&:  SelectedHoverOff_BeginStoryboard��#��[ ; N� EnterActions; �� $%: SelectedHoverOn_BeginStoryboard��#��[ < ]� 
Conditions< �� = �� Property= �@Q�
IsSelected> �� Value> . �� = �@J�IsMouseOver> . ]� < �� = �@Q�
IsSelected> .  �� ? �� 
SourceName$? Selection_Border��= �@J�IsMouseOver> . 9 �� $: HoverOff_BeginStoryboard��#��[ ; �� #��[ P� @ P� Property@ �@Q�
IsExpandedA P� ValueA .  . ��� B �� 
TargetName$B 	ItemsHost�� � y�$ 	Collapsed=�P� @ �@��HasItemsA .  . ��� $B Expander�� � y�$ Hidden=�P� @ �@Q�
IsSelectedA . 9 �� $!: SelectedOff_BeginStoryboard��#��[ ; �� $ : SelectedOn_BeginStoryboard��#��[ . ��� # ["�� � ��]� < �� = �@Q�
IsSelected> . �� = �@Q�IsSelectionActive> .  ./��� # ["�� � ���� $B Selection_Border�� � �� �	#3F545454�� $B border�� � �� �	#72000000P� @ � {�A .  . ��� # ["�� � ����  � �� ��  	 
WhiteColorC �� Color#C [	 D �� TriggersD P� @ �@Q�
IsSelectedA .   E �� DataType4   .Inspire.Common.TreeViewModel.PropertyViewModelF �� ItemsSourceG �� Orientation 
 DisplayPropertyMenu8   2Inspire.Common.TreeViewModel.DisplayGroupViewModel  DisplayGroupMenuH J� SnapsToDevicePixels3   -Inspire.Common.TreeViewModel.DisplayViewModel  AdminDisplayMenuI �� BindingJ �� Value��%!  (��       *, +)7 
 (�� �     *, +)7  (�� �    *, +)7  �� "E  F �� *
Children+.R��� -   $G 
Horizontal=�8   .+��� $��24��$��24��$	��3,0q�$#��Resources\Images\Property.ico���� $��Center=�
����������� *PropertyName+�� "E  F �� *
Children+.R��� -   $G 
Horizontal=�8   .+��� $��24��$��24��$	��3,0q�$'��!Resources\Images\DisplayGroup.ico��H . �� $��Center=����� *DisplayGroupName+�� "E  .R��� -   $G 
Horizontal=�8   .+�� .+��� $��24��$��24��$	��3,0q�$"��Resources\Images\Display.ico���� $��DisplayInactive��$��20��$��20��$��
-10,0,0,10q�$"��Resources\Images\Caution.png������ " ��D �� I �� $ IsActive�J 1.a���  � y�$ 	Collapsed=��� $��Center=����� *DisplayName+