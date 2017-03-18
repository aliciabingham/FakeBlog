using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FakeBlog.DAL
{
    public interface IRepository
    {
        // List of methods to help deliver features
        // Create
        void AddPost(string name, Author owner);
        void AddUser(string name, Post board);

        // Read
        List<Post> GetPostsFromList(int listId);
        Post GetPost(int postId);
        Author GetList(int authorId);
        List<Post> GetPostsFromAuthor(string authorId);
        Post GetBoard(int postId);

        // Update
        bool AttachUser(string authorId, int postId); // true: successful, false: not successful
        void EditPost(Author owner, int postId);

        // Delete
        bool RemovePost(int postId);
        bool RemoveUser(int userId);
    }
}
