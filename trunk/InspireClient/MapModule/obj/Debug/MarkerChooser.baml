   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5   @    	MapModule   MapModule.MarkerChooser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :Inspire&clr-namespace:Inspire;assembly=Inspire     6@     � Title$  MarkerChooser��6w   $	��400��6�   $	��320��6�      ListBackgroundBrush#��[  6�    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   $   Inspire.InnerGlowBorderControl     InnerGlowColor$ 	#ff000000��6)      InnerGlowSize$ 15,15,15,15q�6D      InnerGlowOpacity$	 0.7Q�6`   $��	0,50,0,44q�5   '   ���	#FF111111���	#FF333333$��2,2,2,2q�6i      CornerRadius$ 5,5,5,5��6�   $��Stretch=�6�   .��5      � $��0,0,0,0q�6   ��5      �� 5	       �� EndPoint$&  127.499000549316,154.52799987793&�6*    �� 
StartPoint$ 117.924003601074,149&�6V    � MappingMode$ Absolute=�6x   	 � SpreadMethod$	 Repeat=�6�   .��5
      � 
 � Color$
 	#00000000��6'   � 5      $
 	#00000000��6'    � Offset$ 1Q�69   � 5      $
 	#00000000��6'   $ 0.498Q�69   � 5      $
 	#00000000��6'   $ 0.55500000715255737Q�69   � 5      $
 	#FF000000��6'   $ 0.527999997138977Q�69   5      .+�5      � $��0,0,0,0q�6   ��5      �� 5      $' !119.947998046875,156.550994873047&�6.   $' !125.474998474121,146.977005004883&�6[   $ Absolute=�6�   $	 Repeat=�6�   .��5      � $
 	#00000000��6+   � 5      $
 	#00000000��6+   $ 1Q�6=   � 5      $
 	#00000000��6+   $ 0.498Q�6=   � 5      $
 	#00000000��6+   $ 0.55500000715255737Q�6=   � 5      $
 	#FF000000��6+   $ 0.527999997138977Q�6=   5      .+�5      �� -   5         ��Name$ lbIcons��5      $��10q�6/   
������ $��0q�6e   $��Disabled=�6y   ��6;   Z� ��5      �� 5      .R�5   "   � 5       5"      5$      5%      5&      �� 5'   
   $��Right=�6   $��Bottom=�61    �� Orientation$ 
Horizontal=�6L   .+�5(      �� -   5        $��btnOk��5(   W      Inspire.ButtonImage   Image$ Resources\Images\Ok16.png��6   $��35��6K   $��5q�6d   $��Right=�6o   $	��128��6�   .��6�   Ok6�   �� 5)      -   5        $��	btnCancel��5)   w   $# Resources\Images\Cancel16.png��6   $��35��6O   $��Right=�6[   $	��128��6�   $��5q�6�   .��6�   Cancel6�   5*         Inspire.InfoTextBox  5+   
   -   5        $��tbName��5+   U   $��31��6   $��Stretch=�6*   $��10q�6I      TextBoxInfo$ Enter Category Name Here��6c   $	��Top=�6�   5,      5-      