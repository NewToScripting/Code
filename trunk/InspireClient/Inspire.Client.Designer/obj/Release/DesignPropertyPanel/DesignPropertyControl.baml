   M S B A M L   `   `   `  ���� ^  ZDevComponents.WpfRibbon, Version=5.8.0.6, Culture=neutral, PublicKeyToken=2037e151916410e7bFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbonDevComponents.WpfRibbon  R NInspire.Client.Designer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Inspire.Client.DesignWindow.DesignPropertyPanel/Inspire.Client.DesignWindow.DesignPropertyPanel a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes i9clr-namespace:Inspire.Client.Designer.DesignPropertyPanel+Inspire.Client.Designer.DesignPropertyPanel S OInspire.AnimationLibrary, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:Inspire.AnimationLibrary;assembly=Inspire.AnimationLibraryInspire.AnimationLibrary G   AInspire.Client.Designer.DesignPropertyPanel.DesignPropertyControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \	WpfRibbonFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbon     Nd@http://schemas.microsoft.com/expression/interactivedesigner/2006     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ]DesignPropertyPanel=clr-namespace:Inspire.Client.DesignWindow.DesignPropertyPanel     oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     ZDesignPropertyPanel19clr-namespace:Inspire.Client.Designer.DesignPropertyPanel     eAnimationLibraryHclr-namespace:Inspire.AnimationLibrary;assembly=Inspire.AnimationLibrary       � 	Resources     VisibleImage �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color �� Triggers �� Binding �� Path �� Value  	HideImage  	LockImage  UnlockImage  UnSelectableImage  SelectableImage  TextBoxBorder	 �� EndPoint
 �� 
StartPoint � MappingMode � Color � Offset  TextBoxStyle1 �� BasedOn �� 
TargetType,  &Microsoft.Windows.Themes.ListBoxChrome  Name J� SnapsToDevicePixels   
Background   BorderBrush   BorderThickness J� IsKeyboardFocusWithin   RenderFocused J� IsMouseOver   RenderMouseOver ��Name �� Triggers P� Property P� Value �� 
TargetName  
LayerStyle � 	Resources 	 Key g� 	BeginTime  �� 
TargetName! �� TargetProperty" O� KeyTime# O� Value$ ��Name% J� Opacity& �� CornerRadius 
 	MainColor' �� Color( ��Name) J� Effect*   Opacity+   
BlurRadius, N� ExitActions- ��Name  HoverSelectedOff. N� EnterActions  HoverSelectedOn/ ]� 
Conditions0 �� Property1 �� Value  HoverOff  HoverOn  SelectedOff  
SelectedOn  DisabledForegroundBrush  
WhiteColor  TitleTemplate2 ��Name  SunkenBackground3 J� IsHitTestVisible4 �Name5 � ColumnDefinitions6 �� 
IsReadOnly7 ��Name8 ��Name  TabTemplate��%�  &	        &	 �     &	 �    &	 ?    &	      &	 �    &	 �    &	     7��7��7  7��7��&	 �    7 
 7 
 7 
 7 
 7  7  7  7  7  7  7  7  7 
 7  7  &	 �    7  7  7  7  7  7  7  7   7  &	 �    �� " ��.���  � ��$ Images/visible.png����  � y�$ 	Collapsed=���  �@J�Effect   $ Green�� ��  �� $ 	IsVisible� true.a���  � y�$ Visible=��� " ��.���  � ��$ Images/visible.png����  � y�$ 	Collapsed=���  �@J�Effect   $	 Red�� ��  �� $ 	IsVisible�	 false.a���  � y�$ Visible=��� " ��.���  � ��$ Images/lock.png����  � y�$ 	Collapsed=���  �@J�Effect   $	 Red�� ��  �� $ IsLocked� true.a���  � y�$ Visible=��� " ��.���  � ��$ Images/unlock.png����  � y�$ 	Collapsed=���  �@J�Effect   $ Green�� ��  �� $ IsLocked�	 false.a���  � y�$ Visible=��� " ��.���  � ��$ Images/Selectable.png����  � y�$ 	Collapsed=���  �@J�Effect   $ Green�� ��  �� $ IsHitTestVisible� true.a���  � y�$ Visible=��� " ��.���  � ��$ Images/UnSelectable.png����  � y�$ 	Collapsed=���  �@J�Effect   $	 Red�� ��  �� $ IsHitTestVisible�	 false.a���  � y�$ Visible=��� $
	 0,20&�$	
 0,0&�$ Absolute=�.��� $ #ABADB3��$
 0.05Q�� $ #E2E3EA��$
 0.07Q�� $ #E3E9EF��$ 1Q��� " �� Z� .���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��$ 1q���  �@J�	AllowDrop . ��  �@�FocusVisualStyle Z� ��  � �� �� " ��.R�  $ Bd�� . # z��# z��# z��# z # z ._��� $ PART_ContentHost��# z  P�  � {� .  . ��� $ Bd��8   �@ 
Background�� 8   � ���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " �� ���� HoverOn	 .��U� $ 00:00:00X�$  contentPresenterHover��$! (UIElement.Opacity)�.\��� $" 00:00:00.2000000��$# 1Q�U� $ 00:00:00X�$  contentPresenterHover��$3! -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $" 00:00:00.2000000��$# 1Q��� HoverOff	 .��U� $ 00:00:00X�$  contentPresenterHover��$! (UIElement.Opacity)�.\��� $" 00:00:00.3000000��$# 0Q��� 
SelectedOn	 .��U� $ 00:00:00X�$  contentPresenter��$3! -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $" 00:00:00.1000000��$# 1Q�U� $ 00:00:00X�$  Selected��$! (UIElement.Opacity)�.\��� $" 00:00:00.1000000��$# 1Q��� SelectedOff	 .��U� $ 00:00:00X�$  Selected��$! (UIElement.Opacity)�.\��� $" 00:00:00.3000000��$# 0Q�U� $ 00:00:00X�$  contentPresenter��$3! -(UIElement.Effect).(DropShadowEffect.Opacity)�.\��� $" 00:00:00.3000000��$# 0Q��� HoverSelectedOn	 .��U� $ 00:00:00X�$  contentPresenterSelected��$! (UIElement.Opacity)�.\��� $" 00:00:00.1000000��$# 1Q��� HoverSelectedOff	 .��U� $ 00:00:00X�$  contentPresenterSelected��$! (UIElement.Opacity)�.\��� $" 00:00:00.3000000��$# 0Q�.R��  . $��5,0,0,0q�.+��� $$ Border����Z� �� $$ Selected��$% 0Q����	#4C000000$��1,1,1,1q�$& 2,2,2,2��$y�	Collapsed=����� 8'   ._��� $��1,1,1,1q�$& 1,1,1,1������ $	 0.5,1&�$
 0.5,0&�.��� $ 	#FF000000��$ 0Q�� $ 	#FFFFFFFF��$ 1Q�� $ 	#FF616161��$ 0.219Q��� $( contentPresenterHover��$��5,2,1,2q�$��Center=�$% 0Q�)   8  $* 1Q�$+ 10Q��� $( contentPresenterSelected��$��5,2,1,2q�$��Center=�$% 0Q�)   8  $* 1Q�$+ 10Q��� $( contentPresenter��$��5,2,1,2q�$��Center=�)   8  $* 0Q�$+ 4Q� ]� , �� $&-  HoverSelectedOff_BeginStoryboard��8�� . �� $%- HoverSelectedOn_BeginStoryboard��8�� / �� 0 �@��
IsSelected1 . �� 0 �@J�IsMouseOver1 . ]� / �� 0 �@J�IsMouseOver1 . �� 0 �@��
IsSelected1 .  , �� $- HoverOff_BeginStoryboard��8�� . �� 8�� P�  �@��
IsSelected . , �� $!- SelectedOff_BeginStoryboard��8�� . �� $ - SelectedOn_BeginStoryboard��8��	 P�  � {� .  . ��� 8 
  � ����  � �� �� 8'   P�  �@��
IsSelected . . ���  � �� �� 8'  ��  �� $ 
IsSelected� True.a���  �@��
IsSelected . ]� / �� 0 �@J�IsMouseOver1 . �� 0 �@��
IsSelected1 .  ./���  � �� �� 8'  ]� / �� 0 �@��
IsSelected1 . �� 0 �@J�IsMouseOver1 . ./���  � �� �� 8'  �� .R��� $2 lbiLayer��-   8��  8�� 3 . .���� $$ btnLayer��
�������$��1q����	#01000000._�� $4 grLayer��{�. 5 �� $��20 ��� $��20 ��� $	��150 ��� $��20 �.+��� -   $��2��$��2q�$��Center=�8�� $��0q�6 . 
�������
������ $
��Bold"����� $ Content.Tag��� $7 imgLock��-   $��0��$��2q�$
��Left=�$��Bottom=�8�� $��16���� $7 	imgUnLock��-   $��0��$��2q�$
��Left=�$��Bottom=�8�� $��16���� $7 imgUnSelectable��-   $��1��$��2q�$
��Left=�$��Bottom=�8�� $��16���� $7 imgSelectable��-   $��1��$��2q�$
��Left=�$��Bottom=�8�� $��16���� $7 
imgVisible��-   $��3��$��2q�$��16��$��Right=�8�� �� $7 imgHide��-   $��3��$��2q�$��16��$��Right=�8�� �� $8 txtGuid��$y�	Collapsed=����� $
 GUID��� .R��� ���� .��,   &DevComponents.WpfRibbon.NavigationPane  
9 � Tag$9 
Properties��:   ContentTemplate#: [ $��LeftToRight=�$��Right=�$	��268��  WindowBackgroundBrush#��[ .@�&    DevComponents.WpfRibbon.PaneItem  -	   ;  Name$; PropertiesPane��$��
Properties��.���� -
   < ��Name$< PropertyLayerTabControl��= �� TabStripPlacement$	= Top=�$��Stretch=�#��[ .@��� $��Layers��$��Stretch=�  
Foreground#��[ .���� -   > ��Name$> 
LayerPanel��#��[ ? $� IsVirtualizing? .  @ $� VirtualizationMode$@ 	Recycling=�$��Visible=�#��[ �� -   A ��Name$A PropertyTab��$��
Properties��#��[ .���� $
��Auto=�.���� $��0,0,5,0q�._�� .+�� -   $4 CanvasPropertyGrid��$��Stretch=�#��[ .+�E  ?Inspire.Client.Designer.DesignPropertyPanel.CanvasPropertyPanel  -   B  Name$B CanvasPropPanel��#��[ C  =Inspire.Client.Designer.DesignPropertyPanel.PropertyPanelPart  -   C  Name$C ControlPropertyGrid��$��Stretch=��� $��
Animations��$��Stretch=�#��[ .��1  +Inspire.AnimationLibrary.StoryBoardSelector  -   D  Name$D AnimationPanel��#��[ $	��Top=�  E   
IsSelectedE . $��Slides��.��� -   $��
SlidePanel��$��Stretch=�.+�H  BInspire.Client.DesignWindow.DesignPropertyPanel.DesignSlideControl  -   F  Name$F designSlideControl�� . $��Stretch=�