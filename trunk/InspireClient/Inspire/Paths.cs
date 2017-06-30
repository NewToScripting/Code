using System;
using System.IO;
using System.Security.AccessControl;

namespace Inspire
{
    public class Paths
    {
        private const string CLIENT_LOCAL_SLIDE_PACKAGE_PATH = @"INSPIREDisplays\LocalSlides\Packages\";

        private const string CLIENT_OFFLINE_SLIDE_FILE = @"OfflineSlides.isf";

        private const string CLIENT_LOCAL_SLIDE_IMAGES_PATH = @"INSPIREDisplays\LocalSlides\Images\";

        private const string CLIENT_LOCAL_SLIDES_PATH = @"INSPIREDisplays\LocalSlides\";

        private const string CLIENT_TEMP_PATH = @"INSPIREDisplays\Temp\";

        private const string CLIENT_SAVE_PATH = @"INSPIRE\";

        private const string CLIENT_TEMPLATE_TEMP_PATH = @"INSPIREDisplays\TemplateTemp\";

        private const string CLIENT_TRANSFER_PATH = @"INSPIREDisplays\Transfer\";

        private const string CLIENT_SCHEDULE_PLAYBACK_PATH = @"INSPIREDisplays\PlaybackTemp\";

        private const string CLIENT_MODULE_PATH = @"Modules\";

        /// <summary>
        /// Base directory where the service should store files transferred from the server
        /// </summary>
        private const string PLAYER_SERVICE_DIRECTORY = @"Temp\";
        // offset from base for files in SERVER_CONTENT_SLIDEDIRECTORY and subdirectories
        private const string PLAYER_SLIDE_DIRECTORY = @"Slides\";
        // contains default Slide for the Player Application
        private const string PLAYER_DEFAULT_SLIDE_DIRECTORY = @"DefaultSlide\";

        private const string defaultPlayerBase = @"C:\InspireTest\";

        public static string PlayerBaseDirectory
        {
            get
            {
                if (Directory.Exists(ApplicationDirectory))
                {
                    return ApplicationDirectory;
                }
                DirectoryInfo di = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
                return di.Parent.FullName;
            }
        }

        public static string PlayerAppBaseDirectory
        {
            get
            {
                return PlayerBaseDirectory;
            }
        }

        public static string PlayerServiceBaseDirectory
        {
            get
            {
                return Path.Combine(PlayerBaseDirectory, PLAYER_SERVICE_DIRECTORY);
            }
        }

        public static string PlayerScheduleDirectory
        {
            get
            {
                return Path.Combine(PlayerAppBaseDirectory, PLAYER_SLIDE_DIRECTORY);
            }
        }


        public static string PlayerSlideDirectory
        {
            get
            {
                return Path.Combine(PlayerAppBaseDirectory, PLAYER_SLIDE_DIRECTORY);
            }
        }

        public static string PlayerDefaultSlideDirectory
        {
            get
            {
                return Path.Combine(PlayerAppBaseDirectory, PLAYER_DEFAULT_SLIDE_DIRECTORY);
            }
        }

        public static string SaveDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_SAVE_PATH);
            }
        }

        public static string BaseDirectory
        {
            get
            {
                return Path.GetTempPath();
            }
        }

        public static string ApplicationDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static string ClientLocalSlidesDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_LOCAL_SLIDES_PATH);
            }
        }

        public static string ClientLocalSlidesFile
        {
            get
            {
                return Path.Combine(ClientLocalSlidesDirectory, CLIENT_OFFLINE_SLIDE_FILE);
            }
        }

        public static string ClientLocalSlidePackagesDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_LOCAL_SLIDE_PACKAGE_PATH);
            }
        }

        public static string ClientLocalSlideImagesDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_LOCAL_SLIDE_IMAGES_PATH);
            }
        }

        public static string ClientTempDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_TEMP_PATH);
            }
        }

        public static string ClientTemplateTempDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_TEMPLATE_TEMP_PATH);
            }
        }

        public static string ClientPlaybackTempDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_SCHEDULE_PLAYBACK_PATH);
            }
        }

        public static string ClientTransferDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, CLIENT_TRANSFER_PATH);
            }
        }

        public static string ClientModulesDirectory
        {
            get
            {
                return Path.Combine(ApplicationDirectory, CLIENT_MODULE_PATH);
            }
        }

        public static void CreateDirectories()
        {
            try
            {
                // make sure all the app directories exist
                if (!Directory.Exists(ClientTempDirectory))
                {
                    Directory.CreateDirectory(ClientTempDirectory);
                    Directory.CreateDirectory(ClientTempDirectory, new DirectorySecurity(ClientTempDirectory, AccessControlSections.Owner));
                }

                if (!Directory.Exists(ClientLocalSlidesDirectory))
                {
                    Directory.CreateDirectory(ClientLocalSlidesDirectory);
                    Directory.CreateDirectory(ClientLocalSlidesDirectory, new DirectorySecurity(ClientLocalSlidesDirectory, AccessControlSections.Owner));
                }

                if (!Directory.Exists(ClientLocalSlidePackagesDirectory))
                {
                    Directory.CreateDirectory(ClientLocalSlidePackagesDirectory);
                    Directory.CreateDirectory(ClientLocalSlidePackagesDirectory, new DirectorySecurity(ClientLocalSlidePackagesDirectory, AccessControlSections.Owner));
                }

                if (!Directory.Exists(ClientLocalSlideImagesDirectory))
                {
                    Directory.CreateDirectory(ClientLocalSlideImagesDirectory);
                    Directory.CreateDirectory(ClientLocalSlideImagesDirectory, new DirectorySecurity(ClientLocalSlideImagesDirectory, AccessControlSections.Owner));
                }

                if (!Directory.Exists(ClientTransferDirectory))
                {
                    Directory.CreateDirectory(ClientTransferDirectory);
                    Directory.CreateDirectory(ClientTransferDirectory, new DirectorySecurity(ClientTransferDirectory, AccessControlSections.Owner));
                }

                if (!Directory.Exists(ClientTemplateTempDirectory))
                {
                    Directory.CreateDirectory(ClientTemplateTempDirectory);
                    Directory.CreateDirectory(ClientTemplateTempDirectory, new DirectorySecurity(ClientTemplateTempDirectory, AccessControlSections.Owner));
                }

                if (!Directory.Exists(ClientPlaybackTempDirectory))
                {
                    Directory.CreateDirectory(ClientPlaybackTempDirectory);
                    Directory.CreateDirectory(ClientPlaybackTempDirectory, new DirectorySecurity(ClientPlaybackTempDirectory, AccessControlSections.Owner));
                }

                if (!Directory.Exists(SaveDirectory))
                {
                    Directory.CreateDirectory(SaveDirectory);
                    Directory.CreateDirectory(SaveDirectory, new DirectorySecurity(SaveDirectory, AccessControlSections.Owner));
                }

            }
            catch (Exception)
            {
                ;
            }
        }

        public static string FindFirstLayerFolderPath(string path)
        {
            var dirInfo = new DirectoryInfo(path);

            if(dirInfo.Exists)
            {
                if (dirInfo.GetDirectories().Length > 0)
                    return dirInfo.GetDirectories()[0].ToString();
            }
            return null;
        }
    }
}
