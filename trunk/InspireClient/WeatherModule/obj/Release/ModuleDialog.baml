   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  H DWeatherModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WeatherModule.CommandsWeatherModule.Commands     WeatherModule.ModuleDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     9Commands$clr-namespace:WeatherModule.Commands       � Title$  ModuleDialog�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�$	��338��$	��344��   	TextBrush#���     WindowBackgroundBrush#���   J� CommandBindings )  #System.Windows.Input.CommandBinding  -   ,  &WeatherModule.Commands.WeatherCommands   InsertWeatherCommand   Command# Z  � 	Resources   searchResults��%   &	       S� .��� .+��� $��22��$
��Left=�$��7,26,0,0q�$	��Top=�$��96��.��Zip or location:�� $��32��$
��Left=�$	��Top=�$��64��$��	38,54,0,0q�.��	Location:   Inspire.InfoTextBox  -   $��
tbLocation��   TextBoxInfo$ Enter Zip / Location��$��
98,20,16,0q�$��28��$	��Top=��� -   $��resultsListBox��$��
98,54,16,0q� �� SelectedIndex$ 0��#���   $��87��$	��Top=����� 	 �� Source#	 [ ���� .��� 
 �� Property
 � �� �� Value ��  �� Path$ FullName��� -   $��cbWeatherResource��$��98,147,16,0q�$��28��$	��Top=�$ 2�� �� Text �� $ Value����� .R��� #���   ���� $ Value��� $
��Left=�$��27,149,0,117q�$��76��.��Days/Style:�� -   $��btnOk��   Inspire.ButtonImage   Image$ Resources\Images\Ok16.png��$��35��#��Z $��Bottom=�$��
0,0,146,12q�$��Right=�$	��128��.��Ok�� -   $��	btnCancel��$# Resources\Images\Cancel16.png��$��35��$��Right=�$��Bottom=�$	��128��$��	0,0,12,12q�.��Cancel�� #���   $��Degree Type��$��60��$��
98,0,16,53q�$��Bottom=�.��� .+�	� -   $	��rbF��#���    d� 	IsChecked$
 TrueY� 	� 	GroupName$ DegType��$
��Left=�$��6,6,0,0q�$	��132��$��25.04��$	��Top=�.��
Fahrenheit	� -   $	��rbC��#���   $	��0,6q�$ DegType��$��Right=�$	��101��.��	Celsius