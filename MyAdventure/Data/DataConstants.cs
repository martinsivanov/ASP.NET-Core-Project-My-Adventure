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
            public const string AdminPassword = "123456";

            public const string RouteOneName = "От хижа Вихрен до връх Вихрен";
            public const string RouteOneImageUrl = "/img/routeOne.jpg";
            public const string RouteOneDescription = "Върха се намира в северния дял на Пирин на главното било между връх Кутело (на северозапад) и Хвойнати връх (на югоизток). С тези два върха го свързват седловините Премката (2610 м) на север и Кабата (2535 м) на юг.";
            public const string RouteOneDepartureTime = "25.09.2021г. 08:30";
            public const string RouteOneDuration = "2 часа";
            public const string RouteOneMountain = "Пирин";
            public const string RouteOneStartPoint = "хижа Вихрен";
            public const string RouteOneEndPoint = "връх Вихрен";
            public const string RouteOneLength = "15 км.";
            public const string RouteOnePrice = "20 лева";
            public const string RouteOneRegion = "Благоевград";
            public const int RouteOneParticipants = 5;

            public const string RouteTwoName = "От хижа Мальовица до връх Мальовица";
            public const string RouteTwoImageUrl = "/img/routeTwo.jpg";
            public const string RouteTwoDescription = "В полите на връх Мальовица е разположена едноименната хижа Мальовица, изходна точка за излети към върха. От хижата до върха през ледниковата долина води маркирана пътека, част от международния туристически маршрут. От Мальовишкото било пътеката продължава в посока Раздела, хижа Иван Вазов и района на Седемте рилски езера, с разклонение към Рилския манастир. Районът около връх Мальовица и склоновете на троговата долина на река Мальовица са лавиноопасни и трябва да бъдат преминавани с повишено внимание през зимния сезон.";
            public const string RouteTwoDepartureTime = "25.09.2021г. 06:30";
            public const string RouteTwoDuration = "4 часа";
            public const string RouteTwoMountain = "Рила";
            public const string RouteTwoStartPoint = "хижа Мальовица";
            public const string RouteTwoEndPoint = "връх Мальовица";
            public const string RouteTwoLength = "25 км.";
            public const string RouteTwoPrice = "30 лева";
            public const string RouteTwoRegion = "София";
            public const int RouteTwoParticipants = 2;

            public const string RouteThreeName = "От хижа Добрила до връх Ботев";
            public const string RouteThreeImageUrl = "/img/routeThree.jpg";
            public const string RouteThreeDescription = "От запад към върха води билен маршрут, който започва от хижа Добрила. Трудността му е от степен IV. Лятото в хубаво време се минава сравнително лесно от всеки средностатистически турист. Има на места въжета за улеснение, като на едно-две места е нужно набиране, а другаде – спускане почти само на ръце. При хубаво време и добра видимост, които там са рядкост, предлага неповторими гледки към Северна и Южна България.";
            public const string RouteThreeDepartureTime = "26.09.2021г. 05:30";
            public const string RouteThreeDuration = "5 часа";
            public const string RouteThreeMountain = "Стара Планина";
            public const string RouteThreeStartPoint = "хижа Добрила";
            public const string RouteThreeEndPoint = "връх Ботев";
            public const string RouteThreeLength = "35 км.";
            public const string RouteThreePrice = "50 лева";
            public const string RouteThreeRegion = "София";
            public const int RouteThreeParticipants = 2;

            public const string RouteFourName = "От хижа Вихрен до връх Синаница";
            public const string RouteFourImageUrl = "/img/routeFour.jpg";
            public const string RouteFourDescription = "Синаница (2516 м), наричан още Разцепения връх, Варовитата чука или Чуката, е връх в Пирин. Издига се на Синанишкото странично било, на югозапад от връх Георгийца и на запад от Момин връх. Изграден е от розово-сив мрамор. Има характерен разцепен вид, поради което не може да се сбърка, когато се гледа от югозапад, например от град Сандански.";
            public const string RouteFourDepartureTime = "25.09.2021г. 06:30";
            public const string RouteFourDuration = "4 часа";
            public const string RouteFourMountain = "Пирин";
            public const string RouteFourStartPoint = "хижа Вихрен";
            public const string RouteFourEndPoint = "връх Синаница";
            public const string RouteFourLength = "25 км.";
            public const string RouteFourPrice = "20 лева";
            public const string RouteFourRegion = "Благоевград";
            public const int RouteFourParticipants = 6;

            public const string BlogPostTitle = "Защо планината е полезна?";
            public const string BlogPostPic = "/img/blogPost.jpg";
            public const string BlogPostAuthor = "Test";
            public const string BlogPostContent = "Най-голямото предимство на планинския въздух пред градския безспорно е това, че е чист, тъй като в него няма прах и вредни за лигавиците летящи вещества. Но не по-малко важно е, че в атмосферата на планинските райони концентрацията на въглероден диоксид, който е толкова важен за организма ни, колкото е и кислородът, е по-висока. Затова вдишването на планински въздух ни помага да напълним кръвта си с въглероден диоксид, като по този начин възстановяваме баланса му в кръвта и клетките си.";
        };

    public class Error
    {
        public const string RouteFull = "Няма свободни места!";
        public const string UserExist = "Вече сте записан за този маршрут.";
        public const string UserIsGuide = "Не можете да се записвате защото сте Водач.";
        public const string UserAlreadyAddedReview = "Вече сте дали вашия отзив.";

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

        public const int UserReviewContentMaxLenght = 100;
        public const int UserReviewContentMinLenght = 10;
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

    public class Review
    {

    }
}
}
