   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5       Inspire.Client.Designer/   )Inspire.Client.Designer.Dialogs.SaveSlide   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5        � Title$  
Save Slide��5      $	��238��6   $	��485��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6G    � 	Resources 5      %   Inspire.ReverseIsEmptyConverter   reverseEmptyConverter��%   &	          5   
   6*   5      .��5
      �   PopupBackgroundBrush#��[ 6   .+�5   
   �� -   5        $��lblGroupName��5   Q   $
��Left=�6   $��	18,25,0,0q�6+   
�������$��79��6e   $��25��6p   $	��Top=�6|   .��6�   Slide Name :6�      Inspire.InfoTextBox  5   
   -   5        $��tbSlideName��5   E   $��
95,27,12,0q�6   
�������$��25��6X   $	��Top=�6d      TextBoxInfo$! Enter a Name For The Slide.��6|   �� 5   
   -   5        $��label1��5   Q   $
��Left=�6   $��	18,56,0,0q�6+   
�������$��79��6_   $��25��6j   $	��Top=�6v   .��6�   Description :6�     5   
   -   5        $��tbSlideDescription��5      $��95,58,12,46q�68   $��95��6M    �� TextWrapping$
 Wrap=�6Y   
�������$	��Top=�6�   $
��Left=�6�   $	��Top=�6�   $( "Enter a Description For The Slide.��6�   �� 5   
   -   5        $��btnSave��5   �   $��35��6   $��189,0,146,5q�6      Inspire.ButtonImage   Image$ Images\Ok16.png��6�   $��Bottom=�6�   {�62   ��  �� ElementName$ tbSlideName�� �� Path$
 Text�	 �� 	Converter#	 [  .��6  Save6  �� 5   
   -   5        $��	btnCancel��5   {   $��35��6   $��Right=�6   $ Images\Cancel16.png��69   $��0,0,12,5q�6i   $��Bottom=�6�   $	��128��6�   .��6�   Cancel6�   5      5      