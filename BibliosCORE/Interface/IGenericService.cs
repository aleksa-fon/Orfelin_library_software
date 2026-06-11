using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orfelin.Core.Interface
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetAllById(int id);
        Task AddASync(T entity);
        Task UpdateASync(T entity);
        Task DeleteASync(int id);

    }
}
