   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  U QInfoStrat.VE.Windows7Touch, Version=2.2.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:InfoStrat.VE.Windows7Touch;assembly=InfoStrat.VE.Windows7TouchInfoStrat.VE.Windows7Touch D @MapModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MapModule	MapModule    MapModule.PushPointPicker   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     fWindows7TouchLclr-namespace:InfoStrat.VE.Windows7Touch;assembly=InfoStrat.VE.Windows7Touch     -	MapModuleclr-namespace:MapModule        	TextBrush#���     � Title$%  Add your locations of interest.��$	��800��$	��692�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�  WindowBackgroundBrush#��[ ��Z�  � 	Resources   locationTemplate2 �� Orientation  MapModule.DynamicMarker   SelectedTemplate �� Path   Title  
Foreground3  -InfoStrat.VE.Windows7Touch.Win7TouchVEPushPin �� 
TargetType	 �� Property
 �� Value �� 
TargetType��%)  &	       7  '  �     �� .R��� $ 
Horizontal=�.+�(� $��10q�$��16��$��16��.��   �� $ MarkerPin.CategoryStyle� �� $ LocationName��� 8��  ���� *Name+�� "  .��� 	 � ��
 �� "  .R�   �� $ CategoryStyle� �� $ LocationName�.��� .+�]� ��. .+��� $	��200��$��Bottom=�._��� $ 
Horizontal=�.+��� $ Vertical=�.+��� $ 
Horizontal=�.+��� -   $��btnHome��$��5,5,5,2q�$
��Left=�$��Set Home��$��35��$��75�� � ToolTip$ Set the home location.���� $ 
Horizontal=�$��2q�.+�(� $��24��$��24��.��  -     Name$ dmtempl�� �� $ LocationName��� -    ��Name$ tbHomLoc��$��3,0,0,0q�$��Center=�#��[ ���� *LocationName+R� -   $��tvCategories��  	DarkBrush#��[ $��5,2,5,2q�$	��270��$��Bottom=�$��Stretch=�$	��149����Z�   �� DataType  MapModule.MapCategory �� ItemsSource"  MapModule.InspireMapLocation��%A  (��       *, +)7  (�� �     *, +)7  �� "   �� *MapLocations+.R��� $ 
Horizontal=�$��2q�.+�(� $��16��$��16��.��   �� $ CategoryStyle� �� $
 Name��� $��3,0,0,0q�8��  ���� *Name+�� "  .R��� $ 
Horizontal=�.+��� 8��  $��Center=����� *LocationName+�� $ Vertical=�$��0,10,0,0q�.+��� -    ��Name$ cbShowMapOnly��$��5,0,5,0q�$��Map Only��#��[ $B <Just shows the map instead of the search pane along with it.���� -   $ cbShowPrint��$��5,5,5,0q�$��
Show Print��#��[ $B <Displays the print button so that directions can be printed.���� -   $��btnAddCategory��$	��Top=�$��5,5,5,5q�$��     Category��$��23��$��85��$ Add a category.���� -   $��btnRemoveCategory��$	��Top=�$��5,0,5,5q�$��    Category��$��23��$��85��$ Remove a category.���� -	   $��btnAdd��$	��Top=�$��5,5,5,5q�$��     Location��$��23��$��85��$ Add location to category.���� -
   $��	btnRemove��$	��Top=�$��5,0,5,5q�$��     Location��$��23��$��85��$$ Remove location from category.���� -   $ cbAutoPopCat��$��5,0,5,0q�$��Auto Populate��#��[ $a [Automatically finds nearby locations based on the category name and places them on the map.�� d� 	IsChecked �� *AutoPopulate+�� $ Vertical=�.+��� #���   $��	Map Style�� �� TextAlignment$ Center=�$	��Top=�$��60��$��5q�$	��267��.���� $ 
Horizontal=�$��Stretch=�$	��207��.+�	� -   $��rbRoad��#���    	� 	GroupName$ MapStyle��$��5q�.��Road	� -   $��rbHybrid��#���   $
 TrueY�$��5q�$ MapStyle��.��Hybrid	� -   $��rbAerial��#���   $ MapStyle��$��5q�.��Arial�� $ Vertical=�.+��� $ 
Horizontal=�.+��� -   $��cbShowTraffic��$��5,5,5,5q�$y�	Collapsed=�$ FalseY�#���   $��Show Traffic���� -   $��cbShowBuildings��$��10,5,5,5q�$
 TrueY�#���   $��Show Buildings���� $ 
Horizontal=�.+��� -   $��cbShowBuildingTextures��$��5,5,5,5q�$
 TrueY�#���   $��Show Building Textures���� -   $��cbShow3DCursor��$��10,5,5,5q�#���   $��Show 3D Cursor���� $ 
Horizontal=�.+��� -   $��cbAutoAdvance��$��5,5,5,5q�$
 TrueY�$C =Auto shows nearby locations in selected categories when idle.��#���   $��Auto Show Locations���� -   $��cbShowMapControls��$��10,5,5,5q�#���   $��Show Map Controls��� .+��� $��Bottom=�$ 
Horizontal=�.+��� -   $��btnOk��   Inspire.ButtonImage   Image$ Resources\Images\Ok16.png��$��35��$��5q�$��Right=�$	��128��.��Ok�� -   $��	btnCancel��$# Resources\Images\Cancel16.png��$��35��$��Right=�$	��128��$��5q�.��Cancel� .+��� -    ��Name$ 	mapHolder���� ���#000fff$��1��	 �� X1$ 0��	 �� Y1$ 0��	 �� X2$	 670��	 �� Y2$ 0��$��Center=��� ���#000fff$��1��$ 0��$ 0��$ 0��$	 600��$��Center=��� $��Resources/Add.png��$��16��$��16��$��Bottom=�$��295,0,0,127q� J� IsHitTestVisible .  $
��Left=��� $��Resources/Add.png��$��16��$��16��$��Bottom=�$��
295,0,0,65q� .  $
��Left=��� $��Resources/Remove.png��$��16��$��16��$��Bottom=�$��
295,0,0,99q� .  $
��Left=��� $��Resources/Remove.png��$��16��$��16��$��Bottom=�$��
295,0,0,39q� .  $
��Left=�