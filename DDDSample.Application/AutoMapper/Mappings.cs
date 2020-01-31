using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.AutoMapper
{
    public class Mappings
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }
    }
}
