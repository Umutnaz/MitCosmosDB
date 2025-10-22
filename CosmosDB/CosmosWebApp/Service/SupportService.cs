// Service/SupportService.cs
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Model;

namespace CosmosWebApp.Service;

public class SupportService
{
    private readonly Container _container;
    private readonly ILogger<SupportService> _log;

    public SupportService(CosmosClient client, string db, string container, ILogger<SupportService> log)
    {
        _container = client.GetContainer(db, container);
        _log = log;
    }

    public async Task<List<SupportMessage>> GetAllAsync()
    {
        var it = _container.GetItemQueryIterator<SupportMessage>(new QueryDefinition("SELECT * FROM c"));
        var list = new List<SupportMessage>();
        while (it.HasMoreResults) list.AddRange(await it.ReadNextAsync());
        return list;
    }

    // VIGTIGT: Lad SDK udlede partition key'en fra dokumentets "category"
    public async Task CreateAsync(SupportMessage msg)
    {
        try
        {
            await _container.UpsertItemAsync(msg); // <-- ingen PartitionKey-parameter
        }
        catch (CosmosException ex)
        {
            _log.LogError(ex, "Cosmos insert failed. Status {Status} SubStatus {SubStatus}. Message: {Message}",
                ex.StatusCode, ex.SubStatusCode, ex.Message);
            throw;
        }
    }
}