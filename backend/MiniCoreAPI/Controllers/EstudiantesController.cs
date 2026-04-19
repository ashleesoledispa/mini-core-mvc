using Microsoft.AspNetCore.Mvc;
using MiniCoreAPI.Models;

namespace MiniCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Calcular(Estudiante estudiante)
        {
            double promedio = (estudiante.Progreso1 * 0.25) +
                              (estudiante.Progreso2 * 0.35) +
                              (estudiante.Progreso3 * 0.40);

            bool aprueba = promedio >= 6;

            double necesarioP3 = 0;

            if (!aprueba)
            {
                necesarioP3 = (6 - (estudiante.Progreso1 * 0.25 + estudiante.Progreso2 * 0.35)) / 0.40;
            }

            return Ok(new
            {
                estudiante.Nombre,
                promedio,
                aprueba,
                necesarioP3
            });
        }
    }
}