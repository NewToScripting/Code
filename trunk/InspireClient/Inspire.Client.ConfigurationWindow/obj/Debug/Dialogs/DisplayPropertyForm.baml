   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5      D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  5      & "Inspire.Client.ConfigurationWindowD   >Inspire.Client.ConfigurationWindow.Dialogs.DisplayPropertyForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5        � Title$  Property Info��5      $	��238��6   $	��485��6(    � WindowStartupLocation$ CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        &    Inspire.Commands.InspireCommands   SavePropertyFormCommand   Command# Z 5      6�   .��5
      �    PopupBackgroundBrush#��[  6   .+�5   
   �� -   5        $��lblGroupName��5   Q   $
��Left=�6   $��	12,25,0,0q�6+   
�������$��89��6e   $��25��6p   $	��Top=�6|   .��6�   Property Name :6�      Inspire.InfoTextBox  5   
   -   5        $��tbPropertyName��5   ^      TextBoxInfo$# Enter A Name For The Property��6   $��
95,27,12,0q�6J   $��25��6t   $	��Top=�6�   �� 5   
   -   5        $��label1��5   Q   $
��Left=�6   $��	18,56,0,0q�6+   
�������$��79��6_   $��25��6j   $	��Top=�6v   .��6�   Description :6�     5   
   -   5        $��tbPropertyDescription��5   Q   $* $Enter A Description For The Property��6   $��95,58,12,46q�6n    �� TextWrapping$
 Wrap=�6�   �� 5   
   -   5        $��btnSave��5   2   $��35��6   $��189,0,146,5q�6   $��Bottom=�6A   #��Z 6\   .��6�   Save6�   �� 5   
   -   5        $��	btnCancel��5   K   $��35��6   $��Right=�6   $��0,0,12,5q�69   $��Bottom=�6\   $	��128��6w   .��6�   Cancel6�   5      5      