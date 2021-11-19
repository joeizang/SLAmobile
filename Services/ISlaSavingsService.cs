using AutoMapper;
using MediatR;
using SLAMobileApi.Data;
using SLAMobileApi.DomainModels;
using SLAMobileApi.Dtos;

namespace SLAMobileApi.Services;

public interface ISlaSavingsService : IDataService<Savings>
{
    Task<CreateSavingsResponse> CreateSavings(CreateSavingsInputModel model);
}

public class SlaSavingsService : GenericDataService<Savings>, ISlaSavingsService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SlaSavingsService(SlaMobileContext context, IMapper mapper, IMediator mediator) : base(context)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<CreateSavingsResponse> CreateSavings(CreateSavingsInputModel model)
    {
        if (model is null) throw new ArgumentNullException("Invalid savings creation data sent!");
        var savings = _mapper.Map<CreateSavingsInputModel, Savings>(model);
        // TODO: call cowrywise client api to save money for client
        // TODO: assuming cowrywise ops is successful then save response to db
        EntitySet.Add(savings);
        await Commit(CancellationToken.None).ConfigureAwait(false);
        return new CreateSavingsResponse("Look at you all grown up and making grown up decisions.", "Well Done");
    }
}