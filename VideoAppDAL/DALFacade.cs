using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Repositories;
using VideoAppDAL.UOW;

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

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMemory();
            }
        }
    }
}
