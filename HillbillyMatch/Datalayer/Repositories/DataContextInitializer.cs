using Datalayer.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.IO;


namespace Datalayer.Repositories
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            SeedUsers(context);
        }

        public static void SeedUsers(DataContext context)
        {
            // Creating The Users
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var jim = new ApplicationUser
            {
                Firstname = "Jim",
                Lastname = "Bob",
                Gender = Gender.Man,
                UserName = "jim@hillbilly.se",
                Email = "jim@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Boys\jim.PNG"),
                Description = "I am a hard working man who doesnt take any shit. I am looking for a wife. I am sorry about my profile picture, was pissed at the time, best beard picture I have though...",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Oldschool,
                QuestionBoundaries = QuestionBoundaries.AbsolutelyNot,
                QuestionDrive = QuestionDrive.ASunkyOne,
                QuestionDrunkPeriods = QuestionDrunkPeriods.MoreThankOneWeek,
                QuestionLive = QuestionLive.TrailerPark,
                QuestionSpeed = QuestionSpeed.SlowPace,
                QuestionFun = QuestionFun.BurningTires,
                QuestionFood = QuestionFood.Stake,
                QuestionMaterial = QuestionMaterial.Sand
            };
            manager.Create(jim, "Hejsan45!");

            var dale = new ApplicationUser
            {
                Firstname = "Dale",
                Lastname = "Bauer",
                Gender = Gender.Man,
                UserName = "dale@hillbilly.se",
                Email = "dale@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Boys\dale.PNG"),
                Description = "This is my world, I make the rules. I have lots and lots of cash. Looking for a new gal. Please leave a message and my manager will ask you a few questions.",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Modern,
                QuestionBoundaries = QuestionBoundaries.MaybeSome,
                QuestionDrive = QuestionDrive.TryToWalk,
                QuestionDrunkPeriods = QuestionDrunkPeriods.OneThreeDays,
                QuestionLive = QuestionLive.TrailerPark,
                QuestionSpeed = QuestionSpeed.FullSpeed,
                QuestionFun = QuestionFun.BurningTires,
                QuestionFood = QuestionFood.Beef,
                QuestionMaterial = QuestionMaterial.Sand
            };
            manager.Create(dale, "Hejsan45!");

            var bart = new ApplicationUser
            {
                Firstname = "Bart",
                Lastname = "Gus",
                Gender = Gender.Man,
                UserName = "bart@hillbilly.se",
                Email = "bart@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Boys\bart.PNG"),
                Description = "I been and I was. Sometimes even both. Looking for a happy chick. Sorry about the mugshot. Peace.",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Oldschool,
                QuestionBoundaries = QuestionBoundaries.AbsolutelyNot,
                QuestionDrive = QuestionDrive.ASunkyOne,
                QuestionDrunkPeriods = QuestionDrunkPeriods.MoreThankOneWeek,
                QuestionLive = QuestionLive.TrailerPark,
                QuestionSpeed = QuestionSpeed.SlowPace,
                QuestionFun = QuestionFun.BurningTires,
                QuestionFood = QuestionFood.Beef,
                QuestionMaterial = QuestionMaterial.Mud
            };
            manager.Create(bart, "Hejsan45!");

            var woody = new ApplicationUser
            {
                Firstname = "Woody",
                Lastname = "Buckley",
                Gender = Gender.Man,
                UserName = "woody@hillbilly.se",
                Email = "woody@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Boys\woody.PNG"),
                Description = "I couldnt get my camera to work so I took a picture from the internet but I look almost like that. I have the same cap. Hard working and likes my whisky. I have been single for only 8 years but I feel that I am ready to commit.",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Modern,
                QuestionBoundaries = QuestionBoundaries.MaybeSome,
                QuestionDrive = QuestionDrive.TryToWalk,
                QuestionDrunkPeriods = QuestionDrunkPeriods.OneThreeDays,
                QuestionLive = QuestionLive.NoHome,
                QuestionSpeed = QuestionSpeed.FullSpeed,
                QuestionFun = QuestionFun.NoTires,
                QuestionFood = QuestionFood.Beef,
                QuestionMaterial = QuestionMaterial.Mud
            };
            manager.Create(woody, "Hejsan45!");

            var ray = new ApplicationUser
            {
                Firstname = "Ray",
                Lastname = "Wayne",
                Gender = Gender.Man,
                UserName = "ray@hillbilly.se",
                Email = "ray@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Boys\ray.PNG"),
                Description = "YEAH! Been to every festival on a 100 miles radius. Still havent found you. So please contact me and we can discuss it over a bottle of wine?",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Oldschool,
                QuestionBoundaries = QuestionBoundaries.AbsolutelyNot,
                QuestionDrive = QuestionDrive.ASunkyOne,
                QuestionDrunkPeriods = QuestionDrunkPeriods.MoreThankOneWeek,
                QuestionLive = QuestionLive.NoHome,
                QuestionSpeed = QuestionSpeed.FullSpeed,
                QuestionFun = QuestionFun.NoTires,
                QuestionFood = QuestionFood.Beef,
                QuestionMaterial = QuestionMaterial.Mud
            };
            manager.Create(ray, "Hejsan45!");

            var buffy = new ApplicationUser
            {
                Firstname = "Buffy",
                Lastname = "Sue",
                Gender = Gender.Woman,
                UserName = "buffy@hillbilly.se",
                Email = "buffy@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Girls\buffy.PNG"),
                Description = "Looking for a descent guy who likes to party. I dont want to travel the world. But I do get out sometimes. Dont drink and drive.",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Modern,
                QuestionBoundaries = QuestionBoundaries.MaybeSome,
                QuestionDrive = QuestionDrive.TryToWalk,
                QuestionDrunkPeriods = QuestionDrunkPeriods.MoreThankOneWeek,
                QuestionLive = QuestionLive.TrailerPark,
                QuestionSpeed = QuestionSpeed.FullSpeed,
                QuestionFun = QuestionFun.BurningTires,
                QuestionFood = QuestionFood.Stake,
                QuestionMaterial = QuestionMaterial.Sand
            };
            manager.Create(buffy, "Hejsan45!");

            var mary = new ApplicationUser
            {
                Firstname = "Mary",
                Lastname = "Dakota",
                Gender = Gender.Woman,
                UserName = "mary@hillbilly.se",
                Email = "mary@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Girls\mary.PNG"),
                Description = "Hehe, my profile is fake, I dont really look like that. It was from a festival, usually I have black hair. I am a smoker though. And a drinker. Looking forward meeting mr perfect.",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Oldschool,
                QuestionBoundaries = QuestionBoundaries.MaybeSome,
                QuestionDrive = QuestionDrive.TryToWalk,
                QuestionDrunkPeriods = QuestionDrunkPeriods.OneThreeDays,
                QuestionLive = QuestionLive.TrailerPark,
                QuestionSpeed = QuestionSpeed.SlowPace,
                QuestionFun = QuestionFun.NoTires,
                QuestionFood = QuestionFood.Beef,
                QuestionMaterial = QuestionMaterial.Mud
            };
            manager.Create(mary, "Hejsan45!");

            var desiree = new ApplicationUser
            {
                Firstname = "Desiree",
                Lastname = "Jo",
                Gender = Gender.Woman,
                UserName = "desiree@hillbilly.se",
                Email = "desiree@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Girls\desiree.PNG"),
                Description = "I am a funny girl who likes beer more than anything. If you also like beer give me a call, but wait, do you have my number? If you dont, call me anyway!",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Oldschool,
                QuestionBoundaries = QuestionBoundaries.AbsolutelyNot,
                QuestionDrive = QuestionDrive.TryToWalk,
                QuestionDrunkPeriods = QuestionDrunkPeriods.MoreThankOneWeek,
                QuestionLive = QuestionLive.TrailerPark,
                QuestionSpeed = QuestionSpeed.SlowPace,
                QuestionFun = QuestionFun.BurningTires,
                QuestionFood = QuestionFood.Stake,
                QuestionMaterial = QuestionMaterial.Sand
            };
            manager.Create(desiree, "Hejsan45!");

            var larlene = new ApplicationUser
            {
                Firstname = "Larlene",
                Lastname = "Maddison",
                Gender = Gender.Woman,
                UserName = "larlene@hillbilly.se",
                Email = "larlene@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Girls\larlene.PNG"),
                Description = "I have been drunk for 20 years now, life is great! Only getting better each year. Contact me if you want to party!",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Oldschool,
                QuestionBoundaries = QuestionBoundaries.MaybeSome,
                QuestionDrive = QuestionDrive.TryToWalk,
                QuestionDrunkPeriods = QuestionDrunkPeriods.OneThreeDays,
                QuestionLive = QuestionLive.NoHome,
                QuestionSpeed = QuestionSpeed.SlowPace,
                QuestionFun = QuestionFun.NoTires,
                QuestionFood = QuestionFood.Beef,
                QuestionMaterial = QuestionMaterial.Mud
            };
            manager.Create(larlene, "Hejsan45!");

            var debbie = new ApplicationUser
            {
                Firstname = "Debbie",
                Lastname = "Jean",
                Gender = Gender.Woman,
                UserName = "debbie@hillbilly.se",
                Email = "debbie@hillbilly.se",
                //ProfileImage = StreamImageUrlToBinary(@"c:\User-images\Girls\debbie.PNG"),
                Description = "If you contact me I will seriously shoot you!",
                QuestionKindOfHillbilly = QuestionKindOfHillbilly.Modern,
                QuestionBoundaries = QuestionBoundaries.AbsolutelyNot,
                QuestionDrive = QuestionDrive.TryToWalk,
                QuestionDrunkPeriods = QuestionDrunkPeriods.OneThreeDays,
                QuestionLive = QuestionLive.TrailerPark,
                QuestionSpeed = QuestionSpeed.FullSpeed,
                QuestionFun = QuestionFun.BurningTires,
                QuestionFood = QuestionFood.Beef,
                QuestionMaterial = QuestionMaterial.Sand
            };
            manager.Create(debbie, "Hejsan45!");

            //Adding Posts
            var post1 = new Post
            {
                Text = "What is happening today?",
                Date = new DateTime(2017, 10, 25, 14, 32, 00),
                Sender = dale,
                Reciever = jim
            };

            var post2 = new Post
            {
                Text = "Can I buy a few beers?",
                Date = new DateTime(2017, 11, 20, 14, 32, 00),
                Sender = dale,
                Reciever = jim
            };

            var post3 = new Post
            {
                Text = "Get your own beers!",
                Date = new DateTime(2017, 11, 20, 14, 40, 32),
                Sender = jim,
                Reciever = jim
            };

            var post4 = new Post
            {
                Text = "I am just ignoring you from now on!",
                Date = new DateTime(2017, 10, 19, 14, 32, 00),
                Sender = debbie,
                Reciever = dale
            };

            var post5 = new Post
            {
                Text = "Hope to see you soon, last time was wicked! I was in bed for two days after.",
                Date = new DateTime(2017, 10, 24, 14, 32, 00),
                Sender = buffy,
                Reciever = larlene
            };

            var post6 = new Post
            {
                Text = "Did you burn on my property yesterday?",
                Date = new DateTime(2017, 7, 25, 14, 32, 00),
                Sender = ray,
                Reciever = woody
            };

            var post6reply = new Post
            {
                Text = "No I thought it was you?",
                Date = new DateTime(2017, 7, 26, 14, 32, 00),
                Sender = woody,
                Reciever = woody
            };

            var post6reply2 = new Post
            {
                Text = "Haha, it was me! Didnt you see me wave?",
                Date = new DateTime(2017, 7, 28, 14, 32, 00),
                Sender = buffy,
                Reciever = woody
            };

            var post7 = new Post
            {
                Text = "Have you seen my car? My brother left it at your place last week. My brother is pist at me because he says that its his car.",
                Date = new DateTime(2017, 10, 25, 14, 32, 00),
                Sender = mary,
                Reciever = dale
            };

            var post8 = new Post
            {
                Text = "Do you want to buy some car stuff?",
                Date = new DateTime(2017, 9, 20, 08, 15, 00),
                Sender = bart,
                Reciever = dale
            };

            var post9 = new Post
            {
                Text = "Na, the yard is full. But do you want to buy some moonshine?",
                Date = new DateTime(2017, 9, 20, 08, 30, 55),
                Sender = dale,
                Reciever = dale
            };

            var post10 = new Post
            {
                Text = "Do you want to meet me and go to a car rally?",
                Date = new DateTime(2018, 01, 07, 04, 20, 22),
                Sender = buffy,
                Reciever = jim
            };

            var post11 = new Post
            {
                Text = "You look really nice, want to get together sometime?",
                Date = new DateTime(2018, 01, 05, 05, 20, 22),
                Sender = bart,
                Reciever = debbie
            };

            var post12 = new Post
            {
                Text = "You look really nice, want to get together sometime?",
                Date = new DateTime(2018, 01, 05, 05, 25, 22),
                Sender = bart,
                Reciever = buffy
            };

            var post12reply = new Post
            {
                Text = "I am sorry, its not you, its me. Already have someone I am interested in.",
                Date = new DateTime(2018, 01, 7, 05, 25, 22),
                Sender = buffy,
                Reciever = buffy
            };

            var post13 = new Post
            {
                Text = "You look really nice, want to get together sometime?",
                Date = new DateTime(2018, 01, 05, 05, 30, 22),
                Sender = bart,
                Reciever = desiree
            };

            var post14 = new Post
            {
                Text = "You look really nice, want to get together sometime?",
                Date = new DateTime(2018, 01, 05, 05, 35, 22),
                Sender = bart,
                Reciever = larlene
            };

            var post15 = new Post
            {
                Text = "You look really nice, want to get together sometime?",
                Date = new DateTime(2018, 01, 05, 05, 40, 22),
                Sender = bart,
                Reciever = mary
            };

            var post15reply = new Post
            {
                Text = "Of course I want! Give me a call! Your cousin has my number. There is a costume party on Saturday at Billy. Would be fun if you came.",
                Date = new DateTime(2018, 01, 06, 05, 40, 22),
                Sender = mary,
                Reciever = mary
            };

            var post16 = new Post
            {
                Text = "If you dont drop dead I will help you.",
                Date = new DateTime(2018, 01, 06, 10, 7, 5),
                Sender = debbie,
                Reciever = debbie
            };

            var post17 = new Post
            {
                Text = "You look really hot! Do you hunt?",
                Date = new DateTime(2018, 01, 1, 10, 7, 5),
                Sender = ray,
                Reciever = debbie
            };

            var post18 = new Post
            {
                Text = "Somebody here? Where is everybody?",
                Date = new DateTime(2018, 01, 1, 10, 7, 5),
                Sender = bart,
                Reciever = bart
            };

            var post19 = new Post
            {
                Text = "You are handsome and so am I. Want to get drunk sometime?",
                Date = new DateTime(2017, 12, 22, 10, 7, 5),
                Sender = mary,
                Reciever = ray
            };

            var post19reply = new Post
            {
                Text = "Sure, why not? I currently have some problem finding my trailer, your place?",
                Date = new DateTime(2017, 12, 23, 10, 7, 5),
                Sender = ray,
                Reciever = ray
            };

            var post20 = new Post
            {
                Text = "Party at my place tomorrow?",
                Date = new DateTime(2018, 01, 06, 10, 7, 5),
                Sender = larlene,
                Reciever = desiree
            };

            var post20reply = new Post
            {
                Text = "That sounds perfect! I was in the right mood for a party, I bring some meat. Kiss kiss",
                Date = new DateTime(2018, 01, 06, 11, 7, 5),
                Sender = desiree,
                Reciever = desiree
            };

            var post20reply2 = new Post
            {
                Text = "Can I come?",
                Date = new DateTime(2018, 01, 06, 12, 7, 5),
                Sender = woody,
                Reciever = desiree
            };

            var post20reply3 = new Post
            {
                Text = "Of course! Bring every hillbilly you know! :)",
                Date = new DateTime(2018, 01, 06, 13, 7, 5),
                Sender = larlene,
                Reciever = desiree
            };

            context.Posts.AddRange(new[] { post1, post1, post2, post3, post4, post5, post6, post6reply, post6reply2, post7, post8, post9, post10, post11, post12, post12reply, post13, post14, post15, post15reply, post16, post17, post18, post19, post19reply, post20, post20reply, post20reply2, post20reply3 });

            // Lets make some requests

            var request1 = new Request
            {
                RequestDate = DateTime.Now,
                RequestedBy = buffy,
                RequestedTo = jim,
            };

            var request2 = new Request
            {
                RequestDate = DateTime.Now,
                RequestedBy = ray,
                RequestedTo = bart,
            };

            var request3 = new Request
            {
                RequestDate = DateTime.Now,
                RequestedBy = buffy,
                RequestedTo = bart,
            };

            context.Requests.AddRange(new[] { request1, request2, request3 });

            // Add some friends

            var JimDaleRelationship = new Friend
            {
                TheUser = jim,
                TheFriend = dale,
                Category = FriendCategory.standard
            };

            var JimDaleRelationshipReverse = new Friend
            {
                TheUser = dale,
                TheFriend = jim,
                Category = FriendCategory.standard
            };
            context.Friends.AddRange(new[] { JimDaleRelationship, JimDaleRelationshipReverse });

            var JimBartRelationship = new Friend
            {
                TheUser = jim,
                TheFriend = bart,
                Category = FriendCategory.standard
            };

            var JimBartRelationshipReverse = new Friend
            {
                TheUser = bart,
                TheFriend = jim,
                Category = FriendCategory.standard
            };
            context.Friends.AddRange(new[] { JimBartRelationship, JimBartRelationshipReverse });

            var JimRayRelationship = new Friend
            {
                TheUser = jim,
                TheFriend = ray,
                Category = FriendCategory.standard
            };

            var JimRayRelationshipReverse = new Friend
            {
                TheUser = ray,
                TheFriend = jim,
                Category = FriendCategory.standard
            };
            context.Friends.AddRange(new[] { JimRayRelationship, JimRayRelationshipReverse });

            var JimWoodyRelationship = new Friend
            {
                TheUser = jim,
                TheFriend = woody,
                Category = FriendCategory.standard
            };

            var JimWoodyRelationshipReverse = new Friend
            {
                TheUser = woody,
                TheFriend = jim,
                Category = FriendCategory.standard
            };
            context.Friends.AddRange(new[] { JimWoodyRelationship, JimWoodyRelationshipReverse });

            var JimDesireeRelationship = new Friend
            {
                TheUser = jim,
                TheFriend = desiree,
                Category = FriendCategory.favorite
            };

            var JimDesireeRelationshipReverse = new Friend
            {
                TheUser = desiree,
                TheFriend = jim,
                Category = FriendCategory.favorite
            };
            context.Friends.AddRange(new[] { JimDesireeRelationship, JimDesireeRelationshipReverse });

            var visitor1 = new Visitor
            {
                VisitDate = DateTime.Now,
                VisitBy = bart,
                VisitTo = jim,
            };

            var visitor2 = new Visitor
            {
                VisitDate = DateTime.Now,
                VisitBy = dale,
                VisitTo = jim,
            };

            var visitor3 = new Visitor
            {
                VisitDate = DateTime.Now,
                VisitBy = buffy,
                VisitTo = jim,
            };

            var visitor4 = new Visitor
            {
                VisitDate = DateTime.Now,
                VisitBy = debbie,
                VisitTo = jim,
            };

            var visitor5 = new Visitor
            {
                VisitDate = DateTime.Now,
                VisitBy = woody,
                VisitTo = jim,
            };
            context.Visitors.AddRange(new[] { visitor1, visitor2, visitor3, visitor4, visitor5 });
        }

        public static byte[] StreamImageUrlToBinary(string url)
        {
            FileStream fs = File.OpenRead(url);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
    }
}
