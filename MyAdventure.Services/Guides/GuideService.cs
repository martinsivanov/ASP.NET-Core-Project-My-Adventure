﻿namespace MyAdventure.Services.Guides
{
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Services.Guides.Models;
    using MyAdventure.Services.Routes.Models;
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
           var guide = this.data
                       .Guides
                       .FirstOrDefault(x => x.UserId == userId);

           var reservation = this.data.Reservations.Where(x => x.Id == reservationId).FirstOrDefault();
            if (guide != null)
            {
                if (reservation.GuideId == guide.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsGuide(string userId)
        {
            return this.data.Guides.Any(x => x.UserId == userId);
        }

        public IEnumerable<GuideServiceModel> GetAllGuides()
        {
           return this.data.Guides.Select(x => new GuideServiceModel
            {
                GuideId = x.Id,
                GuideName = x.Name,
                PhoneNumber = x.PhoneNumber,
                Routes = x.Routes.Select(x => new RouteServiceModel 
                { 
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Mountain = x.Mountain,
                    Name = x.Name,
                    Region = x.Region
                })
            })
                .ToList();
        }

        public bool IsRemoved(int guideId)
        {
            var guide = this.data.Guides.Find(guideId);
            if (guide != null)
            {
                this.data.Guides.Remove(guide);
                this.data.SaveChanges();
                return true;
            }
            return false;
        }

        public bool IsGuideExists(int guideId)
        {
            return this.data.Guides.Any(x => x.Id == guideId);
        }

    }
}
