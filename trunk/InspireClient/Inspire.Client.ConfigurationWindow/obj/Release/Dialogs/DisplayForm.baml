   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  & "Inspire.Client.ConfigurationWindow<   6Inspire.Client.ConfigurationWindow.Dialogs.DisplayForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire       � Title$  Display��$	��470��$	��717�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources    GroupComboTemplate  
Foreground �� Mode �� Path  PropertyComboTemplate��%�   &	        7  &	 V     7  �� .R�� $
��Auto��$
��Auto��.+��� 8��  ���� $ OneWay=�$ 	GroupName��� .R�� $
��Auto��$
��Auto��.+��� 8��  ���� $ OneWay=�$ PropertyName� J� CommandBindings )  #System.Windows.Input.CommandBinding  -   &    Inspire.Commands.InspireCommands   SaveDisplayFormCommand   Command# Z .���   PopupBackgroundBrush#��[ .+��� 
�������$��32��$
��Left=�$��	21,68,0,0q�$	��Top=�$	��130��$��RightToLeft=�.��: Display Name�� 
�������$��32��$
��Left=�$��
21,100,0,0q�$	��Top=�$	��130��$��RightToLeft=�.��
: Hostname�� 
�������$��32��$
��Left=�$��	8,132,0,0q�$	��Top=�$	��143��$��RightToLeft=�.��: Horizontal Resolution�� 
�������$��32��$
��Left=�$��
21,164,0,0q�$	��Top=�$	��130��$��RightToLeft=�.��: Vertical Reslution�� 
�������$
��Left=�$��21,196,0,208q�$	��130��$��RightToLeft=�.��
: Location�� 
�������$��32��$
��Left=�$��
21,0,0,178q�$��Bottom=�$	��130��$��RightToLeft=�.��: Controller Type�� 
�������$��32��$
��Left=�$��
21,0,0,146q�$��Bottom=�$	��130��$��RightToLeft=�.��: Controller Model�� 
�������$��32��$
��Left=�$��
21,0,0,114q�$��Bottom=�$	��130��$��RightToLeft=�.��: Monitor Type�� 
�������$��32��$
��Left=�$��	21,0,0,82q�$��Bottom=�$	��130��$��RightToLeft=�.��: Monitor Model�� 
�������$��32��$
��Left=�$��	21,0,0,50q�$��Bottom=�$	��130��$��RightToLeft=�.��: Monitor Size   Inspire.InfoTextBox  -   	  Name$	 txtDispName��
   TextBoxInfo$"
 Enter A Name For The Display��$��25��$��157,68,331,0q�$	��Top=�  -   $	 txtHostName��$(
 "Enter The Hostname for the Display��$��25��$��157,100,331,0q�$	��Top=�  -   $	 txtHRes��$/
 )Enter The Display's Horizontal Resolution��$��25��$��157,132,331,0q�$	��Top=�  -   $	 txtVRes��$-
 'Enter The Display's Vertical Resolution��$��25��$��157,164,331,0q�$	��Top=�  -   $	 txtLoc��$#
 Where Is The Display Located?��$��25��$��157,198,331,219q�  -   $	 txtContType��$"
 What Is The Controller Type?��$��25��$��157,0,331,187q�$��Bottom=�  -   $	 txtContModel��$(
 "Enter The Model For The Controller��$��25��$��157,0,331,155q�$��Bottom=�  -	   $	 
txtMonType��$"
 What Type Of Monitor? Brand?��$��25��$��157,0,331,123q�$��Bottom=�  -
   $	 	txtMonMod��$
 What Is The Model Number?��$��25��$��157,0,331,91q�$��Bottom=�  -   $	 
txtMonSize��$&
  Enter The Monitor Size in Inches��$��25��$��157,0,331,59q�$��Bottom=��� 
�������$��RightToLeft=�$��32��$��Right=�$��
0,68,220,0q�$	��Top=�$	��110��.��: OS�� 
�������$��RightToLeft=�$��32��$��Right=�$��0,100,220,0q�$	��Top=�$	��110��.��
: Domain�� 
�������$��RightToLeft=�$��Right=�$��0,0,220,182q�$	��110��$��32��$��Bottom=�.��	: Group�� 
�������$��RightToLeft=�$��Right=�$��0,131,220,0q�$	��110��$��32��$	��Top=�.��
: Status�� 
�������$��RightToLeft=�$��Right=�$��0,165,220,0q�$	��110��$��38��$	��Top=�.��: Orientation�� 
�������$��RightToLeft=�$��Right=�$��0,196,220,214q�$	��110��.��
: Property  -   $��txtOS��$!
 OS Installed On Controller?��$��25��$��Right=�$��	0,68,20,0q�$	��Top=�$	��194��  -   $��	txtDomain��$
 Domain Controller Is On��$��25��$��Right=�$��
0,100,20,0q�$	��Top=�$	��194���� -   $��	txtStatus�� �� 
IsReadOnly . $��Right=�$��
0,131,20,0q�$	��194��$��25��$	��Top=�  -   $��txtOrientation��$
 Horizontal / Vertical?��$��Right=�$��
0,165,20,0q�$	��194��$��25��$	��Top=��� $��35��$��Right=�$��	0,0,139,5q�$��Bottom=�$	��128��#��Z .��Save�� -   $��35��$��Right=�$��Bottom=�$	��128��$��0,0,5,5q�.��Cancel�� -   $��
cbProperty��$��25��$��Right=�$��0,197,20,220q�$	��194��#��[ �� -   $��cbGroup��$��Right=�$��
0,0,20,189q�$	��194��$��25��$��Bottom=�#��[  �� -   $��lblGuid��$��28��$��Right=�$��
0,0,12,122q�$��Bottom=�$	��292��$y�Hidden=�.��Label