using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Bisuteria.App.Dominio;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public class Repositorios : IRepositorios
    {
        private readonly AppContext _appContext;
        public IEnumerable<Cliente> clientes {get; set;} 
        public IEnumerable<Producto> productos {get; set;} 
        public IEnumerable<Categoria> categorias {get; set;} 
        public IEnumerable<Estado_Producto> estado_productos {get; set;} 
        public IEnumerable<Material> materiales {get; set;} 
        public IEnumerable<Talla> tallas{get; set;} 

        public Repositorios(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD Cliente
        Cliente IRepositorios.AddCliente(Cliente cliente)
        {
          try
          {
            var ClienteAdicionado = _appContext.Clientes.Add( cliente ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return ClienteAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Cliente> IRepositorios.GetAllClientes(string? nombre)
        {
            if (nombre != null) {
                clientes = _appContext.Clientes.Where(p => p.nombre.Contains(nombre)); //like sobre la tabla
            }
            else 
                clientes = _appContext.Clientes;  //select * from Cliente
            return clientes;
        }

       Cliente IRepositorios.GetCliente(int? idCliente)
       {
            return _appContext.Clientes.FirstOrDefault(p => p.id == idCliente);
       }

       Cliente IRepositorios.UpdateCliente(Cliente cliente)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(p => p.id == cliente.id); //SELECT
            if (ClienteEncontrado != null)
            {
                ClienteEncontrado.identificacion  = cliente.identificacion; //
                ClienteEncontrado.nombre = cliente.nombre;
                ClienteEncontrado.apellido= cliente.apellido;
                ClienteEncontrado.direccion= cliente.direccion;
                ClienteEncontrado.telefono= cliente.telefono;
                ClienteEncontrado.correo= cliente.correo;
                _appContext.SaveChanges();  //UPDATE 
            }
            return ClienteEncontrado;
        }

        void IRepositorios.DeleteCliente(int idCliente)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(p => p.id == idCliente);
            if (ClienteEncontrado == null)
                return;
            _appContext.Clientes.Remove( ClienteEncontrado );
            _appContext.SaveChanges();
        }
    
         //CRUD Producto
        Producto IRepositorios.AddProducto(Producto producto)
        {
          try
          {
            var ProductoAdicionado = _appContext.Productos.Add( producto ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return ProductoAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Producto> IRepositorios.GetAllProductos(string? nombre)
        {
            if (nombre != null) {
              productos = _appContext.Productos.Where(p => p.nombre.Contains(nombre)); //like sobre la tabla
            }
            else 
               productos = _appContext.Productos;  //select * from producto
            return productos;
        }

       Producto IRepositorios.GetProducto(int? idProducto)
       {
            return _appContext.Productos.FirstOrDefault(p => p.id == idProducto);
       }

       Producto IRepositorios.UpdateProducto(Producto producto)
        {
            var ProductoEncontrado = _appContext.Productos.FirstOrDefault(p => p.id == producto.id); //SELECT
            if (ProductoEncontrado != null)
            {
                ProductoEncontrado.nombre = producto.nombre;
                ProductoEncontrado.preciocompra= producto.preciocompra;
                ProductoEncontrado.precioventa = producto.precioventa;
                ProductoEncontrado.stock= producto.stock;
                ProductoEncontrado.peso = producto.peso;
                _appContext.SaveChanges();  //UPDATE 
            }
            return ProductoEncontrado;
        }

        void IRepositorios.DeleteProducto(int idProducto)
        {
            var ProductoEncontrado = _appContext.Productos.FirstOrDefault(p => p.id == idProducto);
            if (ProductoEncontrado == null)
                return;
            _appContext.Productos.Remove( ProductoEncontrado );
            _appContext.SaveChanges();
        }
    

        // CRUD Categoria
        Categoria IRepositorios.AddCategoria(Categoria categoria)
        {
          try
          {
            var CategoriaAdicionado = _appContext.Categorias.Add( categoria ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return CategoriaAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Categoria> IRepositorios.GetAllCategorias(string? nombre)
        {
            if (nombre != null) {
              categorias = _appContext.Categorias.Where(p => p.nombre.Contains(nombre)); //like sobre la tabla
            }
            else 
               categorias = _appContext.Categorias;  //select * from categoria
            return categorias;
        }

       Categoria IRepositorios.GetCategoria(int? idCategoria)
       {
            return _appContext.Categorias.FirstOrDefault(p => p.id == idCategoria);
       }

       Categoria IRepositorios.UpdateCategoria(Categoria categoria)
        {
            var CategoriaEncontrado = _appContext.Categorias.FirstOrDefault(p => p.id == categoria.id); //SELECT
            if (CategoriaEncontrado != null)
            {
                CategoriaEncontrado.nombre = categoria.nombre;
                CategoriaEncontrado.descripcion = categoria.descripcion;
                _appContext.SaveChanges();  //UPDATE 
            }
            return CategoriaEncontrado;
        }

        void IRepositorios.DeleteCategoria(int idCategoria)
        {
            var CategoriaEncontrado = _appContext.Categorias.FirstOrDefault(p => p.id == idCategoria);
            if (CategoriaEncontrado == null)
                return;
            _appContext.Categorias.Remove( CategoriaEncontrado );
            _appContext.SaveChanges();
        }


        //CRUD Estado_Producto
        Estado_Producto IRepositorios.AddEstado_Producto(Estado_Producto estado_producto)
        {
          try
          {
            var Estado_ProductoAdicionado = _appContext.Estado_Productos.Add( estado_producto ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return Estado_ProductoAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Estado_Producto> IRepositorios.GetAllEstado_Productos(string? nombre)
        {
            if (nombre != null) {
              estado_productos = _appContext.Estado_Productos.Where(p => p.nombre.Contains(nombre)); //like sobre la tabla
            }
            else 
               estado_productos = _appContext.Estado_Productos;  //select * from estado_producto
            return estado_productos;
        }

       Estado_Producto IRepositorios.GetEstado_Producto(int? idEstado_Producto)
       {
            return _appContext.Estado_Productos.FirstOrDefault(p => p.id == idEstado_Producto);
       }

       Estado_Producto IRepositorios.UpdateEstado_Producto(Estado_Producto estado_producto)
        {
            var Estado_ProductoEncontrado = _appContext.Estado_Productos.FirstOrDefault(p => p.id == estado_producto.id); //SELECT
            if (Estado_ProductoEncontrado != null)
            {
                Estado_ProductoEncontrado.nombre = estado_producto.nombre;
                Estado_ProductoEncontrado.descripcion = estado_producto.descripcion;
                _appContext.SaveChanges();  //UPDATE 
            }
            return Estado_ProductoEncontrado;
        }

        void IRepositorios.DeleteEstado_Producto(int idEstado_Producto)
        {
            var Estado_ProductoEncontrado = _appContext.Estado_Productos.FirstOrDefault(p => p.id == idEstado_Producto);
            if (Estado_ProductoEncontrado == null)
                return;
            _appContext.Estado_Productos.Remove( Estado_ProductoEncontrado );
            _appContext.SaveChanges();
        }
    
        //CRUD Material
        Material IRepositorios.AddMaterial(Material material)
        {
          try
          {
            var MaterialAdicionado = _appContext.Materiales.Add( material ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return MaterialAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Material> IRepositorios.GetAllMateriales(string? nombre)
        {
            if (nombre != null) {
              materiales = _appContext.Materiales.Where(p => p.nombre.Contains(nombre)); //like sobre la tabla
            }
            else 
               materiales = _appContext.Materiales;  //select * from material
            return materiales;
        }

       Material IRepositorios.GetMaterial(int? idMaterial)
       {
            return _appContext.Materiales.FirstOrDefault(p => p.id == idMaterial);
       }

       Material IRepositorios.UpdateMaterial(Material material)
        {
            var MaterialEncontrado = _appContext.Materiales.FirstOrDefault(p => p.id == material.id); //SELECT
            if (MaterialEncontrado != null)
            {
                MaterialEncontrado.nombre = material.nombre;
                MaterialEncontrado.descripcion = material.descripcion;
                _appContext.SaveChanges();  //UPDATE 
            }
            return MaterialEncontrado;
        }

        void IRepositorios.DeleteMaterial(int idMaterial)
        {
            var MaterialEncontrado = _appContext.Materiales.FirstOrDefault(p => p.id == idMaterial);
            if (MaterialEncontrado == null)
                return;
            _appContext.Materiales.Remove( MaterialEncontrado );
            _appContext.SaveChanges();
        }
    
        //CRUD Talla
        Talla IRepositorios.AddTalla(Talla talla)
        {
          try
          {
            var TallaAdicionado = _appContext.Tallas.Add( talla ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return TallaAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Talla> IRepositorios.GetAllTallas(string? nombre)
        {
            if (nombre != null) {
              tallas = _appContext.Tallas.Where(p => p.nombre.Contains(nombre)); //like sobre la tabla
            }
            else 
               tallas = _appContext.Tallas;  //select * from talla
            return tallas;
        }

       Talla IRepositorios.GetTalla(int? idTalla)
       {
            return _appContext.Tallas.FirstOrDefault(p => p.id == idTalla);
       }

       Talla IRepositorios.UpdateTalla(Talla talla)
        {
            var TallaEncontrado = _appContext.Tallas.FirstOrDefault(p => p.id == talla.id); //SELECT
            if (TallaEncontrado != null)
            {
                TallaEncontrado.nombre = talla.nombre;
                TallaEncontrado.descripcion = talla.descripcion;
                _appContext.SaveChanges();  //UPDATE 
            }
            return TallaEncontrado;
        }

        void IRepositorios.DeleteTalla(int idTalla)
        {
            var TallaEncontrado = _appContext.Tallas.FirstOrDefault(p => p.id == idTalla);
            if (TallaEncontrado == null)
                return;
            _appContext.Tallas.Remove( TallaEncontrado );
            _appContext.SaveChanges();
        }
    
    }
}