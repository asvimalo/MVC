﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_1.Areas.Administration.Models
{
    public class PhotoViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

    }
}