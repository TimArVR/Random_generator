using Microsoft.AspNetCore.Mvc;
using RandomNumberApp.Models;

namespace RandomNumberApp.Controllers
{
    public class HomeController : Controller
    {

        // GET: /Home/
        public IActionResult Index()
        {
            return View(new NumberRangeViewModel());
        }

        // POST: /Home/GenerateRandomNumbers
        [HttpPost]
        public IActionResult GenerateRandomNumbers(NumberRangeViewModel model)
        {
            // Проверка валидности модели
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Дополнительная проверка: From <= To
            if (model.From > model.To)
            {
                ModelState.AddModelError("", "Начальное значение должно быть меньше или равно конечному.");
                return View("Index", model);
            }

            // Генерация списка чисел в диапазоне
            List<int> numbers = new List<int>();
            for (int i = model.From; i <= model.To; i++)
            {
                numbers.Add(i);
            }

            // Перемешивание чисел в случайном порядке (алгоритм Фишера-Йетса)
            Random random = new Random();
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1); // Случайный индекс от 0 до i (иногда индекс может меняться сам с собой, это нормальное поведение, чтобы распределение было равновероятным)
                // Меняем местами элементы
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            // Сохраняем перемешанные числа в модель
            model.ShuffledNumbers = numbers;

            // Передача модели обратно в представление
            return View("Index", model);
        }
    }
}
