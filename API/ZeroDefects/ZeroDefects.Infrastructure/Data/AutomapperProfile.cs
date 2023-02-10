using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Infrastructure.Data
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Instructions, InstructionsDto>().ReverseMap();
        }
    }
}
