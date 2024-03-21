using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T : IEntity
    {
        //List Command

        List<T> GetAll();
        List<T> GetActives();

        //Todo: GetActivesAsync
        Task<List<T>> GetActivesAsync();
        List<T> GetPassives();
        List<T> GetModifieds();

        //Modify Commands
        void Add(T item);
        Task AddAsync(T item);
        Task AddRangeAsync(List<T> list);
        void AddRange(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);

        //Linq Commands
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);

        object Select(Expression<Func<T, object>> exp); //Anonymus Type'a mapping'e destek vermek icin kullanabilecegimiz bir Select metodudur...
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp); //Generic tip'e göre işlem yapmasını istedigimizi Select metodu...

        //Find Command

        //Todo: x01 params

        Task<T> FindAsync(int id);

        List<T> GetLastDatas(int count);
        List<T> GetFirstDatas(int count);


        //Expression tipi 

        // x => x.CategoryName == "asdad"
        
    }
}
