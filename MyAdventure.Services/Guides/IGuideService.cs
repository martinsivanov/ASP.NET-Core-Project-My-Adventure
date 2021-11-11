namespace MyAdventure.Services.Guides
{
    using MyAdventure.Services.Guides.Models;
    using MyAdventure.Services.Routes.Models;
    using System.Collections.Generic;

    public interface IGuideService
    {
        public bool IsGuide(string userId);

        public bool CanGuideRemoveReservation(string userId, int reservationId);

        public int GetGuideId(string userId);

        public void CreateGuide(string name, string phoneNumber, string userId);

        public IEnumerable<GuideParticipantsServiceModel> GetAllParticipantsByRouteId(int routeId);

        public IEnumerable<GuideServiceModel> GetAllGuides();

        public bool IsRemoved(int guideId);

        public bool IsGuideExists(int guideId);

    }
}
