   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  D/clr-namespace:Inspire.Commands;assembly=InspireInspire.Commands  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  Inspire.Client)   #Inspire.Client.Dialogs.Registration   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     DCommands/clr-namespace:Inspire.Commands;assembly=Inspire     9System&clr-namespace:System;assembly=mscorlib     -     � Title$  Registration��$	��690��$	��670�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency .  � Topmost .   � WindowStartupLocation$ CenterScreen=� J� Opacity$	 .95Q���Z�  � 	Resources    Inspire.FullDateConverter   fullDateConverter2��%   &	           J� CommandBindings )  #System.Windows.Input.CommandBinding  -   &    Inspire.Commands.InspireCommands	   RegisterCommand
   Command#
 Z	 .���� $ 1Q� �� CornerRadius$ 0��
������ ._�� $��10q�  ListBackgroundBrush#���    PopupDropShadow J� Effect# �   � RowDefinitions �� $
��362* ��� $
��267* �.+��� -    ��Name$ imgLogo_Copy��$	��233��$	��151��$��..\\Logo.png��$��UniformToFill=� J� RenderTransformOrigin$ 0.5,0.5&�$
��Left=�$��
-15,44,0,0q�$	��Top=� J� OpacityMask ��  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#00000000�� � Offset$ 0.304Q�� $ 	#FFFFFFFF��$ 1Q�� $ 	#00646464��$ 0.393Q�� $ 	#33A4A4A4��$ 0.571Q�� $ 	#FFE9E9E9��$ 0.683Q�z�V� .~���  �� ScaleX$ -1Q� �� ScaleY$ 1Q���  �� AngleX$ 0Q� �� AngleY$ 0Q���  �� Angle$ 179.886Q�T�  T� X$ 0Q� T� Y$ 0Q���  �� TextAlignment$ Right=�$��14(�
�������$��Right=�$��0,6,6,0q�$	��170��$��26��$	��Top=�����  �� 	Converter# [  
 �� Now �� Source# Z �� $��4��$��	0,90,-1,0q�$	��Top=�  DefaultedBorderBrush#��[ �� -   $ imgLogo��$��-15,-15,0,0q�$��..\\Logo.png��$��UniformToFill=�$
��Left=�$	��233��$	��151��$	��Top=��� -     ��Name$  label1��$ .5Q�$��0,48,6,0q�$��30(�
�������$��46��$	��Top=�$��Right=�$	��191��$��Registration��$
��Bold"��� -   ! ��Name$! btnLogin��#��Z	 $��35��$��
0,0,140,28q�   Inspire.ButtonImage"   Image$#" ..\\Resources\Images\Ok16.png��$��Bottom=�# �� 	IsDefault# . $��Register��$��Right=�$	��134��$��1���� -   $! 	btnCancel��$��35��$��Right=�$��0,0,6,28q�$'" !..\\Resources\Images\Cancel16.png��$��Bottom=�$	��128��$��Cancel��$��1����   PopupBackgroundBrush#��[ $��22��$��Bottom=�$��1���� 
�������$��	0,0,-2,-4q�$��Right=�$	��132��$��23��$��Bottom=�$��1���� $�Inspire Digital Signage���� -   $��label3��$��Right=�$��
Last Name:��$��15(�
�������$��21��$
��Left=�$��
47,181,0,0q�$	��Top=�$	��158���� -	   $  label2��$��Right=�$��
47,142,0,0q�
�������$��15(�$��21��$	��Top=�$
��Left=�$	��158��$��First Name:���� -
   $��label4��$��Company Name:��$��15(�
�������$
��Left=�$��Right=�$��47,220,0,121q�$	��158���� -   $��label5��$
��Zip:��$��15(�
�������$��21��$
��Left=�$��Right=�$��
330,14,0,0q�$	��Top=�$��67��$��1���� -   $��label6��$��Registration Key:��$��15(�
�������$��21��$
��Left=�$��Right=�$��
25,148,0,0q�$	��Top=�$	��122��$��1���� -   $��label7��$��Phone:��$��15(�
�������$��21��$��Right=�$��47,92,421,0q�$	��Top=�$��1���� -   $��label8��$��Email:��$��15(�
�������$��21��$
��Left=�$��Right=�$��	47,53,0,0q�$	��Top=�$	��158��$��1���� -   $��label9��$��State:��$��15(�
�������$��21��$
��Left=�$��Right=�$��	47,14,0,0q�$	��Top=�$	��158��$��1���� -   $��label10��$��City:��$��15(�
�������$��21��$
��Left=�$��Right=�$��
47,337,0,0q�$	��Top=�$	��158���� -   $��label11��$��Address Line 2:��$��15(�
�������$��21��$
��Left=�$��Right=�$��
47,298,0,0q�$	��Top=�$	��158���� -   $��label12��$��Address Line 1:��$��15(�
�������$��21��$
��Left=�$��Right=�$��
47,259,0,0q�$	��Top=�$	��158��   Inspire.InfoTextBox  -   $��textBox1��$��23��$
��Left=�$��224,140,0,0q�$	��Top=�$	��331������ *	FirstName+$ �� Mode$$ TwoWay=�  -   $��textBox2��$��23��$
��Left=�$��224,179,0,0q�$	��Top=�$	��331������ *
LastName+$$ TwoWay=�  -   $��textBox3��$��23��$
��Left=�$��224,218,0,0q�$	��Top=�$	��331������ *CompanyName+$$ TwoWay=�  -   $��textBox4��$��23��$
��Left=�$��224,257,0,0q�$	��Top=�$	��331������ *AddressLine1+$$ TwoWay=�  -   $��textBox5��$��23��$
��Left=�$��224,296,0,0q�$	��Top=�$	��331������ *AddressLine2+$$ TwoWay=�  -   $��textBox6��$��23��$
��Left=�$��224,338,0,0q�$	��Top=�$	��331������ *City+$$ TwoWay=�  -   $��textBox7��$��23��$
��Left=�$��
403,15,0,0q�$	��Top=�$	��152��$��1������ *Zip+$$ TwoWay=�  -   $��textBox8��$��23��$
��Left=�$��
224,15,0,0q�$	��Top=�$	��100��$��1������ *State+$$ TwoWay=�  -   $��textBox9��$��23��$
��Left=�$��
224,51,0,0q�$	��Top=�$	��331��$��1������ *EmailAddress+$$ TwoWay=�  -   $��	textBox10��%   TextBoxInfo$% 
(optional)��$��23��$
��Left=�$��
224,93,0,0q�$	��Top=�$	��331��$��1������ *Phone+$$ TwoWay=��� -   $��	textBox11��$��23��$
��Left=�$��159,146,0,0q�$	��Top=�$	��396��$��1������ *RegistrationGuid+$$ TwoWay=�