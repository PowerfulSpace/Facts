﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewModels
{
    public class ManualNotificationViewModel
    {
        [Required(ErrorMessage = "{0} - обязательное поле")]
        [StringLength(100, ErrorMessage = "Длина {0} не должна превышать {1} символов")]
        [Display(Name = "Тема сообщения")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "{0} - обязательное поле")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        [StringLength(50, ErrorMessage = "Длина {0} не должна превышать {1} символов")]
        [Display(Name = "Email КОМУ")]
        public string? MailTo { get; set; }

        [Required(ErrorMessage = "{0} - обязательное поле")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        [StringLength(50, ErrorMessage = "Длина {0} не должна превышать {1} символов")]
        [Display(Name = "Email ОТ")]
        public string? MailFrom { get; set; }

        [Required(ErrorMessage = "{0} - обязательное поле")]
        [StringLength(2000, ErrorMessage = "Длина {0} не должна превышать {1} символов")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Текст сообщения")]
        public string? Body { get; set; }
    }
}
