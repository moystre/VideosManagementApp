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
        //IVideoRepository repository;
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        //implementations moved to VideoRepositoryFakeDB:

        public Video Create(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(video);
                uow.Complete();
                return newVideo;
            }
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return newVideo;
            }

            //var listOfVideos = FakeDB.Videos.Where(x => x.Id == Id).ToList();
            //FakeDB.Videos.RemoveAll(x => x.Id == Id);

        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            }
        }

        public Video Update(Video video)
        {
            using(var uow = facade.UnitOfWork)
            {
                var videoFromDB = uow.VideoRepository.Get(video.Id);
                if (videoFromDB == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                videoFromDB.Title = video.Title;
                videoFromDB.Genre = video.Genre;
                videoFromDB.Duration = video.Duration;
                uow.Complete();
                return videoFromDB;
            }
            
            
        }
    }
}
