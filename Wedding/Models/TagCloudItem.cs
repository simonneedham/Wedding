using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedding.Models
{
    public class TagCloudItem
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public int TotalTagCount { get; set; }

        public TagCloudItem()
        {
        }

        public TagCloudItem(int totalTagCount, int count, string name)
        {
            this.TotalTagCount = totalTagCount;
            this.Count = count;
            this.Name = name;
        }

        public int Rank
        {
            get
            {
                if(this.TotalTagCount <= 0)
                    return 1;

                var rank = (double)this.Count / (double)this.TotalTagCount * 100.0;

                if(rank <= 1)
                    return 1;

                if(rank <= 4)
                    return 2;

                if(rank <= 8)
                    return 3;

                if(rank <= 12)
                    return 4;

                if(rank <= 18)
                    return 5;

                if (rank <= 30)
                    return 6;

                return rank <= 50 ? 7 : 8;

            }
        }
    }
}