   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5       FilterModule!   FilterModule.AlphabitFilter   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      -   5          >�Name$  thisElement��5   E    � 	Resources 5         ListBoxStyle1 �� 
TargetType �� 	Resources �� Color �� Property �� Value �� 
TargetType ��Name	 J� SnapsToDevicePixels
 �� Padding �� Triggers P� Property P� Value �� 
TargetName  myListboxStyle  TBItemTemplate ��Name �� TextAlignment �� ElementName �� Triggers �� Value �� Binding �� Path �� RelativeSource �� AncestorType3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Color��%�  &	        '�� L    &	 �    &	 t    �� 5   
   " ��6&    5      ���� 5
      $ Transparent��6T   (��       6"   * SystemColors.HighlightBrushKey+)6T   5      .�5      ��  � ��# � ��6+   �� 5       � ��$ 0q�60   �� 5       � ��# � ��6+   �� 5       � ��$
 Auto=�6K   �� 5       � ��$
 Auto=�6I   �� 5       � �� . 6>   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   	 . #��z��6H   #��z��6r   #��z��6�   $
 1q�6�   ._�5      �� #��z��6+   |�.  .��5   "   �� #	 z	 61   5      5       5      P� 5       � {� .  . �5   "   �� $ Bd��6?   # � ��6O    � ��5      P� 5       �@��
IsGrouping . . �5    "   ��  � �� .  6R   5!      5#      5%      5&      �� 5(   
   " ��6   .�5)      ��  � ��
 ���� 6+   �� 5*       � ��$ Center=�6;   �� 5+       � ��$ Center=�69   �� 5,       � �� 5-      �� 5.      " ��6&   .R�5/      �� $ Bd��6!   	 . #��z��6H   #��z��6r   #��z��6�   #
 z��6�   ._�50      �� -   5        $��Center=�50   /   $��Center=�6g   #	 z	 6�   51      52      54      55      �� 57   
    58      ���� 5:      $ Transparent��6T   (��       6"   * SystemColors.HighlightBrushKey+)6T   5;      5<      �� 5>   
   .R�5?      �� $
 root��6   $
��11.2��6&   $ Center=�6�   ��63   Z� ��6D   �� *SelectedFontFamily+$ thisElement����6�   �� *CharacterForeground+$ thisElement����6�   �� 5@       5A      �� 5B      $
 True��6    6+   �� $ 
IsSelected� �� " ��.a�5D      �� $
 root��6    6E   �� *SelectedCharacterBrush+$ thisElement�� � ���� 5E      $
 root��6    �@J�Effect 5F        5G      $ 3Q�6o   $ 0Q�6~    6/   �� *GlowForeground.Color+$ thisElement��6~   5I      5J      5L      5M      .��5N      �� -   5        $��0q�5N      
������ #��[ 6�   $��Center=�6�   #��[  6�   $��Disabled=�6�   $��Disabled=�6*  ��5O   
   �� 5P      .R�5Q         Inspire.FishEyePanel  $��Center=�6'   5R      5T      5U      