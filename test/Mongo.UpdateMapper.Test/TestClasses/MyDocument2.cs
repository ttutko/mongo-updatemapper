using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.UpdateMapper.Test
{
    public class MyDocument2
    {
        public string Field1 {get;set;}
        [BsonElement("NewFieldName")]
        public string Field2 {get;set;}
        public string Field3 {get;set;}
    }
}