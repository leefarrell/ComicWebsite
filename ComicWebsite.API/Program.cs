using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ComicWebsite.API;
using ComicWebsite.API.Models;
//using ComicWebsite.API.Utils;

namespace ComicWebsite.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
/* 
    	    string searchedVolume = "The Amazing Spider-Man";
            int issueNumber = 175;

            List<ComicVineIssue> comicVineIssueList = new List<ComicVineIssue>();
            ComicVineService comicVineService = new ComicVineService();
            comicVineService.ComicVineKey = "b5c2734f702dd0c406902b3108ae7890fb2c3488";

            // Xml Working
            comicVineService.SearchType = SearchType.Json;
            comicVineService.MatchType = MatchType.AbsoluteMatch;

            // Query the service
            List<ComicVineVolume> comicVinevolumes = new List<ComicVineVolume>();
            comicVinevolumes = comicVineService.SearchVolume(searchedVolume);

            if (comicVinevolumes.Count > 0)
            {
                Console.WriteLine("The query returned " + comicVinevolumes.Count.ToString() +   " results");

                foreach (ComicVineVolume volu in comicVinevolumes)
                {
                    Console.WriteLine(volu.id.ToString() + " - " + volu.name);

                    ComicVineIssue issue = new ComicVineIssue();
                    issue = comicVineService.GetComicVineIssue(volu.id, issueNumber);

                    if (issue.id >0)
                    {
                        Console.WriteLine("We have a full match!");
                        Console.WriteLine("");
                        Console.WriteLine("Title: " + issue.name);
                        Console.WriteLine("URL: " + issue.api_detail_url);
                        Console.WriteLine("Issue number: " + issue.issue_number);
                        Console.WriteLine("Id: " + issue.id);

                        Console.WriteLine("----------");
                        Console.WriteLine("# of Credits:" + issue.credits.Count.ToString());

                        foreach (ComicVineCredit credit in issue.credits)
                        {
                            Console.WriteLine(credit.name + ": " + credit.role);
                        }

                        Console.WriteLine("----------");
                        Console.WriteLine("# of Characters:" + issue.characters.Count.ToString());
                        foreach (ComicVineCharacter character in issue.characters)
                        {
                            Console.WriteLine(character.name);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The query returned 0 results");
            }
            */



        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
