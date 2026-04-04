using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.TeacherDTOs
{
    public class GetTeacherDto : IDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Desc { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
    }
}
