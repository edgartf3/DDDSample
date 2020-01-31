﻿using AutoMapper;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RamoAtividade, RamoAtividadeViewModel>().ReverseMap();
        }
    }
}