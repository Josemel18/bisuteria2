using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bisuteria.App.Dominio;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public interface IRepositorios
    {
        // contraos de cliente
        Cliente AddCliente(Cliente cliente);
        IEnumerable<Cliente> GetAllClientes(string? nombre);         
        Cliente GetCliente (int? idCliente);
        Cliente UpdateCliente(Cliente cliente);
        void DeleteCliente(int idCliente); 

        // contratos de productos
        Producto AddProducto(Producto producto);
        IEnumerable<Producto> GetAllProductos(string? nombre);         
        Producto GetProducto(int? idProducto);
        Producto UpdateProducto(Producto producto);
        void DeleteProducto(int idProducto); 

        // contratos de categoria
        Categoria AddCategoria(Categoria categoria);
        IEnumerable<Categoria> GetAllCategorias(string? nombre);         
        Categoria GetCategoria(int? idCategoria);
        Categoria UpdateCategoria(Categoria categoria);
        void DeleteCategoria(int idCategoria); 

        // contratos de Estado_Producto
        Estado_Producto AddEstado_Producto(Estado_Producto estado_producto);
        IEnumerable<Estado_Producto> GetAllEstado_Productos(string? nombre);         
        Estado_Producto GetEstado_Producto(int? idEstado_Producto);
        Estado_Producto UpdateEstado_Producto(Estado_Producto estado_producto);
        void DeleteEstado_Producto(int idEstado_Producto); 

        // contratos de material
        Material AddMaterial(Material material);
        IEnumerable<Material> GetAllMateriales(string? nombre);         
        Material GetMaterial(int? idMaterial);
        Material UpdateMaterial(Material material);
        void DeleteMaterial(int idMaterial); 

        // contrados de Talla
        Talla AddTalla(Talla talla);
        IEnumerable<Talla> GetAllTallas(string? nombre);         
        Talla GetTalla(int? idTalla);
        Talla UpdateTalla(Talla talla);
        void DeleteTalla(int idTalla); 

    }
}