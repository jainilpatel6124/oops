using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Classes
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }

        public Comment(int id, string content, User author)
        {
            Id = id;
            Content = content;
            Author = author;
        }

        public void DisplayComment()
        {
            Console.WriteLine($"Comment ID: {Id}, Author: {Author.Username}, Content: {Content}");
        }
    }
}
