using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Services
{
    class NavigationService
    {
        private static NavigationService singleton = null;
        public static NavigationService GetNavigationService()
        {
            return singleton ??= new NavigationService();
        }
    }
}
