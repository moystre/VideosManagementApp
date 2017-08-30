using System;
using System.Collections.Generic;
using System.Text;
using VideoAppUI.VideoAppBLL.BusinessObjects;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    class VideoConverter
    {
        internal Video Convert(VideoBO videoBO)
        {
            return new Video()
            {
                Id = videoBO.Id,
                Title = videoBO.Title,
                Genre = videoBO.Genre,
                Duration = videoBO.Duration
            };
        }

        internal VideoBO Convert(Video video)
        {
            return new VideoBO()
            {
                Id = video.Id,
                Title = video.Title,
                Genre = video.Genre,
                Duration = video.Duration
            };
        }
    }
}
