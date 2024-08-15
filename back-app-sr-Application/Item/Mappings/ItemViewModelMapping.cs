﻿using AutoMapper;
using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Items;

namespace back_app_sr_Application.Item.Mappings;

public class ItemViewModelMapping : Profile
{
    public ItemViewModelMapping()
    {
        CreateMap<ItemModel, ItemViewModel>()
            .ForMember(dest => dest.ItemId,
                opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
    }
}