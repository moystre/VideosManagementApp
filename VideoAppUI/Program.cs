
﻿using System;
using System.Collections.Generic;
using VideoAppBLL;
using VideoAppUI.VideoAppBLL.BusinessObjects;

namespace VideoAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {
            #region addingStartUpVideos

            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = "Lord of the ringz",
                Genre = "Fantasy",
                Duration = 432
            });

            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = "Spongebob Firekant",
                Genre = "everything",
                Duration = 6666
            });

            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = "Letel Litelel Mermaid",
                Genre = "cortoonz",
                Duration = 92
            });

            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = "Lalalandeded",
                Genre = "comedy",
                Duration = 83
            });

            #endregion


            string[] menuItems = {
                "Show list of videos",
                "Search for video",
                "Add video",
                "Add multiple videos",
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
                        AddCreatedVideo(AddVideo());
                        break;
                    case 4:
                        AddMultipleVideos();
                        break;
                    case 5:
                        EditVideo();
                        break;
                    case 6:
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
                || selection > items.Length + 1
                || selection < 0)
            {
                Console.WriteLine("Select existing item");
            }
            return selection;
        }

        static void ShowListOfVideos()
        {
            Console.WriteLine("List of videos:");
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                ShowVideoInformation(video);
            }
            Console.WriteLine("");
        }

        static VideoBO GetVideoById()
        {
            int id;
            videoId:
            Console.WriteLine("Video Id: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Pass a number please. Try again.");
            }
            return bllFacade.VideoService.Get(id);
            //goto noSuchVideo;

            //noSuchVideo:
            Console.WriteLine($"Video with id: {id} does not exist. Try again: ");
            goto videoId;
        }

        static void ShowVideoInformation(VideoBO video)
        {
            if (video == null)
            {
                Console.WriteLine("The video does not exist. Try again.");
            }
            else
                Console.WriteLine($"{video.Id}   |   {video.Title} | {video.Genre} | {video.Duration}");
        }

        static VideoBO AddVideo()
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
            if (genre.Length == 0)
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

            VideoBO video = new VideoBO();
            video.Title = title;
            video.Genre = genre;
            video.Duration = duration;

            return video;
        }

        static void AddCreatedVideo(VideoBO video)
        {
            var newVideo = bllFacade.VideoService.Create(video);
            ShowVideoInformation(newVideo);
            Console.WriteLine($"Video {newVideo.Id} added.");
        }

        static void AddMultipleVideos()
        {
            List<VideoBO> list = new List<VideoBO>();

            addingVideo:
            Console.WriteLine("Add video:");
            list.Add(AddVideo());

            Console.WriteLine("Do you want to add next video? Type Y / N");
            var response = Console.ReadLine();
            if (response.Equals("Y") || response.Equals("y"))
            {
                goto addingVideo;
            }
            else
            {
                bllFacade.VideoService.CreateVideos(list);
                Console.WriteLine($"{list.Count} videos added.");
            }
        }

        static void EditVideo()
        {
            var video = GetVideoById();

            Console.WriteLine("Actual video information: ");
            ShowVideoInformation(video);

            if (video != null)
            {
                Console.WriteLine("Pass new information: \n");
                Console.WriteLine("Title: ");
                video.Title = Console.ReadLine();
                Console.WriteLine("Genre: ");
                video.Genre = Console.ReadLine();
                Console.WriteLine("Duration: ");
                int duration = 0;
                while (!int.TryParse(Console.ReadLine(), out duration))
                {
                    Console.WriteLine("Please pass a number.");
                }

                video.Duration = duration;
                bllFacade.VideoService.Update(video);
                Console.WriteLine("Video infomation changed");
                ShowVideoInformation(video);
            }
            else
            {
                Console.WriteLine("Video not found");
            }

        }            


        static void DeleteVideo()
        {
            var videoFound = GetVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
                var response = videoFound == null ?
               "Video not found" : $"Video {videoFound.Id} has been deleted.";
            Console.WriteLine(response);
        }


    }
}