using System;

namespace Bisuteria.App.Dominio
{
    public class Cliente
    {
        //atributos de la tabla clientes
        public int id { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
    }
}