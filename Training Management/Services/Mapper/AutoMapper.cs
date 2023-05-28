﻿using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Training_Management.Dtos;
using Training_Management.Models;
using Training_Management.ViewModels;
using TrainingManagement.Dtos;
using TrainingManagement.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shawrney.infrastructure.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //user
            CreateMap<ApplicationUser, UserViewModel>().ForMember(x => x.Phone, x => x.MapFrom(x => x.PhoneNumber));
            CreateMap<CreateApplicationUserDto, ApplicationUser>() ;
            CreateMap<UpdateApplicationUserDto, ApplicationUser>().ReverseMap();

			//advisor
			CreateMap<Advisor, AdvisorViewModel>();
			CreateMap<CreateAdviserDto, Advisor>();
			CreateMap<UpdateAdviserDto, Advisor>().ReverseMap();
			
			//trainee
			CreateMap<Trainee, TraineeViewModel>();
			CreateMap<CreateTraineeDto, Trainee>();
			CreateMap<UpdateTraineeDto, Trainee>().ReverseMap();

            //trainee
            CreateMap<Manager, ManagerViewModel>();
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<UpdateManagerDto, Manager>().ReverseMap();
        }
    }
}
