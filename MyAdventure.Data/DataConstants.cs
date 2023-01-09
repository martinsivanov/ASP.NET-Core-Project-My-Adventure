namespace MyAdventure.Data
{
    public class DataConstants
    {
        public class BlogPost
        {
            public const int TitleMaxLenght = 100;
            public const int TitleMinLenght = 5;

            public const int ContentMaxLenght = 6000;
            public const int ContentMinLenght = 100;

            public const int AuthorMaxLenght = 40;
            public const int AuthorMinLenght = 5;
        }

        public class SeedData
        {
            public const string FirstCategoryName = "Walking";
            public const string SecondCategoryName = "Cycling";

            public const string FirstSeasonName = "Summer";
            public const string SecondSeasonName = "Winter";
            public const string ThirdSeasonName = "Spring";
            public const string FourthSeasonName = "Autumn";

            public const string GuideEmail = "guide@guide.com";
            public const string GuideName = "Martin";
            public const string GuidePhoneNumber = "0888123456";

            public const string UserEmail = "user@user.com";

            public const string DefaultPassword = "123456";

            public const string AdminEmail = "admin@ma.com";
            public const string AdminPassword = "123456";

            public const string RouteOneName = "From Vihren Hut to Vihren Peak";
            public const string RouteOneImageUrl = "/img/routeOne.jpg";
            public const string RouteOneDescription = "Vihren peak is located in the northern part of Pirin";
            public const string RouteOneDepartureTime = "2022-03-21 08:30";
            public const string RouteOneDuration = "2 hours";
            public const string RouteOneMountain = "Pirin";
            public const string RouteOneStartPoint = "Vihren hut";
            public const string RouteOneEndPoint = "Vihren peak";
            public const string RouteOneLength = "15 km.";
            public const string RouteOnePrice = "20 lv";
            public const string RouteOneRegion = "Blagoevgrad";
            public const int RouteOneParticipants = 5;

            public const string RouteTwoName = "From Maliovitsa hut to Maliovitsa peak";
            public const string RouteTwoImageUrl = "/img/routeTwo.jpg";
            public const string RouteTwoDescription = "In the foothills of Malovitsa hut is the Malovitsa hut of the same name, a starting point for excursions to the summit. A marked path leads from the hut to the summit through the glacial valley, part of the international tourist route. From the Malovishka ridge, the trail continues in the direction of Razdela, Ivan Vazov hut and the area of the Seven Rila Lakes, with a branch to the Rila Monastery. The area around the Malovitsa peak and the slopes of the trough valley of the Malovitsa river are avalanche-dangerous and must be crossed with caution during the winter season.";
            public const string RouteTwoDepartureTime = "2022-03-21 08:30";
            public const string RouteTwoDuration = "4 hours";
            public const string RouteTwoMountain = "Rila";
            public const string RouteTwoStartPoint = "Malovitsa hut";
            public const string RouteTwoEndPoint = "Malovitsa peak";
            public const string RouteTwoLength = "25 km.";
            public const string RouteTwoPrice = "30 lv";
            public const string RouteTwoRegion = "Sofia";
            public const int RouteTwoParticipants = 2;

            public const string RouteThreeName = "From Dobrila hut to Botev peak";
            public const string RouteThreeImageUrl = "/img/routeThree.jpg";
            public const string RouteThreeDescription = "From the west to the top there is a trail that starts from the Dobrila hut. Summer in good weather is relatively easy for any average tourist. There are ropes in places to make it easier, and in one or two places you need to pull up, and in other places, you need to descend almost only by hands. In good weather and good visibility, which are rare there, it offers unique views of Northern and Southern Bulgaria.";
            public const string RouteThreeDepartureTime = "2022-03-21 08:30";
            public const string RouteThreeDuration = "5 hours";
            public const string RouteThreeMountain = "Stara Planina";
            public const string RouteThreeStartPoint = "Dobrila hut";
            public const string RouteThreeEndPoint = "Botev peak";
            public const string RouteThreeLength = "35 km.";
            public const string RouteThreePrice = "50 lv";
            public const string RouteThreeRegion = "Sofia";
            public const int RouteThreeParticipants = 2;

            public const string RouteFourName = "From Vihren hut to Sinanitsa peak";
            public const string RouteFourImageUrl = "/img/routeFour.jpg";
            public const string RouteFourDescription = "Sinanitsa (2516 m), also called the Split Peak, the Chalk Hammer or the Hammer, is a peak in Pirin. It rises on the Sinani side ridge, southwest of Georgiitsa peak and west of Momin peak. It is built of pink-gray marble. It has a characteristic split appearance, which is why it cannot be mistaken when viewed from the southwest, for example from the town of Sandanski.";
            public const string RouteFourDepartureTime = "2022-03-21 08:30";
            public const string RouteFourDuration = "4 hours";
            public const string RouteFourMountain = "Pirin";
            public const string RouteFourStartPoint = "Vihren hut";
            public const string RouteFourEndPoint = "Sinanitsa peak";
            public const string RouteFourLength = "25 km.";
            public const string RouteFourPrice = "20 lv";
            public const string RouteFourRegion = "Blagoevgrad";
            public const int RouteFourParticipants = 6;

            public const string BlogPostTitle = "Why is the mountain useful?";
            public const string BlogPostPic = "/img/blogPost.jpg";
            public const string BlogPostAuthor = "Test";
            public const string BlogPostContent = "The biggest advantage of mountain air over city air is undoubtedly that it is clean, as there is no dust and harmful substances in it. But it is no less important that in the atmosphere of mountainous regions the concentration of carbon dioxide, which is as important for our body as oxygen, is higher. Therefore, inhaling mountain air helps us fill our blood with carbon dioxide, thus restoring its balance in our blood and cells.";
        };

    public class Error
    {
        public const string RouteFull = "Route is full!";
        public const string UserExist = "You already booked on this route!";
        public const string UserIsGuide = "Your cannot book, because you are already guide!";
        public const string UserAlreadyAddedReview = "Your have already added your review!";

    }

    public class User
    {
        public const int UserFirstNameMaxLength = 40;
        public const int UserFirstNameMinLength = 5;

        public const int UserLastNameMaxLength = 40;
        public const int UserLastNameMinLength = 5;

        public const int UserCityMaxLength = 30;
        public const int UserCityMinLength = 4;

        public const int UserPhoneNumberMaxLength = 30;
        public const int UserPhoneNumberMinLength = 5;

        public const int UserPasswordMaxLength = 100;
        public const int UserPasswordMinLength = 6;

        public const int UserReviewContentMaxLength = 100;
        public const int UserReviewContentMinLength = 10;
    }

    public class Route
    {
        public const int RouteNameMaxLength = 100;
        public const int RouteNameMinLength = 5;

        public const int RouteDescriptionMaxLenght = 600;
        public const int RouteDescriptionMinLenght = 50;

        public const int RouteMaxLength = 8;
        public const int RouteMinLength = 4;

        public const int RouteDurationMaxLength = 10;
        public const int RouteDurationMinLength = 5;

        public const int MountainMaxLength = 20;
        public const int MountainMinLength = 4;

        public const int RegionMaxLength = 15;
        public const int RegionMinLength = 4;

        public const int RouteStartPointMaxLength = 30;
        public const int RouteStartPointMinLength = 10;
        public const int RouteEndPointMaxLength = 30;
        public const int RouteEndPointMinLength = 10;

        public const int MountainNameMaxLength = 25;
        public const int MountainNameMinLength = 4;

        public const int RegionNameMaxLength = 15;
        public const int RegionNameMinLength = 4;

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

    public class Review
    {

    }
}
}
