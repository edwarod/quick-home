using QuickHome.Dto;

namespace QuickHome.Business.DomainServices.Contracts
{
    public interface INotificationDomainService
    {
        void NotifyRentalRequirement(RentDto rentDto);

        void NotifyRentalApproval(RentDto rentDto);

        void NotifyRentalRejection(RentDto rentDto);
    }
}
