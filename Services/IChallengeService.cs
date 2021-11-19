using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLAMobileApi.Data;
using SLAMobileApi.DomainModels;
using SLAMobileApi.Dtos;

namespace SLAMobileApi.Services;

public interface IChallengeService : IDataService<Challenge>
{
    Task<CreateChallengeResponse> CreateChallenge(CreateChallengeInputModel model);

    Task<ChallengeDashboardViewModel> GetAllChallengesPerUser(string userId);

    Task WithdrawFromChallenge(string userId, string challengeId, decimal amountToDraw);
}

public class ChallengeService : GenericDataService<Challenge>, IChallengeService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ChallengeService(SlaMobileContext context, IMapper mapper, IMediator mediator) : base(context)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    public async Task<CreateChallengeResponse> CreateChallenge(CreateChallengeInputModel model)
    {
        if (model is null) throw new ArgumentNullException("Invalid challenge creation data sent!");
        var challenge = _mapper.Map<CreateChallengeInputModel, Challenge>(model);
        // TODO: call cowrywise client api to setup investment or save money for client for client
        // TODO: assuming cowrywise ops is successful then save response to db
        EntitySet.Add(challenge);
        await Commit(CancellationToken.None).ConfigureAwait(false);
        var amountSaved = (decimal)(model.IncomePercentage/ 100) * model.Amount;
        return new CreateChallengeResponse(true, "Way to go girl, you have locked down", amountSaved, model.Duration);
    }

    public async Task<ChallengeDashboardViewModel> GetAllChallengesPerUser(string userId)
    {
        if(string.IsNullOrEmpty(userId)) throw new ArgumentNullException("You must provide a user Id with this request!");
        var stopError = await EntitySet.ToListAsync();
        return new ChallengeDashboardViewModel();
    }

    public Task WithdrawFromChallenge(string userId, string challengeId, decimal amountToDraw)
    {
        throw new NotImplementedException();
    }
}