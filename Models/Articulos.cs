using System.ComponentModel.DataAnnotations;

namespace Ap1_P1_AngelGonzalez.Models;

public class Articulos
{
    //ArticuloId, Descripcion,Costo,Ganancia,precio
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "Este Campo Debe Contener una Descripción para el Artículo")]
    [RegularExpression(@"[a-zA-ZÑñ\s]+$")]
    public string? Descripcion { get; set;}

    [Required(ErrorMessage = "Este Campo Debe Contener un Costo para el Artículo")]
    [Range(0.01,1000000, ErrorMessage ="El Costo debe estar entre el siguiente Rango 0.01 hasta 1,000,000")]
    public decimal Costo { get; set; }

    [Required(ErrorMessage = "Este Campo Debe Contener una Ganancia para el Artículo")]
    [Range(0.01, 100, ErrorMessage = "El Rango de Ganancia debe tener un minimo de 0.01 hasta un 100%")]
    public decimal Ganancia { get; set; }

    [Required(ErrorMessage = "Este Campo Debe Contener un Precio de Venta para el Artículo")]
    [Range(0.01, 1000000000000, ErrorMessage = "El Costo debe estar entre el siguiente Rango 0.01 hasta 1,000,000,000,000")]
    public decimal Precio { get; set; }
}
