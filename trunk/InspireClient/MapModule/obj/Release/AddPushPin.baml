   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire   	MapModule   MapModule.AddPushPin   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire       � Title$  
AddPushPin��$	��313��$	��451�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�   	TextBrush#���     WindowBackgroundBrush#���  ��Z� .��� .+��� $��20��$
��Left=�$	��Top=� �� TextAlignment$ Right=�$��Name:��$��42��$��	30,19,0,0q�   Inspire.InfoTextBox  -     Name$ tbName��   TextBoxInfo$
 Name��$��	76,10,0,0q�$
��Left=�$	��341��$��31��$	��Top=��� $��20��$
��Left=�$��1,48,0,0q�$��Description:��$ Right=�$	��Top=�$��69��  -   $ tbDescription�� �� TextWrapping$
 Wrap=�$! Description of the location��$��74��$
��Left=�$��	76,47,0,0q�$	��Top=�$	��341���� -   $��
textBlock2��$��20��$
��Left=�$��
12,135,0,0q�$��	Category:��$ Right=�$	��Top=�$��60���� -    ��Name$ 
tbCategory��$��Category Here��$��18(�$��Italic$�$��31��{�.  $
��Left=�$��
80,130,0,0q�$	��Top=�$	��341���� -   $��btnOk��   Inspire.ButtonImage   Image$ Resources\Images\Ok16.png��$��35��$��Bottom=�$��
0,0,146,12q�$��Right=�$	��128��.��Ok�� -   $��	btnCancel��$# Resources\Images\Cancel16.png��$��35��$��Right=�$��Bottom=�$	��128��$��	0,0,12,12q�.��Cancel!   Inspire.AmountRatingControl  -   	  Name$	 
amtControl��$y�	Collapsed=�$
��Left=�$��
76,164,0,0q�$	��Top=�$��26��$��87���� -   
 ��Name$
 cbShowAvgPriceControl��$y�	Collapsed=�$"��Include Avg. Price Indicator��#��[  $��181,170,0,0q�$��20��$	��Top=�$
��Left=�$	��182���� $y�	Collapsed=�$��20��$
��Left=�$��
12,170,0,0q�$��	Avg Price��$ Right=�$	��Top=�$��60���� -	   $��cbMarkerVisible�� d� 	IsChecked$
 TrueY�$��Marker Visible��#��[  $��20��$
��Left=�$��181,196,0,0q�$	��Top=�$	��112��