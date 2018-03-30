using System;
using System.ComponentModel.DataAnnotations;


namespace MyWebAPI.Models
{
    public class CustomerInput
    {
        [Required(ErrorMessage = "Пожалуйста, введите название журнала событий")]
        public string JournalName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите начальную дату периода выборки")]
        public DateTime FirstDate { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите конечную дату периода выборки")]
        public DateTime SecondDate { get; set; }
    }
}