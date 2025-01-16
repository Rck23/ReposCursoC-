namespace SuperHeroesApp.Models
{
    public class SuperPoder
    {
        public SuperPoder()
        {
            Nivel = nivelPoder.Uno;
        }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public nivelPoder Nivel { get; set; }

    }


    public  enum nivelPoder
    {
        Uno,
        Dos,
        Tres
    }

}