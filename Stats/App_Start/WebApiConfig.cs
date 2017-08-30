﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Stats
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


           config.Routes.MapHttpRoute(
                name: "GameEvent",
                routeTemplate: "api/game/{id}/events",
                defaults: new { controller="game",action="createEvent" }
            );


        }
    }
}
