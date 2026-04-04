using Core.Utilities.Result.Abstract;
using Entities.DTOs.GroupDTOs;
using Entities.DTOs.Recommendations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IGroupService
    {
        public Task<IDataResult<List<GetAllGroupsDto>>> GetAllGroupsAsync();

        public Task<IDataResult<GetGroupDto>> GetGroupById(Guid id);

        public Task<IResult> AddGroupAsync(CreateGroupDto createGroupDto);

        public Task<IResult> DeleteGroupAsync(Guid id);

        public Task<IResult> UpdateGroupAsync(Guid id, UpdateGroupDto GroupDto);
    }
}
