//using Entities.DTOs.TeacherDTOs;
//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Business.Validators.Teachers
//{
//    public class UpdateTeacherDTOValidator: AbstractValidator<UpdateTeacherDto>
//    {
//        public UpdateTeacherDTOValidator()
//        {
//            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
//               .NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
//            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required")
//               .NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Surname size can be maximum 100");
//            RuleFor(x => x.Desc).NotEmpty().WithMessage("Descrption is required")
//                .NotNull().WithMessage("Can not be empty").MaximumLength(500).WithMessage("Description size can be maximum 500");
//            RuleFor(x => x.Position).NotEmpty().WithMessage("Position is required")
//                .NotNull().WithMessage("Can not be empty").MaximumLength(500).WithMessage("Position size can be maximum 500");
//            //RuleFor(t => t.ImageFile)
//            //    .NotNull().WithMessage("An image file is required")
//            //    .Must(file => file != null &&
//            //                  (file.ContentType == "image/jpeg" ||
//            //                   file.ContentType == "image/png" ||
//            //                   file.ContentType == "image/jpg"))
//            //    .WithMessage("Only JPG and PNG format images are accepted.")
//            //    .Must(file => file != null && file.Length <= 2 * 1024 * 1024)
//            //    .WithMessage("Image size can be a maximum of 2MB.");
//        }
//    }
//}
