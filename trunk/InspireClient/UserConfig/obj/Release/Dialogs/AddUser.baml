   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands   
UserConfig    UserConfig.Dialogs.AddUser   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire       � Title$  Add New User��$	��361��$	��494�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -   &    Inspire.Commands.InspireCommands   SaveCommand   Command# Z   -      CancelCommand# Z .���    PopupBackgroundBrush#��[  .+��� -   $��lblUserName��$
��Left=�$��	41,30,0,0q�
�������$��76��$��25��$	��Top=�.��User Name :   Inspire.InfoTextBox  -   $��
tbUserName��  
Foreground#��[ $��107,27,12,0q�$��25��$	��Top=�$	��344��   TextBoxInfo$ Enter the User's Name���� 
�������$��28��$
��Left=�$��	69,62,0,0q�$	��Top=�$��50��.��	Login :  -   $��tbUserLogin��#��[ $��25��$	��344��$��107,58,12,0q�$	��Top=�$6 0Enter the User Login ID Associated with the User���� 
�������$
��Left=�$��
49,132,0,0q�$��70��$��22��$	��Top=�.��
Password :G� -   $��pbOldPassword��$y�	Collapsed=�#��[ $��25��$��118,92,22,0q�$	��Top=�G� -   $��tbUserPassword��#��[ $��118,127,22,0q�$��25��$	��Top=�G� -   $��	pbConfirm��#��[ $��25��$��118,160,22,0q�$	��Top=��� -	   $��label1��$
��Left=�$��25��$��
39,193,0,0q�
�������$��79��$	��Top=�.��Description :  -
   $��tbUserDescription��#��[ $��107,193,12,0q�$	��344�� �� TextWrapping$
 Wrap=�$0 *Enter an optional description for the user��$��83��$	��Top=��� -   $��btnSave��$��35��   Inspire.ButtonImage	   Image$"	 ..\Resources\Images\Ok16.png��$��189,0,146,5q�$��Bottom=�#��Z 
 �� 	IsDefault
 . ����  �� RelativeSource �� *Self+ �� Path$ Command.Text��� -   $��	btnCancel��$��35��$&	  ..\Resources\Images\Cancel16.png��$��Right=�$��0,0,12,5q�#��Z $��Bottom=�$	��128������  �� *Self+$ Command.Text��� $��Confirm Password :��
�������$��25��$
��Left=�$��	4,165,0,0q�$	��Top=�$	��101���� -    ��Name$ 
lblOldPass��$y�	Collapsed=�$��Old Password :��
�������$��22��$
��Left=�$��	29,97,0,0q�$	��Top=�$��90��