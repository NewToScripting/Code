   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  _ [DevComponents.WpfEditors, Version=5.8.0.6, Culture=neutral, PublicKeyToken=cbba4a1563683cdbeHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditorsDevComponents.WpfEditors ! Inspire.Client.ScheduleWindowA   ;Inspire.Client.ScheduleWindow.Dialogs.SlideTransitionDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     _
WpfEditorsHclr-namespace:DevComponents.WpfEditors;assembly=DevComponents.WpfEditors       � Title$  SlideTransitionDialog�� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������ $	��270��$	��600�� � 
ResizeMode$ NoResize=�.���� 
�������$��1q�   	DarkBrush#��[   �� CornerRadius$ 30��$��12q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   
BlurRadius$ 30Q�._�� .+��� -   	 ��Name$	 tbText��$
��Wrap=�$��18(�$
��Bold"�
�������$K��EChoose the transition effect that will occur when this slide appears:��$��0,7,11,0q�$��Right=�$	��364��$��61��$	��Top=�   �� $(��"../Resources/Images/transition.png��$
��Left=�$	��197���� -   $��btnOk��$��40��$��	0,0,156,5q�   Inspire.ButtonImage
   Image$"
 ../Resources/Images/Ok16.png��$��Bottom=�$	��128��$��Right=�$��Ok���� -   $��	btnCancel��$��40��$��Right=�$��0,0,22,5q�$&
  ../Resources/Images/Cancel16.png��$��Bottom=�$	��128��$��Cancel���� -   $��
textBlock1��$��18(�$
��Bold"�  
Foreground#��[ $��27��$��Right=�$��
0,74,215,0q�$��Current Transition:��$
��Wrap=�$	��Top=�$	��170��   �� -   $��tbTransitionName��$��16(�$
��Bold"�
�������$��27��$��Right=�$��0,76,6,0q�$
��Fade��$
��Wrap=�$	��Top=�$	��213��   �� -   $��button1��$��Select Transition��$��40��$��Right=�$��	0,0,22,59q�$��Bottom=�$	��128��