   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5   @    	MapModule   MapModule.AddPushPin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :Inspire&clr-namespace:Inspire;assembly=Inspire     6@     � Title$  
AddPushPin��6w   $	��313��6�   $	��451��6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�      	TextBrush#���   6�     WindowBackgroundBrush#���  6  ��5   K   Z� .��5      � .+�5   
   �� $��20��6   $
��Left=�6    $	��Top=�6;    �� TextAlignment$ Right=�6S   $��Name:��6i   $��42��6v   $��	30,19,0,0q�6�      Inspire.InfoTextBox  5   
   -   5          Name$ tbName��5         TextBoxInfo$
 Name��6.   $��	76,10,0,0q�6A   $
��Left=�6T   $	��341��6o   $��31��6{   $	��Top=�6�   �� 5   
   $��20��6   $
��Left=�6    $��1,48,0,0q�6;   $��Description:��6M   $ Right=�6a   $	��Top=�6w   $��69��6�     5   
   -   5        $ tbDescription��5       �� TextWrapping$
 Wrap=�65   $! Description of the location��6I   $��74��6s   $
��Left=�6   $��	76,47,0,0q�6�   $	��Top=�6�   $	��341��6�   �� 5	   
   -   5        $��
textBlock2��5	   O   $��20��6   $
��Left=�6    $��
12,135,0,0q�6;   $��	Category:��6a   $ Right=�6r   $	��Top=�6�   $��60��6�   �� 5
   
   -   5         ��Name$ 
tbCategory��5
      $��Category Here��6(   $��18(�6=   $��Italic$�6K   $��31��6^   {�.  $
��Left=�6|   $��
80,130,0,0q�6�   $	��Top=�6�   $	��341��6�   �� 5   
   -   5        $��btnOk��5   S      Inspire.ButtonImage   Image$ Resources\Images\Ok16.png��6   $��35��6G   $��Bottom=�6`   $��
0,0,146,12q�6{   $��Right=�6�   $	��128��6�   .��6�   Ok6�   �� 5   
   -   5        $��	btnCancel��5   s   $# Resources\Images\Cancel16.png��6   $��35��6K   $��Right=�6W   $��Bottom=�6�   $	��128��6�   $��	0,0,12,12q�6�   .��6�   Cancel6�   !   Inspire.AmountRatingControl  5   
   -   5        	  Name$	 
amtControl��5   l   $y�	Collapsed=�6&   $
��Left=�6=   $��
76,164,0,0q�6X   $	��Top=�6�   $��26��6�   $��87��6�   �� 5   
   -   5        
 ��Name$
 cbShowAvgPriceControl��5      $y�	Collapsed=�62   $"��Include Avg. Price Indicator��6J   #��[  6q   $��181,170,0,0q�6�   $��20��6�   $	��Top=�6�   $
��Left=�6�   $	��182��6�   �� 5   
   $y�	Collapsed=�6   $��20��6+   $
��Left=�67   $��
12,170,0,0q�6R   $��	Avg Price��6f   $ Right=�6w   $	��Top=�6�   $��60��6�   �� 5   
   -	   5        $��cbMarkerVisible��5   �    d� 	IsChecked$
 TrueY�6   $��Marker Visible��6$   #��[  6=   $��20��6e   $
��Left=�6q   $��181,196,0,0q�6�   $	��Top=�6�   $	��112��6�   5      5      