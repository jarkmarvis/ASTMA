using ASTMA.Application.Common.Interfaces;
using ASTMA.Application.Common.Models;
using ASTMA.Application.Taskers.Commands.Create;
using ASTMA.Application.Taskers.Commands.Update;
using ASTMA.Application.Taskers.Queries.GetByFilter;
using ASTMA.Infrastructure.Documents;
using AutoMapper;
using MongoDB.Driver;

namespace ASTMA.Infrastructure.Repositories;

public class TaskerRepository : ITaskerRepository
{
    private readonly IApplicationDbContext<TaskerDocument> _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Repository For handling CRUD operations for Tasker objects
    /// </summary>
    /// <param name="context">IMongoDbContext<TaskerDocument></param>
    /// <param name="mapper">IMapper</param>
    public TaskerRepository(IApplicationDbContext<TaskerDocument> context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task<TaskerDto> CreateAsync(CreateTaskerArgs args)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<TaskerDto> GetAsync(string id)
    {
        var filter = Builders<TaskerDocument>.Filter.Eq(t => t.Id, id);
        var result = await _context.Collection.Find(filter).FirstOrDefaultAsync();
        return _mapper.Map<TaskerDto>(result);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TaskerDto>> GetAsync(GetTaskerArgs args)
    {
        //var filter = Builders<TaskerDocument>.Filter.Eq(t => t.Title, args.Title);
        //var result = await _context.Collection.Find(filter).ToListAsync();
        //return _mapper.Map<IEnumerable<TaskerDto>>(result);
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<TaskerDto> UpdateAsync(UpdateTaskerArgs args)
    {
        //    var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
        //    await _context.Collection.ReplaceOneAsync(filter, user);
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<TaskerDto> DeleteAsync(int id)
    {
        //    var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        //    await _context.Collection.DeleteOneAsync(filter);
        throw new NotImplementedException();
    }
}

