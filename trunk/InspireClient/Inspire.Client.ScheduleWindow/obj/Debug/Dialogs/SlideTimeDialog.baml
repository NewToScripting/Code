   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5   @   _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors 6w   ! Inspire.Client.ScheduleWindow3   -Inspire.Client.ScheduleWindow.SlideTimeDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :Inspire&clr-namespace:Inspire;assembly=Inspire     6@   _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors     6w     � AllowsTransparency  .  � WindowStartupLocation$ CenterScreen=�6�    � WindowStyle$
 None=�6  
������  � Title$ SlideTimeDialog��6>  $	��345��6V  $	��795��6c   � 
ResizeMode$ NoResize=�6o  .��5      �� 
�������$��1q�6!      	DarkBrush#��[  65    �� CornerRadius$ 4��6]   $��12q�6n    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 10Q�6      
BlurRadius$ 30Q�60   ._�5   
   � .+�5	      �� -   5        	 ��Name$	 tbText��5	      $
��Wrap=�6(   $��18(�6<   $
��Bold"�6J   
�������$b��\Choose how long you would like the slide to play for before transitioning to the next slide:��6o   $��	203,7,0,0q�6�   $��66��6�   $	��Top=�6�   $
��Left=�6
  $	��533��6%   5
        5      5      �� 5      -   5        $	 tbDefaultText��5      $^��X(The current value is based on recommended values from elements contained in the slide.)��6/   $
��Wrap=�6�     
Foreground#��[ 6�   $��
203,72,0,0q�6�   $��70��6�   $	��Top=�6�   $
��Left=�6  $	��342��6  �� 5      $&��   (Hours)   (Minutes)  (Seconds)��6   $��
548,71,0,0q�6@     	TextBrush#��[ 6T   $
��Left=�6|   $	��169��6�   $��31��6�   $	��Top=�6�   ,  &DevComponents.WpfEditors.DateTimeInput  5      -   5        
  Name$
 dtiDuration��5   �   
���   �$��40(�6;   $��
547,93,0,0q�6I   $
��Left=�6]    � ToolTip$ Duration��6x   $	��Top=�6�      Format$ Custom=�6�      CustomFormat$ HH:mm:ss��6�      ShowDropDown .     AllowEmptyState .  $��52��6  $	��178��6  �� 5      $#��../Resources/Images/clock.png��6   $
��Left=�6;   $	��125��6V   $��42,7,0,0q�6b   $	��129��6t   $	��Top=�6�   �� 5      $(��"../Resources/Images/transition.png��6   $
��Left=�6@   $	��125��6[   $��
42,142,0,0q�6g   $	��139��6{   $	��Top=�6�   �� 5      -   5        $��btnOk��5   m   $��40��6   $��	0,0,156,5q�6!      Inspire.ButtonImage   Image$" ../Resources/Images/Ok16.png��64   $��Bottom=�6z   $	��128��6�   $��Right=�6�   $��Ok��6�   6�   �� 5      -   5        $��	btnCancel��5   �   $��40��6   $��Right=�6!   $��0,0,22,5q�6=   $&  ../Resources/Images/Cancel16.png��6O   $��Bottom=�6�   $	��128��6�   $��Cancel��6�   6�   �� 5      -   5        $��
textBlock1��5   �   $��18(�6   $
��Bold"�6&   
�������$��61��6K   $
��Left=�6W   $��181,156,0,0q�6r   $K��EChoose the transition effect that will occur when this slide appears:��6�   $
��Wrap=�6�   $	��Top=�6�   $	��383��6   6    61  6Y  �� 5      -   5        $��tbTransitionName��5   �   $��16(�6   $
��Bold"�6&   
�������$��27��6K   $
��Left=�6W   $��396,182,0,0q�6r   $
��Fade��6�   $
��Wrap=�6�   $	��Top=�6�   $	��213��6�    6�     6�   6  �� 5      -   5        $��button1��5   m   $��Select Transition��6   $��40��61   $
��Left=�6=   $��597,191,0,0q�6X   $	��Top=�6|   $	��128��6�   6�   5      5      5      