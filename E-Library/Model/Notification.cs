﻿using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class Notification
    {
        [Key]
        public int Notification_ID { get; set; }
        public string Receiver { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
