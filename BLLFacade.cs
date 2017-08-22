﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.Services;
using VideoAppEntity;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        //choose one of two ways

        //public IVideoService GetVideoService()
        //{
        //    return new VideoService();
        //}

        public void Create(Video video)
        {
            throw new NotImplementedException();
        }

        public IVideoService VideoService
        {
            get
            {
                    return new VideoService();
            }
        }
    }
}

