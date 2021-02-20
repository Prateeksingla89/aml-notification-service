using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.StorageService.TableStorage
{
    public interface ITableStorageService
    {
        public Task<object> AddAsync(string tableName, ITableEntity entity);

        public Task<T> GetAsync<T>(string tableName, string partitionKey, string rowKey) where T : class, ITableEntity;

        public Task<object> DeleteAsync(string tableName, ITableEntity entity);
        public Task<object> UpdateAsync<T>(string tableName, T entity) where T : class, ITableEntity;

    }

    public class TableStorageService : ITableStorageService
    {
        private readonly ITableStorageRepository tableStorageRepository;

        public TableStorageService(ITableStorageRepository tableStorageRepository)
        {
            this.tableStorageRepository = tableStorageRepository;
        }

        public async Task<object> AddAsync(string tableName, ITableEntity entity)
        {
            return await tableStorageRepository.AddAsync(tableName, entity);
        }

        public async Task<T> GetAsync<T>(string tableName, string partitionKey, string rowKey) where T : class, ITableEntity
        {
            return await tableStorageRepository.GetAsync<T>(tableName, partitionKey, rowKey);
        }

        public async Task<object> DeleteAsync(string tableName, ITableEntity entity)
        {
            return await tableStorageRepository.DeleteAsync(tableName, entity);
        }

        public async Task<object> UpdateAsync<T>(string tableName, T entity) where T : class, ITableEntity
        {
            return await tableStorageRepository.UpdateAsync(tableName, entity);
        }

    }
}
