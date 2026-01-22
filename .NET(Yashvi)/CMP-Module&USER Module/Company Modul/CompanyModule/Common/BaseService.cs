using AutoMapper;
using CompanyModule.Common.Responses;
using CompanyModule.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompanyModule.Common
{
    public abstract class BaseService<TRequest, TResponse, TEntity>
        where TEntity : class
        where TRequest : class
        where TResponse : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected BaseService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<ServiceResponse<bool>> Insert(TEntity entity)
        {
            var result = await _repository.Insert(entity);
            return ServiceResponse<bool>.SuccessResponse(result != null);
        }

        public virtual async Task<ServiceResponse<bool>> Update(TEntity entity)
        {
            var result = await _repository.Update(entity);
            return ServiceResponse<bool>.SuccessResponse(result != null);
        }

        public virtual async Task<ServiceResponse<bool>> Update(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            var result = await _repository.Update(entity);
            return ServiceResponse<bool>.SuccessResponse(result != null);
        }

        public virtual async Task<ServiceResponse<bool>> Update(List<TRequest> requests)
        {
            var entities = _mapper.Map<List<TEntity>>(requests);
            foreach (var entity in entities)
            {
                await _repository.Update(entity);
            }
            return ServiceResponse<bool>.SuccessResponse(true);
        }

        public virtual async Task<ServiceResponse<bool>> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            return ServiceResponse<bool>.SuccessResponse(result);
        }

        public virtual async Task<ServiceResponse<TResponse>> GetById(Guid id)
        {
            var entity = await _repository.GetById(id);
            var response = _mapper.Map<TResponse>(entity);
            return ServiceResponse<TResponse>.SuccessResponse(response);
        }

        public virtual async Task<ServiceResponse<IList<TResponse>>> GetAll()
        {
            var entities = await _repository.GetAll().ToListAsync();
            var responses = _mapper.Map<IList<TResponse>>(entities);
            return ServiceResponse<IList<TResponse>>.SuccessResponse(responses);
        }

        public virtual async Task<ServiceResponse<IList<TResponse>>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _repository.Get(predicate).ToListAsync();
            var responses = _mapper.Map<IList<TResponse>>(entities);
            return ServiceResponse<IList<TResponse>>.SuccessResponse(responses);
        }

        public virtual async Task<ServiceResponse<IList<TResponse>>> GetAllddlData(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _repository.Get(predicate).ToListAsync();
            var responses = _mapper.Map<IList<TResponse>>(entities);
            return ServiceResponse<IList<TResponse>>.SuccessResponse(responses);
        }

        public virtual Task<ServiceResponse<PaginationResult<IList<TResponse>>>> GetPaginated(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}