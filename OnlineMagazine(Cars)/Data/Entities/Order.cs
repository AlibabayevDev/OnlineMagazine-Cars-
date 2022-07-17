using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetMagazin.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Имя"),MinLength(3), MaxLength(15),Required(ErrorMessage ="Длина имени не менее 3 символов")]
        public string Name { get; set; }

        [Display(Name = "Фамилия"), MinLength(5), Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string Surname { get; set; }

        [Display(Name = "Адрес"), MinLength(5), Required(ErrorMessage = "Длина адреса не менее 5 символов")]
        public string Adress { get; set; }

        [Display(Name = "Номер"),MinLength(5), DataType(DataType.PhoneNumber), StringLength(10), Required(ErrorMessage = "Длина номера не менее 10 символов")]
        public string Phone { get; set; }

        [Display(Name = "Email"),MinLength(9), DataType(DataType.EmailAddress), StringLength(10), Required(ErrorMessage = "Длина Email не менее 10 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


    }
}
