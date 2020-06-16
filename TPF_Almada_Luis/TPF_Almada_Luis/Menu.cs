using System;

namespace TPF_Almada_Luis
{
	public class Menu
	{
		public void pantallaBienvenida()
		{
			Console.WriteLine("B i e n v e n i d o ! ! !");
			Console.WriteLine("A continuacion presione una tecla para iniciar o pulse Q para salir");
			string opcion = Console.ReadLine();
			if (opcion == "Q" || opcion == "q"){
				Console.WriteLine("Gracias por haber jugado!!!");
				Console.WriteLine("Hasta la proxima. . .");
				Console.ReadLine();
				Environment.Exit(0);
			}
		}
	}
}
