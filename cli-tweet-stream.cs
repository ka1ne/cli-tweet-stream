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
            Auth.SetUserCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_SECRET");

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