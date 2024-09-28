using Filippov_Georgy_KT_31_21.Entities;
using Filippov_Georgy_KT_31_21.Filters.Models;

namespace Filippov_Georgy_KT_31_21.Services.Interfaces {
    public interface IService<EntityT> where EntityT: IEntity {
        public Task<IEnumerable<EntityT>> GetAsync(FilterModel<EntityT> filter, CancellationToken cancellationToken);
        public Task UpdateAsync(EntityT entity, CancellationToken cancellationToken);
        public Task CreateAsync(EntityT entity, CancellationToken cancellationToken);
        public Task DeleteAsync(EntityT entity, CancellationToken cancellationToken);
    }
}