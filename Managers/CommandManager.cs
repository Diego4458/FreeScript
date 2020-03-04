using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeScript.Managers
{
    class CommandManager
    {
        ObjectManager Objects;

        public CommandManager(ObjectManager Object)
        {
            Objects = Object;
        }

        public String HanddleCommands(String Cmd)
        {
            if (Cmd.Length > 0)
            {
                List<String> Destrinchado = Destrinchado = GetCmd(Cmd);
                switch (Destrinchado[0])
                {
                    case "add":
                        Objects.Add(Destrinchado[1]);
                        break;
                    case "find":
                        {
                            GameObject Object = Objects.FindByName(Destrinchado[1]);
                                string frase = string.Format("Objeto Encontrado\nNome:{0}\nLolcalização: X:{1},Y:{2}\nTamanho: X:{3} Y:{4}",
                                    Object.GetName(),
                                    Object.GetLocation().X, Object.GetLocation().Y, Object.GetSize().X, Object.GetSize().Y);
                                Console.WriteLine(frase);
                        }
                        break;
                    case "move":
                        {
                            GameObject Object = Objects.FindByName(Destrinchado[1]);
                            Object.AddLocation(new Vector2D() { X = Convert.ToInt32(Destrinchado[2]), Y = Convert.ToInt32(Destrinchado[3]) });
                                string frase = string.Format("Objeto Movido \nNome:{0}\nLolcalização: X:{1},Y:{2}",
                                    Object.GetName(),
                                    Object.GetLocation().X, Object.GetLocation().Y);
                                Console.WriteLine(frase);
                        }
                        break;
                    default:
                        Console.WriteLine("[Error]Commando Invalido");
                        break;
                }
            }
            return String.Empty;
        }
        static private List<String> GetCmd(String cmd)
        {
            string comp = string.Empty;
            List<string> comp2 = new List<string>();
            for (int x = 0; x < cmd.Length; x++)
            {
                if (cmd[x].ToString() == " ")
                {

                    comp2.Add(comp);
                    comp = String.Empty;
                }
                else if (x == cmd.Length - 1)
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



    }
}
