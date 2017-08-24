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
        IVideoRepository repository;
        public VideoService(IVideoRepository repository)
        {
            this.repository = repository;
        }

        //implementations moved to VideoRepositoryFakeDB:
        
        public Video Create(Video video)
        {
            return this.repository.Create(video);
        }

        public Video Delete(int Id)
        {
            return this.repository.Delete(Id);

            //var listOfVideos = FakeDB.Videos.Where(x => x.Id == Id).ToList();
            //FakeDB.Videos.RemoveAll(x => x.Id == Id);

        }

        public Video Get(int Id)
        {
            return this.repository.Get(Id);
        }

        public List<Video> GetAll()
        {
            return this.repository.GetAll();
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
