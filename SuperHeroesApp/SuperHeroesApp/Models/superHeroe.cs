using System.Text;
using SuperHeroesApp.Interfaces;

namespace SuperHeroesApp.Models
{
    public class SuperHeroe : Heroe, ISuperHeroe
    {

        public SuperHeroe()
        {
            SuperPoderes = new List<SuperPoder>();
            Volar = false;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? IdentidadSecreta { get; set; }
        public string? Ciudad { get; set; }
        public List<SuperPoder> SuperPoderes { get; set; }
        public bool Volar { get; set; }

        public override string SalvarElMundo()
        {
            return $"{Nombre} ha salvado el mundo"; 
        }

        public string usarPoder()
        {

            StringBuilder stringBuildersb = new StringBuilder();
            foreach (var item in SuperPoderes)
            {
                stringBuildersb.AppendLine($"{Nombre} esta usando el super poder {item.Nombre}");
            }

            return stringBuildersb.ToString();
        }

    }

}