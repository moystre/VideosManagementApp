using System;
using System.Collections.Generic;
using System.Text;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video video);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //no update - task for UOW
        //D
        Video Delete(int Id);
        //
    }
}
