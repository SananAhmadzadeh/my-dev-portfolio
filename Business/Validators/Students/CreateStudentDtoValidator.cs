
//using Entities.DTOs.StudentDTOs;
//using FluentValidation;

//namespace Business.Validators.Students;

//public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
//{
//    public CreateStudentDtoValidator()
//    {
//        RuleFor(x => x.FirstName)
//            .NotEmpty().WithMessage("First name is required.")
//            .MinimumLength(2).WithMessage("First name must be at least 2 characters.")
//            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.")
//            .Matches(@"^[a-zA-ZəöüçıİƏÖÜÇ\s'-]+$")
//            .WithMessage("First name contains invalid characters.");

//        RuleFor(x => x.LastName)
//            .NotEmpty().WithMessage("Last name is required.")
//            .MinimumLength(2).WithMessage("Last name must be at least 2 characters.")
//            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.")
//            .Matches(@"^[a-zA-ZəöüçıİƏÖÜÇ\s'-]+$")
//            .WithMessage("Last name contains invalid characters.");

//        RuleFor(x => x.Email)
//            .NotEmpty().WithMessage("Email is required.")
//            .EmailAddress().WithMessage("Email format is invalid.")
//            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

//        RuleFor(x => x.PhoneNumber)
//            .Matches(@"^\+?[0-9]{7,15}$")
//            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
//            .WithMessage("Phone number format is invalid.");

//        RuleFor(x => x.Address)
//            .MaximumLength(250)
//            .When(x => !string.IsNullOrWhiteSpace(x.Address))
//            .WithMessage("Address must not exceed 250 characters.");
    
//    }
//}
