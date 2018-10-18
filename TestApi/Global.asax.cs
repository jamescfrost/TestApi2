using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TestApi.Models;

namespace TestApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new Container();
            container.EnableHttpRequestMessageTracking(GlobalConfiguration.Configuration);
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IStringFormatter>(
                () => {
                    var msg = container.GetCurrentHttpRequestMessage();
                    IEnumerable<string> headerValues;
                    var append = "*";
                    if (msg != null && msg.Headers.TryGetValues("test", out headerValues))
                    {
                        append = headerValues?.FirstOrDefault() ?? "*";
                    }
                    return new CustomStringFormatter(append);
                }, Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

    }
}
