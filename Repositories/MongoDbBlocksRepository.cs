using MesplantApi.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MesplantApi.Repositories
{
    public class MongoDbBlocksRepository : IBlocksRepository
    {

        private const string databaseName = "blocksDB";
        private const string CollectionName = "blocks";

        private readonly IMongoCollection<Block> blocksCollection;
        private readonly FilterDefinitionBuilder<Block> filterBuilder = Builders<Block>.Filter;
        public MongoDbBlocksRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            blocksCollection = database.GetCollection<Block>(CollectionName);
        }

        public async Task CreateBlockAsync(Block block)
        {
            await blocksCollection.InsertOneAsync(block);
        }

        public async Task DeleteBlockAsync(Guid id)
        {
            var filter = filterBuilder.Eq(block => block.id, id);
            await blocksCollection.DeleteOneAsync(filter);

        }

        public async Task<Block> GetBlockAsync(Guid id)
        {
            var filter = filterBuilder.Eq(block => block.id, id);
            return await blocksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Block>> GetBlocksAsync()
        {
            return await blocksCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateBlockAsync(Block block)
        {
            var filter = filterBuilder.Eq(existingblock => existingblock.id, block.id);
            await blocksCollection.ReplaceOneAsync(filter, block);
        }
    }
}