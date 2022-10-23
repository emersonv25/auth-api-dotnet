using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Models.Object
{
    public class Result
    {
        private List<object> results;

        public List<object> Results
        {
            get { return results; }
            set { results = value; }
        }

        private int totalResults;

        public int TotalResults
        {
            get { return totalResults; }
            set { totalResults = value; }
        }

        private int itemsPerPage;

        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; }
        }

        private int currentPage;

        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

    }
}
