// Service/SupportService.cs
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Model;

namespace CosmosWebApp.Service;

public class SupportService
{
    private readonly Container _c;
    private readonly ILogger<SupportService> _log;

    public SupportService(CosmosClient client, string db, string container, ILogger<SupportService> log)
    {
        _c = client.GetContainer(db, container);
        _log = log;
    }

    public async Task<List<SupportMessage>> GetAllAsync()
    {
        var it = _c.GetItemQueryIterator<SupportMessage>(new QueryDefinition("SELECT * FROM c"));
        var list = new List<SupportMessage>();
        while (it.HasMoreResults) list.AddRange(await it.ReadNextAsync());
        return list;
    }

    public Task CreateAsync(SupportMessage m) =>
        _c.UpsertItemAsync(m, new PartitionKey(m.Kategori)); // PK = /category
}