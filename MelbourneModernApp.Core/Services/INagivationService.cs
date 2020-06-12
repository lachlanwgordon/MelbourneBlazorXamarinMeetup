using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MelbourneModernApp.Core.Services
{
    public interface INavigationService
    {
        Task NavigateToPageAsync(string url);
        Task NavigateToPageAsync(string url, string parameterKey, string parameterValue);
    }
}
