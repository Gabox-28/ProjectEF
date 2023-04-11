using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    private ITareasServices tareasService;

    public TareaController(ITareasServices service)
    {
        tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareasService.Save(tarea);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Post(Guid id, [FromBody] Tarea tarea)
    {
        tareasService.Update(id, tarea);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Post(Guid id)
    {
        tareasService.Delete(id);
        return Ok();
    }
}