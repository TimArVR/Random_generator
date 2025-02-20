using System.ComponentModel.DataAnnotations;

namespace RandomNumberApp.Models
{
    public class NumberRangeViewModel
    {
        [Required(ErrorMessage = "Поле 'От' обязательно для заполнения.")]
        [Range(-100, 100, ErrorMessage = "Значение 'От' должно быть в диапазоне от -100 до 100.")]
        public int From { get; set; }
        [Required(ErrorMessage = "Поле 'До' обязательно для заполнения.")]
        [Range(-100, 100, ErrorMessage = "Значение 'До' должно быть в диапазоне от -100 до 100.")]
        public int To { get; set; }
        public List<int> ShuffledNumbers { get; set; } = new List<int>();
    }
}
