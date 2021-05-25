using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_store.Model
{
    [Serializable]
    public class USER
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ЛОГИН\t\t | Введите данные\n")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_]*$", ErrorMessage = "ЛОГИН\t\t | Формат неверен.\nЛогин должен начинаться с буквы, может содержать символы латинского алфавита, цифры, нижнее подчеркивание.\n")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "ЛОГИН\t\t | Минимальная длина 4 символа\n")]
        public string Login { get; set; }

        [Required(ErrorMessage = "ПАРОЛЬ\t\t | Введите данные\n")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "\nПАРОЛЬ\t\t | Минимальная длина 4 символа\n")]
        //[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "\nПАРОЛЬ\t\t | Формат неверен.\nПароль может содержать символы латинского алфавита, цифры.\nМинимальная длина: 4 символа\n")]        
        public string Password { get; set; }
        public string Role { get; set; }
        public int? ClientId { get; set; }
        public virtual CLIENT Client { get; set; }
        public static USER CurrentUser { get; set; }

    }
}
