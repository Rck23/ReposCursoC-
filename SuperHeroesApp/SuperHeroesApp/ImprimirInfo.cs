using SuperHeroesApp.Interfaces;

namespace SuperHeroesApp
{
    public class ImprimirInfo{

        public void ImprimirSuperHero(ISuperHeroe superHeroe){
            System.Console.WriteLine($"Id: {superHeroe.Id}");
            System.Console.WriteLine($"Nombre: {superHeroe.Nombre}");
         
        }
    }
}