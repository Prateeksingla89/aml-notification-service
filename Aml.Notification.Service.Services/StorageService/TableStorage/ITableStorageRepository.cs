using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.StorageService.TableStorage
{
    public interface ITableStorageRepository
    {
        Task<object> AddAsync(string tableName, ITableEntity entity);

        Task<T> GetAsync<T>(string tableName, string partitionKey, string rowKey) where T : class, ITableEntity;

        Task<List<T>> GetAllAsync<T>(string tableName) where T : class, ITableEntity, new();

        Task<IQueryable<T>> FindAsync<T>(string tableName, Expression<Func<T, bool>> expression) where T : class, ITableEntity, new();

        Task<object> UpdateAsync<T>(string tableName, T entity) where T : class, ITableEntity;

        Task<object> DeleteAsync(string tableName, ITableEntity entity);
    }
}
