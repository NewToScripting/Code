   M S B A M L   `   `   `  ����R  NInspire.Client.Designer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Inspire.Client.Designer.DragCanvas"Inspire.Client.Designer.DragCanvas  5      B >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands 5      3    -Inspire.Client.Designer.DragCanvas.DragCanvas   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      G
DragCanvas0clr-namespace:Inspire.Client.Designer.DragCanvas     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5      -   5        $
��Auto��5      $
��Auto��6     J� 	AllowDrop  . 
�������$��1q�6\   
���   �   DesignerCanvasContextMenu � ContextMenu# [  6�    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5	   
   -   5        &   Inspire.Commands.InspireCommands   SelectAllCommand   Command# Z 5	      6u     5
   
   -   5           BringToFrontCommand# Z 5
      6{     5   
   -   5           BringForwardCommand# Z 5      6�     5   
   -   5           SendToBackCommand# Z 5      6~     5   
   -   5           SendBackwardCommand# Z 5      6�     5   
   -   5        	   FitToSlideCommand# Z	 5      6~     5   
   -   5        
   AddReflectionCommand# Z
 5      6�     5   
   -	   5           MoveItemUpCommand# Z 5      6w     5   
   -
   5           MoveItemDownCommand# Z 5      6{     5   
   -   5           MoveItemLeftCommand# Z 5      6{     5   
   -   5           MoveItemRightCommand# Z 5      6}     5   
   -   5           MoveItemUpShiftCommand# Z 5      6�     5   
   -   5           MoveItemDownShiftCommand# Z 5      6�     5   
   -   5           MoveItemLeftShiftCommand# Z 5      6�     5   
   -   5            MoveItemRightShiftCommand# Z 5      6�    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ./CanvasItem.xaml?�6%   %    5       .��5"      � .+�5#      �� ��6   ��  �� Path$ 	DataItems���5$   
   �� 5%      .R�5&      6   0Inspire.Client.Designer.DragCanvas.InspireCanvas  6   0Inspire.Client.Designer.DragCanvas.InspireCanvas   Drop DesignerCanvas_Drop6>      PreviewMouseDown InspireCanvas_MouseDown6j      PreviewMouseLeftButtonUp* &InspireCanvas_PreviewMouseLeftButtonUp6�    K� IsItemsHost .   . 5*      5+      5-      �� 5.       J� SnapsToDevicePixels . ���	#FF324B77$��1q�6@   5/      6   50      