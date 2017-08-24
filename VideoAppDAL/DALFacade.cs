using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Repositories;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
                //return new VideoRepositoryFakeDB();
                get 
                {
                    //returning inmemory repository
                    return new VideoRepositoryEFMemory(new Context.InMemoryContext());
                }
        }
    }
}
