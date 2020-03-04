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

        public static String Cmd = string.Empty;

        public static bool IsRunning;

        static List<GameObject> Objects;
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
            IsRunning = true;
            Objects = new List<GameObject>();
            Objects.Add(new GameObject());
            Objects[0].SetLocation(new Vector2D() { X = 0, Y = 0 });
            Objects[0].SetSize(new Vector2D() { X = 100, Y = 100 });
            Render.Controls.Add(Objects[0].ReturnGameObject());
            while(true)
            {
                CommandHandler(Render);
                if (Objects[0].ofCourse())
                {

                }
                Objects[0].AddLocation(new Vector2D() { X = 1, Y = 1 });

                for (int x=0;x< Objects.Count;x++)
                {
                    Objects[x].Update();
                }
                
            }
            IsRunning = false;
        }

        static void CommandHandler(Form Render)
        {
            if (Cmd.Length > 0)
            {
                List<String> Destrinchado = new List<string>();
                Destrinchado = GetCmd(Cmd);
                switch (Destrinchado[0])
                {
                    case "add":
                        Objects.Add(new GameObject());
                        int last = Objects.Count - 1;
                        Objects[last].SetName(Destrinchado[1]);
                        Objects[last].SetLocation(new Vector2D() { X = 50, Y = 50 });
                        Objects[last].SetSize(new Vector2D() { X = 100, Y = 100 });
                        Render.Controls.Add(Objects[last].ReturnGameObject());
                        Console.WriteLine(String.Format("[Att] Agora Contem {0} Objetos Em Cena", Objects.Count));
                        break;
                    case "find":
                        for (int x = 0; x < Objects.Count; x++)
                        {
                            if (Objects[x].GetName() == Destrinchado[1])
                            {
                                string frase = string.Format("Objeto Encontrado\nNome:{0}\nLolcalização: X:{1},Y:{2}\nTamanho: X:{3} Y:{4}",
                                    Objects[x].GetName(),
                                    Objects[x].GetLocation().X, Objects[x].GetLocation().Y, Objects[x].GetSize().X, Objects[x].GetSize().Y);
                                Console.WriteLine(frase);

                            }
                        }
                        break;
                    case "move":
                        for (int x = 0; x < Objects.Count; x++)
                        {
                            if (Objects[x].GetName() == Destrinchado[1])
                            {
                                Objects[x].AddLocation(new Vector2D() { X = Convert.ToInt32(Destrinchado[2]), Y = Convert.ToInt32(Destrinchado[3]) });
                                string frase = string.Format("Objeto Movido \nNome:{0}\nLolcalização: X:{1},Y:{2}",
                                    Objects[x].GetName(),
                                    Objects[x].GetLocation().X, Objects[x].GetLocation().Y);
                                Console.WriteLine(frase);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("[Error]Commando Invalido");
                        break;
                }
                Cmd = String.Empty;
            }
        }

        static private List<String> GetCmd(String cmd)
        {
            string comp = string.Empty;
            List<string> comp2 = new List<string>();
            for(int x = 0;x<cmd.Length;x++)
            {
                if(cmd[x].ToString() == " ")
                {
                    
                    comp2.Add(comp);
                    comp = String.Empty;
                }
                else if(x == Cmd.Length - 1)
                {
                    comp += cmd[x];
                    comp2.Add(comp);
                }
                else
                {
                    comp += cmd[x];
                }
            }
            return comp2;
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
