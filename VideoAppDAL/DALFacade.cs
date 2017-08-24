using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Repositories;

namespace VideoAppDAL
{
    public class DALFacede
    {
        public IVideoRepository VideoRepository
        {
            get
            {
                return new VideoRepositoryFakeDB();
            }
        }
    }
}
