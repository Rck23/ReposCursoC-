using System.Text;
using SuperHeroesApp;
using SuperHeroesApp.Models;

var superFuerza = new SuperPoder(); 
superFuerza.Nombre = "Super fuerza"; 
superFuerza.Nivel = nivelPoder.Tres; 

var regeneracion = new SuperPoder(); 
regeneracion.Nombre = "Regeneración"; 
regeneracion.Nivel = nivelPoder.Dos; 

var superman = new SuperHeroe(); 

superman.Id = 1;
superman.Nombre = "Superman";
superman.IdentidadSecreta = "Clarck";
superman.Ciudad  = "Metropolis";
superman.Volar = true;

List<SuperPoder> supermanList = new List<SuperPoder>();
supermanList.Add(superFuerza);
superman.SuperPoderes = supermanList;
superman.usarPoder();
string resultadoSupermanPoderes = superman.usarPoder();
Console.WriteLine(resultadoSupermanPoderes);

string resultSalvarElMundo = superman.SalvarElMundo();
System.Console.WriteLine(resultSalvarElMundo);

var wolverine = new AntiHeroe();
wolverine.Id = 2;
wolverine.Nombre = "Wolverine";
wolverine.IdentidadSecreta = "Logan";
wolverine.Volar = false;

List<SuperPoder> poderesWolverine = new List<SuperPoder>();
poderesWolverine.Add(superFuerza);
poderesWolverine.Add(regeneracion);
wolverine.SuperPoderes = poderesWolverine;
string resultadowolverinePoderes = wolverine.usarPoder();
Console.WriteLine(resultadowolverinePoderes);

string accionAntiHeroe = wolverine.RealizarAccionAntiHeroe("Ataca la policia");
System.Console.WriteLine(accionAntiHeroe);

var imprimirInfo = new ImprimirInfo();

imprimirInfo.ImprimirSuperHero(superman);
imprimirInfo.ImprimirSuperHero(wolverine);