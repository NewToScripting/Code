   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5   '   _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors 6Y    FlightInfoModule+   %FlightInfoModule.FlightControlDetails   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5my&clr-namespace:Inspire;assembly=Inspire     5   '   _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors     6Y     � WindowStartupLocation$  CenterScreen=�5         WindowBackgroundBrush#��[  6D   $	��344��5      $	��510��6   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��140* �6   �� 5      $	��48* �6   .+�5         Inspire.InfoTextBox  -   5        $��tbapCode��5   6   $��23��6   $��166,65,10,0q�6!   $	��Top=�6G      TextBoxInfo$> 8Airport Code or Inspire Code (Only needed if no Airport)��6_   �� 5      -   5        $��label1��5   h   $��Center=�6   $��28��6.   $
��Left=�6:   $��	84,63,0,0q�6U   $��Airport Code:��6v   $	��Top=�6�   $��81��6�   �� 5      -   5        $��label2��5   b   $��Seconds Per Page:��6   $��28��6(   $
��Left=�64   $��	58,94,0,0q�6O   $	��Top=�6p   $��Center=�6�   $	��109��6�   �� 5      -   5        $��cbSecPP��5   /   $��23��6   $��
162,96,0,0q�6   $	��Top=�6>   $
��Left=�6V   $��52��6q   .@�5   
   �� .��6   3.06   �� 5   
   .��6   4.06   �� 5   
   .��6   5.06   �� 5   
   .��6   6.06   �� 5   
   .��6   7.06   �� 5   
    �� 
IsSelected . .��62   8.067   �� 5   
   .��6   9.06   �� 5   
   .��6   10.06   �� 5   
   .��6   12.06   �� 5   
   .��6   14.06   �� 5   
   .��6   16.06   �� 5   
   .��6   18.06   �� 5   
   .��6   20.06   �� 5    
   .��6   22.06   5!      �� 5"      -   5        $��lblTS��5"   K   $��Touchscreen Enabled:��6   $��28��6+   $��
41,123,0,0q�67   $	��Top=�6X   $��Center=�6p   $
��Left=�6�   $	��125��6�   �� 5#      -   5        $��cbTouchScreen��5#   ]   {�.  $��16��6!   $
��Left=�6-   $��162,130,0,0q�6H   $	��Top=�6r   $��19��6�   �� 5$      $��45��6   $��Bottom=�6   $��5q�68   $��Right=�6C   $��1��6_    �� Orientation$ 
Horizontal=�6l   $��2��6�   .+�5%   
   �� -   5        $��Ok��5%      $	��150��6   $��6q�6*   65   �� 5&   
   -   5        $��Cancel��5&      $	��150��6"   $��6q�6.   69   5'      �� 5(      -	   5        $��label3��5(   l   $ ��Show name instead of icon:��6   $��28��61   $
��Left=�6=   $��
11,149,0,0q�6X   $	��Top=�6z   $��Center=�6�   $	��162��6�   �� 5)      -
   5        $��cbNameInsteadOfIcon��5)   K   $��16��6   $
��Left=�6   $��162,157,0,0q�66   $	��Top=�6f   $��19��6~   �� 5*      -   5        $��label4��5*   s   $&�� Show prior to Departure/Arrival:��6   $��28��67   $
��Left=�6C   $��203,123,0,0q�6^   $	��Top=�6�   $��Center=�6�   $	��178��6�   �� 5+      -   5        $��label5��5+   s   $&�� Show after to Departure/Arrival:��6   $��28��67   $
��Left=�6C   $��203,149,0,0q�6^   $	��Top=�6�   $��Center=�6�   $	��178��6�   ,  &DevComponents.WpfEditors.DateTimeInput  5,      -   5        $��dtShowAhead��5,   a      Value$ 08:00X�6   
���   �$��22��6@   $��380,124,0,0q�6L   $	��Top=�6t   $
��Left=�6�   $��56��6�      ShowDropDown .     Format$ Custom=�6�      CustomFormat$ HH:mm��6�   	   AllowEmptyState	 .  6�     5-      -   5        $��dtShowBehind��5-   a   $ 00:15X�6   
���   �$��22��6@   $��380,152,0,0q�6L   $	��Top=�6u   $
��Left=�6�   $��56��6�    .  $ Custom=�6�   $ HH:mm��6�   	 .  6�   �� 5.      -   5        $��label6��5.   V   $	��h/m��6   $��16��6   $
��Left=�6&   $��390,104,0,0q�6A   $	��Top=�6d   $��Center=�6|   $��37��6�   �� 5/      -   5        $��label7��5/   Y   $��Style:��6   $��28��6   $
��Left=�6)   $��126,179,0,0q�6D   $	��Top=�6g   $��Center=�6   $��33��6�   �� 50      -   5        
 ��Name$
 CbStyle��50      $��23��6    $��Right=�6,   $��0,181,161,0q�6H   $	��Top=�6]   $	��162��6u   .@�51   
   ��  . .��62   
Standard6<   �� 52   
   .��6   	Bubbled6    �� 53   
   .��6   
Standard6!   �� 54   
   .��6   Standard_City_First6,   �� 55   
   .��6   Bubbled_City_First6+   �� 56   
   .��6   Standard_City_First_With_Gate66   �� 57   
   .��6   Bubbled_City_First_With_Gate65   58      �� 59      -   5        $��cbAnimation��59   K   $��23��6   $
��Left=�6   $��165,212,0,0q�66   $	��Top=�6^   $	��162��6v   $��2��6�   .@�5:   
   �� $��EnterTopExitTop-Quad��6    . 66   �� 5;   
   $��EnterTopExitBottom-Quad��6   �� 5<   
   $#��EnterTopExitTop-BackEaseInOut��6   �� 5=   
   $&�� EnterTopExitBottom-BackEaseInOut��6   �� 5>   
   $
��None��6   5?      �� 5@      -   5        $��label8��5@   \   $��
Animation:��6   $��28��6!   $
��Left=�6-   $��
96,207,0,0q�6H   $	��Top=�6j   $��Center=�6�   $��63��6�   $��2��6�   �� 5A      $
��Wrap=�6     
Foreground#��[ 6$   $��14(�6M   $p��jAirport information code may be required from Inspire Digital Signage if it is not already provided below.��6[   $��12,12,10,170q�6�   5O      5P      