using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Enums.Contact
{
    public enum ContactType
    {
        [Display(Name = "Telefon")]
        Telephone = 1,
        [Display(Name = "E-poçt")]
        Email = 2,
        [Display(Name = "Məkan")]
        Adress = 3,
        [Display(Name = "İş Saatları")]
        WorkTimes = 4
    }
}
