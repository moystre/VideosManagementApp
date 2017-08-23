using System;
using System.Collections.Generic;
using System.Text;
using VideoAppEntity;

namespace VideoAppBLL
{
    public interface IVideoService
    {
        //C
        Video Create(Video video);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U
        Video Update(Video video);
        //D
        Video Delete(int Id);
    }
}
