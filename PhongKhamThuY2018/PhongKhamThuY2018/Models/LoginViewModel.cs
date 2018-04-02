using System.ComponentModel.DataAnnotations;

namespace PhongKhamThuY2018.Models
{

    //trên cái View nè mình tạo ra cái này để nhận vào các biến r truyền vào cái Models DB
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string  Pass { get; set; }

    }
}