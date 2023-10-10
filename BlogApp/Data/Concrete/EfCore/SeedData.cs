using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Win32.SafeHandles;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Entity.Tag {Text = "football",Url="football",Color = Entity.TagColors.primary},
                        new Entity.Tag{Text = "stadium",Url="stadium", Color = Entity.TagColors.danger},
                        new Entity.Tag{Text = "goals",Url="goals", Color = Entity.TagColors.success},
                        new Entity.Tag{Text = "trophy",Url="trophy", Color = Entity.TagColors.warning},
                        new Entity.Tag{Text = "cups",Url="cups", Color = Entity.TagColors.info}
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User {UserName = "AlexStar", Name="Alex Vega", Email="alexvega@gmail.com",Password="123456", Image= "4.jpeg"},
                        new Entity.User {UserName = "James__34",Name="James Smith", Email="jamessmitha@gmail.com",Password="1234",Image= "5.jpeg"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Entity.Post {
                            Title = "Santiago Bernabeu",
                            Description = "Real Madrid",
                            Content = "Real Madrid",
                            Url = "santiago-bernabeu",
                            IsActive = true,
                            Image = "1.jpg",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1,
                            Comments = new List<Comment>{new Comment{Text="Amazing",PublishedOn=new DateTime(),UserId=1},
                                                         new Comment{Text="Best of the world!",PublishedOn=new DateTime(),UserId=2}}
                            },
                        new Entity.Post {
                            Title = "Old Trafford",
                            Description = "Manchester United",
                            Content = "Manchester United",
                            Url = "old-trafford",
                            IsActive = true,
                            Image = "2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1
                            },
                        new Entity.Post {
                            Title = "San Siro",
                            Description = "A.C. Milan and Inter Milan",
                            Content = "A.C. Milan and Inter Milan",
                            Url = "san-siro",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                            }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}