using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.Converter;
using VideoAppDAL;
using VideoAppUI.VideoAppBLL.BusinessObjects;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;
        VideoConverter conv = new VideoConverter();

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(conv.Convert(video));
                uow.Complete();
                return conv.Convert(newVideo);
            }
        }

        public List<VideoBO> CreateVideos(List<VideoBO> listOfVideos)
        {
            using (var uow = facade.UnitOfWork)
            {
                List<VideoBO> newListOfVideos = new List<VideoBO>();
                foreach (var VideoBO in listOfVideos)
                {
                    var newVideo = uow.VideoRepository.Create(conv.Convert(VideoBO));
                    newListOfVideos.Add(conv.Convert(newVideo));
                }
                uow.Complete();
                return newListOfVideos;
            }      
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newVideo);
            }

            //var listOfVideos = FakeDB.Videos.Where(x => x.Id == Id).ToList();
            //FakeDB.Videos.RemoveAll(x => x.Id == Id);
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //list of Videos -> VideoBO
                return uow.VideoRepository.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }

        public VideoBO Update(VideoBO video)
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
                return conv.Convert(videoFromDB);
            }
        }
    }
}
