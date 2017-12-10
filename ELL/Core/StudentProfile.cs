using AutoMapper;
using ELL.Models;
using ELL.ViewModels.Payments;
using ELL.ViewModels.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELL.Core
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentVM>()
                .ForMember(vm => vm.ContactName, 
                           m => m.MapFrom(s => s.EmergencyContact.FirstName + " " + s.EmergencyContact.LastName)
                          );
            CreateMap<Student, CreateStudentVM>().ReverseMap();
        }
    }
}