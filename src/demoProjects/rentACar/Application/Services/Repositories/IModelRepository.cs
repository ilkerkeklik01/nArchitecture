using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Features.Repositories;

public interface IModelRepository:IAsyncRepository<Model>,IRepository<Model>
{
    
}