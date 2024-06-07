﻿using AutoMapper;
using ChineseOction.Migrations;
using ChineseOction.Models.DTO;

namespace ChineseOction.Models
{
    public class DIProfile : Profile
    {
        public DIProfile()
        {
            CreateMap<DonorDto, Donor>().ReverseMap();
            CreateMap<UpdateDonorDto, Donor>().ReverseMap();
            CreateMap<GiftDto, Gift>();
            CreateMap<UpdateGiftDto, Gift>();




        }
    }
}
