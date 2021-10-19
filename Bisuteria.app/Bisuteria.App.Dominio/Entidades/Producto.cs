using System;

namespace Bisuteria.App.Dominio
{
    public class Producto
    {
       //atributos de la clase Producto
       public int id { get; set; }
       public string nombre { get; set; }
       public float preciocompra { get; set; }
       public float precioventa { get; set; }
       public int stock{ get; set; }
       public float peso { get; set; }
       public int categoria { get; set; }
       public int estado_producto { get; set; }
       public int material { get; set; }
       public int talla { get; set; }
    }
}