using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Inspire.MediaObjects;

namespace Inspire.Interfaces
{
    public interface IMediaModule
    {
        DesignContentControl Execute(double canvasWidth, double canvasHeight);
        DesignContentControl EditControl(DesignContentControl designContentControl);
        string CreatePlayerControl(DesignContentControl designContentControl, string guid);
        //DesignContentControl GetPlayerControl(DesignContentControl designContentControl);
        DesignContentControl CreateClientControl(DesignContentControl designContentControl);
        DesignContentControl CreateContentControl(string mediaFilePath);
        void PlayControl(DesignContentControl designContentControl, string filePath, string displayGuid);
        void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid);
        void Dispose(DesignContentControl designContentControl);
        MediaType GetModuleType();
        string GetModuleName();
        List<string> GetSupportedFileTypes();
        UserControl GetPropertyPanel();
        bool GetIsPanelModule();
        IEnumerable<string> GetRules(DesignContentControl designContentControl);
        bool GetIsApp();
    }
}
