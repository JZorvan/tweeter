using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweeter.Models;

namespace Tweeter.DAL
{
    public class TweeterRepository
    {
        // Set up Repo/Context
        public TweeterContext Context { get; set; }

        public TweeterRepository()
        {
            Context = new TweeterContext();
        }

        public TweeterRepository(TweeterContext _context)
        {
            Context = _context;
        }

        // Gets a List of all Usernames
        public List<string> GetUsernames()
        {
            return Context.TweeterUsers.Select(u => u.BaseUser.UserName).ToList();
        }

        // Add a user to DB
        public void AddUser(ApplicationUser username)
        {
            Twit user = new Twit { BaseUser = username };
            Context.TweeterUsers.Add(user);
            Context.SaveChanges();
        }

        // Boolean - checks if a username is in use already
        public bool CheckUserNameExists(string username)
        {
            Twit found_user = Context.TweeterUsers.FirstOrDefault(a => a.BaseUser.UserName.ToLower() == username.ToLower());
            if (found_user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Add a Tweet
        public void AddTweet(Tweet newTweet)
        {
            Context.Tweets.Add(newTweet);
            Context.SaveChanges();
        }

        // Add Tweet by Content
        public void AddTweet(string username, string content)
        {
            Twit found_user = Context.TweeterUsers.FirstOrDefault(u => u.BaseUser.UserName == username);
            if (found_user != null)
            {
                Tweet new_tweet = new Tweet
                {
                    Message = content,
                    CreatedAt = DateTime.Now,
                    Author = found_user
                };
                Context.Tweets.Add(new_tweet);
                Context.SaveChanges();
            }
        }

        // Delete a Tweet
        public Tweet DeleteTweet(int id)
        {
            Tweet found_tweet = Context.Tweets.FirstOrDefault(t => t.TweetId == id);
            if (found_tweet != null)
            {
                Context.Tweets.Remove(found_tweet);
                Context.SaveChanges();
            }
            return found_tweet;
        }
         
        // Get all Tweets
        public List<Tweet> GetAllTweets()
        {
            return Context.Tweets.ToList();
        }
    }
}