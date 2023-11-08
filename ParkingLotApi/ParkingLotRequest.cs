﻿using System.ComponentModel.DataAnnotations;

namespace ParkingLotApi
{
    public class ParkingLotRequest
    {
        [Required]
        public string Name { get; set; }

        [Range(10, int.MaxValue, ErrorMessage = "Capacity must greater than 10")]
        public int Capacity { get; set; }

        public string Location { get; set; }
    }
}