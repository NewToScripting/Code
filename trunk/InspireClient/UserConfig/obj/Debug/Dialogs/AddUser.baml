   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5      D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  5       
UserConfig    UserConfig.Dialogs.AddUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5        � Title$  Add New User��5      $	��361��6   $	��494��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        &    Inspire.Commands.InspireCommands   SaveCommand   Command# Z 5      6n     5	   
   -   5           CancelCommand# Z 5	      6o   .��5      �    PopupBackgroundBrush#��[  6   .+�5   
   �� -   5        $��lblUserName��5   Q   $
��Left=�6   $��	41,30,0,0q�6+   
�������$��76��6d   $��25��6q   $	��Top=�6}   .��6�   User Name :6�      Inspire.InfoTextBox  5   
   -   5        $��
tbUserName��5   \     
Foreground#��[ 6   $��107,27,12,0q�6G   $��25��6n   $	��Top=�6z   $	��344��6�      TextBoxInfo$ Enter the User's Name��6�   �� 5   
   
�������$��28��6#   $
��Left=�6/   $��	69,62,0,0q�6J   $	��Top=�6]   $��50��6u   .��6�   	Login :6�     5   
   -   5        $��tbUserLogin��5   t   #��[ 6   $��25��6G   $	��344��6S   $��107,58,12,0q�6_   $	��Top=�6�   $6 0Enter the User Login ID Associated with the User��6�   �� 5   
   
�������$
��Left=�6$   $��
49,132,0,0q�6?   $��70��6T   $��22��6_   $	��Top=�6k   .��6�   
Password :6�   G� 5   
   -   5        $��pbOldPassword��5   x   $y�	Collapsed=�6   #��[ 6.   $��25��6W   $��118,92,22,0q�6c   $	��Top=�6�   G� 5   
   -   5        $��tbUserPassword��5   b   #��[ 6   $��118,127,22,0q�6?   $��25��6V   $	��Top=�6y   G� 5   
   -   5        $��	pbConfirm��5   a   #��[ 6   $��25��6?   $��118,160,22,0q�6K   $	��Top=�6t   �� 5   
   -	   5        $��label1��5   ^   $
��Left=�6   $��25��6+   $��
39,193,0,0q�67   
�������$��79��6l   $	��Top=�6w   .��6�   Description :6�     5   
   -
   5        $��tbUserDescription��5   G   #��[ 6   $��107,193,12,0q�6`   $	��344��6v    �� TextWrapping$
 Wrap=�6�   $0 *Enter an optional description for the user��6�   $��83��6�   $	��Top=�6�   �� 5   
   -   5        $��btnSave��5   k   $��35��6      Inspire.ButtonImage	   Image$"	 ..\Resources\Images\Ok16.png��6   $��189,0,146,5q�6V   $��Bottom=�6z   #��Z 6�   
 �� 	IsDefault
 . ��6�   ��  �� RelativeSource �� *Self+ �� Path$ Command.Text�6.  �� 5   
   -   5        $��	btnCancel��5   �   $��35��6   $&	  ..\Resources\Images\Cancel16.png��6   $��Right=�6Z   $��0,0,12,5q�6v   #��Z 6�   $��Bottom=�6!  $	��128��6<  ��6�   ��  �� *Self+$ Command.Text�6b  �� 5   
   $��Confirm Password :��6   
�������$��25��6@   $
��Left=�6L   $��	4,165,0,0q�6g   $	��Top=�6z   $	��101��6�   �� 5   
   -   5         ��Name$ 
lblOldPass��5      $y�	Collapsed=�6$   $��Old Password :��6;   
�������$��22��6g   $
��Left=�6s   $��	29,97,0,0q�6�   $	��Top=�6�   $��90��6�   5      5      