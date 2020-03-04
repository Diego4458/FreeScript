using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using FreeScript.Managers;

namespace FreeScript
{
    class Program
    {

        public static String Cmd = string.Empty;


        static List<GameObject> Objects;
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
            Render.FormBorderStyle = FormBorderStyle.None;
            Render.StartPosition = FormStartPosition.CenterScreen;
            Render.Show();
            return Render;
        }

        static void InitEngine()
        {
            Form Render = Setup();
            ObjectManager Objects = new ObjectManager(Render);
            CommandManager CmdManager = new CommandManager(Objects);
            while(true)
            {
                Application.DoEvents();
                Cmd = CmdManager.HanddleCommands(Cmd);
                Objects.Update();
            }
        }

        public static  bool Compare(Vector2D First, Vector2D First_Size, Vector2D Second,Vector2D Second_Size)
        {
            if((First.X+ First_Size.X+ Second_Size.X) == (Second.X + Second_Size.X))
            {
                if((First.Y + First_Size.Y) == (Second.Y + Second_Size.Y))
                { 
                return true;
                }
                else
                {
                return false;
                }
            }
            return false;
        }

    }
}
