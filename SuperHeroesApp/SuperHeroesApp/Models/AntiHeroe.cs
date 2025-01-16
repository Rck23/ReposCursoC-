namespace SuperHeroesApp.Models
{
    public class AntiHeroe: SuperHeroe{
        public string RealizarAccionAntiHeroe(string accion) { 
            return $"El antiheroe {Nombre} ha realizado: {accion}";
         }
    }
}