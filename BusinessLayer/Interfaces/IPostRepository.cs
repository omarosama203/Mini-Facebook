using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPostRepository
    {
        public void createPost(Post post);
        public void updatePost(Post post);
        public void deletePost(int id);
        public Post getPostById(int id);
        public List<Post> getPostList();
        public List<Post> getUserPosts(string userId);
        
    }
}
