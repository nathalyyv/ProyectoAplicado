using Microsoft.AspNetCore.Mvc;

namespace GoldClub.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login() => View();
        public IActionResult LoginError() => View();
        public IActionResult Dashboard() => View();
        public IActionResult Menu() => View();
    }

    public class InventarioController : Controller
    {
        public IActionResult RegistrarEntrada() => View();
        public IActionResult AsignarUbicacion() => View();
        public IActionResult RegistrarSalida() => View();
        public IActionResult ConsultarMovimientos() => View();
        public IActionResult GenerarAlerta() => View();
        public IActionResult VerificarDocumentos() => View();
        public IActionResult CrearProducto() => View();
        
    }

    public class DocumentosController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult NotaDespacho() => View();
        public IActionResult ReporteIncidentes() => View();
        public IActionResult OrdenPreparacion() => View();
        public IActionResult InformeBaja() => View();
        public IActionResult ReporteImpreso() => View();
    }

    public class TareasController : Controller
    {
        public IActionResult Caducidad() => View();
    }
}
