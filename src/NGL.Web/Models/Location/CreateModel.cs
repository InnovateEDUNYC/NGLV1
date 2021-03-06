﻿using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Location
{
    public class CreateModel
    {
        [Required]
        [StringLength(20)]
        public string ClassroomIdentificationCode { get; set; }

        public int? MaximumNumberOfSeats { get; set; }

        public int? OptimalNumberOfSeats { get; set; }

    }
}