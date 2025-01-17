using System;

namespace WebAPI.Services;

public class categoriaService:IcategoriaService
{
    public IEnumerable<categoriaService> Get(){ 
        return new List<categoriaService>();
    } 
}
public interface IcategoriaService
{

}
