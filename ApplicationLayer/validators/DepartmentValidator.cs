using ApplicationLayer.dto;
using FluentValidation;
using System;

namespace ApplicationLayer.validators
{
    public class DepartmentValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentValidator()
        {
            RuleFor(department => department.Id).NotNull().NotEqual(Guid.Empty);
            RuleFor(department => department.Title).NotNull().NotEmpty();
        }
    }
}
