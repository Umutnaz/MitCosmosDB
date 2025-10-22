using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Model; // bruger din SupportMessage-model uændret
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosWebApp.Service
{
    public class SupportService
    {
        private readonly Container _container;
        private readonly ILogger<SupportService> _logger;

        public SupportService(CosmosClient cosmosClient, string databaseName, string containerName, ILogger<SupportService> logger)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
            _logger = logger;
        }

        public async Task CreateAsync(SupportMessage message)
        {
            try
            {
                // Brug id som partition key (tilpas hvis din container bruger andet)
                await _container.UpsertItemAsync(message, new PartitionKey(message.Id));
            }
            catch (CosmosException ex)
            {
                _logger.LogError($"CosmosDB Error: {ex.StatusCode} - {ex.Message}. ActivityId: {ex.ActivityId}");
                throw;
            }
        }

        public async Task<List<SupportMessage>> GetAllAsync()
        {
            var results = new List<SupportMessage>();
            var query = _container.GetItemQueryIterator<SupportMessage>(
                new QueryDefinition("SELECT * FROM c"));

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        // Til hente én specifik supportbesked efter id
        public async Task<SupportMessage?> GetByIdAsync(string id)
        {
            try
            {
                var resp = await _container.ReadItemAsync<SupportMessage>(id, new PartitionKey(id));
                return resp.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
