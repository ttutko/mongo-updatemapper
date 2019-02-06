using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mongo.UpdateMapper.Test
{
    public class UpdateMapperTests
    {
        [Fact]
        public void CreateUpdateReturnsUpdateDefinition()
        {
            MyDocumentUpdate update = new MyDocumentUpdate() { Field1 = "updated", Field2 = "updated", Field3 = "updated"};

            var updateFilter = UpdateMapper.CreateUpdate<MyDocument, MyDocumentUpdate>(update);

            Assert.IsAssignableFrom(typeof(MongoDB.Driver.UpdateDefinition<MyDocument>), updateFilter);
        }

        [Fact]
        public void CreateUpdateReturnsUpdateForAllFields()
        {
            MyDocumentUpdate update = new MyDocumentUpdate() { Field1 = "updated", Field2 = "updated", Field3 = "updated"};

            var updateFilter = UpdateMapper.CreateUpdate<MyDocument, MyDocumentUpdate>(update);

            var bson = updateFilter.Render(BsonSerializer.LookupSerializer<MyDocument>(), BsonSerializer.SerializerRegistry);
            var json = JObject.Parse(bson.ToJson());
            
            var expected = new JObject() {
                {"$set", new JObject {
                        {"Field1", "updated"},
                        {"Field2", "updated"},
                        {"Field3", "updated"}
                    }
                }
            };

            Assert.True(JToken.DeepEquals(json, expected));
        }
    }
}