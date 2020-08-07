using System;
using Tweetinvi;
using Tweetinvi.Models;

namespace cli_tweet_stream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Twitter API authentication
            Auth.SetUserCredentials("8dE5BOtZaoiblZ0KOHXDNsug5", "zph6ivL7vcOQZAXSxao4sdPs8Sg7mNjbtusR3rRmw19VvYPk7a", "300408799-Smd6y0BHL4TuKs92ZKTaqYEeVP2364EZJFR9fQiM", "66QGvO7BjicQF0h512c4yAOoubqgw3ANsMZcNg6FuzITg");

            var stream = Stream.CreateFilteredStream();

            // adding track (NBA is what we are looking for here)
            stream.AddTrack("NBA");
            stream.AddTweetLanguageFilter(LanguageFilter.English);

            // when we find a match
            stream.MatchingTweetReceived += (sender, theTweet) =>
            {
                Console.WriteLine("\n");
                Console.WriteLine($"{theTweet.Tweet}");

            };
            
            stream.StartStreamMatchingAllConditions();
        }
    }
}