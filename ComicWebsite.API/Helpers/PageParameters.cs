using System;

namespace ComicWebsite.API.Helpers
{
    public class PageParameters
    {
        private const int MaxPageSize = 30;

        public int PageNumber { get; set; } = 1;
        private int pageSize = 25;
        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value;}
        }

        public static DateTime minDate = new DateTime(1970, 1, 1);
        public static DateTime maxDate = new DateTime(2030, 12, 31);
        DateTime dateOnlyMin = minDate.Date;
        DateTime dateOnlyMax = maxDate.Date;
        public DateTime MinDate { get; set; } = minDate;
        public DateTime MaxDate { get; set; } = maxDate;
        
    }
}