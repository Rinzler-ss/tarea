using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appWeb._3.Dominio.Entidad;
using appWeb._4.Infraestructura.Repositorio;

namespace appWeb._1.UserInterface.Web
{
    public class HerramientaController : Controller
    {
        private herramientaDAO herramientaDAO;
        private categoriaDAO categoriaDAO;

        public HerramientaController()
        {
            herramientaDAO = new herramientaDAO();
            categoriaDAO = new categoriaDAO();
        }

        // GET: Herramienta
        public ActionResult Index()
        {
            try
            {
                List<Herramienta> listaHerramientas = herramientaDAO.Listado();
                return View(listaHerramientas);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar las herramientas: " + ex.Message;
                return View(new List<Herramienta>());
            }
        }

        // GET: Herramienta/Agregar
        public ActionResult Agregar()
        {
            try
            {
                ViewBag.categorias = categoriaDAO.Listado();
                return View(new Herramienta());
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar las categorías: " + ex.Message;
                return View(new Herramienta());
            }
        }

        // POST: Herramienta/Agregar
        [HttpPost]
        public ActionResult Agregar(Herramienta herramienta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool resultado = herramientaDAO.Agregar(herramienta);
                    if (resultado)
                    {
                        ViewBag.Mensaje = "Herramienta agregada exitosamente.";
                        ViewBag.TipoMensaje = "success";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo agregar la herramienta.";
                        ViewBag.TipoMensaje = "error";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Por favor, complete todos los campos correctamente.";
                    ViewBag.TipoMensaje = "warning";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error al agregar la herramienta: " + ex.Message;
                ViewBag.TipoMensaje = "error";
            }

            ViewBag.categorias = categoriaDAO.Listado();
            return View(herramienta);
        }

        // GET: Herramienta/Editar/id
        public ActionResult Editar(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("Index");
                }

                Herramienta herramienta = herramientaDAO.BuscarPorId(id);
                if (herramienta == null)
                {
                    ViewBag.Error = "Herramienta no encontrada.";
                    return RedirectToAction("Index");
                }

                ViewBag.categorias = categoriaDAO.Listado();
                return View(herramienta);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar la herramienta: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Herramienta/Editar
        [HttpPost]
        public ActionResult Editar(Herramienta herramienta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool resultado = herramientaDAO.Actualizar(herramienta);
                    if (resultado)
                    {
                        ViewBag.Mensaje = "Herramienta actualizada exitosamente.";
                        ViewBag.TipoMensaje = "success";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo actualizar la herramienta.";
                        ViewBag.TipoMensaje = "error";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Por favor, complete todos los campos correctamente.";
                    ViewBag.TipoMensaje = "warning";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error al actualizar la herramienta: " + ex.Message;
                ViewBag.TipoMensaje = "error";
            }

            ViewBag.categorias = categoriaDAO.Listado();
            return View(herramienta);
        }
    }
}