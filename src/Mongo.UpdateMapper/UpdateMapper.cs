using MongoDB.Driver;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Mongo.UpdateMapper
{
    public class UpdateMapper
    {
        public static MongoDB.Driver.UpdateDefinition<TDest> CreateUpdate<TDest,TSource>(TSource update)
        {
            List<UpdateDefinition<TDest>> updateDefinitions = new List<UpdateDefinition<TDest>>();
            var destProperties = typeof(TDest).GetProperties().ToList();
            foreach(var srcProp in typeof(TSource).GetProperties())
            {
                var matchingProperty = destProperties.Where(p => p.Name == srcProp.Name).SingleOrDefault();
                if(matchingProperty != null)
                {
                    var value = srcProp.GetValue(update);
                    if(value == null)
                    {
                        continue;
                    }
                    var curUpdate = Builders<TDest>.Update.Set(matchingProperty.Name, value);
                    updateDefinitions.Add(curUpdate);
                }
            }

            return Builders<TDest>.Update.Combine(updateDefinitions);
        }
    }
}