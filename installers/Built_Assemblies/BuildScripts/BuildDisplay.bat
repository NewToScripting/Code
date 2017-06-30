msbuild "C:\Code\trunk\DisplayApp\DisplayApp.sln" /t:Rebuild /p:Configuration=Release /t:Clean


copy "C:\Code\trunk\DisplayApp\Service\Inspire.Display.Service\bin\Release\Inspire.Display.Service.exe" "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Display.Service.exe"
copy "C:\Code\trunk\InspireWatchDog\Inspire.WatchDog.Interface\bin\Release\Inspire.WatchDog.Interface.exe" "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.WatchDog.Interface.exe"

copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\InspireDisplay.exe" "C:\Code\installers\Built_Assemblies\PreObf\Display\InspireDisplay.exe"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\BubbleModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\BubbleModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\DateTimeModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\DateTimeModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\EffectLibrary.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\EffectLibrary.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\EventEntry.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\EventEntry.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\EventsModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\EventsModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\Inspire.Events.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Events.Proxy.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\FilterModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\FilterModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\FlightInfoModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\FlightInfoModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\FlightInfoModule.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\FlightInfoModule.Proxy.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\ImageModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\ImageModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\Inspire.AnimationLibrary.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.AnimationLibrary.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\Inspire.Common.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Common.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\Inspire.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\Inspire.Server.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Server.Proxy.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\MapModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\MapModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\PlaylistModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\PlaylistModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\QuickTimeModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\QuickTimeModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\ReflectionModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\ReflectionModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\RichTextModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\RichTextModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\RSSModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\RSSModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\ScrollModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\ScrollModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\ShapesModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\ShapesModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\SpinningLogo.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\SpinningLogo.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\Transitionals.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\Transitionals.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\VideoModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\VideoModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\WeatherModule.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\WeatherModule.dll"
copy "C:\Code\trunk\DisplayApp\InspireDisplay\bin\Release\WeatherModule.Proxy.dll" "C:\Code\installers\Built_Assemblies\PreObf\Display\WeatherModule.Proxy.dll"

C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Display.Service.exe" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Inspire.Display.Service.exe" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.WatchDog.Interface.exe" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Inspire.WatchDog.Interface.exe" --noildasm --nomsil --noinvalidopcodes

C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\InspireDisplay.exe" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\InspireDisplay.exe" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\BubbleModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\BubbleModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\DateTimeModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\DateTimeModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\EffectLibrary.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\EffectLibrary.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\EventEntry.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\EventEntry.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\EventsModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\EventsModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Events.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Inspire.Events.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\FilterModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\FilterModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\FlightInfoModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\FlightInfoModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\FlightInfoModule.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\FlightInfoModule.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\ImageModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\ImageModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.AnimationLibrary.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Inspire.AnimationLibrary.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Common.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Inspire.Common.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Inspire.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Inspire.Server.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Inspire.Server.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\MapModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\MapModule.dll" --notypes --noproperties --nomethods --noevents --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\PlaylistModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\PlaylistModule.dll" --nomethods --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\QuickTimeModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\QuickTimeModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\ReflectionModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\ReflectionModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\RichTextModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\RichTextModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\RSSModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\RSSModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\ScrollModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\ScrollModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\ShapesModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\ShapesModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\SpinningLogo.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\SpinningLogo.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\Transitionals.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\Transitionals.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\VideoModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\VideoModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\WeatherModule.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\WeatherModule.dll" --noildasm --nomsil --noinvalidopcodes
C:\Code\installers\Built_Assemblies\babel.exe "C:\Code\installers\Built_Assemblies\PreObf\Display\WeatherModule.Proxy.dll" --output "C:\Code\installers\Built_Assemblies\Obfuscated\Display\WeatherModule.Proxy.dll" --noildasm --nomsil --noinvalidopcodes
