using System;

namespace WhatsLeft.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public DateTime NextPayDay { get; set; }
    }
}
