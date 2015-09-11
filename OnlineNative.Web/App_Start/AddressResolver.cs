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