﻿using back_app_sr_Application.Item.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Item.Query.GetItemById;

public class GetItemByIdQuery : IRequest<ItemResponseViewModel>
{
    [JsonProperty("item_id")]
    public int ItemId { get; set; }
}