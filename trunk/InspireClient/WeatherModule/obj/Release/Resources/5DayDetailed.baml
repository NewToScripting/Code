   M S B A M L   `   `   `  ���� H  DWeatherModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WeatherModuleWeatherModule  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType"    WeatherModule.WeatherControl �� Orientation �� Mode �� Path�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     -WeatherModuleclr-namespace:WeatherModule  %�  (��       *,  +)�� "    .R�(� .���� $ Vertical=�.+��� $��10q�$ Vertical=�.+��� 
�������$��5,0,0,0q�$��22(�$
��Bold"�$��Today��� $	��Top=�$��135.5��$	��500��.+��� $
��Left=�$��18,19,0,36.5q�$��80������ *WeatherReport.BackgroundImage+$ OneWay=��� $��117,14.5,0,0q�$ 
Horizontal=�$	��Top=�$
��Left=�.+��� 
�������$	��Top=�$��65(����� */-WeatherReport.LatestWeather.TemperatureString+$ OneWay=��� 
�������$��19(�$
��Bold"�$��	20,0,0,11q�$��Bottom=�$��26.543��$
��Left=����� *75WeatherReport.LatestWeather.SkyCondition.SkyCondition+$ OneWay=��� $ 
Horizontal=�$��	0,10,20,0q�$��Right=�.+��� $��Right=�$��0,0,8,0q�$	��Top=�.+��� 
�������$��18(�$��High:���� 
�������$��18(�$
��Low:���� 
�������$��18(�$��	Humidity:���� 
�������$��18(�$��Wind:���� $ Vertical=�.+��� 
�������$
��Bold"�$��18(����� $5 /WeatherReport.Forecast[0].HighTemperatureString��� 
�������$
��Bold"�$��18(����� $4 .WeatherReport.Forecast[0].LowTemperatureString��� $ 
Horizontal=�.+��� 
�������$
��Bold"�$��18(����� $* $WeatherReport.LatestWeather.Humidity��� 
�������$
��Bold"�$��17(�$��%���� $ 
Horizontal=�.+��� 
�������$
��Bold"�$��18(����� $2 ,WeatherReport.LatestWeather.WindVector.Speed��� 
�������$
��Bold"�$��18(����� $6 0WeatherReport.LatestWeather.WindVector.Direction��� $��0,0,64,8q�
�������$��18(�$��Bottom=�$��19.543��$��Chance of Rain:��$��Right=�$	��160���� $ 
Horizontal=�$��Right=�$��Bottom=�$��73.987��$��24.543��$��	0,0,2,4.5q�.+��� $
��Bold"�
�������$��20(����� $- 'WeatherReport.Forecast[0].Precipitation��� $
��Bold"�
�������$��18(�$��%���� $��10q�$ Vertical=�.+��� 
�������$��5,0,0,0q�$��22(�$
��Bold"����� $3 -WeatherReport.Forecast[1].StartTime.DayOfWeek�� $	��Top=�$��135.5��$	��500��.+��� $
��Left=�$��18,19,0,36.5q�$��80������ $ 	Day1Image�$ OneWay=��� $��117,14.5,0,0q�$ 
Horizontal=�$	��Top=�$
��Left=�.+��� 
�������$	��Top=�$��65(����� *1/WeatherReport.Forecast[1].HighTemperatureString+$ OneWay=��� 
�������$��19(�$
��Bold"�$��	20,0,0,11q�$��Bottom=�$��26.543��$
��Left=����� *53WeatherReport.Forecast[1].SkyCondition.SkyCondition+$ OneWay=��� $ 
Horizontal=�$��	0,10,20,0q�$��Right=�.+��� $��Right=�$��0,0,8,0q�$	��Top=�.+��� 
�������$��18(�$��High:���� 
�������$��18(�$
��Low:���� $ Vertical=�.+��� 
�������$
��Bold"�$��18(����� $5 /WeatherReport.Forecast[1].HighTemperatureString��� 
�������$
��Bold"�$��18(����� $4 .WeatherReport.Forecast[1].LowTemperatureString��� $��0,0,64,8q�
�������$��18(�$��Bottom=�$��19.543��$��Chance of Rain:��$��Right=�$	��160���� $ 
Horizontal=�$��Right=�$��Bottom=�$��73.987��$��24.543��$��	0,0,2,4.5q�.+��� $
��Bold"�
�������$��20(����� $- 'WeatherReport.Forecast[1].Precipitation��� $
��Bold"�
�������$��18(�$��%���� $��10q�$ Vertical=�.+��� 
�������$��5,0,0,0q�$��22(�$
��Bold"����� $3 -WeatherReport.Forecast[2].StartTime.DayOfWeek�� $	��Top=�$��135.5��$	��500��.+��� $
��Left=�$��18,19,0,36.5q�$��80������ $ 	Day2Image�$ OneWay=��� $��117,14.5,0,0q�$ 
Horizontal=�$	��Top=�$
��Left=�.+��� 
�������$	��Top=�$��65(����� *1/WeatherReport.Forecast[2].HighTemperatureString+$ OneWay=��� 
�������$��19(�$
��Bold"�$��	20,0,0,11q�$��Bottom=�$��26.543��$
��Left=����� *53WeatherReport.Forecast[2].SkyCondition.SkyCondition+$ OneWay=��� $ 
Horizontal=�$��	0,10,20,0q�$��Right=�.+��� $��Right=�$��0,0,8,0q�$	��Top=�.+��� 
�������$��18(�$��High:���� 
�������$��18(�$
��Low:���� $ Vertical=�.+��� 
�������$
��Bold"�$��18(����� $5 /WeatherReport.Forecast[2].HighTemperatureString��� 
�������$
��Bold"�$��18(����� $4 .WeatherReport.Forecast[2].LowTemperatureString��� $��0,0,64,8q�
�������$��18(�$��Bottom=�$��19.543��$��Chance of Rain:��$��Right=�$	��160���� $ 
Horizontal=�$��Right=�$��Bottom=�$��73.987��$��24.543��$��	0,0,2,4.5q�.+��� $
��Bold"�
�������$��20(����� $- 'WeatherReport.Forecast[2].Precipitation��� $
��Bold"�
�������$��18(�$��%���� $��10q�$ Vertical=�.+��� 
�������$��5,0,0,0q�$��22(�$
��Bold"����� $3 -WeatherReport.Forecast[3].StartTime.DayOfWeek�� $	��Top=�$��135.5��$	��500��.+��� $
��Left=�$��18,19,0,36.5q�$��80������ $ 	Day3Image�$ OneWay=��� $��117,14.5,0,0q�$ 
Horizontal=�$	��Top=�$
��Left=�.+��� 
�������$	��Top=�$��65(����� *1/WeatherReport.Forecast[3].HighTemperatureString+$ OneWay=��� 
�������$��19(�$
��Bold"�$��	20,0,0,11q�$��Bottom=�$��26.543��$
��Left=����� *53WeatherReport.Forecast[3].SkyCondition.SkyCondition+$ OneWay=��� $ 
Horizontal=�$��	0,10,20,0q�$��Right=�.+��� $��Right=�$��0,0,8,0q�$	��Top=�.+��� 
�������$��18(�$��High:���� 
�������$��18(�$
��Low:���� $ Vertical=�.+��� 
�������$
��Bold"�$��18(����� $5 /WeatherReport.Forecast[3].HighTemperatureString��� 
�������$
��Bold"�$��18(����� $4 .WeatherReport.Forecast[3].LowTemperatureString��� $��0,0,64,8q�
�������$��18(�$��Bottom=�$��19.543��$��Chance of Rain:��$��Right=�$	��160���� $ 
Horizontal=�$��Right=�$��Bottom=�$��73.987��$��24.543��$��	0,0,2,4.5q�.+��� $
��Bold"�
�������$��20(����� $- 'WeatherReport.Forecast[3].Precipitation��� $
��Bold"�
�������$��18(�$��%���� $��10q�$ Vertical=�.+��� 
�������$��5,0,0,0q�$��22(�$
��Bold"����� $3 -WeatherReport.Forecast[4].StartTime.DayOfWeek�� $	��Top=�$��135.5��$	��500��.+��� $
��Left=�$��18,19,0,36.5q�$��80������ $ 	Day4Image�$ OneWay=��� $��117,14.5,0,0q�$ 
Horizontal=�$	��Top=�$
��Left=�.+��� 
�������$	��Top=�$��65(����� *1/WeatherReport.Forecast[4].HighTemperatureString+$ OneWay=��� 
�������$��19(�$
��Bold"�$��	20,0,0,11q�$��Bottom=�$��26.543��$
��Left=����� *53WeatherReport.Forecast[4].SkyCondition.SkyCondition+$ OneWay=��� $ 
Horizontal=�$��	0,10,20,0q�$��Right=�.+��� $��Right=�$��0,0,8,0q�$	��Top=�.+��� 
�������$��18(�$��High:���� 
�������$��18(�$
��Low:���� $ Vertical=�.+��� 
�������$
��Bold"�$��18(����� $5 /WeatherReport.Forecast[4].HighTemperatureString��� 
�������$
��Bold"�$��18(����� $4 .WeatherReport.Forecast[4].LowTemperatureString��� $��0,0,64,8q�
�������$��18(�$��Bottom=�$��19.543��$��Chance of Rain:��$��Right=�$	��160���� $ 
Horizontal=�$��Right=�$��Bottom=�$��73.987��$��24.543��$��	0,0,2,4.5q�.+��� $
��Bold"�
�������$��20(����� $- 'WeatherReport.Forecast[4].Precipitation��� $
��Bold"�
�������$��18(�$��%��