using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ToDoListMVCWebApp
{
    public class UnityConfig
    {
        #region UnityContainer

        private static IUnityContainer _container;


        /// <summary>
        /// The Unity container for the current application
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }

        public static void InitContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
            }

            // Register the relevant types for the 
            // container here through classes or configuration
            UnityConfigurationSection section = LoadUnitySection() as UnityConfigurationSection;
            section.Containers.Default.Configure(_container);
        }

        private static object LoadUnitySection()
        {
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
                return WebConfigurationManager.GetSection("unity");
            return ConfigurationManager.GetSection("unity");
        }

        public static void CleanUp()
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

        #endregion
    }
}