   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  5      2&clr-namespace:Inspire;assembly=InspireInspire  5       
UserConfig)   #UserConfig.UserConfigurationControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5        � 	Resources  5         EditUserContext&    Inspire.Commands.InspireCommands   EditUserCommand m� Command �� RelativeSource �� Path m� Icon��%   &	        �� 5   
   ���	#FF000000.@�5      m� # Z 6   ���	#FF000000��6U   ��  �� *Self+$ Command.Text� 5	      �� 5
      $��Resources\Images\Edit.png��6   $��16��5      $��16��5      5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           AddUserFormCommand   Command# Z 5      6y     5   
   -   5        # Z 5      6s     5   
   -   5        	   DeleteUserCommand# Z	 5      6w     5   
   -   5        
   AddRoleFormCommand# Z
 5      6y     5   
   -   5           RemoveRoleCommand# Z 5      6w   .��5      � $��Stretch=�6   $��0,0,5,0q�6)    � ColumnDefinitions 5   
   �� 5      $	��200��6   $
��205* �6.   �� 5      $	��200��6   $
��205* �6.    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��300��6   $
��300* �6,   �� 5       $��54 �6   .+�5"   
   �� $��0��6   $��0��6$   $��Center=�61   $��15(�6N   $��Users:��6\   $��5q�6j   
�������6u   �� 5#      -   5         ��Name$ lbUsers��5#   7   $��0��6   $��1��6*   $��3q�6H   $��Stretch=�6S   ��5$      �� 5%      .R�5&      ��  �� Orientation$ 
Horizontal=�6)    � ContextMenu# [  6B   .+�5'   "   �� $��24��6(   $��24��63   $	��3,0q�6?   $��Resources\Images\user.png��6L   �� 5(   "   ��6,   �� *Name+5)      5*      5,      �� 5-      $ 
Horizontal=�6   $��Right=�66   $��0��6R   $��2��6b   .+�5.      �� $��35��6      Inspire.ButtonImage   Image$ Resources\Images\add.png��6!   #��Z 6V   $��Bottom=�6�   $
��Left=�6�   $��3q�6  $	��128��6$  ��6�   ��  �� *Self+$ Command.Text�62  �� 5/      $��35��6   $! Resources\Images\remove.png��6!   #��Z	 6Y   $��Right=�6�   $��Bottom=�6  $��3q�6  $	��128��6'  ��6�   ��  �� *Self+$ Command.Text�65  50      �� 51      $��1��6   $��0��6,   $��15(�69   $��Center=�6G   $��Roles:��6d   $��5q�6r   
�������6}   �� 52      -   5        $ lbRoles��52   7   $��1��6   $��1��6*   $��Stretch=�6H   $��3q�6f   ��53      �� 54      .R�55      �� $ 
Horizontal=�6)   .+�56   "   �� ��6,   �� *Name+57      58      5:      �� 5;      $ 
Horizontal=�6   $��Right=�66   $��1��6R   $��2��6b   .+�5<      �� $��35��6   $ Resources\Images\add.png��6)   #��Z
 6^   $��Bottom=�6�   $
��Left=�6  $��3q�6!  $	��128��6,  ��6�   ��  �� *Self+$ Command.Text�6:  �� 5=      $��35��6   $! Resources\Images\remove.png��6)   #��Z 6a   $��Right=�6�   $��Bottom=�6	  $��3q�6$  $	��128��6/  ��6�   ��  �� *Self+$ Command.Text�6=  5>      5?      5@      