using Span.Culturio.Core.Models.Package;
using Span.Culturio.Core.Models.Subscription;

namespace Span.Culturio.Subscriptions.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDto>> GetAsync(int userId);

        Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto createSubscriptionDto);
        Task<SubscriptionDto> GetById(int subscriptionId);

        Task<string> TrackVisit(TrackVisitDto trackVisitDto);
        Task<string> Activate(ActivateDto activateDto, int validDays);
        Task<string> CreateVisit(int subscriptionId, List<PackageItemDto> packageItemsDto);
    }
}
