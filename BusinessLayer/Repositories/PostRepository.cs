using BusinessLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class PostRepository : IPostRepository
    {
        DataBase db;
        public PostRepository(DataBase database) { 
        db = database;
        }
        public void createPost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }

       public void deletePost(int id)
        {
          
            db.Posts.Remove(getPostById(id));
            db.SaveChanges();
        }

        public Post getPostById(int id)
        {
            return db.Posts.FirstOrDefault(x => x.Id == id);
            
        }

        public List<Post> getPostList()
        {
            return db.Posts.OrderByDescending(post => post.Created).ToList();
        }

        public List<Post> getUserPosts(string userId)
        {
            return db.Posts.Where(p=>p.UserId==userId).OrderByDescending(p=>p.Created).ToList();
        }

        public void updatePost(Post post)
        {
            db.Posts.Update(post);
            db.SaveChanges();
        }
    }
}
