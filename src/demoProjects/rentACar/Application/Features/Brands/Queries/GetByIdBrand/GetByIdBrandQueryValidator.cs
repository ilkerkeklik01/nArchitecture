using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQueryValidator: AbstractValidator<GetByIdBrandQuery>
    {

        public GetByIdBrandQueryValidator()
        {
            RuleFor(x => x.Id).Must(ValidateId);
        }

        private bool ValidateId(int id)
        {
            if (id>0)
            {
                return true;
            }
            return false;
        }

    }
}
