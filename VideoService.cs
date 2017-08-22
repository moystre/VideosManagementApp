using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL;
using VideoAppEntity;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        public Video Create(Video video)
        {
            Video newVideo;
            FakeDB.Videos.Add(newVideo = new Video()
            {
                Id = FakeDB.Id++,
                Title = video.Title,
                Genre = video.Genre,
                Duration = video.Duration
            });
            return newVideo;
        }

        public Video Delete(int Id)
        {
            var video = Get(Id);
            FakeDB.Videos.Remove(video);
            return video;

            //var listOfVideos = FakeDB.Videos.Where(x => x.Id == Id).ToList();
            //FakeDB.Videos.RemoveAll(x => x.Id == Id);

        }

        public Video Get(int Id)
        {
            return FakeDB.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.Videos);
        }

        public Video Update(Video video)
        {
            var videoFromDB = Get(video.Id);
            if (videoFromDB == null)
            {
                throw new InvalidOperationException("Video not found");
            }
            videoFromDB.Title = video.Title;
            videoFromDB.Genre = video.Genre;
            videoFromDB.Duration = video.Duration;
            return videoFromDB;
        }
    }
}
