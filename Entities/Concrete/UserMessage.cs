using Core.Entities.Abstract;
using Entities.Common;
using Entities.Enums.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserMessage : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public Topic Topic { get; set; }
        public string Message { get; set; }
    }
}
