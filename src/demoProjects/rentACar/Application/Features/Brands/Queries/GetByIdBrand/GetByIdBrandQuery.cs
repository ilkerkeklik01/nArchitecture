using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery: IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }


        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {

            private readonly IBrandRepository _repository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _rules;
            public GetByIdBrandQueryHandler(IBrandRepository repository,IMapper mapper,BrandBusinessRules rules)   
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand? returnedBrand = await _repository.GetAsync(x => x.Id == request.Id) ;
                _rules.BrandMustExistsWhenRequested(returnedBrand);


                BrandGetByIdDto result = _mapper.Map<BrandGetByIdDto>(returnedBrand);
                
                return result;

            }


        }

    }
}
