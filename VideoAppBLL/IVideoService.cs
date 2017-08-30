using System;
using System.Collections.Generic;
using System.Text;
using VideoAppUI.VideoAppBLL.BusinessObjects;

namespace VideoAppBLL
{
    public interface IVideoService
    {
        //C
        VideoBO Create(VideoBO video);
        List<VideoBO> CreateVideos(List<VideoBO> listOfVideos);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        //U
        VideoBO Update(VideoBO video);
        //D
        VideoBO Delete(int Id);
    }
}
