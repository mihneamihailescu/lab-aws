using Amazon.DynamoDBv2.DataModel;

namespace AplicatieAPI.Entities
{
    [DynamoDBTable("products")]
    public class ProductEntity
    {
        [DynamoDBHashKey("id")]
        public string Id { get; set; }

        [DynamoDBProperty("name")]
        public required string Name { get; set; }
       
        [DynamoDBProperty("price")]
        public long Price { get; set; }

        [DynamoDBProperty("quantity")]
        public int Quantity { get; set; }

        [DynamoDBProperty("description")]

        public required string Description { get; set; }

    }
}
