using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext _context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Video Create(Video video)
        {
            _context.Videos.Add(video);
            return video;
        }

        public object Create()
        {
            throw new NotImplementedException();
        }

        public Video Delete(int Id)
        {
            var video = Get(Id);
            _context.Videos.Remove(video);
            return video;
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }
    }
}
