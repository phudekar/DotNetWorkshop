using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Practices.Unity;

namespace ToDoList.Common.Container
{
    public class UnityControllerFactory : IControllerFactory
    {
        private IUnityContainer container;

        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public  IController CreateController
            (RequestContext requestContext, string controllerName)
        {
            controllerName += "Controller";
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            var controllerTypes = from t in currentAssembly.GetTypes()
                                  where t.Name.Contains(controllerName)
                                  select t;

            if (controllerTypes.Count() > 0)
            {
                return container.Resolve(controllerTypes.First(), controllerName) as IController;
            }
            return null;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }


        public  void ReleaseController(IController controller)
        {
            controller = null;
        }

    }
}
