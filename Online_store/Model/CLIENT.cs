using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Model
{
    
    public class CLIENT
    {
        public int Id { get; set; }

        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Фамилия\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "ФАМИЛИЯ\t\t | Введите данные\n")]
        [StringLength(20)]
        public string Surname { get; set; }

        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Имя\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "ИМЯ\t\t\t | Введите данные\n")]
        [StringLength(20)]
        public string Firstname { get; set; }

        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Область\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "ОБЛАСТЬ\t\t | Введите данные\n")]
        [StringLength(20)]
        public string Region { get; set; }

        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Город\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "ГОРОД\t\t | Введите данные\n")]
        [StringLength(20)]
        public string City { get; set; }

        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage = "Улица\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "Улица\t\t | Введите данные\n")]
        [StringLength(20)]
        public string Street { get; set; }

        [RegularExpression(@"\d*", ErrorMessage = "Номер дома\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "ДОМ\t\t | Введите данные\n")]
        [StringLength(20)]
        public string House { get; set; }

        [RegularExpression(@"\d*", ErrorMessage = "Номер квартиры\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "КВАРТИРА\t\t | Введите данные\n")]
        [StringLength(3)]
        public string Flat { get; set; }

        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
            ErrorMessage = "Email\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "EMAIL\t\t | Введите данные\n\t\t\t | Пример: wanne27@mail.ru\n")]
        [StringLength(20)]
        public string E_mail { get; set; }

        [RegularExpression(@"\d*", ErrorMessage = "НОМЕР КАРТЫ\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "НОМЕР КАРТЫ\t\t | Введите данные\n")]
        [StringLength(16)]
        public string Card { get; set; }

        [RegularExpression(@"^\+375(17|29|33|44|25)[0-9]{7}$", ErrorMessage = "МОБИЛЬНЫЙ ТЕЛЕФОН\t\t | Формат неверен\n")]
        [Required(ErrorMessage = "ТЕЛЕФОН\t\t | Введите данные.\n\t\t\t | Пример: +375291234567")]
        [StringLength(13)]
        public string Phone { get; set; }
       
    }
}
