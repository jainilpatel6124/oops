using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Classes
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(int id, string content, User author)
        {
            Id = id;
            Content = content;
            Author = author;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
            Console.WriteLine("Comment added.");
        }

        public void DisplayPost()
        {
            Console.WriteLine($"Post ID: {Id}, Author: {Author.Username}, Content: {Content}");
            foreach (var comment in Comments)
            {
                comment.DisplayComment();
            }
        }
    }
}
