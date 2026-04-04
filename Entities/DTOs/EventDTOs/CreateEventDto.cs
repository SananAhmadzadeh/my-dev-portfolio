using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.Events
{
    public class CreateEventDto : IDto
    {
        public bool IsFree { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
    }
}
