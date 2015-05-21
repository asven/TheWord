using SubSonic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheWord.Models;

namespace TheWord.Common
{
    public static class GaryPostManager
    {
        public static SimpleRepository repo = new SimpleRepository("TheWord");

        public static List<GaryPost> GetUsersPosts(string userId)
        {
            List<GaryPost> garyPosts = repo.All<GaryPost>().Where(gp => gp.ByUser == userId).OrderByDescending(gp => gp.PostedDate).ToList();
            if (userId == "asven")
            {
                garyPosts.AddRange(repo.All<GaryPost>().Where(gp => gp.ByUser != userId).OrderByDescending(gp => gp.PostedDate));
            }
            return garyPosts;
        }


        public static GaryPost GetPostById(int garyPostId)
        {
            GaryPost garyPost = repo.All<GaryPost>().Where(gp => gp.ID == garyPostId).FirstOrDefault();
            return garyPost;
        }

        public static List<GaryPost> GetAllPosts()
        {
            List<GaryPost> garyPosts = repo.All<GaryPost>().OrderByDescending(gp => gp.PostedDate).ToList();
            return garyPosts;
        }

        public static void SavePost(GaryPost garyPost, string userId)
        {
            garyPost.PostedDate = DateTime.Now;
            garyPost.ByUser = userId;

            if (garyPost.ID == 0)
            {

                repo.Add(garyPost);
            }
            else
            {
                repo.Update(garyPost);
            }
        }

        public static void DeletePost(int garyPostId)
        {
            repo.Delete<GaryPost>(garyPostId);
        }
    }
}