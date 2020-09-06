using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Subscription
    {
        [Key]
        public int subscriptionId { get; set; }

        public DateTime dateTime { get; set; }

        public virtual User user { get; set; }

        public int userId { get; set; }

        public int storyId { get; set; }

        public int episodeId { get; set; }
    }
}
