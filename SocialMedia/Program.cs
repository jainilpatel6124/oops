using SocialMedia.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Post> posts = new List<Post>();
            int userIdCounter = 1;
            int postIdCounter = 1;
            int commentIdCounter = 1;

            while (true)
            {
                Console.WriteLine("\nSocial Media Platform");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Post");
                Console.WriteLine("3. Comment on Post");
                Console.WriteLine("4. Display Posts");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Create User
                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();

                        User user = new User(userIdCounter++, username);
                        users.Add(user);
                        Console.WriteLine("User created.");
                        break;

                    case 2:
                        // Create Post
                        Console.WriteLine("Available Users:");
                        foreach (var usr in users)
                        {
                            Console.WriteLine($"User ID: {usr.Id}, Username: {usr.Username}");
                        }

                        Console.Write("Enter User ID to create post: ");
                        int userIdForPost = int.Parse(Console.ReadLine());
                        var postAuthor = users.Find(u => u.Id == userIdForPost);

                        if (postAuthor != null)
                        {
                            Console.Write("Enter Post Content: ");
                            string postContent = Console.ReadLine();

                            Post post = new Post(postIdCounter++, postContent, postAuthor);
                            posts.Add(post);
                            Console.WriteLine("Post created.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                        break;

                    case 3:
                        // Comment on Post
                        Console.WriteLine("Available Posts:");
                        foreach (var post in posts)
                        {
                            post.DisplayPost();
                        }

                        Console.Write("Enter Post ID to comment on: ");
                        int postIdForComment = int.Parse(Console.ReadLine());
                        var postToComment = posts.Find(p => p.Id == postIdForComment);

                        if (postToComment != null)
                        {
                            Console.WriteLine("Available Users:");
                            foreach (var usr in users)
                            {
                                Console.WriteLine($"User ID: {usr.Id}, Username: {usr.Username}");
                            }

                            Console.Write("Enter User ID to comment: ");
                            int userIdForComment = int.Parse(Console.ReadLine());
                            var commentAuthor = users.Find(u => u.Id == userIdForComment);

                            if (commentAuthor != null)
                            {
                                Console.Write("Enter Comment Content: ");
                                string commentContent = Console.ReadLine();

                                Comment comment = new Comment(commentIdCounter++, commentContent, commentAuthor);
                                postToComment.AddComment(comment);
                                Console.WriteLine("Comment added.");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Post not found.");
                        }
                        break;

                    case 4:
                        // Display Posts
                        foreach (var post in posts)
                        {
                            post.DisplayPost();
                        }
                        break;

                    case 5:
                        // Exit
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
