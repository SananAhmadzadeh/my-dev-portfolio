using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.BlogDTOs;
using Entities.DTOs.GroupDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class GroupManager : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public GroupManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddGroupAsync(CreateGroupDto createGroupDto)
        {
            var group = _mapper.Map<Group>(createGroupDto);
            await _unitOfWork.EfGroupRepository.AddAsync(group);
            var result = await _unitOfWork.SaveAsync();
            if (result==0)
            {
                return new ErrorResult("elave edilmedi");
            }
            return new SuccessResult("elave edildi");
        }

        public Task<IResult> DeleteGroupAsync(Guid id)
        {
            var group =  _unitOfWork.EfGroupRepository.GetAsync(g => g.Id == id).Result;
            if (group==null)
            {
                return Task.FromResult<IResult>(new ErrorResult("melumat tapilmadi"));
            }
            _unitOfWork.EfGroupRepository.Delete(group);
            var result =  _unitOfWork.SaveAsync().Result;
            if (result==0)
            {
                return Task.FromResult<IResult>(new ErrorResult("melumat silinmedi"));
            }
            return Task.FromResult<IResult>(new SuccessResult("melumat silindi"));
        }

        public async Task<IDataResult<List<GetAllGroupsDto>>> GetAllGroupsAsync()
        {
            var groups = await _unitOfWork.EfGroupRepository
                 .GetAllAsync(null, "Course", "Teacher", "Teacher.AppUser");
            if (groups.Count==0)
            {
                return new ErrorDataResult<List<GetAllGroupsDto>>("melumat tapilmadi");
            }
            var mappedGroup = _mapper.Map<List<GetAllGroupsDto>>(groups);
            return new SuccessDataResult<List<GetAllGroupsDto>>((mappedGroup),"melumatlar getirildi");
        }

        public Task<IDataResult<GetGroupDto>> GetGroupById(Guid id)
        {
            var group=  _unitOfWork.EfGroupRepository.GetAsync(g => g.Id == id).Result;
            if(group==null)
            {
                return Task.FromResult<IDataResult<GetGroupDto>>(new ErrorDataResult<GetGroupDto>("melumat tapilmadi"));
            }
            var mappedGroup = _mapper.Map<GetGroupDto>(group);
            return Task.FromResult<IDataResult<GetGroupDto>>(new SuccessDataResult<GetGroupDto>(mappedGroup,"melumat getirildi"));
        }

        public async Task<IResult> UpdateGroupAsync(Guid id, UpdateGroupDto GroupDto)
        {
            var group =  await _unitOfWork.EfGroupRepository.GetAsync(g => g.Id == id);
            if (group == null)
            {
                return new ErrorResult("melumat tapilmadi");
            }
           var updated= _mapper.Map(GroupDto, group);
            _unitOfWork.EfGroupRepository.Update(updated);
            var result = await  _unitOfWork.SaveAsync();
            if (result==0)
            {
                return new ErrorResult("melumat yenilenemedi");
            }
            return new SuccessResult("melumat yenilendi") ;
        }
    }
}
