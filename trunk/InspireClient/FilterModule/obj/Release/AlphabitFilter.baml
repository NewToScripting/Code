   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire   FilterModule!   FilterModule.AlphabitFilter   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     -     >�Name$  thisElement�� � 	Resources    ListBoxStyle1 �� 
TargetType �� 	Resources �� Color �� Property �� Value �� 
TargetType ��Name	 J� SnapsToDevicePixels
 �� Padding �� Triggers P� Property P� Value �� 
TargetName  myListboxStyle  TBItemTemplate ��Name �� TextAlignment �� ElementName �� Triggers �� Value �� Binding �� Path �� RelativeSource �� AncestorType3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Color��%�  &	        '�� �    &	 �    &	     �� " �� ���� $ Transparent��(��       * SystemColors.HighlightBrushKey+).���  � ��# � ����  � ��$ 0q���  � ��# � ����  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$ Center=���  � �� �� " ��.R��� $ Bd��	 . #��z��#��z��#��z��$
 1q�._��� #��z��|�.  .���� #	 z	  P�  � {� .  . ��� $ Bd��# � �� � ��P�  �@��
IsGrouping . . ���  � �� .  �� " ��.���  � ��
 ���� ��  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R��� $ Bd��	 . #��z��#��z��#��z��#
 z��._��� -   $��Center=�$��Center=�#	 z	 ��  ���� $ Transparent��(��       * SystemColors.HighlightBrushKey+)�� .R��� $
 root��$
��11.2��$ Center=���Z� ���� *SelectedFontFamily+$ thisElement������ *CharacterForeground+$ thisElement������  �� $
 True�� �� $ 
IsSelected� �� " ��.a��� $
 root�� �� *SelectedCharacterBrush+$ thisElement�� � ���� $
 root�� �@J�Effect   $ 3Q�$ 0Q� �� *GlowForeground.Color+$ thisElement��.���� -   $��0q�
������ #��[ $��Center=�#��[  $��Disabled=�$��Disabled=����� .R�   Inspire.FishEyePanel  $��Center=�