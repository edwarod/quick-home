using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Dto;

namespace QuickHome.Business.DomainServices
{
    public class NotificationDomainService : INotificationDomainService
    {
        public void NotifyRentalApproval(RentDto rentDto)
        {
            // Add notification logic here
        }

        public void NotifyRentalRejection(RentDto rentDto)
        {
            // Add notification logic here
        }

        public void NotifyRentalRequirement(RentDto rentDto)
        {
            // Add notification logic here
        }
    }
}
