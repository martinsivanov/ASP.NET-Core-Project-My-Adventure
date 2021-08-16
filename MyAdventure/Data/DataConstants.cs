namespace MyAdventure.Data
{
    public class DataConstants
    {
        public class SeedData
        {
            public const string FirstCategoryName = "Пешеходен";
            public const string SecondCategoryName = "Вело";

            public const string FirstSeasonName = "Летен";
            public const string SecondSeasonName = "Зимен";
            public const string ThirdSeasonName = "Пролетен";
            public const string FourthSeasonName = "Есенен";

            public const string GuideEmail = "guide@guide.com";
            public const string GuideName = "Мартин";
            public const string GuidePhoneNumber = "0888123456";

            public const string UserEmail = "user@user.com";

            public const string DefaultPassword = "123456";

            public const string AdminEmail = "admin@ma.com";
            public const string AdminPassword = "admin123";

            public const string RouteName = "От хижа Вихрен до връх Вихрен";
            public const string RouteImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b0/Vihren%2C_Pirin_National_Park_01.JPG/800px-Vihren%2C_Pirin_National_Park_01.JPG";
            public const string RouteDescription = "Върха се намира в северния дял на Пирин на главното било между връх Кутело (на северозапад) и Хвойнати връх (на югоизток). С тези два върха го свързват седловините Премката (2610 м) на север и Кабата (2535 м) на юг.";
            public const string RouteDepartureTime = "25.09.2021г. 08:30";
            public const string RouteDuration = "2 часа";
            public const string RouteMountain = "Пирин";
            public const string RouteStartPoint = "хижа Вихрен";
            public const string RouteEndPoint = "връх Вихрен";
            public const string RouteLength = "15 км.";
            public const string RoutePrice = "20 лева";
            public const string RouteRegion = "Благоевград";
            public const int RouteParticipants = 5;

        }

        public class Error
        {
            public const string RouteFull = "Няма свободни места!";
            public const string UserExist = "Вече сте записан за този маршрут.";
            public const string UserIsGuide = "Не можете да се записвате защото сте Водач.";
        }

        public class User
        {
            public const int UserFirstNameMaxLenght = 40;
            public const int UserFirstNameMinLenght = 5;

            public const int UserLastNameMaxLenght = 40;
            public const int UserLastNameMinLenght = 5;

            public const int UserCityMaxLenght = 30;
            public const int UserCityMinLenght = 4;

            public const int UserPhoneNumberMaxLenght = 30;
            public const int UserPhoneNumberMinLenght = 5;

            public const int UserPasswordMaxLenght = 100;
            public const int UserPasswordMinLenght = 6;
        }

        public class Route
        {
            public const int RouteNameMaxLength = 100;
            public const int RouteNameMinLength = 5;

            public const int RouteDescriptionMaxLenght = 600;
            public const int RouteDescriptionMinLenght = 50;

            public const int RouteMaxLenght = 8;
            public const int RouteMinLenght = 4;

            public const int RouteDurationMaxLenght = 10;
            public const int RouteDurationMinLenght = 5;

            public const int MountainMaxLenght = 20;
            public const int MountainMinLenght = 4;

            public const int RegionMaxLenght = 15;
            public const int RegionMinLenght = 4;

            public const int RouteStartPointMaxLenght = 30;
            public const int RouteStartPointMinLenght = 10;
            public const int RouteEndPointMaxLenght = 30;
            public const int RouteEndPointMinLenght = 10;

            public const int MountainNameMaxLenght = 25;
            public const int MountainNameMinLenght = 4;

            public const int RegionNameMaxLenght = 15;
            public const int RegionNameMinLenght = 4;

            public const int RouteMaxParticipants = 6;
            public const int RouteMinParticipants = 1;
        }
        public class Season
        {
            public const int SeasonNameMaxLenght = 10;
            public const int SeasonNameMinLenght = 5;
        }
        public class Category
        {
            public const int CategoryNameMaxLenght = 10;
            public const int CategoryNameMinLenght = 4;
        }
        public class Guide
        {
            public const int GuideNameMaxLenght = 30;
            public const int GuideNameMinLenght = 4;
            public const int GuidePhoneMaxLenght = 30;
            public const int GuidePhoneMinLenght = 6;
        }
    }
}
