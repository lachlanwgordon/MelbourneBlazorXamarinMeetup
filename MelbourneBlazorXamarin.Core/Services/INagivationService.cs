using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MelbourneBlazorXamarin.Core.Services
{
    public interface INavigationService
    {
        Task NavigateToPageAsync(string url);
        Task NavigateToPageAsync(string url, string parameterKey, string parameterValue);
    }
}
