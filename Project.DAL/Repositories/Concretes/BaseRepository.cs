using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    //Artık .Net Core'de kullandıgımız Hybrid N-Tier Architecture'da BaseRepository class'ını Abstract olmayacak...Cünkü BaseRepository anlamlı veri modelleri olusturabilecek bir class'tır...

    /*
     * Senkron Metot (Add):

        Eğer veritabanına ekleme işlemi yapılırken uygulamanın diğer işlemleri beklemesi gerekiyorsa (örneğin, işlem sonucuna bağlı diğer adımlar varsa), senkron metodu kullanabilirsiniz.
        Bu metot, işlem tamamlanana kadar bekler ve iş parçacığı bloke olabilir. Bu, talep edilen işlemin tamamlanmasını beklerken potansiyel olarak performans sorunlarına yol açabilir, özellikle yüksek trafikli uygulamalarda.

        Asekron Metot (AddAsync):

        Eğer uygulamanın diğer işlemlerini bloke etmeden ekleme işleminin arka planda gerçekleşmesini istiyorsanız, AddAsync metodu daha uygun olabilir.
        Bu metot, asenkron olarak çalıştığı için iş parçacığı bloke olmaz ve uygulamanın diğer işlemlerini yürütmeye devam edebilir.
        Ancak, asenkron metotlar genellikle kodun daha karmaşık hale gelmesine neden olabilir ve hataların yönetimi daha dikkat gerektirir.
    */
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        protected void Save()
        {
            _db.SaveChanges();
        }
        // Veritabanına eklenme esnasında başka iş yapmaz o sebeple performans açısından yavaştır.(Senkron)
        // Bu metot, işlem tamamlanana kadar bekler ve iş parçacığı bloke olabilir. 
        public void Add(T item) 
        {
            _db.Set<T>().Add(item);
            Save();
        }

        // Veritabanına eklenme esnasında başka iş yapabilir o sebeple performans açısından daha iyidir.(Asenkron) Await işlemin arka planda bekletirken genel anlamda akışı bekletmez. 
        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _db.Set<T>().AddRangeAsync(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);

        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {

            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public async Task<List<T>> GetActivesAsync()
        {
            return await _db.Set<T>().Where(x=>x.Status != ENTITIES.Enums.DataStatus.Deleted).ToListAsync();

           
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetLastDatas(int count)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(count).ToList();

        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);

        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);

        }

        public async Task UpdateAsync(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            T originalEntity = await FindAsync(item.ID);
            _db.Entry(originalEntity).CurrentValues.SetValues(item);
            Save();
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            foreach (T item in list) await UpdateAsync(item);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        
    }
}
