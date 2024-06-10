using AutoMapper;
using BackEnd.Models.Material;
using BackEnd.Models.PrintingPress;
using BackEnd.Models.Users;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<CreateMaterialModel, Material>();

            CreateMap<UpdateUserModel, User>();
            CreateMap<AddUserModel, User>();
            CreateMap<CreatePrintingPressModel, PrintingPress>();
        }
    }
}
