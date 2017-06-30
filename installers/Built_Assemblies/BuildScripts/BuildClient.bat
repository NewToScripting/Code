msbuild c:\Code\trunk\InspireClient\InspireClient.sln /t:Rebuild /p:Configuration=Release /t:Clean

mkdir "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\"

copy "C:\Code\trunk\InspireClient\Inspire.AnimationLibrary\obj\Release\Inspire.AnimationLibrary.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.AnimationLibrary.dll"
copy "C:\Code\trunk\InspireClient\Inspire\obj\Release\Inspire.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Client.ConfigurationWindow\obj\Release\Inspire.Client.ConfigurationWindow.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.ConfigurationWindow.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Client.Designer\obj\Release\Inspire.Client.Designer.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.Designer.dll"
copy "C:\Code\trunk\InspireClient\InspireClient\obj\Release\Inspire.Client.exe" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.exe"
copy "C:\Code\trunk\InspireClient\Inspire.Client.ScheduleWindow\obj\Release\Inspire.Client.ScheduleWindow.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.ScheduleWindow.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Common\obj\Release\Inspire.Common.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Common.dll"
copy "C:\Code\trunk\InspireClient\EffectLibrary\obj\Release\EffectLibrary.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\EffectLibrary.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Server.Proxy\obj\Release\Inspire.Server.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Server.Proxy.dll"
copy "C:\Code\trunk\InspireClient\Transitionals\obj\Release\Transitionals.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Transitionals.dll"


copy "C:\Code\trunk\InspireClient\Inspire.AnimationLibrary\obj\Release\Inspire.AnimationLibrary.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.AnimationLibrary.dll"
copy "C:\Code\trunk\InspireClient\Inspire\obj\Release\Inspire.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Client.ConfigurationWindow\obj\Release\Inspire.Client.ConfigurationWindow.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Client.ConfigurationWindow.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Client.Designer\obj\Release\Inspire.Client.Designer.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Client.Designer.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Common\obj\Release\Inspire.Common.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Common.dll"
copy "C:\Code\trunk\InspireClient\EffectLibrary\obj\Release\EffectLibrary.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\EffectLibrary.dll"
copy "C:\Code\trunk\InspireClient\Inspire.Server.Proxy\obj\Release\Inspire.Server.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Server.Proxy.dll"
copy "C:\Code\trunk\InspireClient\Transitionals\obj\Release\Transitionals.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Transitionals.dll"
copy "C:\Code\trunk\DesignModules\BubbleModule\obj\Release\BubbleModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\BubbleModule.dll"
copy "C:\Code\trunk\DesignModules\DateTimeModule\obj\Release\DateTimeModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\DateTimeModule.dll"
copy "C:\Code\trunk\DesignModules\EventEntry\obj\Release\EventEntry.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\EventEntry.dll"
copy "C:\Code\trunk\DesignModules\EventsModule\obj\Release\EventsModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\EventsModule.dll"
copy "C:\Code\trunk\DesignModules\EventsModule.Proxy\obj\Release\Inspire.Events.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Events.Proxy.dll"
copy "C:\Code\trunk\DesignModules\ImageModule\obj\Release\ImageModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ImageModule.dll"
copy "C:\Code\trunk\DesignModules\PlaylistModule\obj\Release\PlaylistModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\PlaylistModule.dll"
copy "C:\Code\trunk\DesignModules\QuickTimeModule\obj\Release\QuickTimeModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\QuickTimeModule.dll"
copy "C:\Code\trunk\DesignModules\RichTextModule\obj\Release\RichTextModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\RichTextModule.dll"
copy "C:\Code\trunk\DesignModules\RSSModule\obj\Release\RSSModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\RSSModule.dll"
copy "C:\Code\trunk\DesignModules\ScrollModule\obj\Release\ScrollModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ScrollModule.dll"
copy "C:\Code\trunk\DesignModules\VideoModule\obj\Release\VideoModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\VideoModule.dll"
copy "C:\Code\trunk\InspireClient\FilterModule\obj\Release\FilterModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\FilterModule.dll"
copy "C:\Code\trunk\InspireClient\FlightInfoModule\obj\Release\FlightInfoModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\FlightInfoModule.dll"
copy "C:\Code\trunk\InspireClient\FlightInfoModule.Proxy\obj\Release\FlightInfoModule.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\FlightInfoModule.Proxy.dll"
copy "C:\Code\trunk\InspireClient\MapModule\obj\Release\MapModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\MapModule.dll"
copy "C:\Code\trunk\InspireClient\ReflectionModule\obj\Release\ReflectionModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ReflectionModule.dll"
copy "C:\Code\trunk\InspireClient\ShapesModule\obj\Release\ShapesModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ShapesModule.dll"
copy "C:\Code\trunk\InspireClient\UserConfig\obj\Release\UserConfig.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\UserConfig.dll"
copy "C:\Code\trunk\InspireClient\WeatherModule\obj\Release\WeatherModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\WeatherModule.dll"
copy "C:\Code\trunk\InspireClient\WeatherModule.Proxy\obj\Release\WeatherModule.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\WeatherModule.Proxy.dll"

C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.AnimationLibrary.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.AnimationLibrary.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.dll" --nomethods --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.ConfigurationWindow.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.Client.ConfigurationWindow.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.Designer.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.Client.Designer.dll" --notypes --noproperties --nomethods --noevents --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.exe" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.Client.exe" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Client.ScheduleWindow.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.Client.ScheduleWindow.dll"
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Common.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.Common.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\EffectLibrary.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\EffectLibrary.dll" --nomethods --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Inspire.Server.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Inspire.Server.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Transitionals.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Transitionals.dll" --noildasm --nomsil --noinvalidopcodes

C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Client.ConfigurationWindow.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\Inspire.Client.ConfigurationWindow.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Client.Designer.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\Inspire.Client.Designer.dll" --nomethods --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\BubbleModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\BubbleModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\DateTimeModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\DateTimeModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\EventEntry.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\EventEntry.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\EventsModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\EventsModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\Inspire.Events.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\Inspire.Events.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ImageModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\ImageModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\PlaylistModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\PlaylistModule.dll" --nomethods --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\QuickTimeModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\QuickTimeModule.dll" --nomsil --noinvalidopcodes --noildasm
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\RichTextModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\RichTextModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\RSSModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\RSSModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ScrollModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\ScrollModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\VideoModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\VideoModule.dll" --noildasm --nomsil --noinvalidopcodes 
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\FilterModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\FilterModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\FlightInfoModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\FlightInfoModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\FlightInfoModule.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\FlightInfoModule.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\MapModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\MapModule.dll" --notypes --noproperties --nomethods --noevents --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ReflectionModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\ReflectionModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\ShapesModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\ShapesModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\UserConfig.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\UserConfig.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\WeatherModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\WeatherModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Client\Modules\WeatherModule.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Client\Modules\WeatherModule.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
