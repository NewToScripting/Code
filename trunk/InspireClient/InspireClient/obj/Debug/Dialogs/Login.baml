   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      2&clr-namespace:Inspire;assembly=InspireInspire  5       Inspire.Client   Inspire.Client.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     5      6sys&clr-namespace:System;assembly=mscorlib     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      @d2http://schemas.microsoft.com/expression/blend/2008     5   �   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6  -   5          � Title$  Login��5      $	��346��6   
������ $	��533��69    � 
ResizeMode$ NoResize=�6E    � WindowStyle$
 None=�6[    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5	         Inspire.FullDateConverter   fullDateConverter2��%   &	          5
   
   6$   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        &    Inspire.Commands.InspireCommands   AdminLoginCommand   Command# Z 5      6w   .��5      �� 	 J� Opacity$		 .95Q�6   
 �� CornerRadius$
 0��6   $	��269��6,   ._�5      � $��10q�6     ListBackgroundBrush#���  6     PopupDropShadow J� Effect# �  6J   .+�5   
   ��  �� TextAlignment$ Right=�6   $��14(�6*   
�������$��Right=�6�   $��	0,48,30,0q�6�   $	��201��6�   $��26��6�   $	��Top=�6�   ��6K   ��  �� 	Converter# [  
 �� Now �� Source# Z 6�   �� 5   
   $��4��6   $��	0,70,-1,0q�6   $	��Top=�62     DefaultedBorderBrush#��[ 6J   �� 5      -   5         ��Name$ imgLogo��5   -   $��-15,-36,0,0q�6   $��..\\Logo.png��6>   $��UniformToFill=�6T   $
��Left=�6l   $	��233��6�   $	��151��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ label1��5   %   $��0,0,237,129q�6   $��15(�65   
�������$��20��6V   $��Bottom=�6b   $��Right=�6}   $��35��6�   $��User:��6�   �� 5   
   -   5        $ label2��5   E   $��
0,0,237,90q�6   
�������$��15(�67   $��21��6U   $��Bottom=�6a   $��Right=�6|   $��66��6�   $��	Password:��6�   �� 5   
   -   5         ��Name$ cbUser��5   )   $��0,100,30,124q�6   $��Right=�69   $	��201��6U   ��5      �� 5      .R�5      ��   	TextBrush#��[ 6`   ��6    ��  �� Path$
 Name� � ToolTip 6;   �� $ Description�6`   5      5      G� 5   
   -   5         G�Name$ txtPassword��5   ^   
�������$��Center=�6)   $��	0,0,30,85q�6K   $��30��6s   $��Bottom=�6   $��Right=�6�   $	��198��6�   �� 5      -   5         ��Name$ btnLogin��5   7   $��35��6   $��217,0,164,39q�6!      Inspire.ButtonImage   Image$# ..\\Resources\Images\Ok16.png��6I   $��Bottom=�6�    �� 	IsDefault . $��Login��6�   �� 5      -	   5        $ 	btnCancel��5   �   $��35��6   $��Right=�6!   $��	0,0,30,39q�6=   $' !..\\Resources\Images\Cancel16.png��6P   $��Bottom=�6�   $	��128��6�   $��Cancel��6�   �� 5         PopupBackgroundBrush#��[ 6   $��22��6E   $��Bottom=�6Q   �� 5!      
�������$��	0,0,-2,-4q�6.   $��Right=�6A   $	��132��6]   $��23��6i   $��Bottom=�6u   �� 6�   $�Inspire Digital Signage��6�   6�   �� 5"      -
   5        $ imgLogo_Copy��5"   .   $��-8,29.5,0,88.322q�6   $��..\\Logo.png��6D   $��UniformToFill=�6Z    J� RenderTransformOrigin$ 0.5,0.5&�6r   $
��Left=�6�   $��240.96��6�    J� OpacityMask 5#      �� 5$   	    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6.   .��5%   
   �  � Color$ 	#00000000��6    � Offset$ 0.304Q�6)   � 5&   
   $ 	#FFFFFFFF��6   $ 1Q�6)   � 5'   
   $ 	#00646464��6   $ 0.393Q�6)   � 5(   
   $ 	#33A4A4A4��6   $ 0.571Q�6)   � 5)   
   $ 	#FFE9E9E9��6   $ 0.683Q�6)   5*   
   z�5,      V� 5-   	   .~�5.   
   ��  �� ScaleX$ -1Q�6     �� ScaleY$  1Q�6%   �� 5/   
   ! �� AngleX$! 0Q�6   " �� AngleY$" 0Q�6#   �� 50   
   # �� Angle$# 179.886Q�6   T� 51   
   $ T� X$$ 0Q�6   % T� Y$% 0Q�6#   52   
   54      55      56      57      