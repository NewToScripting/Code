   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors  FlightInfoModule+   %FlightInfoModule.FlightControlDetails   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5my&clr-namespace:Inspire;assembly=Inspire     _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors       � WindowStartupLocation$  CenterScreen=�   WindowBackgroundBrush#��[  $	��344��$	��510��.���  � RowDefinitions �� $
��140* ��� $	��48* �.+�   Inspire.InfoTextBox  -   $��tbapCode��$��23��$��166,65,10,0q�$	��Top=�   TextBoxInfo$> 8Airport Code or Inspire Code (Only needed if no Airport)���� -   $��label1��$��Center=�$��28��$
��Left=�$��	84,63,0,0q�$��Airport Code:��$	��Top=�$��81���� -   $��label2��$��Seconds Per Page:��$��28��$
��Left=�$��	58,94,0,0q�$	��Top=�$��Center=�$	��109���� -   $��cbSecPP��$��23��$��
162,96,0,0q�$	��Top=�$
��Left=�$��52��.@��� .��3.0�� .��4.0�� .��5.0�� .��6.0�� .��7.0��  �� 
IsSelected . .��8.0�� .��9.0�� .��10.0�� .��12.0�� .��14.0�� .��16.0�� .��18.0�� .��20.0�� .��22.0�� -   $��lblTS��$��Touchscreen Enabled:��$��28��$��
41,123,0,0q�$	��Top=�$��Center=�$
��Left=�$	��125���� -   $��cbTouchScreen��{�.  $��16��$
��Left=�$��162,130,0,0q�$	��Top=�$��19���� $��45��$��Bottom=�$��5q�$��Right=�$��1�� �� Orientation$ 
Horizontal=�$��2��.+��� -   $��Ok��$	��150��$��6q��� -   $��Cancel��$	��150��$��6q��� -	   $��label3��$ ��Show name instead of icon:��$��28��$
��Left=�$��
11,149,0,0q�$	��Top=�$��Center=�$	��162���� -
   $��cbNameInsteadOfIcon��$��16��$
��Left=�$��162,157,0,0q�$	��Top=�$��19���� -   $��label4��$&�� Show prior to Departure/Arrival:��$��28��$
��Left=�$��203,123,0,0q�$	��Top=�$��Center=�$	��178���� -   $��label5��$&�� Show after to Departure/Arrival:��$��28��$
��Left=�$��203,149,0,0q�$	��Top=�$��Center=�$	��178��,  &DevComponents.WpfEditors.DateTimeInput  -   $��dtShowAhead��   Value$ 08:00X�
���   �$��22��$��380,124,0,0q�$	��Top=�$
��Left=�$��56��   ShowDropDown .     Format$ Custom=�   CustomFormat$ HH:mm��	   AllowEmptyState	 .    -   $��dtShowBehind��$ 00:15X�
���   �$��22��$��380,152,0,0q�$	��Top=�$
��Left=�$��56�� .  $ Custom=�$ HH:mm��	 .  �� -   $��label6��$	��h/m��$��16��$
��Left=�$��390,104,0,0q�$	��Top=�$��Center=�$��37���� -   $��label7��$��Style:��$��28��$
��Left=�$��126,179,0,0q�$	��Top=�$��Center=�$��33���� -   
 ��Name$
 CbStyle��$��23��$��Right=�$��0,181,161,0q�$	��Top=�$	��162��.@���  . .��
Standard�� .��	Bubbled�� .��
Standard�� .��Standard_City_First�� .��Bubbled_City_First�� .��Standard_City_First_With_Gate�� .��Bubbled_City_First_With_Gate�� -   $��cbAnimation��$��23��$
��Left=�$��165,212,0,0q�$	��Top=�$	��162��$��2��.@��� $��EnterTopExitTop-Quad�� . �� $��EnterTopExitBottom-Quad���� $#��EnterTopExitTop-BackEaseInOut���� $&�� EnterTopExitBottom-BackEaseInOut���� $
��None���� -   $��label8��$��
Animation:��$��28��$
��Left=�$��
96,207,0,0q�$	��Top=�$��Center=�$��63��$��2���� $
��Wrap=�  
Foreground#��[ $��14(�$p��jAirport information code may be required from Inspire Digital Signage if it is not already provided below.��$��12,12,10,170q�