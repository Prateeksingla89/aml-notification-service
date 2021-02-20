using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aml.Notification.Service.Model.TableStorageEntities
{
    /// <summary>
    /// Allows enums to be stored as text values in TableStorage.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityEnumPropertyConverterAttribute : Attribute
    {
        public EntityEnumPropertyConverterAttribute()
        {
        }
    }

    /// <summary>
    /// Custom attribute [EntityEnumPropertyConverter] to allow enum text values to be stored in TableStorage.
    /// </summary>
    public class EntityEnumPropertyConverter
    {
        public static void Serialize<TEntity>(TEntity entity, IDictionary<string, EntityProperty> results)
        {
            entity.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(EntityEnumPropertyConverterAttribute), false).Any())
                .ToList()
                .ForEach(x => results.Add(x.Name, new EntityProperty(x.GetValue(entity)?.ToString())));
        }

        public static void Deserialize<TEntity>(TEntity entity, IDictionary<string, EntityProperty> properties)
        {
            entity.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(EntityEnumPropertyConverterAttribute), false).Any())
                .ToList()
                .ForEach(x => x.SetValue(entity, Enum.Parse(x.PropertyType, properties[x.Name].StringValue)));
        }
    }
}
