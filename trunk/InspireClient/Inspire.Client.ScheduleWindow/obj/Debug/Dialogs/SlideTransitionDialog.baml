   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5   '   _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors 6^   ! Inspire.Client.ScheduleWindowA   ;Inspire.Client.ScheduleWindow.Dialogs.SlideTransitionDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :Inspire&clr-namespace:Inspire;assembly=Inspire     5   '   _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors     6^     � Title$  SlideTransitionDialog��6	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�    � WindowStyle$
 None=�6�   
������ $	��270��6%  $	��600��62   � 
ResizeMode$ NoResize=�6>  .��5      �� 
�������$��1q�6!      	DarkBrush#��[  65    �� CornerRadius$ 30��6]   $��12q�6o    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 10Q�6      
BlurRadius$ 30Q�60   ._�5	   
   � .+�5
      �� -   5        	 ��Name$	 tbText��5
      $
��Wrap=�6(   $��18(�6<   $
��Bold"�6J   
�������$K��EChoose the transition effect that will occur when this slide appears:��6o   $��0,7,11,0q�6�   $��Right=�6�   $	��364��6�   $��61��6�   $	��Top=�6   5        5      5      �� 5      $(��"../Resources/Images/transition.png��6   $
��Left=�6@   $	��197��6[   �� 5      -   5        $��btnOk��5   m   $��40��6   $��	0,0,156,5q�6!      Inspire.ButtonImage
   Image$"
 ../Resources/Images/Ok16.png��64   $��Bottom=�6z   $	��128��6�   $��Right=�6�   $��Ok��6�   6�   �� 5      -   5        $��	btnCancel��5   �   $��40��6   $��Right=�6!   $��0,0,22,5q�6=   $&
  ../Resources/Images/Cancel16.png��6O   $��Bottom=�6�   $	��128��6�   $��Cancel��6�   6�   �� 5      -   5        $��
textBlock1��5   �   $��18(�6   $
��Bold"�6&     
Foreground#��[ 68   $��27��6a   $��Right=�6m   $��
0,74,215,0q�6�   $��Current Transition:��6�   $
��Wrap=�6�   $	��Top=�6�   $	��170��6�    6    6  6=  �� 5      -   5        $��tbTransitionName��5   �   $��16(�6   $
��Bold"�6&   
�������$��27��6K   $��Right=�6W   $��0,76,6,0q�6s   $
��Fade��6�   $
��Wrap=�6�   $	��Top=�6�   $	��213��6�    6�     6�   6  �� 5      -   5        $��button1��5   l   $��Select Transition��6   $��40��61   $��Right=�6=   $��	0,0,22,59q�6Y   $��Bottom=�6{   $	��128��6�   6�   5      5      5      