   M S B A M L   `   `   `  ���� ]  YInspire.Client.ConfigurationWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�\clr-namespace:Inspire.Client.ConfigurationWindow;assembly=Inspire.Client.ConfigurationWindow"Inspire.Client.ConfigurationWindow  X TInspire.Client.ScheduleWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltRclr-namespace:Inspire.Client.ScheduleWindow;assembly=Inspire.Client.ScheduleWindowInspire.Client.ScheduleWindow R NInspire.Client.Designer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:Inspire.Client.Designer;assembly=Inspire.Client.DesignerInspire.Client.Designer B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands e aActiproSoftware.Ribbon.Wpf30, Version=4.5.477.0, Culture=neutral, PublicKeyToken=36ff2196ab5654b9�dclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Controls;assembly=ActiproSoftware.Ribbon.WPF300ActiproSoftware.Windows.Controls.Ribbon.Controls �aclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Input;assembly=ActiproSoftware.Ribbon.WPF30-ActiproSoftware.Windows.Controls.Ribbon.Input W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media �^clr-namespace:ActiproSoftware.Windows.Controls.Ribbon.UI;assembly=ActiproSoftware.Ribbon.WPF30*ActiproSoftware.Windows.Controls.Ribbon.UI 2&clr-namespace:Inspire;assembly=InspireInspire ^ ZDevComponents.WpfRibbon, Version=5.8.0.6, Culture=neutral, PublicKeyToken=2037e151916410e7bFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbonDevComponents.WpfRibbon _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors \ XDevComponents.WpfDock, Version=5.8.0.6, Culture=neutral, PublicKeyToken=adef513edc9ed778\Bclr-namespace:DevComponents.WpfDock;assembly=DevComponents.WpfDockDevComponents.WpfDock I	 EInspire.Client, Version=1.0.5.1, Culture=neutral, PublicKeyToken=null/clr-namespace:Inspire.ClientInspire.Client	 �cclr-namespace:Inspire.Client.ScheduleWindow.ScheduleTreeView;assembly=Inspire.Client.ScheduleWindow.Inspire.Client.ScheduleWindow.ScheduleTreeView �jclr-namespace:Inspire.Client.ConfigurationWindow.AdminTreeView;assembly=Inspire.Client.ConfigurationWindow0Inspire.Client.ConfigurationWindow.AdminTreeView  �Zclr-namespace:Inspire.Client.Designer.DesignPropertyPanel;assembly=Inspire.Client.Designer+Inspire.Client.Designer.DesignPropertyPanel   	 Inspire.Client.MainWindow   \
 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation 
    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  
   |ConfigurationWindow\clr-namespace:Inspire.Client.ConfigurationWindow;assembly=Inspire.Client.ConfigurationWindow  
   mScheduleWindowRclr-namespace:Inspire.Client.ScheduleWindow;assembly=Inspire.Client.ScheduleWindow  
   [DesignerFclr-namespace:Inspire.Client.Designer;assembly=Inspire.Client.Designer  
   DCommands/clr-namespace:Inspire.Commands;assembly=Inspire  
   xActiprodclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Controls;assembly=ActiproSoftware.Ribbon.WPF30  
   sInputaclr-namespace:ActiproSoftware.Windows.Controls.Ribbon.Input;assembly=ActiproSoftware.Ribbon.WPF30  
   Nmedia<clr-namespace:System.Windows.Media;assembly=PresentationCore  
   mUI^clr-namespace:ActiproSoftware.Windows.Controls.Ribbon.UI;assembly=ActiproSoftware.Ribbon.WPF30  
   :Inspire&clr-namespace:Inspire;assembly=Inspire  
   YRibbonFclr-namespace:DevComponents.WpfRibbon;assembly=DevComponents.WpfRibbon  
   _
DevEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors  
   SDockBclr-namespace:DevComponents.WpfDock;assembly=DevComponents.WpfDock  
   /Clientclr-namespace:Inspire.Client  
   �ScheduleTreeViewcclr-namespace:Inspire.Client.ScheduleWindow.ScheduleTreeView;assembly=Inspire.Client.ScheduleWindow  
   �AdminTreeViewjclr-namespace:Inspire.Client.ConfigurationWindow.AdminTreeView;assembly=Inspire.Client.ConfigurationWindow  
   {DesignPropertyPanel1Zclr-namespace:Inspire.Client.Designer.DesignPropertyPanel;assembly=Inspire.Client.Designer  
   -   *  $DevComponents.WpfRibbon.RibbonWindow   Name$  	InspireUI�� � Title$ INSPIRE Designer�� � 
ResizeMode$ 	CanResize=� � WindowStartupLocation$ CenterScreen=�$	��850��$	��730��$��7.75pt(����#DDD$��Verdana)� � 	Resources    AppMenuCommandButton �� 
TargetType,  &DevComponents.WpfRibbon.ButtonDropDown �� Property �� Value  AppMenuSeparator��%e   &	        &	 (     �� "  .���  � ��$ 4,2,4,2q��� " ��.���  � ��$ 40,0,0,0q� J� CommandBindings )  #System.Windows.Input.CommandBinding  -   &   Inspire.Commands.InspireCommands	   NewSlideCommand
   Command#
 Z	   -      SchedulerNewSlideCommand#
 Z   -      SaveSlideCommand#
 Z   -      SaveSlideToServerCommand#
 Z   -      SaveSlideLocalCommand#
 Z   -      ExportSlideCommand#
 Z   -      LoadSlideCommand#
 Z   -	      EditSlideCommand#
 Z   -
      DeleteSlideCommand#
 Z   -      ClearSlideCommand#
 Z   -      ShowDesignerCommand#
 Z   -      ShowSchedulerCommand#
 Z   -      ShowConfigurationCommand#
 Z   -      UndoCommand#
 Z   -      RedoCommand#
 Z   -      DeleteCommand#
 Z   -      CopyCommand#
 Z   -      DuplicateCommand#
 Z   -      PasteCommand#
 Z   -      
CutCommand#
 Z   -      UpdateDisplaysCommand#
 Z   -      AlignLeftCommand#
 Z   -   $    AlignHorizontalCentersCommand#
 Z    -   !   AlignRightCommand#
 Z!   -   "   AlignTopCommand#
 Z"   -   "#   AlignVerticalCentersCommand#
 Z#   -   $   AlignBottomCommand#
 Z$   -   "%   DistributeHorizontalCommand#
 Z%   -    &   DistributeVerticalCommand#
 Z&   -   '   PlayCanvasCommand#
 Z'   -    (   StopCanvasCommand#
 Z(   -!   )   PlayScheduleCommand#
 Z)   -"   *   ShowLayersPanel#
 Z*   -#   +   Rotate90RightCommand#
 Z+   -$   ,   Rotate90LeftCommand#
 Z,   -%   -   FlipVerticalCommand#
 Z-   -&   .   FlipHorizontalCommand#
 Z.   -'   #/   LoadOfflineFileDialogCommand#
 Z/ .��� .+��� 
���   �$	��Top=�$��Right=�$��20��$	��200��$��	0,5,120,0q�$��14(�0 �� TextAlignment$0 Right=����� *Inspire:User.UserName+1 J� Effect1 3  -System.Windows.Media.Effects.DropShadowEffect  2   Color$2 White��3   
BlurRadius$3 5Q�4   	Direction$
4 -446Q�5   ShadowDepth$5 -2Q�]� ��. $	��Top=�.+�$  DevComponents.WpfRibbon.Ribbon  -(   6  Name$6 mainApplictionRibbon��7   
LicenseKey$7 DAD80300DA22��$	��Top=�8   QuickAccessToolbar8 !  DevComponents.WpfRibbon.Qat  -)   9  Name$9 quickAT��.@�  :   PartVisibility$: 	ImageOnly=�;   KeyTip$; S��< � ToolTip$< 
Save Slide��=   Command#= Z >   Image> �� $��16��$��16��$!��Resources/Images/save16.png��  $: 	ImageOnly=�$; Z��$
< Undo��#= Z > �� $��16��$��16��$!��Resources/Images/undo16.png��  $: 	ImageOnly=�$; Y��$
< Redo��#= Z > �� $��16��$��16��$!��Resources/Images/redo16.png��  $: 	ImageOnly=�$; N��$< 	New Slide��#= Z	 > �� $��16��$��16��$ ��Resources/Images/New16.png��?   ApplicationMenu? -  'DevComponents.WpfRibbon.ApplicationMenu  -*   @  Name$@ appMenu��> �� $��AllIcons.ico��$��24��$��24��A   AppItemsA   ���#DDD$��Exit Application��.@�  #= Z/ > �� $ ��Resources/Images/New32.png��$��32��$��32��$��0,0,10,0q�$��Import Slide / Template����   > �� $!��Resources/Images/Update.png��$��32��$��32��$��0,0,10,0q�$#��Force Update for All Displays��.@�'	  !DevComponents.WpfRibbon.RibbonTab	  -+   B 	 Name$B scheduleTab��$
��Home��$y�	Collapsed=�$��10(�$; S��.��,
  &DevComponents.WpfRibbon.RibbonBarPanel
  $��90��- 
 'System.Windows.Input.KeyboardNavigationC   DirectionalNavigation$C Cycle=�D   TabNavigation$D Cycle=�.+�'  !DevComponents.WpfRibbon.RibbonBar  2  ,DevComponents.WpfRibbon.HeaderedPopupControlE   Header$E Slide��$��3q�$; FO��.@�)  #DevComponents.WpfRibbon.ButtonPanel  F   Orientation$F 
Horizontal=�$��Stretch=�.+�  G   ImagePosition$	G Top=�H   MinAutoSizeHint$H Medium=�I   ExpandPosition$I Bottom=�J   InlineExpandJ .  K   	PopupType$
K Menu=�L   ContentExpandsL .  $��Center=�$; N��#= Z > �� $ ��Resources/Images/New32.png��$
��None=�$	��New��  $E Schedule��$��3q�$; FO��.@�  $F 
Horizontal=�$��Stretch=�.+�  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��M   NewScheduleCommand#= ZM > �� $#��Resources/Images/Schedule.png��$��35��$
��Fill=�$	��New��  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; D��N   DeleteScheduleCommand#= ZN > �� $!��Resources/Images/Remove.png��$
��Fill=�O J� SnapsToDevicePixelsO . $��16��$��16��$��3q�$��Delete��  $E Update��$��3q�$  DevComponents.WpfDock.DockSiteP   Dock$P Right=�$; FO��.@�  $F 
Horizontal=�$��Stretch=�$	��7,0q�.+�  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; U��#= Z > �� $!��Resources/Images/Update.png��$��32��$��Update Displays��  $E Preview��$��3q�$; FO��$��Center=�.@�  $F 
Horizontal=�$��Stretch=�.+�  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; P��#= Z) > �� $!��Resources/Images/Play32.png��$
��None=�$
��Play��	  -,   $B designerHomeTab��$
��Home��$��10(�$; H��.��
  $��90��$C Cycle=�$D Cycle=�.+�  $��Center=�Q   DialogLauncherVisible$Q Hidden=�$E Preview��$��3q�$; FO��.@�  $F 
Horizontal=�$��Stretch=�.+�  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; P��#= Z' > �� $��32��$��32��$(��"Resources/Images/PlayPreview32.png��$��Preview��  $F 
Horizontal=�$��Stretch=�.+�  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; S��#= Z( > �� $��32��$��32��$(��"Resources/Images/StopPreview32.png��$
��Stop��  $E 	Clipboard��$��1q�$; FO��$Q Hidden=�.@�  $F 
Horizontal=�.+�  $��2q�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z > �� $ ��Resources/Images/Cut16.png��$
��None=�$	��Cut��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z > �� $"��Resources/Images/Paste16.png��$
��None=�$��Paste��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z > �� $��16��$��16��$!��Resources/Images/Remove.png��$��Remove��  .+�  $��2q�.+�  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L . $��Center=�$; C��#= Z > �� $!��Resources/Images/Copy32.png��$
��None=�$
��Copy��.@�  R   Role$R MenuItem=�$; C��#= Z $
��Copy��  $R MenuItem=�$; D��#= Z $��	Duplicate��  $E Slide��$��3q�$; FO��$Q Hidden=�.@�  $F 
Horizontal=�$��Stretch=�.+�  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z	 > �� $ ��Resources/Images/New32.png��$
��None=�$	��New��  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L . $��Center=�$; S��#= Z $
��Save��S ^� PlacementTargetS �� T �� ElementName$T 	AppRibbon��< *  $DevComponents.WpfRibbon.SuperToolTip  U   Header$U Save (Ctrl+S)��.���� $
��Wrap=�$	��180��Save the slide to the server.> �� $!��Resources/Images/Save32.png��$
��None=�.@�  $R MenuItem=�$; S��#= Z $��Save to Server��> �� $!��Resources/Images/Save16.png��$��16��$��16��$
��Fill=�  $R MenuItem=�$; E��#= Z $3��-Save Slide to File (Doesn't upload to server)��> �� $ ��Resources/Images/New16.png��$
��None=�  $��0,10,0,0q�$	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z > �� $��20��$��20��$!��Resources/Images/Remove.png��$
��None=�$��Clear��  $
E Font��$��3q�$Q Hidden=�V   ResizeOrderIndex$V 2��$��Center=�$; FN��W   CollapsedImageW �� $$��resources/images/FontColor.png��.@�  $F 
Horizontal=�.+�B  <ActiproSoftware.Windows.Controls.Ribbon.Controls.ButtonGroup  $��4,0,0,0q�X   	HasBorderX .  .@�I  CActiproSoftware.Windows.Controls.Ribbon.Controls.FontFamilyComboBox  $	��120��?  9ActiproSoftware.Windows.Controls.Ribbon.Controls.ComboBoxY   IsPreviewEnabledY . Z   
FontFamilyN  HActiproSoftware.Windows.Controls.Ribbon.Controls.Primitives.ComboBoxBase[   Command#[ ZZ \   KeyTipAccessText$\ FF����Z� G  AActiproSoftware.Windows.Controls.Ribbon.Controls.FontSizeComboBox  $��50��]   FontSize#[ Z] $\ FS����Z�   $F 
Horizontal=�$��2q�.+�  $< Increase Font Size��$: 	ImageOnly=�$; 1��$&=  EditingCommands.IncreaseFontSize��> �� $&�� resources/images/FontSizeInc.png��  $< Decrease Font Size��$: 	ImageOnly=�$&=  EditingCommands.DecreaseFontSize��> �� $&�� resources/images/FontSizeDec.png��  $F 
Horizontal=�.+�  $F 
Horizontal=�$��2q�.+�  $ = EditingCommands.ToggleBold��$
< Bold��$: 	ImageOnly=�> �� $��resources/images/Bold.png��  $"= EditingCommands.ToggleItalic��$< Italic��$: 	ImageOnly=�> �� $!��resources/images/Italic.png��  $%= EditingCommands.ToggleUnderline��$< 	Underline��$: 	ImageOnly=�> �� $$��resources/images/Underline.png��  $%= EditingCommands.ToggleSubscript��$< 	Subscript��$: 	ImageOnly=�> �� $$��resources/images/Subscript.png��  $'= !EditingCommands.ToggleSuperscript��$< Superscript��$: 	ImageOnly=�> �� $&�� resources/images/Superscript.png��  ^   ToggleStrikethrough#= Z^ $< Strikethrough��$��Strikethrough��$: 	ImageOnly=�> �� $!��resources/images/Strike.png��  _   ClearFormatting#= Z_ $< Clear Formatting��$��Clear Formatting��$: 	ImageOnly=�> �� $,��&resources/images/ClearFormatting16.png��  X .  .@�B  <ActiproSoftware.Windows.Controls.Ribbon.Controls.SplitButton  `   ApplyDefaultBackgroundM  GActiproSoftware.Windows.Controls.Ribbon.Controls.Primitives.ControlBasea   Command#a Z` b   KeyTipAccessText$b I��c   ScreenTipDescription$?c 9Make text look like it was marked with a highlighter pen.��d   ImageSourceSmall$(d "resources/images/TextHighlight.png��Q  KActiproSoftware.Windows.Controls.Ribbon.Controls.Primitives.PopupButtonBasee   PopupContent.e �� .+�C  =ActiproSoftware.Windows.Controls.Ribbon.Controls.PopupGallery  $��Center=�f   ApplyBackgroundR  LActiproSoftware.Windows.Controls.Ribbon.Controls.Primitives.ItemsControlBaseg   Command#g Zf h   InitialColumnCount$h 5��M  GActiproSoftware.Windows.Controls.Ribbon.Controls.Primitives.GalleryBasei   IsPreviewEnabledi . "j   VerticalScrollBarVisibility$j Hidden=�k   CommandParameterk N  HActiproSoftware.Windows.Controls.Ribbon.Input.BrushValueCommandParameter  ���� .R��� $��24��$��24��
�������$��1q����� l �� BindsDirectlyToSourcel . .@��� !  System.Windows.Media.Colorsm   Yellown �� Color#n Zm A  ;ActiproSoftware.Windows.Controls.Ribbon.UI.ScreenTipServiceo   ScreenTipHeader$o Yellow���� p   Lime#n Zp $
o Lime���� q   Teal#n Zq $
o Teal���� r   Magenta#n Zr $o Magenta���� s   Blue#n Zs $
o Blue���� 
t   Red#n Zt $	o Red���� u   Navy#n Zu $
o Navy���� v   Cyan#n Zv $
o Cyan���� w   Green#n Zw $o Green���� x   Purple#n Zx $o Purple���� y   Maroon#n Zy $o Maroon���� z   Olive#n Zz $o Olive���� {   Gray#n Z{ $
o Gray���� |   Silver#n Z| $o Silver���� }   Black#n Z} $o Black��@  :ActiproSoftware.Windows.Controls.Ribbon.Controls.Separator  ;   5ActiproSoftware.Windows.Controls.Ribbon.Controls.Menu   .@�=!  7ActiproSoftware.Windows.Controls.Ribbon.Controls.Button!  #a Zf ~   Label$~ No Color��  !  {�.  $~ Stop Highlighting��  }�.    ApplyDefaultForeground#a Z $c Change the font color.��$b FC��.e �� .+�I"  CActiproSoftware.Windows.Controls.Ribbon.Controls.ColorPickerGallery"  $��Center=��   ApplyForeground#g Z� $h 10��i . �   CategorizedItemsSource� �� � �� Type"� ��.s��� $n #FFFFFF��� "  LayoutBehavior$� Shaded=��   Category$� Theme Colors��$o White���� $n #000000��$� Shaded=�$� Theme Colors��$o Black���� $n #EEECE1��$� Shaded=�$� Theme Colors��$	o Tan���� $n #1F497D��$� Shaded=�$� Theme Colors��$o 	Dark Blue���� $n #4F81BD��$� Shaded=�$� Theme Colors��$
o Blue���� $n #C0504D��$� Shaded=�$� Theme Colors��$	o Red���� $n #9BBB59��$� Shaded=�$� Theme Colors��$o Olive Green���� $n #8064A2��$� Shaded=�$� Theme Colors��$o Purple���� $n #4BACC6��$� Shaded=�$� Theme Colors��$
o Aqua���� $n #F79646��$� Shaded=�$� Theme Colors��$o Orange���� $n #C00000��$� Standard Colors��$o Dark Red���� $n #FF0000��$� Standard Colors��$	o Red���� $n #FFC000��$� Standard Colors��$o Orange���� $n #FFFF00��$� Standard Colors��$o Yellow���� $n #92D050��$� Standard Colors��$o Light Green���� $n #00B050��$� Standard Colors��$o Green���� $n #00B0F0��$� Standard Colors��$o 
Light Blue���� $n #0070C0��$� Standard Colors��$
o Blue���� $n #002060��$� Standard Colors��$o 	Dark Blue���� $n #7030A0��$� Standard Colors��$o Purple��     .@�!  --   $~ More Colors...��  $E 	Paragraph��$��3q�$; FO��$Q Hidden=�.@�  $��0,10,0,0q�$F Vertical=�.+�  $F 
Horizontal=�$��2q�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C��$= EditingCommands.AlignLeft��> �� $*��$Resources/Images/AlignTextLeft16.png��$
��None=�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��$!= EditingCommands.AlignCenter��> �� $,��&Resources/Images/AlignTextCenter16.png��$
��None=�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��$ = EditingCommands.AlignRight��> �� $+��%Resources/Images/AlignTextRight16.png��$
��None=�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��$"= EditingCommands.AlignJustify��> �� $-��'Resources/Images/AlignTextJustify16.png��$
��None=�  $F 
Horizontal=�$��2q�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C��$)= #EditingCommands.DecreaseIndentation��> �� $+��%Resources/Images/DecreaseIndent16.png��$
��None=�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��$)= #EditingCommands.IncreaseIndentation��> �� $+��%Resources/Images/IncreaseIndent16.png��$
��None=�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��$#= EditingCommands.ToggleBullets��> �� $$��Resources/Images/Bullets16.png��$
��None=�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��$%= EditingCommands.ToggleNumbering��> �� $&�� Resources/Images/Numbering16.png��$
��None=�	  -.   $B designerFormatTab��$��Format��$��10(�$; F��.��
  $��90��$C Cycle=�$D Cycle=�.+�  $��Center=�$E Arrange��$Q Hidden=�$��3q�$; AR��.@�  $F 
Horizontal=�.+�  $	G Top=�$H Medium=�$I Bottom=�J . $
K Menu=�L . $��Center=�$; S���   BringForwardCommand#= Z� $��Bring Forward��S �� $T 	AppRibbon��<   $U Bring Forward��.���� $
��Wrap=�$	��180��Bring Forward> �� $��0,4,0,0q�$��32��$��32��$)��#Resources/Images/BringForward32.png��.@�  $R MenuItem=�$; F��#= Z� $��Bring Forward��> �� $)��#Resources/Images/BringForward16.png��$��16��$��16��$
��Fill=�  $R MenuItem=�$; r���   BringToFrontCommand#= Z� $��Bring to Front��> �� $)��#Resources/Images/BringToFront16.png��$��16��$��16��$
��Fill=�  $	G Top=�$H Medium=�$I Bottom=�J . $
K Menu=�L . $��Center=�$; S���   SendBackwardCommand#= Z� $��Send Backward��S �� $T 	AppRibbon��<   $U Send Backward��.���� $
��Wrap=�$	��180��Send Backward> �� $��0,4,0,0q�$��32��$��32��$)��#Resources/Images/SendBackward32.png��.@�  $R MenuItem=�$; B��#= Z� $��Send Backward��> �� $)��#Resources/Images/SendBackward16.png��$��16��$��16��$
��Fill=�  $R MenuItem=�$; k���   SendToBackCommand#= Z� $��Send to Back��> �� $'��!Resources/Images/SendToBack16.png��$��16��$��16��$
��Fill=�  $	G Top=�$H Medium=�$I Bottom=�J . $
K Menu=�L . $��Center=�$; S��#= Z+ $��Rotate��S �� $T 	AppRibbon��<   $U Rotate��.���� $
��Wrap=�$	��180��Rotate> �� $��0,4,0,0q�$��32��$��32��$#��Resources/Images/Rotate32.png��.@�  $R MenuItem=�$; R��#= Z+ $��Rotate Right 90º��> �� $#��Resources/Images/Rotate16.png��$��16��$��16��$
��Fill=�  $R MenuItem=�$; L��#= Z, $��Rotate Left 90º��> �� $'��!Resources/Images/RotateLeft16.png��$��16��$��16��$
��Fill=�  $R MenuItem=�$; V��#= Z- $��Flip Vertical��> �� $)��#Resources/Images/FlipVertical16.png��$��16��$��16��$
��Fill=�  $R MenuItem=�$; H��#= Z. $��Flip Horizontal��> �� $)��#Resources/Images/FlipHorizontal.png��$��16��$��16��$
��Fill=�  $��Center=�$��Center=�$E 	Alignment��$Q Hidden=�$��3q�$; FO��.@�  $F 
Horizontal=�.+�  $F Vertical=�.+�  $F 
Horizontal=�$��2q�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C��#= Z > �� $��16��$��16��$+��%Resources/Images/AlignObjectsLeft.png��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z  > �� $��16��$��16��$9��3Resources/Images/AlignObjectsCenteredHorizontal.png��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z! > �� $��16��$��16��$,��&Resources/Images/AlignObjectsRight.png��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C��#= Z" > �� $*��$Resources/Images/AlignObjectsTop.png��$
��None=�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z# > �� $��16��$��16��$7��1Resources/Images/AlignObjectsCenteredVertical.png��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z$ > �� $��16��$��16��$-��'Resources/Images/AlignObjectsBottom.png��  $F 
Horizontal=�$��2q�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C��#= Z% > �� $��16��$��16��$6��0Resources/Images/DistributeObjectsHorizontal.png��$��
Horizontal��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N��#= Z& > �� $��16��$��16��$4��.Resources/Images/DistributeObjectsVertical.png��$��Vertical��  $	G Top=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N���   FitToSlideCommand#= Z� > �� $��32��$��32��$(��"Resources/Images/FitToCanvas32.png��$��Fit to Canvas��  $��Center=�$��Center=�$E Size and Position��$Q Hidden=�$��3q�$; SP��.@�  $F 
Horizontal=�.+�  $F Vertical=�.+��� � �� Orientation$� 
Horizontal=�$��3q�.+��� $��16��$��16��$#��Resources/Images/Height16.png���� $��4,0,0,0q�$
0 Left=�$��Center=�$��25��$
��Top:��# 	 Inspire.Client.NumUpDown#  -/   � # Name$� tbTop��$��75��$
��Left=�� #  Value� �� � �� Path$� (Canvas.Top)�� �� Mode$� TwoWay=��� $� 
Horizontal=�$��3q�.+��� $��16��$��16��$"��Resources/Images/Width16.png���� $��4,0,0,0q�$
0 Left=�$��Center=�$��25��$��Left:��#  -0   $� tbLeft��$��75��$
��Left=�� �� $� (Canvas.Left)�$� TwoWay=�  $F Vertical=�.+��� $� 
Horizontal=�$��3q�.+��� $��16��$��16��$#��Resources/Images/Height16.png���� $��4,0,0,0q�$
0 Left=�$��Center=�$��40��$��Height:��#  -1   $� tbHeight��$��75��$
��Left=�� �� $� (Height)�$� TwoWay=��� $� 
Horizontal=�$��3q�.+��� $��16��$��16��$"��Resources/Images/Width16.png���� $��4,0,0,0q�$
0 Left=�$��Center=�$��40��$��Width:��#  -2   $� tbWidth��$��75��$
��Left=�� �� $� (Width)�$� TwoWay=�	  -3   $B configurationTab��$y�	Collapsed=�$��Configuration��$��10(�$; C��.��
  $��90��$C Cycle=�$D Cycle=�.+�  $E Manage Displays��$��3q�$; FO��.@�  $F 
Horizontal=�.+�($  "DevComponents.WpfRibbon.GroupPanel$  $��2q�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C���   NewPropertyCommand#= Z� > �� $#��Resources/Images/Property.ico��$��24��$
��Fill=�$	��Add��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N���   EditPropertyCommand#= Z� $
��Edit��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N���   DeletePropertyCommand#= Z� $��Remove��  .+�$  $��2q�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C���   NewDisplayGroupCommand#= Z� > �� $'��!Resources/Images/DisplayGroup.ico��$��24��$
��Fill=�$	��Add��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N���   EditDisplayGroupCommand#= Z� $
��Edit��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N�� �   DeleteDisplayGroupCommand#= Z� $��Remove��  $F 
Horizontal=�.+�$  $��2q�$F Vertical=�.+�  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; C���   NewDisplayCommand#= Z� $��Center=�> �� $"��Resources/Images/Display.ico��$��24��$
��Fill=�$	��Add��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N���   EditDisplayCommand#= Z� $��Center=�$
��Edit��  $
G Left=�$H Medium=�$I Bottom=�J .  $
K Menu=�L .  $��Center=�$; N���   DeleteDisplayCommand#= Z� $��Center=�> �� $!��Resources/Images/Remove.png��$
��None=�$��Remove��� $��Stretch=�$��Stretch=�� � ColumnDefinitions� �� $
��400* �$	��400��.+�  -4   �  Name$� ConfigurationDock��$��0��$P Right=��   
LicenseKey$� DAD80300DA22��.��]� ��. .+�,%  &DevComponents.WpfRibbon.NavigationPane%  -5   � % Name$� ToolBarPane��$
��Left=�� %  
IsExpanded� .  $
��Left=�  WindowBackgroundBrush#��[ .@�&&   DevComponents.WpfRibbon.PaneItem&  -6   � & Name$� 
DesignPane��$��Design��� &  
IsSelected� . � &  
SmallState� . � &  Image� �� $��24��$��24��$!��Resources/Images/design.png��.��E'  ?Inspire.Client.Designer.DesignPropertyPanel.DesignModuleControl'  -7   � ' Name$� DesignPaneModulePanel��&  -8   $� SchedulePane��$��Schedule��� �� $��24��$��24��$#��Resources/Images/schedule.png��.��H(  BInspire.Client.ScheduleWindow.ScheduleTreeView.ScheduleTreeControl(  -9   � ( Name$� SchedulerTreeControl��$
��Left=�$
��Left=�$��Stretch=�&  -:   $� ConfigurePane��$��	Configure��� �� $��24��$��24��$#��Resources/Images/settings.png��.��G)   AInspire.Client.ConfigurationWindow.AdminTreeView.AdminTreeControl)  -;   � ) Name$� ConfigurationTreeControl��$
��Left=�$
��Left=�$��Stretch=�� -<   � �Name$� WindowHolder��.+�2*  ,Inspire.Client.ScheduleWindow.ScheduleWindow*  -=   � * Name$� SchedulerWindow��$��Stretch=�$��Stretch=�$y�	Collapsed=�*+  $Inspire.Client.Designer.DesignWindow+  ->   � + Name$� DesignerWindow��$
��Left=�$	��Top=�� J� 	AllowDrop� . <,   6Inspire.Client.ConfigurationWindow.ConfigurationWindow,  -?   � , Name$� ConfigureWindow��$��Stretch=�$��Stretch=�$y�	Collapsed=�