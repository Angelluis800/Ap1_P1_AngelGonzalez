using Ap1_P1_AngelGonzalez.DAL;
using Ap1_P1_AngelGonzalez.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ap1_P1_AngelGonzalez.Services;

public class ArticuloService
{
    private readonly Contexto _contexto;

    public ArticuloService(Contexto contexto) {  _contexto = contexto; }

    public async Task<bool> Guardar(Articulos articulo)
    {
        if (!await Existe(articulo.ArticuloId))
            return await Insertar(articulo);
        else
            return await Modificar(articulo);
    }

    public async Task<bool> Insertar(Articulos articulos)
    {
        _contexto.Articulos.Add(articulos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Articulos articulos)
    {
        _contexto.Articulos.Update(articulos);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(articulos).State = EntityState.Detached;
        return modificado;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Articulos
            .AnyAsync(e => e.ArticuloId == id);       
    }

    public async Task<bool> Existe(int id, string? descripcion)
    {
        return await _contexto.Articulos
            .AnyAsync(e => e.ArticuloId != id && e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Articulos
            .Where(e => e.ArticuloId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Articulos?> BuscarId(int id)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ArticuloId == id);
    }

    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public decimal CalcularPrecioVenta(decimal costo, decimal ganancia)
    {
        var precio = costo * ganancia / 100;
        return costo + precio;
    }
}
