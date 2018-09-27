using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Models;
using Models.SearchCriteria;
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

                config.CreateMap<Organization, OrganizationEntryVm>();
                config.CreateMap<OrganizationEntryVm, Organization>();

                config.CreateMap<BatchEntryVm, Batch>();
                config.CreateMap<Batch, BatchEntryVm>();

                config.CreateMap<TrainerEntryVm, Trainer>();
                config.CreateMap<Trainer, TrainerEntryVm>();

                config.CreateMap<ParticipantEntryVm, Participant>();
                config.CreateMap<Participant, ParticipantEntryVm>();


            });
        }
    }
}
