   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors ! Inspire.Client.ScheduleWindow3   -Inspire.Client.ScheduleWindow.SlideTimeDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors       � AllowsTransparency  .  � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � Title$ SlideTimeDialog��$	��345��$	��795�� � 
ResizeMode$ NoResize=�.���� 
�������$��1q�   	DarkBrush#��[   �� CornerRadius$ 4��$��12q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   
BlurRadius$ 30Q�._�� .+��� -   	 ��Name$	 tbText��$
��Wrap=�$��18(�$
��Bold"�
�������$b��\Choose how long you would like the slide to play for before transitioning to the next slide:��$��	203,7,0,0q�$��66��$	��Top=�$
��Left=�$	��533��   �� -   $	 tbDefaultText��$^��X(The current value is based on recommended values from elements contained in the slide.)��$
��Wrap=�  
Foreground#��[ $��
203,72,0,0q�$��70��$	��Top=�$
��Left=�$	��342���� $&��   (Hours)   (Minutes)  (Seconds)��$��
548,71,0,0q�  	TextBrush#��[ $
��Left=�$	��169��$��31��$	��Top=�,  &DevComponents.WpfEditors.DateTimeInput  -   
  Name$
 dtiDuration��
���   �$��40(�$��
547,93,0,0q�$
��Left=� � ToolTip$ Duration��$	��Top=�   Format$ Custom=�   CustomFormat$ HH:mm:ss��   ShowDropDown .     AllowEmptyState .  $��52��$	��178���� $#��../Resources/Images/clock.png��$
��Left=�$	��125��$��42,7,0,0q�$	��129��$	��Top=��� $(��"../Resources/Images/transition.png��$
��Left=�$	��125��$��
42,142,0,0q�$	��139��$	��Top=��� -   $��btnOk��$��40��$��	0,0,156,5q�   Inspire.ButtonImage   Image$" ../Resources/Images/Ok16.png��$��Bottom=�$	��128��$��Right=�$��Ok���� -   $��	btnCancel��$��40��$��Right=�$��0,0,22,5q�$&  ../Resources/Images/Cancel16.png��$��Bottom=�$	��128��$��Cancel���� -   $��
textBlock1��$��18(�$
��Bold"�
�������$��61��$
��Left=�$��181,156,0,0q�$K��EChoose the transition effect that will occur when this slide appears:��$
��Wrap=�$	��Top=�$	��383��   �� -   $��tbTransitionName��$��16(�$
��Bold"�
�������$��27��$
��Left=�$��396,182,0,0q�$
��Fade��$
��Wrap=�$	��Top=�$	��213��   �� -   $��button1��$��Select Transition��$��40��$
��Left=�$��597,191,0,0q�$	��Top=�$	��128��