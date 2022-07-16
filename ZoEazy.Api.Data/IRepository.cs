using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZoEazy.Api.Model;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Data
{
    public interface IRepository
    {
        Task<ZipCode> ZipCodeById(string code);
    }
    public interface IAdminRepository<T> where T : class, IId
    {
        IEnumerable<T> GetAll();
        Task<T> Get(long id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
       // void InsertRange(List<T> entity);
       // void UpdateRange(List<T> entity);
        void Delete(T entity);
    }
   
    public interface IBranchRepository : IAdminRepository<Branch>
    {
        Task<Branch> UpdateGeo(Branch entity);
    }
}

