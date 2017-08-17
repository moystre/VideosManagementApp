using System;
using System.Collections.Generic;
using VideoApplication;

namespace VideoApplication
{
    class Program
    {

        static int id = 1;
        static List<Video> videos = new List<Video>();

        static void Main(string[] args)
        {
            string[] menuItems = {
                "Show list of videos",
                "Search for video",
                "Add video",
                "Edit information about existing video",
                "Delete video",
                "Exit the application"
            };

            var selected = showMenuItems(menuItems);
            while(selected != 6)
            {
                switch (selected)
                { 
                    case 1:
                        //showListOfVideos();
                        Console.WriteLine("*showinglist*");
                        break;
                    case 2:
                        //searchForVideo();
                        Console.WriteLine("*searching*");
                        break;
                    case 3:
                        //addVideo();
                        Console.WriteLine("*adding*");
                        break;
                    case 4:
                        //editVideo();
                        Console.WriteLine("*editing*");
                        break;
                    case 5:
                        //deleteVideo();
                        Console.WriteLine("*deleting*");
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
                selected = showMenuItems(menuItems);
                
            }
            Console.WriteLine("Goodbye!");
            Console.ReadLine();//?
        }

        static int showMenuItems(string[] items)
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

        static void goBack()
        {
            Console.Write("\n\n[B] Go back\n");
           // if(ConsoleKey.B.)
        }

        //static void showListOfVideos();
        //static void searchForVideo();
        //static void addVideo();
        //static void editVideo();
        //static void deleteVideo();

    }
}