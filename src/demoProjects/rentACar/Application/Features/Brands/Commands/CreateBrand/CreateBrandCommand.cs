using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        public string Name  { get; set; }


        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly BrandBusinessRules _rules;
            private readonly IBrandRepository _repository;
            private readonly IMapper _mapper;
            public CreateBrandCommandHandler(IBrandRepository repository,IMapper mapper, BrandBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;

            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                //business rules will be here
                await _rules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);



                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand createdBrand = await _repository.AddAsync(mappedBrand);
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);
                
                return createdBrandDto;

            }


        }



    }
}
