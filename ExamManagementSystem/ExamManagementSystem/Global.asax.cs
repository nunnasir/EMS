using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Models;
using Models.ViewModels;

namespace ExamManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigAutoMapper();
        }

        private void ConfigAutoMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CourseEntryVm, Course>();
                config.CreateMap<Course, CourseEntryVm>();
            });
        }
    }
}
