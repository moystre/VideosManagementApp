using System;
using System.Collections.Generic;
using System.Text;
using VideoAppEntity;

namespace VideoAppDAL
{
    public class FakeDB
    {
        #region FakeDB
        public static int Id = 1;
        public static List<Video> Videos = new List<Video>();
        #endregion
    }
}
