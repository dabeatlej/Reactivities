
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        Id = "b",
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        Id = "c",
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                     new AppUser
                    {
                        Id = "d",
                        DisplayName = "CQ_rite",
                        UserName = "clint",
                        Email = "cq@test.com"
                    },
                     new AppUser
                    {
                        Id = "e",
                        DisplayName = "Dmony",
                        UserName = "deyarni",
                        Email = "dmony@test.com"
                    },
                     new AppUser
                    {
                        Id = "f",
                        DisplayName = "Beks",
                        UserName = "becky",
                        Email = "beks@test.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Pub",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-2)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "Culture",
                        City = "Paris",
                        Venue = "The Louvre",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-1)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(-1)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "Music",
                        City = "London",
                        Venue = "Wembly Stadium",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "Food",
                        City = "London",
                        Venue = "Jamies Italian",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Pub",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(3)
                            },
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(3)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "Culture",
                        City = "London",
                        Venue = "British Museum",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(4)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Punch and Judy",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "Music",
                        City = "London",
                        Venue = "O2 Arena",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(6)
                            },
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(6)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Activity 7 months in future",
                        Category = "Travel",
                        City = "Berlin",
                        Venue = "All",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(7)
                            },
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(7)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Activity 8 months in future",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Pub",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(8)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(8)
                            },
                        }
                    },
                     new Activity
                    {
                        Title = "MusicLEJ Activity 9",
                        Date = DateTime.Now.AddMonths(9),
                        Description = "Activity 9 months in future",
                        Category = "Music",
                        City = "Kingston",
                        Venue = "Club",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "d",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(9)
                            },
                            new UserActivity
                            {
                                AppUserId = "e",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(9)
                            },
                        }
                    },
                     new Activity
                    {
                        Title = "SoundLEJ Activity 10",
                        Date = DateTime.Now.AddMonths(10),
                        Description = "Activity 10 months in future",
                        Category = "Music",
                        City = "Mandeville",
                        Venue = "Bar",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "e",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(10)
                            },
                            new UserActivity
                            {
                                AppUserId = "f",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(10)
                            },
                            new UserActivity
                            {
                                AppUserId = "d",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(10)
                            },
                        }
                   },
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}























// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Domain;
// using Microsoft.AspNetCore.Identity;

// namespace Persistence
// {
//     public class Seed
//     {
//         public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
//         {
//             if (!userManager.Users.Any())
//             {
//                 var users = new List<AppUser>
//                 {
//                     new AppUser
//                     {
//                         DisplayName = "CQ_rite",
//                         UserName = "clint",
//                         Email = "cq@test.com"
//                     },
//                      new AppUser
//                     {
//                         DisplayName = "Dmony",
//                         UserName = "deyarni",
//                         Email = "dmony@test.com"
//                     },
//                      new AppUser
//                     {
//                         DisplayName = "Beks",
//                         UserName = "becky",
//                         Email = "beks@test.com"
//                     }
//                 };

//                 foreach (var user in users)
//                 {
//                     await userManager.CreateAsync(user, "Pa$$w0rd");
//                 }
                
//             }




//             if (!context.Activities.Any())
//             {
//                 var activities = new List<Activity>
//                 {
//                     new Activity
//                     {
//                         Title = "Past Activity 1",
//                         Date = DateTime.Now.AddMonths(-2),
//                         Description = "Activity 2 months ago",
//                         Category = "drinks",
//                         City = "London",
//                         Venue = "Pub",
//                     },
//                     new Activity
//                     {
//                         Title = "Past Activity 2",
//                         Date = DateTime.Now.AddMonths(-1),
//                         Description = "Activity 1 month ago",
//                         Category = "culture",
//                         City = "Paris",
//                         Venue = "Louvre",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 1",
//                         Date = DateTime.Now.AddMonths(1),
//                         Description = "Activity 1 month in future",
//                         Category = "culture",
//                         City = "London",
//                         Venue = "Natural History Museum",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 2",
//                         Date = DateTime.Now.AddMonths(2),
//                         Description = "Activity 2 months in future",
//                         Category = "music",
//                         City = "London",
//                         Venue = "O2 Arena",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 3",
//                         Date = DateTime.Now.AddMonths(3),
//                         Description = "Activity 3 months in future",
//                         Category = "drinks",
//                         City = "London",
//                         Venue = "Another pub",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 4",
//                         Date = DateTime.Now.AddMonths(4),
//                         Description = "Activity 4 months in future",
//                         Category = "drinks",
//                         City = "London",
//                         Venue = "Yet another pub",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 5",
//                         Date = DateTime.Now.AddMonths(5),
//                         Description = "Activity 5 months in future",
//                         Category = "drinks",
//                         City = "London",
//                         Venue = "Just another pub",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 6",
//                         Date = DateTime.Now.AddMonths(6),
//                         Description = "Activity 6 months in future",
//                         Category = "music",
//                         City = "London",
//                         Venue = "Roundhouse Camden",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 7",
//                         Date = DateTime.Now.AddMonths(7),
//                         Description = "Activity 2 months ago",
//                         Category = "travel",
//                         City = "London",
//                         Venue = "Somewhere on the Thames",
//                     },
//                     new Activity
//                     {
//                         Title = "Future Activity 8",
//                         Date = DateTime.Now.AddMonths(8),
//                         Description = "Activity 8 months in future",
//                         Category = "film",
//                         City = "London",
//                         Venue = "Cinema",
//                     }
//                 };

//                 context.Activities.AddRange(activities);
//                 context.SaveChanges();
//             }


//         }
//     }
// }