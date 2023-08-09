using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {

        public CreateBrandCommandValidator() { 
            RuleFor(x=> x.Name).NotNull();
            RuleFor(x=>x.Name).MinimumLength(2).NotEmpty();
        }


    }
}
