using Core.Utilities.Result.Abstract;
using Entities.DTOs.AboutDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IAboutService
    {
        //public Task<IDataResult<List<GetAllAboutDTO>>> GetAllAboutsAsync(string languageCode);
        public Task<IDataResult<List<GetAllAboutDTO>>> GetAllAboutsAsync();
        public Task<IDataResult<GetAboutDTO>> GetAboutByIdAsync(Guid id);
        public Task<IResult> AddAboutAsync(CreateAboutDTO createAboutDTO);
        public Task<IResult> DeleteAboutAsync(Guid aboutId);
        public Task<IResult> UpdateAboutAsync(Guid id, UpdateAboutDTO updateAboutDTO);
    }
}
