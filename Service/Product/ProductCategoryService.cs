using AutoMapper;
using Domain.Entities.Product;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Product;
using Domain.Interface.Service.Product;
using Domain.Model.Product;

namespace Service.Product
{
    public class ProductCategoryService : IProductCategoryService
    {
        public readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<ProductCategoryResponse> Create(ProductCategoryRequest request)
        {
            try
            {
                var profile = _mapper.Map<ProductCategory>(request);
                await _repository.Create(profile);

                _uow.Commit();
                return _mapper.Map<ProductCategoryResponse>(profile);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return null;
            }
        }

        public async Task Delete(Guid uuid)
        {
            try
            {
                await _repository.Delete(uuid);
                _uow.Commit();
            }
            catch
            {
                _uow.Rollback();
            }
        }

        public async Task<IEnumerable<ProductCategoryResponse>> Get()
        {
            return _mapper.Map<IEnumerable<ProductCategoryResponse>>(await _repository.Get());
        }

        public async Task<ProductCategoryResponse> Get(Guid uuid)
        {
            return _mapper.Map<ProductCategoryResponse>(await _repository.Get(uuid));
        }

        public async Task<ProductCategoryResponse> Update(Guid uuid, ProductCategoryRequest request)
        {
            try
            {
                var profile = await _repository.Get(uuid);

                profile.Name = request.Name;
                profile.Description = request.Description;
                profile.Status = request.Status;

                await _repository.Update(profile);
                _uow.Commit();

                return _mapper.Map<ProductCategoryResponse>(profile);
            }
            catch
            {
                _uow.Rollback();
                return null;
            }
        }
    }
}
