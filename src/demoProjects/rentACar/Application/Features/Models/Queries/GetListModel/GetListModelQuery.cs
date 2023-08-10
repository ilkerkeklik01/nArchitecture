using Application.Features.Brands.Models;
using Application.Features.Models.Models;
using Application.Features.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModel;

    public class GetListModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }


        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery,ModelListModel>
        {
            private readonly IMapper _mapper;
            private readonly IModelRepository _repository;

            public GetListModelQueryHandler(IMapper mapper, IModelRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Model> models= await _repository.GetListAsync(include:
                                                                        m=>m.Include(c=>c.Brand),
                                                                        index:request.PageRequest.Page,size:request.PageRequest.PageSize
                                                                        );
            //include kısmını vermezsem brandname ler  ull geliyor
                ModelListModel result = _mapper.Map<ModelListModel>(models);

                return result;
            }


        }



    }