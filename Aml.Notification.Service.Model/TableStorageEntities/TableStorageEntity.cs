using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aml.Notification.Service.Model.TableStorageEntities
{
    public class TableStorageEntity : TableEntity
    {
        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var results = base.WriteEntity(operationContext);

            // Serialize any properties with the [EntityEnumPropertyConverter] attribute.
            EntityEnumPropertyConverter.Serialize(this, results);

            return results;
        }

        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            base.ReadEntity(properties, operationContext);

            // Deserialize to any properties with the [EntityEnumPropertyConverter] attribute.
            EntityEnumPropertyConverter.Deserialize(this, properties);
        }
    }
}
