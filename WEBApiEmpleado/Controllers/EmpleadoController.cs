using EmpleadoLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBApiEmpleado.Models;

namespace WEBApiEmpleado.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/v1/empleado")]
        public respuesta listar(string rut = "")
        {
            respuesta respuest = new respuesta();
            try
            {
                List<empleados> listado = new List<empleados>();
                empleadoEntity clienteData = new empleadoEntity();
                DataSet data = rut == "" ? clienteData.listadoEmpleados() : clienteData.listadoEmpleados(rut);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    empleados item = new empleados();
                    item.rut = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.apellido = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.mail = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[4].ToString();
                    listado.Add(item);
                }
                respuest.error = false;
                respuest.mensaje = "OK";
                if (listado.Count > 0)
                {
                    respuest.data = listado;
                }
                else
                    respuest.data = "No se encontro empleado";
                return respuest;
            }
            catch (Exception e)
            {
                respuest.error = true;
                respuest.mensaje = "Error:" + e.Message;
                respuest.data = null;
                return respuest;
            }
        }
        [HttpPost]
        [Route("api/v1/setempleado")]
        public respuesta guardar(empleados empleado)
        {
            respuesta respuest = new respuesta();
            try
            {
                empleadoEntity emp = new empleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.mail, empleado.telefono);
                int estado = emp.guardar();
                if (estado == 1)
                {
                    respuest.error = false;
                    respuest.mensaje = "el empleado fue ingresado correctamente";
                    respuest.data = empleado;
                }
                else
                {
                    respuest.error = true;
                    respuest.mensaje = "no se pudo realizar el ingreso";
                    respuest.data = null;
                }
                return respuest;
            }
            catch (Exception e)
            {
                respuest.error = true;
                respuest.mensaje = "Error:" + e.Message;
                respuest.data = null;
                return respuest;
            }
        }
        [HttpDelete]
        [Route("api/v1/deleteempleado")]
        public respuesta eliminar(string rut)
        {
            respuesta respuest = new respuesta();
            try
            {
                empleadoEntity emp = new empleadoEntity();
                emp.Rut = rut;
                int estado = emp.eliminar();
                if (estado == 1)
                {
                    respuest.error = false;
                    respuest.mensaje = "el empleado fue eliminado correctamente";
                    respuest.data = null;
                }
                else
                {
                    respuest.error = true;
                    respuest.mensaje = "No se pudo realizar la eliminación";
                    respuest.data = null;
                }
                return respuest;
            }
            catch (Exception e)
            {
                respuest.error = true;
                respuest.mensaje = "Error:" + e.Message;
                respuest.data = null;
                return respuest;
            }
        }

        [HttpPut]
        [Route("api/v1/updateempleado")]
        public respuesta update(empleados empleado)
        {
            respuesta respuest = new respuesta();
            try
            {
                empleadoEntity emp = new empleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.mail, empleado.telefono);
                int estado = emp.update(empleado.rut);
                if (estado == 1)
                {
                    respuest.error = false;
                    respuest.mensaje = "el empleado fue modificado";
                    respuest.data = empleado;
                }
                else
                {
                    respuest.error = true;
                    respuest.mensaje = "No se pudo realizar la modificación";
                    respuest.data = null;
                }
                return respuest;
            }
            catch (Exception e)
            {
                respuest.error = true;
                respuest.mensaje = "Error:" + e.Message;
                respuest.data = null;
                return respuest;
            }
        }
    }
}