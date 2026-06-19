using GoldClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoldClub.Controllers
{
    
    /// CRUD completo de Producto: Crear, Leer (listado y detalle),
    /// Actualizar y Eliminar (baja logica). Sin base de datos:
    /// porque no la tenemos todavia, pero se conectaria con esta parte
    public class ProductoController : Controller
    {
        private static readonly List<Producto> _productos = new();
        private static int _siguienteId = 1;

        // ---------- LISTAR (Index) ----------
                public IActionResult Index(string? busqueda)
        {
            ViewData["NavActive"] = "inventario";
            ViewData["Busqueda"] = busqueda;

            var query = _productos.Where(p => p.Activo);

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                query = query.Where(p =>
                    p.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    p.Codigo.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    p.Proveedor.Contains(busqueda, StringComparison.OrdinalIgnoreCase));
            }

            var resultado = query.OrderByDescending(p => p.FechaCreacion).ToList();
            return View(resultado);
        }

        // ---------- DETALLE ----------
        // GET /Producto/Detalle/5
        public IActionResult Detalle(int id)
        {
            ViewData["NavActive"] = "inventario";

            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();

            return View(producto);
        }

        // ---------- CREAR ----------
        // GET /Producto/Crear
        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["NavActive"] = "inventario";
            var modelo = new Producto { CreadoPor = "Juan Pérez" };
            return View(modelo);
        }

        // POST /Producto/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            ViewData["NavActive"] = "inventario";

            bool codigoDuplicado = _productos.Any(p => p.Codigo == producto.Codigo);
            if (codigoDuplicado)
            {
                ModelState.AddModelError(nameof(producto.Codigo), "Ya existe un producto con este código.");
            }

            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            producto.Id = _siguienteId++;
            producto.FechaCreacion = DateTime.Now;
            producto.Activo = true;

            _productos.Add(producto);

            TempData["MensajeExito"] = "Se ha creado con éxito el producto.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- EDITAR ----------
        // GET /Producto/Editar/5
        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["NavActive"] = "inventario";

            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null || !producto.Activo) return NotFound();

            return View(producto);
        }

        // POST /Producto/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Producto productoEditado)
        {
            ViewData["NavActive"] = "inventario";

            if (id != productoEditado.Id) return BadRequest();

            bool codigoDuplicado = _productos.Any(p => p.Codigo == productoEditado.Codigo && p.Id != id);
            if (codigoDuplicado)
            {
                ModelState.AddModelError(nameof(productoEditado.Codigo), "Ya existe otro producto con este código.");
            }

            if (!ModelState.IsValid)
            {
                return View(productoEditado);
            }

            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null || !producto.Activo) return NotFound();

            producto.Nombre = productoEditado.Nombre;
            producto.Codigo = productoEditado.Codigo;
            producto.Proveedor = productoEditado.Proveedor;
            producto.FechaActualizacion = DateTime.Now;

            TempData["MensajeExito"] = "Se ha actualizado con éxito el producto.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- ELIMINAR  ----------
        // GET /Producto/Eliminar/5, pantalla de confirmación
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            ViewData["NavActive"] = "inventario";

            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null || !producto.Activo) return NotFound();

            return View(producto);
        }

        // POST /Producto/EliminarConfirmado/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();

            
            producto.Activo = false;
            producto.FechaActualizacion = DateTime.Now;

            TempData["MensajeExito"] = "El producto se ha eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}