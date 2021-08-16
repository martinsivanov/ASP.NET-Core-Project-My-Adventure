using MyAdventure.Services.Guides.Models;
using System.Collections.Generic;

namespace MyAdventure.Services.Guides
{
 
    public interface IGuideService
    {
        public bool IsGuide(string userId);

        public bool CanGuideRemoveReservation(string userId, int reservationId);

        public int GetGuideId(string userId);

        public void CreateGuide(string name, string phoneNumber, string userId);

        public IEnumerable<GuideParticipantsServiceModel> GetAllParticipantsByRouteId(int routeId);
    }
}
