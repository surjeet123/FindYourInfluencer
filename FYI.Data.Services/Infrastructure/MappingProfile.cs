using AutoMapper;
using FYI.Business.Models;
using FYI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Services.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Customer, CustomerRegisterModel>().ReverseMap();
            CreateMap<Influencer, InfluencerModel>().ReverseMap();
            CreateMap<Influencer, InfluencerRegisterModel>().ReverseMap();
        }
    }
}
