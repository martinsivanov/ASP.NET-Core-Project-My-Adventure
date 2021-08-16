namespace MyAdventure.Services.Guides
{
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Services.Guides.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GuideService : IGuideService
    {
        private readonly MyAdventureDbContext data;

        public GuideService(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public void CreateGuide(string name, string phoneNumber, string userId)
        {
            var guideData = new Guide
            {
                Name = name,
                PhoneNumber = phoneNumber,
                UserId = userId
            };

            this.data.Guides.Add(guideData);
            this.data.SaveChanges();
        }

        public IEnumerable<GuideParticipantsServiceModel> GetAllParticipantsByRouteId(int routeId)
        {
            var reservations = this.data.Reservations.Where(x => x.RouteId == routeId).ToList();

            var usersList = new List<GuideParticipantsServiceModel>();

            foreach (var reservation in reservations)
            {
                usersList.Add(new GuideParticipantsServiceModel
                {
                    UserFirstName = reservation.UserFirstName,
                    UserLastName = reservation.UserLastName,
                    UserPhoneNumber = reservation.UserPhoneNumber,
                    UserCity = reservation.UserCity,
                    ReservationId = reservation.Id,
                    UserId = reservation.UserId
                });
            }
            return usersList;
        }

        public int GetGuideId(string userId)
        {
            var guidId = this.data.Guides
            .Where(x => x.UserId == userId)
            .Select(x => x.Id)
            .FirstOrDefault();
            return guidId;
        }

        public bool CanGuideRemoveReservation(string userId, int reservationId)
        {
           var guideId = this.data
                       .Guides
                       .FirstOrDefault(x => x.UserId == userId).Id;

           var reservation = this.data.Reservations.Where(x => x.Id == reservationId).FirstOrDefault();
            if (reservation.GuideId == guideId)
            {
                return true;
            }
            return false;
        }

        public bool IsGuide(string userId)
        {
            return this.data.Guides.Any(x => x.UserId == userId);
        }
    }
}
