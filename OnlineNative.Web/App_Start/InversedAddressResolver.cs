using AutoMapper;
using OnlineNative.Domain.Model;
using OnlineNative.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineNative.Web.App_Start
{
    public class InversedAddressResolver : ValueResolver<Address, AddressDto>
    {
        protected override AddressDto ResolveCore(Address source)
        {
            return new AddressDto
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