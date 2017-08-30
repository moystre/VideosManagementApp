using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    // made for communicating with a list of data in memory
    class VideoRepositoryFakeDB : IVideoRepository
    {
        #region FakeDB
        private static int Id = 1;
        private static List<Video> Videos = new List<Video>();
        #endregion

        public Video Create(Video video)
        {
            Video newVideo;
            Videos.Add(newVideo = new Video()
            {
                Id = Id++,
                Title = video.Title,
                Genre = video.Genre,
                Duration = video.Duration
            });
            return newVideo;
        }

        public Video Delete(int Id)
        {
            var video = Get(Id);
            Videos.Remove(video);
            return video;
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }
    }
}
