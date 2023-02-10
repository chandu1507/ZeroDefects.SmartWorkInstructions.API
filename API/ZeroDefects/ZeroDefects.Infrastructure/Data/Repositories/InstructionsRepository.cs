using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Entities;
using ZeroDefects.Domain.Interfaces;

namespace ZeroDefects.Infrastructure.Data.Repositories
{
    public class InstructionsRepository : IInstructionsRepository
    {
        private const string CollectionName = "Instructions";
        private readonly IMongoCollection<Instructions> _dbCollection;
        private readonly FilterDefinitionBuilder<Instructions> _filterBuilder = Builders<Instructions>.Filter;

        public InstructionsRepository(IMongoDatabase database)
        {
           _dbCollection= database.GetCollection<Instructions>(CollectionName);
            //var items = _dbCollection.Find(c => true).ToList();
            //var collectionsList = database.ListCollections().ToList();
            //var collectionOfInterest = database.GetCollection<BsonDocument>(CollectionName);
        }

        public async Task AddInstructionAsync(Instructions instructions)
        {
            if (instructions == null)
            {
                throw new ArgumentNullException(nameof(instructions));
            }

            await _dbCollection.InsertOneAsync(instructions);
        }

        public async Task<string?> DeleteInstructionAsync(string id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            var result = await _dbCollection.DeleteOneAsync(filter);

            if (result.DeletedCount != 0)
            {
                return id;
            }

            return null;
        }

        public async Task<IEnumerable<Instructions>> GetAllInstructionsAsync()
        {
            
            return await _dbCollection.Find(c => true).ToListAsync();
        }

        public async Task<Instructions> GetInstructionAsync(string id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Instructions?> UpdateInstructionAsync(Instructions instructions)
        {
            if (instructions == null)
            {
                throw new ArgumentNullException(nameof(instructions));
            }

            var filter = _filterBuilder.Eq(item => item.Id, instructions.Id);
            var result = await _dbCollection.ReplaceOneAsync(filter,instructions); 

            if (result.ModifiedCount != 0)
            {
                return null;
            }

            return null;
        }

        
    }
}
