using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using FreeScript.Managers;
using System.Resources;

namespace FreeScript
{
    class Program
    {

        public static String Cmd = string.Empty;
        public static String Title = "FreeScript Engine  0.2 - {0} FPS";

        static void Main(string[] args)
        {
            Console.Title = "FreeScript Engine";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("--------------------------");
            Console.WriteLine("  FreeScript Engine  0.2  ");
            Console.WriteLine("  Build Data: 04/03/2020  ");
            Console.WriteLine("--------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Log] Iniciando Grafico");
            Thread Render = new Thread(new ThreadStart(InitEngine));
            Render.Start();
            while(Render.IsAlive)
            {
             Cmd = Console.ReadLine();
            }
            Console.Read();
            
        }

        static Form Setup()
        {
            Form Render = new Form();
            Render.Size = new Size(500,500);
            Render.Text = "FreeScript Engine  0.2";
            Render.StartPosition = FormStartPosition.CenterScreen;
            Render.Show();
            return Render;
        }

        static void InitEngine()
        {
            Form Render = Setup();
            ObjectManager.Init(Render);
            Render.KeyUp += InputManager.Render_KeyUp;
            Render.KeyDown += InputManager.Render_KeyDown;
            Render.KeyPress += InputManager.Render_KeyPress;

            while (true)
            {
                Application.DoEvents();
                Cmd = CommandManager.HanddleCommands(Cmd);
                ObjectManager.Update();
                if(InputManager.GetCurrentKey() != null)
                {
                    Console.WriteLine(InputManager.GetCurrentKey());
                }
                InputManager.Reset();
            }
        }

        
    }
}
