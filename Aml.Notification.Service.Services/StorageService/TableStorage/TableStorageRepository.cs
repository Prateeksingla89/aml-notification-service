using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.StorageService.TableStorage
{
    public class TableStorageRepository : ITableStorageRepository
    {
        private readonly CloudTableClient client;

        public TableStorageRepository(ICloudStorageAccountFacade accountParameter)
        {
            ICloudStorageAccountFacade account = accountParameter ?? throw new ArgumentNullException(nameof(account));
            client = account.CreateCloudTableClient();
        }

        public async Task<object> AddAsync(string tableName, ITableEntity entity)
        {
                if (string.IsNullOrEmpty(tableName))
                    throw new ArgumentNullException(nameof(tableName));
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                var table = await GetTable(tableName).ConfigureAwait(false);
                var result = await table.ExecuteAsync(TableOperation.Insert(entity)).ConfigureAwait(false);
                return result.Result;
        }

        private async Task<CloudTable> GetTable(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));
            var table = client.GetTableReference(tableName);
            await table.CreateIfNotExistsAsync().ConfigureAwait(false);
            return table;
        }

        public async Task<T> GetAsync<T>(string tableName, string partitionKey, string rowKey) where T : class, ITableEntity
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));
            if (string.IsNullOrEmpty(partitionKey))
                throw new ArgumentNullException(nameof(partitionKey));
            if (rowKey == null)
                throw new ArgumentNullException(nameof(rowKey));
            var table = await GetTable(tableName).ConfigureAwait(false);
            var result = await table.ExecuteAsync(TableOperation.Retrieve<T>(partitionKey, rowKey)).ConfigureAwait(false);
            return result.Result as T;
        }

        public async Task<List<T>> GetAllAsync<T>(string tableName) where T : class, ITableEntity, new()
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));

            var table = await GetTable(tableName).ConfigureAwait(false);

            TableContinuationToken token = null;
            var entities = new List<T>();
            do
            {
                var queryResult = await table.ExecuteQuerySegmentedAsync(new TableQuery<T>(), token)
                                             .ConfigureAwait(false);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);

            return entities;
        }

        public async Task<IQueryable<T>> FindAsync<T>(string tableName, Expression<Func<T, bool>> expression)
            where T : class, ITableEntity, new()
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            var table = await GetTable(tableName).ConfigureAwait(false);
            return table.CreateQuery<T>().AsQueryable().Where(expression);
        }

        public async Task<object> UpdateAsync<T>(string tableName, T entity) where T : class, ITableEntity
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));

            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var replaceOperation = TableOperation.Replace(entity);
            var table = await GetTable(tableName).ConfigureAwait(false);
            var result = await table.ExecuteAsync(replaceOperation).ConfigureAwait(false);
            return result;

        }

        public async Task<object> DeleteAsync(string tableName, ITableEntity entity)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var table = await GetTable(tableName).ConfigureAwait(false);
            var result = await table.ExecuteAsync(TableOperation.Delete(entity)).ConfigureAwait(false);
            return result.Result;
        }
    }
}
