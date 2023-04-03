﻿using Microsoft.EntityFrameworkCore;
using WebAppOperacionesTDS.Data.Interface;
using WebAppOperacionesTDS.Models;

namespace WebAppOperacionesTDS.Data.DataAccess
{
    public class DAOperacion: IDAOperacion
    {
        public IEnumerable<Operacion> GetOperacion()
        {
            var Listado = new List<Operacion>();
            using(var db=new ApplicationDbContext())
            {
                Listado = db.Operacion.Include(item => item.Cliente)
                    .Include(item => item.Servicio)
                    .Include(item => item.Lugar).ToList();
            }
            return Listado;
        }
        public int InsertOperaciones(Operacion operacion)
        {
            var resultado = 0;
            using(var db=new ApplicationDbContext())
            {
                db.Add(operacion);
                db.SaveChanges();//Guardamos en la base de datos
                resultado = operacion.IdOperacion;
            }
            return resultado;//Retorna el id del registro ingresado
        }
        public Operacion GetIdOperacion(int id)
        {
            var resultado = new Operacion();
            using (var db=new ApplicationDbContext())
            {
                resultado = db.Operacion.Where(item=>item.IdOperacion == id).FirstOrDefault();
            }
            return resultado;
        } //Este código sirve para buscar una operación en la base de datos utilizando su
          //identificador único "id". Si se tiene una aplicación que registra operaciones en una
          //base de datos y se necesita recuperar información específica de una operación en
          //particular, este método puede ser útil.

        //Este codigo es necesario tanto como el details y para el edit

        public Boolean UpdateOperacion(Operacion operacion)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Operacion.Attach(operacion); // Referenciamos a la entidad
                db.Entry(operacion).State = EntityState.Modified;
                db.Entry(operacion).Property(item => item.FechaRegistro).IsModified = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }
        public Boolean DeleteTrabajos(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entity = new Operacion { IdOperacion = id };
                db.Operacion.Attach(entity);
                db.Operacion.Remove(entity);
                resultado = db.SaveChanges() != 0;

                return resultado;
            }
        }


    }
}
