   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5      D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  5      & "Inspire.Client.ConfigurationWindow<   6Inspire.Client.ConfigurationWindow.Dialogs.DisplayForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5        � Title$  Display��5      $	��470��6   $	��717��6"    � WindowStartupLocation$ CenterScreen=�6.    � 
ResizeMode$ NoResize=�6S    � 	Resources 5         GroupComboTemplate  
Foreground �� Mode �� Path  PropertyComboTemplate��%C  &	        7  &	 �     7  �� 5
   
   .R�5      � $
��Auto��6   $
��Auto��6    .+�5      �� 8��  ��6E   �� $ OneWay=�$ 	GroupName�5      5      �� 5   
   .R�5      � $
��Auto��6   $
��Auto��6    .+�5      �� 8��  ��6E   �� $ OneWay=�$ PropertyName�5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        &    Inspire.Commands.InspireCommands   SaveDisplayFormCommand   Command# Z 5      6�   .��5      �   PopupBackgroundBrush#��[ 6   .+�5   
   �� 
�������$��32��6#   $
��Left=�6/   $��	21,68,0,0q�6J   $	��Top=�6]   $	��130��6u   $��RightToLeft=�6�   .��6�   : Display Name6�   �� 5   
   
�������$��32��6#   $
��Left=�6/   $��
21,100,0,0q�6J   $	��Top=�6^   $	��130��6v   $��RightToLeft=�6�   .��6�   
: Hostname6�   �� 5   
   
�������$��32��6#   $
��Left=�6/   $��	8,132,0,0q�6J   $	��Top=�6]   $	��143��6u   $��RightToLeft=�6�   .��6�   : Horizontal Resolution6�   �� 5   
   
�������$��32��6#   $
��Left=�6/   $��
21,164,0,0q�6J   $	��Top=�6^   $	��130��6v   $��RightToLeft=�6�   .��6�   : Vertical Reslution6�   �� 5    
   
�������$
��Left=�6#   $��21,196,0,208q�6>   $	��130��6T   $��RightToLeft=�6`   .��6|   
: Location6�   �� 5!   
   
�������$��32��6#   $
��Left=�6/   $��
21,0,0,178q�6J   $��Bottom=�6^   $	��130��6y   $��RightToLeft=�6�   .��6�   : Controller Type6�   �� 5"   
   
�������$��32��6#   $
��Left=�6/   $��
21,0,0,146q�6J   $��Bottom=�6^   $	��130��6y   $��RightToLeft=�6�   .��6�   : Controller Model6�   �� 5#   
   
�������$��32��6#   $
��Left=�6/   $��
21,0,0,114q�6J   $��Bottom=�6^   $	��130��6y   $��RightToLeft=�6�   .��6�   : Monitor Type6�   �� 5$   
   
�������$��32��6#   $
��Left=�6/   $��	21,0,0,82q�6J   $��Bottom=�6]   $	��130��6x   $��RightToLeft=�6�   .��6�   : Monitor Model6�   �� 5%   
   
�������$��32��6#   $
��Left=�6/   $��	21,0,0,50q�6J   $��Bottom=�6]   $	��130��6x   $��RightToLeft=�6�   .��6�   : Monitor Size6�      Inspire.InfoTextBox  5'   
   -   5        	  Name$	 txtDispName��5'   k   
   TextBoxInfo$"
 Enter A Name For The Display��6   $��25��6I   $��157,68,331,0q�6U   $	��Top=�6�     5(   
   -   5        $	 txtHostName��5(   r   $(
 "Enter The Hostname for the Display��6   $��25��6O   $��157,100,331,0q�6[   $	��Top=�6�     5)   
   -   5        $	 txtHRes��5)   y   $/
 )Enter The Display's Horizontal Resolution��6   $��25��6V   $��157,132,331,0q�6b   $	��Top=�6�     5*   
   -   5        $	 txtVRes��5*   w   $-
 'Enter The Display's Vertical Resolution��6   $��25��6T   $��157,164,331,0q�6`   $	��Top=�6�     5+   
   -   5        $	 txtLoc��5+   o   $#
 Where Is The Display Located?��6   $��25��6J   $��157,198,331,219q�6V   6o     5,   
   -   5        $	 txtContType��5,   l   $"
 What Is The Controller Type?��6   $��25��6I   $��157,0,331,187q�6U   $��Bottom=�6�     5-   
   -   5        $	 txtContModel��5-   r   $(
 "Enter The Model For The Controller��6   $��25��6O   $��157,0,331,155q�6[   $��Bottom=�6�     5.   
   -	   5        $	 
txtMonType��5.   l   $"
 What Type Of Monitor? Brand?��6   $��25��6I   $��157,0,331,123q�6U   $��Bottom=�6�     5/   
   -
   5        $	 	txtMonMod��5/   h   $
 What Is The Model Number?��6   $��25��6F   $��157,0,331,91q�6R   $��Bottom=�6{     50   
   -   5        $	 
txtMonSize��50   o   $&
  Enter The Monitor Size in Inches��6   $��25��6M   $��157,0,331,59q�6Y   $��Bottom=�6�   �� 52   
   
�������$��RightToLeft=�6#   $��32��6?   $��Right=�6K   $��
0,68,220,0q�6g   $	��Top=�6{   $	��110��6�   .��6�   : OS6�   �� 53   
   
�������$��RightToLeft=�6#   $��32��6?   $��Right=�6K   $��0,100,220,0q�6g   $	��Top=�6|   $	��110��6�   .��6�   
: Domain6�   �� 54   
   
�������$��RightToLeft=�6#   $��Right=�6?   $��0,0,220,182q�6[   $	��110��6p   $��32��6|   $��Bottom=�6�   .��6�   	: Group6�   �� 55   
   
�������$��RightToLeft=�6#   $��Right=�6?   $��0,131,220,0q�6[   $	��110��6p   $��32��6|   $	��Top=�6�   .��6�   
: Status6�   �� 56   
   
�������$��RightToLeft=�6#   $��Right=�6?   $��0,165,220,0q�6[   $	��110��6p   $��38��6|   $	��Top=�6�   .��6�   : Orientation6�   �� 57   
   
�������$��RightToLeft=�6#   $��Right=�6?   $��0,196,220,214q�6[   $	��110��6r   .��6~   
: Property6�     59   
   -   5        $��txtOS��59   �   $!
 OS Installed On Controller?��6   $��25��6H   $��Right=�6T   $��	0,68,20,0q�6p   $	��Top=�6�   $	��194��6�     5:   
   -   5        $��	txtDomain��5:   �   $
 Domain Controller Is On��6   $��25��6D   $��Right=�6P   $��
0,100,20,0q�6l   $	��Top=�6�   $	��194��6�   �� 5;   
   -   5        $��	txtStatus��5;   T    �� 
IsReadOnly . $��Right=�6$   $��
0,131,20,0q�6@   $	��194��6e   $��25��6q   $	��Top=�6}     5<   
   -   5        $��txtOrientation��5<   s   $
 Horizontal / Vertical?��6   $��Right=�6C   $��
0,165,20,0q�6_   $	��194��6�   $��25��6�   $	��Top=�6�   �� 5=   
   $��35��6   $��Right=�6   $��	0,0,139,5q�69   $��Bottom=�6L   $	��128��6g   #��Z 6s   .��6�   Save6�   �� 5>   
   -   5        $��35��5>      $��Right=�6   $��Bottom=�69   $	��128��6T   $��0,0,5,5q�6`   .��6�   Cancel6�   �� 5?   
   -   5        $��
cbProperty��5?   Q   $��25��6   $��Right=�6   $��0,197,20,220q�6;   $	��194��6c   #��[ 6o   6�   �� 5@   
   -   5        $��cbGroup��5@   C   $��Right=�6   $��
0,0,20,189q�6/   $	��194��6S   $��25��6_   $��Bottom=�6k   #��[  6�   �� 5A   
   -   5        $��lblGuid��5A   L   $��28��6   $��Right=�6   $��
0,0,12,122q�68   $��Bottom=�6[   $	��292��6v   $y�Hidden=�6�   .��6�   Label6�   5B      5C      