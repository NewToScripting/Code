   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  2&clr-namespace:Inspire;assembly=InspireInspire   
UserConfig)   #UserConfig.UserConfigurationControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     :Inspire&clr-namespace:Inspire;assembly=Inspire       � 	Resources     EditUserContext&    Inspire.Commands.InspireCommands   EditUserCommand m� Command �� RelativeSource �� Path m� Icon��%�   &	        �� ���	#FF000000.@�m� # Z ���	#FF000000����  �� *Self+$ Command.Text� �� $��Resources\Images\Edit.png��$��16��$��16�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      AddUserFormCommand   Command# Z   -   # Z   -   	   DeleteUserCommand# Z	   -   
   AddRoleFormCommand# Z
   -      RemoveRoleCommand# Z .��� $��Stretch=�$��0,0,5,0q� � ColumnDefinitions �� $	��200��$
��205* ��� $	��200��$
��205* � � RowDefinitions �� $��30 ��� $	��300��$
��300* ��� $��54 �.+��� $��0��$��0��$��Center=�$��15(�$��Users:��$��5q�
��������� -    ��Name$ lbUsers��$��0��$��1��$��3q�$��Stretch=����� .R���  �� Orientation$ 
Horizontal=� � ContextMenu# [  .+��� $��24��$��24��$	��3,0q�$��Resources\Images\user.png���� ���� *Name+�� $ 
Horizontal=�$��Right=�$��0��$��2��.+��� $��35��   Inspire.ButtonImage   Image$ Resources\Images\add.png��#��Z $��Bottom=�$
��Left=�$��3q�$	��128������  �� *Self+$ Command.Text��� $��35��$! Resources\Images\remove.png��#��Z	 $��Right=�$��Bottom=�$��3q�$	��128������  �� *Self+$ Command.Text��� $��1��$��0��$��15(�$��Center=�$��Roles:��$��5q�
��������� -   $ lbRoles��$��1��$��1��$��Stretch=�$��3q����� .R��� $ 
Horizontal=�.+��� ���� *Name+�� $ 
Horizontal=�$��Right=�$��1��$��2��.+��� $��35��$ Resources\Images\add.png��#��Z
 $��Bottom=�$
��Left=�$��3q�$	��128������  �� *Self+$ Command.Text��� $��35��$! Resources\Images\remove.png��#��Z $��Right=�$��Bottom=�$��3q�$	��128������  �� *Self+$ Command.Text�