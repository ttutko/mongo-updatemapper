using Xunit;

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
    }
}