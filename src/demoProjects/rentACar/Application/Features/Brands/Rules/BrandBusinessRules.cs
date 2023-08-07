using Application.Features.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {

        private readonly IBrandRepository _repository;

        public BrandBusinessRules(IBrandRepository repository)
        {
            this._repository = repository;
        }


        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _repository.GetListAsync(b=>b.Name == name);
            if(result.Items.Any()) {
                throw new BusinessException("Brand name exists");
                    
                    };
        }


    }
}
