   M S B A M L   `   `   `  ����B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire  5      H DWeatherModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WeatherModule.CommandsWeatherModule.Commands 5          WeatherModule.ModuleDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :Inspire&clr-namespace:Inspire;assembly=Inspire     5      9Commands$clr-namespace:WeatherModule.Commands     5        � Title$  ModuleDialog��5       � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6?   $	��338��6U   $	��344��6b      	TextBrush#���   6n     WindowBackgroundBrush#���  6�    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        ,  &WeatherModule.Commands.WeatherCommands   InsertWeatherCommand   Command# Z 5      6}    � 	Resources 5
        searchResults��%   &	       S� 5   
   6   5      .��5      � .+�5   
   �� $��22��6   $
��Left=�6   $��7,26,0,0q�67   $	��Top=�6I   $��96��6a   .��6l   Zip or location:6~   �� 5   
   $��32��6   $
��Left=�6   $	��Top=�67   $��64��6O   $��	38,54,0,0q�6Z   .��6m   	Location:6x      Inspire.InfoTextBox  5   
   -   5        $��
tbLocation��5   U      TextBoxInfo$ Enter Zip / Location��6   $��
98,20,16,0q�6A   $��28��6�   $	��Top=�6�   �� 5   
   -   5        $��resultsListBox��5   &   $��
98,54,16,0q�6    �� SelectedIndex$ 0��6<   #���   6N   $��87��6�   $	��Top=�6�   ��6�   �� 	 �� Source#	 [ ��5      �� 5      .�5      �� 
 �� Property
 � �� �� Value 6?   ��  �� Path$ FullName�5      5      �� 5   
   -   5        $��cbWeatherResource��5   D   $��98,147,16,0q�6/   $��28��6]   $	��Top=�6i   $ 2��6�    �� Text 6   �� $ Value���5      �� 5      .R�5      �� #���   6    ��6I   �� $ Value�5      5      �� 5   
   $
��Left=�6   $��27,149,0,117q�6+   $��76��6A   .��6L   Days/Style:6Y   �� 5    
   -   5        $��btnOk��5    S      Inspire.ButtonImage   Image$ Resources\Images\Ok16.png��6   $��35��6G   #��Z 6`   $��Bottom=�6�   $��
0,0,146,12q�6�   $��Right=�6�   $	��128��6�   .��6�   Ok6�   �� 5!   
   -   5        $��	btnCancel��5!   s   $# Resources\Images\Cancel16.png��6   $��35��6K   $��Right=�6W   $��Bottom=�6�   $	��128��6�   $��	0,0,12,12q�6�   .��6�   Cancel6�   �� 5"   
   #���   6   $��Degree Type��6<   $��60��6Q   $��
98,0,16,53q�6]   $��Bottom=�6q   .��5#      � .+�5$      	� -   5        $	��rbF��5$   C   #���   6    d� 	IsChecked$
 TrueY�6N    	� 	GroupName$ DegType��6_   $
��Left=�6s   $��6,6,0,0q�6�   $	��132��6�   $��25.04��6�   $	��Top=�6�   .��6�   
Fahrenheit6�   	� 5%      -   5        $	��rbC��5%   C   #���   6   $	��0,6q�6N   $ DegType��6[   $��Right=�6o   $	��101��6�   .��6�   	Celsius6�   5&      5'      5(      5)      