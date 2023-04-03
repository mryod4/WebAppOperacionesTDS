using System.ComponentModel.DataAnnotations;

namespace WebAppOperacionesTDS.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Display(Name = "Razon Social")]
        [Required(ErrorMessage = "Debe ingresar la razon social del cliente")]
        [MaxLength(129, ErrorMessage = "El campo no debe de tener mas de 120 caracteres")]
        public string RazonSocial { get; set; }

        [Display(Name = "RUC")]
        [Required(ErrorMessage = "Debe Ingresar el RUC del cliente")]
        public int RUC { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Debe ingresar la direccion social del cliente")]
        [MaxLength(129, ErrorMessage = "El campo no debe de tener mas de 120 caracteres")]
        public string Direccion { get; set; }

        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
