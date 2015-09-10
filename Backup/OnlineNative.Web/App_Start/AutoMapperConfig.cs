using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineNative.Model.DTOs;
using OnlineNative.Domain;

namespace OnlineNative.Web
{
    public class AutoMapperConfig
    {
        public static void MapperDTO()
        {
            Mapper.CreateMap<NativeProduct, NativeProductDto>();
            Mapper.CreateMap<NativeProductDto, NativeProduct>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
        }
    }
}