using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineNative.Model.DTOs;
using OnlineNative.Domain.Model;
using OnlineNative.Web.App_Start;
using OnlineNative.Model.Enum;
using OnlineNative.Web.WebBase;

namespace OnlineNative.Web
{
    public class AutoMapperConfig
    {
        public static void MapperDTO()
        {
            Mapper.CreateMap<AddressDto, Address>();
            Mapper.CreateMap<UserDto, User>()
                .ForMember(uMermber => uMermber.ContactAddress, mceUto => mceUto.ResolveUsing<AddressResolver>().FromMember(fm => fm.ContactAddress))
                .ForMember(uMember => uMember.DeliveryAddress, mceUto =>
                        mceUto.ResolveUsing<AddressResolver>().FromMember(fm => fm.DeliveryAddress))
                        .ForMember(uMember => uMember.Password, mceUto =>
                        mceUto.ResolveUsing<PassWordResolver>().FromMember(fm => fm.Password));

            Mapper.CreateMap<User, UserDto>()
               .ForMember(udoMember => udoMember.ContactAddress, mceU =>
                   mceU.ResolveUsing<InversedAddressResolver>().FromMember(fm => fm.ContactAddress))
                   .ForMember(udoMember => udoMember.DeliveryAddress, mceU =>
                       mceU.ResolveUsing<InversedAddressResolver>().FromMember(fm => fm.DeliveryAddress))
                       .ForMember(udoMember => udoMember.Password, mceu => mceu.ResolveUsing<InversedPassWordResolver>().FromMember(fm => fm.Password))
                       ;

            Mapper.CreateMap<NativeProduct, ProductDto>();
            Mapper.CreateMap<ProductDto, NativeProduct>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
            Mapper.CreateMap<ShoppingCart, ShoppingCartDto>();
            Mapper.CreateMap<ShoppingCartDto, ShoppingCart>();
            Mapper.CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
            Mapper.CreateMap<ShoppingCartItemDto, ShoppingCartItem>();
            Mapper.CreateMap<OrderItem, OrderItemDto>();
            Mapper.CreateMap<OrderItemDto, OrderItem>();
            Mapper.CreateMap<Order, OrderDto>()
                //.ForMember(odtoMember => odtoMember.Subtotal,
                //    mceO => mceO.ResolveUsing(
                //        o => o.OrderItems.Sum(item => item.ItemAmout)))
                .ForMember(odtoMember => odtoMember.UserContact,
                    mceO => mceO.ResolveUsing(o => o.User.Contact))
                .ForMember(odtoMember => odtoMember.UserPhone,
                    mceO => mceO.ResolveUsing(o => o.User.PhoneNumber))
                .ForMember(odtoMember => odtoMember.UserEmail,
                    mceO => mceO.ResolveUsing(o => o.User.Email))
                .ForMember(odtoMember => odtoMember.UserId,
                    mceO => mceO.ResolveUsing(o => o.User.Id))
                .ForMember(odtoMember => odtoMember.UserName,
                    mceO => mceO.ResolveUsing(o => o.User.UserName))
                .ForMember(odtoMember => odtoMember.UserAddressCountry,
                    mceO => mceO.ResolveUsing(o => o.User.DeliveryAddress.Country))
                .ForMember(odtoMember => odtoMember.UserAddressState,
                    mceO => mceO.ResolveUsing(o => o.User.DeliveryAddress.State))
                .ForMember(odtoMember => odtoMember.UserAddressCity,
                    mceO => mceO.ResolveUsing(o => o.User.DeliveryAddress.City))
                .ForMember(odtoMember => odtoMember.UserAddressStreet,
                    mceO => mceO.ResolveUsing(o => o.User.DeliveryAddress.Street))
                .ForMember(odtoMember => odtoMember.UserAddressZip,
                    mceO => mceO.ResolveUsing(o => o.User.DeliveryAddress.Zip));
            Mapper.CreateMap<OrderDto, Order>();
            Mapper.CreateMap<ProductCategorization, ProductCategorizationDto>();
            Mapper.CreateMap<ProductCategorizationDto, ProductCategorization>();
            Mapper.CreateMap<Role, RoleDto>();
            Mapper.CreateMap<RoleDto, Role>();
        }
    }
}