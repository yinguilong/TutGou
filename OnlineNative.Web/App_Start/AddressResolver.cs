using AutoMapper;
using OnlineNative.Domain.Model;
using OnlineNative.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineNative.Web.App_Start
{
    public class AddressResolver : ValueResolver<AddressDto, Address>
    {
        protected override Address ResolveCore(AddressDto source)
        {
            if (source == null) return new Address()
            {
                City = "未知",
                Country = "未知",
                State = "未知",
                Street = "未知",
                Zip = "未知"
            };
            return new Address
            {
                City = source.City,
                Country = source.Country,
                State = source.State,
                Street = source.Street,
                Zip = source.Zip
            };
        }
    }
}