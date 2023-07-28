using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BBG.Monolit.Models.ViewModels.Commons
{
    public enum Months
    {
        [Display(Name="Январь")]
        January = 1,
        [Display(Name = "Февраль")]
        February,
        [Display(Name = "Март")]
        March,
        [Display(Name = "Апрель")]
        April,
        [Display(Name = "Май")]
        May,
        [Display(Name = "Июнь")]
        June,
        [Display(Name = "Июль")]
        July,
        [Display(Name = "Август")]
        August,
        [Display(Name = "Сентябрь")]
        September,
        [Display(Name = "Октябрь")]
        October,
        [Display(Name = "Ноябрь")]
        November,
        [Display(Name = "Декабрь")]
        December,
    }
}
