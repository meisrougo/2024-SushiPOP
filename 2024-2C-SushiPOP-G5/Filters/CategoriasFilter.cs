using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using _2024_2C_SushiPOP_G5.Models;
using Microsoft.EntityFrameworkCore;

public class CategoriasFilter : IActionFilter
{
    private readonly DbContext _context;

    public CategoriasFilter(DbContext context)
    {
        _context = context;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Llenar el ViewBag con las categorías antes de ejecutar cualquier acción
        var controller = context.Controller as Controller;
        if (controller != null)
        {
            controller.ViewBag.Categorias = _context.Set<Categoria>().ToList();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
