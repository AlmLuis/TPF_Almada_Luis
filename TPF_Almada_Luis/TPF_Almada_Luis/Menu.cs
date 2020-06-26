using System;

namespace TPF_Almada_Luis
{
	public class Menu
	{
		public void pantallaBienvenida()
		{
			Console.WriteLine("B i e n v e n i d o ! ! !");
			Console.WriteLine();
			Console.WriteLine("Presione una tecla para iniciar,de lo contrario pulse 'Q' para salir. . .");
			string opcion = Console.ReadLine();
			if (opcion == "Q" || opcion == "q"){
				Console.WriteLine();
				Console.WriteLine("Gracias por haber jugado!!!");
				Console.WriteLine();
				Console.WriteLine("Hasta la proxima. . .");
				Console.WriteLine();
				Environment.Exit(0);
			}
		}
	}
}
