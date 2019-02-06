using MongoDB.Driver;

namespace Mongo.UpdateMapper
{
    public class UpdateMapper
    {
        public static MongoDB.Driver.UpdateDefinition<TDest> CreateUpdate<TDest,TSource>(TSource update)
        {
            return Builders<TDest>.Update.Set("property", "value");
        }
    }
}