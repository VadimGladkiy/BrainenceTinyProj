using Brainence2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Brainence2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Brainence2.Utilits.MyDIContainer.BindDependency( typeof(Repositories.IRepository<Entity>),
                new Repositories.SentencesRepository());
        }
    }
}
