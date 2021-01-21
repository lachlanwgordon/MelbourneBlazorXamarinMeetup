using System;
namespace MelbourneBlazorXamarin.Core.Services
{
    public static class Settings
    {
#if DEBUG
        //string BaseUrl = "https://witty-smoke-0230db31e.azurestaticapps.net";
        public const string BaseUrl = "http://localhost:7071";
#else
        public const string BaseUrl = "https://witty-smoke-0230db31e.azurestaticapps.net";
#endif
    }
}
