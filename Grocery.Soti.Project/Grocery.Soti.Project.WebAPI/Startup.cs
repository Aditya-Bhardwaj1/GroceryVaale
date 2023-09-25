using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Services.Description;

[assembly: OwinStartup(typeof(Grocery.Soti.Project.WebAPI.Startup))]

namespace Grocery.Soti.Project.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
