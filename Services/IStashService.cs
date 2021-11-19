using AutoMapper;
using MediatR;
using SLAMobileApi.Data;
using SLAMobileApi.DomainModels;
using SLAMobileApi.Dtos;

namespace SLAMobileApi.Services;

public interface IStashService : IDataService<Stash>
{
    Task<CreateStashResponse> CreateStash(CreateStashInputModel model);
}

public class StashService : GenericDataService<Stash>, IStashService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public StashService(SlaMobileContext context, IMapper mapper, IMediator mediator) : base(context)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<CreateStashResponse> CreateStash(CreateStashInputModel model)
    {
        if (model is null) throw new ArgumentNullException("Invalid stash creation data sent!");
        var stash = _mapper.Map<CreateStashInputModel, Stash>(model);
        // TODO: call cowrywise client api to save money for client
        // TODO: assuming cowrywise ops is successful then save response to db
        EntitySet.Add(stash);
        await Commit(CancellationToken.None).ConfigureAwait(false);
        return new CreateStashResponse("Look at you all grown up and making grown up decisions.");
    }
}