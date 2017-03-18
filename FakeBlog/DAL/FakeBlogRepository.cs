using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {

        public FakeBlogContext Context { get; set; }
        //private FakeTrelloContext context; // Data member

        public FakeBlogRepository()
        {
            Context = new FakeBlogContext();
        }

        public FakeBlogRepository(FakeBlogContext context)
        {
            Context = context;
        }

        public void AddPost(string title, Author author)
        {
            
                Post post = new Post { Title = title,  author = author};
                Context.Posts.Add(post);
                Context.SaveChanges();
        }

        public void AddUser(string name, Post board)
        {
            throw new NotImplementedException();
        }

        public bool AttachUser(string authorId, int postId)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Author owner, int postId)
        {
            throw new NotImplementedException();
        }

        public Post GetBoard(int postId)
        {
            throw new NotImplementedException();
        }

        public Author GetList(int authorId)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsFromAuthor(string authorId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsFromList(int listId)
        {
            throw new NotImplementedException();
        }

        public bool RemovePost(int postId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}