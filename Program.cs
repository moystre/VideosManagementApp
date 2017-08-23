using System;
using System.Collections.Generic;
using VideoApplication;

namespace VideoApplication
{
    class Program
    {
        #region FakeDB
        static int id = 1;
        static List<Video> videos = new List<Video>();
        #endregion

        static void Main(string[] args)
        {
            videos.Add(new Video()
            {
                Id = id++,
                Title = "Lord of the ringz",
                Genre = "Fantasy",
                Duration = 432
            });

            videos.Add(new Video()
            {
                Id = id++,
                Title = "Spongebob Firekant",
                Genre = "everything",
                Duration = 6666
            });

            videos.Add(new Video()
            {
                Id = id++,
                Title = "Letel Litelel Mermaid",
                Genre = "cortoonz",
                Duration = 92
            });

            videos.Add(new Video()
            {
                Id = id++,
                Title = "Lalalandeded",
                Genre = "comedy",
                Duration = 83
            });

            string[] menuItems = {
                "Show list of videos",
                "Search for video",
                "Add video",
                "Edit information about existing video",
                "Delete video",
                "Exit the application"
            };

            var selected = ShowMenuItems(menuItems);
            while (selected != 6)
            {
                switch (selected)
                {
                    case 1:
                        ShowListOfVideos();
                        break;
                    case 2:
                        ShowVideoInformation(GetVideoById());
                        break;
                    case 3:
                        AddVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;
                    case 5:
                        DeleteVideo();
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
                selected = ShowMenuItems(menuItems);

            }
            Console.WriteLine("Goodbye!");
        }

        static int ShowMenuItems(string[] items)
        {
            Console.Clear();
            Console.Write("Select what you want to do: \n\n");
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write($"[{i + 1}] {items[i]}\n");
            }
            Console.Write("\n");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection > items.Length
                || selection < 0)
            {
                Console.WriteLine("Select existing item");
            }
            return selection;
        }

        static void ShowListOfVideos()
        {
            Console.WriteLine("List of videos:");
            foreach (var video in videos)
            {
                ShowVideoInformation(video);
            }
            Console.WriteLine("");
        }

        static Video GetVideoById()
        {
            int id;
            videoId:
            Console.WriteLine("Video Id: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Pass a number please. Try again.");
            }
            foreach (var video in videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            goto noSuchVideo;

            noSuchVideo:
            Console.WriteLine($"Video with id: {id} does not exist. Try again: ");
            goto videoId;
        }

        static void ShowVideoInformation(Video video)
        {
            if (video == null)
            {
                Console.WriteLine("The video does not exist. Try again.");
            }
            else
            Console.WriteLine($"{video.Id}   |   {video.Title} | {video.Genre} | {video.Duration}");
        }

        static void AddVideo()
        {
            Console.WriteLine("Title: ");
            emptyName:
            var title = Console.ReadLine();
            if (title.Length == 0)
            {
                Console.WriteLine("You have to insert a title. Try again: ");
                goto emptyName;
            }
            
            Console.WriteLine("Genre: ");
            emptyGenere:
            var genre = Console.ReadLine();
            if(genre.Length == 0)
            {
                Console.WriteLine("You have to insert a genre. Try again: ");
                goto emptyGenere;
            }
            Console.WriteLine("Duration: ");
            var duration = 0;
            while (!int.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Please insert a number.");
            }

            var video = new Video()
            {
                Id = id++,
                Title = title,
                Genre = genre,
                Duration = duration
            };
            videos.Add(video);

            ShowVideoInformation(video);
            Console.WriteLine($"Video {id-1} added.");
        }

        static void EditVideo()
        {
            var video = GetVideoById();

            Console.WriteLine("Actual video information: ");
            ShowVideoInformation(video);

            Console.WriteLine("Pass new information: \n");
            Console.WriteLine("Title: ");
            video.Title = Console.ReadLine();
            Console.WriteLine("Genre: ");
            video.Genre = Console.ReadLine();
            Console.WriteLine("Duration: ");
            int duration = 0;
            while (!int.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Please pass a nymber.");
            }

            video.Duration = duration;

            Console.WriteLine("Video infomation changed");
            ShowVideoInformation(video);
        }

        static void DeleteVideo()
        {
            var video = GetVideoById();
            int id = video.Id;
            if(video != null)
            {
                videos.Remove(video);
            }
            Console.WriteLine($"Video {id} has been deleted.");
        }

    }
}