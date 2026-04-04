//using DataAccess.Repositories.Abstract;
//using Entities.DTOs.StudentDTOs;
//using FluentValidation;

//namespace Business.Validators.Students;
//using FluentValidation;

//public class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto>
//{
//    public UpdateStudentDtoValidator()
//    {
//        RuleFor(x => x.FirstName)
//            .NotEmpty()
//            .When(x => x.FirstName != null)
//            .MinimumLength(2)
//            .MaximumLength(50)
//            .Matches(@"^[a-zA-ZəöüçıİƏÖÜÇ\s'-]+$")
//            .When(x => !string.IsNullOrWhiteSpace(x.FirstName))
//            .WithMessage("First name is invalid.");

//        RuleFor(x => x.LastName)
//            .NotEmpty()
//            .When(x => x.LastName != null)
//            .MinimumLength(2)
//            .MaximumLength(50)
//            .Matches(@"^[a-zA-ZəöüçıİƏÖÜÇ\s'-]+$")
//            .When(x => !string.IsNullOrWhiteSpace(x.LastName))
//            .WithMessage("Last name is invalid.");

//        RuleFor(x => x.Email)
//            .NotEmpty()
//            .When(x => x.Email != null)
//            .EmailAddress()
//            .MaximumLength(100)
//            .When(x => !string.IsNullOrWhiteSpace(x.Email))
//            // .MustAsync(async (dto, email, ct) =>
//            //     string.IsNullOrWhiteSpace(email) ||
//            //     !await studentRepository.IsEmailTakenAsync(email, dto.Id, ct))
//            .WithMessage("Email is already in use.");

//        RuleFor(x => x.PhoneNumber)
//            .Matches(@"^\+?[0-9]{7,15}$")
//            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
//            .WithMessage("Phone number format is invalid.");

//        RuleFor(x => x.Address)
//            .MaximumLength(250)
//            .When(x => !string.IsNullOrWhiteSpace(x.Address));

//    }
//}