//namespace Mulier.Infrastructure.LiteDb.Services;

//using AutoMapper;
//using global::LiteDB;
//using Mulier.Domain.Entities;
//using Mulier.Domain.Interfaces;
//using Mulier.Infrastructure.LiteDb.Models;

//internal sealed class ToDoRepository : IToDoRepository
//{
//    private readonly string connectionString;
//    private readonly IMapper mapper;

//    public ToDoRepository(IMapper mapper, LiteDbOptions options)
//    {
//        this.mapper = mapper;

//        var parts = new[]
//        {
//            new KeyValuePair<string, string>("Filename", options.FileName),
//            new KeyValuePair<string, string>("Connection", nameof(ConnectionType.Shared)),
//        };

//        this.connectionString = string.Join(";", parts.Select(part => $"{part.Key}={part.Value}"));
//    }

//    public Task CreateAsync(ToDoEntity entity, CancellationToken cancellationToken = default)
//    {
//        using var database = new LiteDatabase(this.connectionString);
//        var dbEntities = database.GetCollection<ToDoDbEntity>(nameof(ToDoDbEntity));

//        var dbEntity = this.mapper.Map<ToDoDbEntity>(entity);

//        dbEntities.Insert(dbEntity);

//        return Task.CompletedTask;
//    }

//    public Task DeleteAsync(ToDoId id, CancellationToken cancellationToken = default)
//        => Task.CompletedTask;

//    public async Task<ToDoEntity?> ReadAsync(ToDoId id, CancellationToken cancellationToken = default)
//    {
//        using var database = new LiteDatabase(this.connectionString);
//        var dbEntities = database.GetCollection<ToDoDbEntity>(nameof(ToDoDbEntity));
//        var entity = dbEntities.FindOne(entity => entity.Id == id);

//        var result = this.mapper.Map<ToDoEntity>(entity);

//        return await Task.FromResult(result);
//    }

//    public Task UpdateAsync(ToDoEntity entity, CancellationToken cancellationToken = default)
//        => Task.CompletedTask;
//}


