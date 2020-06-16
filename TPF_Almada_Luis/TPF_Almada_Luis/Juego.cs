using System;

namespace TPF_Almada_Luis
{
	class Juego
	{
		public static void Main(string[] args)
		{
			Menu menu=new Menu();
			menu.pantallaBienvenida();
			Game game = new Game();
			game.play();
		    Console.ReadKey();
		}
	}
}