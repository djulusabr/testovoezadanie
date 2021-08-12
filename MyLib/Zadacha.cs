using System;
using System.ComponentModel.DataAnnotations;

namespace MyLib
{
    public class Zadacha
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Due date time")]
        public DateTime DueDateTime { get; set; }
        [Display(Name = "Выполнена")]
        public bool IsComplete { get; set; }

        public Zadacha()
        {

        }
    }
}
