using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace FreeScript
{
    class Program
    {
        
        public static bool IsRunning;

        static void Main(string[] args)
        {
            Console.Title = "FreeScript Engine";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("--------------------------");
            Console.WriteLine("  FreeScript Engine  0.1  ");
            Console.WriteLine("  Build Data: 03/03/2020  ");
            Console.WriteLine("--------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Log] Iniciando Grafico");
            Thread Render = new Thread(new ThreadStart(InitEngine));
            Render.Start();
            Console.Read();
            
        }

        static Form Setup()
        {
            Form Render = new Form();
            Render.Size = new Size(500,500);
            Render.Show();
            return Render;
        }

        static void InitEngine()
        {
            Form Render = Setup();
            IsRunning = true;
            List<GameObject> Objects = new List<GameObject>();
            Objects.Add(new GameObject());
            Objects.Add(new GameObject());
            Objects[0].SetLocation(new Vector2D() { X = 100, Y = 250 });
            Objects[1].SetLocation(new Vector2D() { X = 300, Y = 250 });
            Objects[0].SetSize(new Vector2D() { X = 100, Y = 100 });
            Objects[1].SetSize(new Vector2D() { X = 100, Y = 100 });
            Render.Controls.Add(Objects[0].ReturnGameObject());
            Render.Controls.Add(Objects[1].ReturnGameObject());
            while(true)
            {
                Objects[0].AddLocation(new Vector2D() { X = 1, Y = 0 });
                Objects[1].AddLocation(new Vector2D() { X = -1, Y = 0 });

                for (int x=0;x< Objects.Count;x++)
                {
                    Objects[x].Update();
                }
                if(Compare(Objects[0].GetLocation(), Objects[0].GetSize(), Objects[1].GetLocation(), Objects[0].GetSize()))
                {
                    Console.WriteLine("[Log] Colisão");
                    break;
                }
                Thread.Sleep(10);
            }
            IsRunning = false;
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
