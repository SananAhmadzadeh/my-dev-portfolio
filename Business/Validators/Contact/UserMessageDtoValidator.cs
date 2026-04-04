using Entities.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Contact
{
    public class UserMessageDtoValidator : AbstractValidator<UserMessageDTO>
    {
        public UserMessageDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email format is invalid");

            RuleFor(x => x.Telephone)
                .NotEmpty().WithMessage("Telephone is required")
                .MaximumLength(20);

            RuleFor(x => x.Topic)
                .IsInEnum().WithMessage("Invalid topic");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required")
                .MaximumLength(1000);
        }
    }
}
