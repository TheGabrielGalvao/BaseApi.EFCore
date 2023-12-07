using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactEntity>> Get();
        Task<ContactEntity> Get(Guid uuid);

        Task<ContactEntity> Create(ContactEntity Contact);

        Task<ContactEntity> Update(ContactEntity Contact);

        Task Delete(Guid uuid);
    }
}
