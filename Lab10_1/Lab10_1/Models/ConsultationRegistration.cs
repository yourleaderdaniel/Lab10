using Lab101.Models;
using System.ComponentModel.DataAnnotations;

public class ConsultationRegistration
{
    [Required(ErrorMessage = "Поле 'Имя и Фамилия' обязательно для заполнения")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Поле 'Email' обязательно для заполнения")]
    [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Поле 'Желаемая дата консультации' обязательно для заполнения")]
    [FutureDate(ErrorMessage = "Дата консультации должна быть в будущем")]
    [NonWeekendDate(ErrorMessage = "Дата консультации не должна приходиться на выходные")]
    public DateTime DesiredDate { get; set; }

    [Required(ErrorMessage = "Пожалуйста, выберите продукт")]
    public string Product { get; set; }

    // Валидация для "Основы" не по понедельникам
    [BasicsNotOnMonday(ErrorMessage = "Консультация по продукту 'Основы' не может быть по понедельникам")]
    public string ProductAndDate { get; set; }
}

public class BasicsNotOnMondayAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var registration = (ConsultationRegistration)validationContext.ObjectInstance;
        if (registration.Product == "Основы" && registration.DesiredDate.DayOfWeek == DayOfWeek.Monday)
        {
            return new ValidationResult(GetErrorMessage());
        }
        return ValidationResult.Success;
    }

    public string GetErrorMessage()
    {
        return "Консультация по продукту 'Основы' не может быть по понедельникам";
    }
}
