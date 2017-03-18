using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;
using Moq;
using FakeBlog.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace FakeBlog.Tests.Controllers
{
    [TestClass]
    public class FakeBlogRepoTests
    {
        public Mock<FakeBlogContext> fake_context { get; set; }
        public FakeBlogRepository repo { get; set; }
        public Mock<DbSet<Post>> mock_posts_set { get; set; }
        public IQueryable<Post> query_posts { get; set; }
        public List<Post> fake_post_table { get; set; }
        public Author sally { get; set; }
        public Author sammy { get; set; }


        [TestInitialize]
        public void Setup()
        {
            fake_post_table = new List<Post>();
            fake_context = new Mock<FakeBlogContext>();
            mock_posts_set = new Mock<DbSet<Post>>();
            repo = new FakeBlogRepository(fake_context.Object);

            sally = new Author { Id = "sally-id-1" };
            sammy = new Author { Id = "sammy-id-1" };
        }

        public void CreateFakeDatabase()
        {
            query_posts = fake_post_table.AsQueryable(); // Re-express this list as something that understands queries

            // Hey LINQ, use the Provider from our *cough* fake *cough* board table/list
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.Provider).Returns(query_posts.Provider);
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.Expression).Returns(query_posts.Expression);
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.ElementType).Returns(query_posts.ElementType);
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.GetEnumerator()).Returns(() => query_posts.GetEnumerator());

            mock_posts_set.Setup(b => b.Add(It.IsAny<Post>())).Callback((Post post) => fake_post_table.Add(post));

            mock_posts_set.Setup(b => b.Remove(It.IsAny<Post>())).Callback((Post post) => fake_post_table.Remove(post));

            fake_context.Setup(c => c.Posts).Returns(mock_posts_set.Object); 
        }
        [TestMethod]
        public void EnsureICanAddPost()
        {
            // Arrange
            CreateFakeDatabase();

            Author a_user = new Author
            {
                Id = "my-user-id",
                Username = "Sammy",
                Email = "sammy@gmail.com"
            };

            // Act
            repo.AddPost("My Board", a_user);

            // Assert
            Assert.AreEqual(1, repo.Context.Posts.Count());
        }
    }
}


//Add post, add user, attach user, edit post, get board, get list, get post, get posts from author, get posts from list, remove user, remove post