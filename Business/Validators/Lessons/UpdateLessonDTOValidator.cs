using Entities.DTOs.LessonDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Lessons
{
    public class UpdateLessonDTOValidator: AbstractValidator<UpdateLessonDTO>
    {
        public UpdateLessonDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3).WithMessage("Lesson name must be at least 3 characters.")
                .MaximumLength(100).WithMessage("Lesson name cannot exceed 100 characters.");

            RuleFor(x => x.CourseId)
                .NotEmpty()
                .NotNull();
                


        }
    }
}
