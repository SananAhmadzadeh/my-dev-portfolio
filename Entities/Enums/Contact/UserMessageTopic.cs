using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Enums.Contact
{
    public enum Topic
    {
        [Display(Name = "Ümumi Sual")]
        GeneralQuestions = 1,
        [Display(Name = "Kurs Haqqında")]
        AboutCourse = 2,
        [Display(Name = "Qeydiyyat")]
        Registration = 3,
        [Display(Name = "Ödəniş")]
        Payment = 4,
        [Display(Name = "Əməkdaşlıq")]
        Collaboration = 5,
        [Display(Name = "Digər")]
        Other = 6
    }
}
