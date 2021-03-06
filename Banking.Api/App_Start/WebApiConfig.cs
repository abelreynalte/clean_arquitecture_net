﻿using Banking.Api.Controllers;
using Banking.Domain.Entity;
using Banking.Domain.Repository;
using Banking.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;
using System.Web.UI;

namespace Banking.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            /*
            var container = new UnityContainer();
            container.RegisterType<IBankAccountRepository, BankAccountEFRepository>();            
            config.DependencyResolver = new UnityResolver(container);
            */

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler()); //json web token
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }


    }
}
