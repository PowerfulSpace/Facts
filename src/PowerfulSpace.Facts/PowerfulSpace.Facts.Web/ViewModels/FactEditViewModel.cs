﻿using PowerfulSpace.Facts.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewModels
{
    public class FactEditViewModel : IHaveTags
    {
        public Guid Id { get; set; }


        [Display(Name = "Содержание факта")]
        public string Content { get; set; } = null!;

        public string ReturnUrl { get; set; } = null!;

        [Display(Name = "Метки для факта")]
        public List<string>? Tags { get; set; }

        [Range(1, 8, ErrorMessage = "Требуется от 1 до 8 меток")]
        [Display(Name = "Метки для факта")]
        public int TotalTags { get; set; }
    }
}
