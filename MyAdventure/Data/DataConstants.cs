﻿namespace MyAdventure.Data
{
    public class DataConstants
    {
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
