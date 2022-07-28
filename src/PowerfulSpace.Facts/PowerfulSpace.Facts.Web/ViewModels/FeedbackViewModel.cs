using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewModels
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage ="{0} - Обязательное поле")]
        [StringLength(100,ErrorMessage ="Длина {0} не должна превышать {1} символ")]
        [Display(Name ="Тема сообщения")]
        public string Subject { get; set; } = null!;


        [Required(ErrorMessage = "{0} - Обязательное поле")]
        [StringLength(50, ErrorMessage = "Длина {0} не должна превышать {1} символ")]
        [Display(Name = "Имя")]
        public string UserName { get; set; } = null!;


        [Required(ErrorMessage = "{0} - Обязательное поле")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage = "{0} - неверный формат")]
        [StringLength(50, ErrorMessage = "Длина {0} не должна превышать {1} символ")]
        [Display(Name = "Email")]
        public string MailForm { get; set; } = null!;


        [Required(ErrorMessage = "{0} - Обязательное поле")]
        [StringLength(50, ErrorMessage = "Длина {0} не должна превышать {1} символ")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Текст сообщения")]
        public string Body { get; set; } = null!;


        [Required(ErrorMessage = "{0} - Обязательное поле")]
        [Display(Name = "Результат вычисления")]
        public int HumanNumber { get; set; }



        public override string ToString()
        {
            return $"Subject: {Subject} UserName: {UserName} MailForm: {MailForm} Body: {Body}";
        }

    }
}
