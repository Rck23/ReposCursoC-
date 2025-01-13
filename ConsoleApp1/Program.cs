// See https://aka.ms/new-console-template for more information

// double lado1, lado2, result; 

// Console.WriteLine("Valor lado 1: ");
// lado1 = Convert.ToDouble( Console.ReadLine());
// Console.WriteLine("Valor lado 2: ");
// lado2 = Convert.ToDouble( Console.ReadLine());

// result = lado1 * lado2; 
// Console.WriteLine("Resultado: " + result);


// Console.WriteLine("Calcular circulo");

// var radio = 0d; 
// var resultado = 0d; 

// Console.WriteLine("Valor del radio: ");
// radio = Convert.ToDouble( Console.ReadLine());

// resultado = Math.PI * radio * radio;
// Console.WriteLine("Resultado del área del circulo: " + resultado);

System.Random random = new System.Random();

int totalJugador = 0;
int totalDealer = 0;
int num = 0;
int coins = 0;
string message = "";
string controlOtraCarta = "";
string switchControl = "menu";

while (true)
{
    Console.WriteLine("Bienvenido al C A S I N O");
    Console.WriteLine("Cuantos cerditos deseas ?");
    coins = int.Parse(Console.ReadLine());

    for (int i = 0; i < coins; i++)
    {
        totalJugador = 0;
        totalDealer = 0;

        switch (switchControl)
        {
            case "menu":
                Console.WriteLine("Escriba '21' para comenzar a jugar");
                switchControl = Console.ReadLine();
                i -= 1;
                break;

            case "21":
                do
                {
                    num = random.Next(1, 12);
                    totalJugador += num;
                    Console.WriteLine($"Tu carta es {num}");
                    Console.WriteLine("Deseas otra carta? ");
                    controlOtraCarta = Console.ReadLine();
                } while (controlOtraCarta == "Si" || controlOtraCarta == "si");

                totalDealer = random.Next(10, 21);
                System.Console.WriteLine("El dealer tiene " + totalDealer);

                if (totalJugador > totalDealer && totalJugador < 22)
                {
                    message = "Ganaste, felicidades";
                    switchControl = "menu";
                }
                else if (totalJugador >= 22)
                {
                    message = "Perdiste, te pasaste de 21";
                    switchControl = "menu";

                }
                else if (totalJugador <= totalDealer)
                {
                    message = "Te ha ganado el Dealer";
                    switchControl = "menu";

                }
                else
                {
                    message = "Condición no valida";
                }


                Console.WriteLine(message);
                break;

            default:
                Console.WriteLine("Operación no valida");
                break;
        }
    }
}