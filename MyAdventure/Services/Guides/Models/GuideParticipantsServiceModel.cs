namespace MyAdventure.Services.Guides.Models
{
    public class GuideParticipantsServiceModel
    {
        public int ReservationId { get; set; }
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserCity { get; set; }
    }
}
