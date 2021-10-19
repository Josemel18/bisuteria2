using System;

namespace Bisuteria.App.Dominio
{
    public class Venta
    {
       //atributos de la clase Venta
       public int id { get; set; }
       public DateTime fecha { get; set; }
       public string valortotal { get; set; }
       public int cliente { get; set; }
       public int medio_pago { get; set; }
       public int estado_venta { get; set; }
       
    }
}