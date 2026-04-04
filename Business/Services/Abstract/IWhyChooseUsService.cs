using Core.Utilities.Result.Abstract;
using Entities.DTOs.HomePageDTOs.WhyChooseUsSection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IWhyChooseUsService
    {
        Task<IDataResult<List<WhyChooseUsItemDto>>> GetItemsAsync();
    }
}
