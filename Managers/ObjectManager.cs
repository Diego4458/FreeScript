using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeScript.Managers
{
    class ObjectManager
    {

        private static List<GameObject> Objects = new List<GameObject>();

        private static Form Screen;

        private static Label TextBox = new Label();

        public static void TextUpdate(string Texto)
        {
            TextBox.Text = Texto;
        }

        public static void Init(Form Screen)
        {
            ObjectManager.Screen = Screen;
            Screen.Controls.Add(TextBox);
        }

        public static void Add(String Name)
        {
            GameObject Novo = new GameObject(Screen);
            Novo.SetName(Name);
            Screen.Controls.Add(Novo.ReturnGameObject());
            Objects.Add(Novo);
        }

        public static void Add()
        {
            GameObject Novo = new GameObject(Screen);
            Screen.Controls.Add(Novo.ReturnGameObject());
            Objects.Add(Novo);
        }

        public static void Update()
        {
            for(int x=0;x< Objects.Count; x++)
            {
                Objects[x].Update();
            }
        }

        public static GameObject FindObjectByName(String Nome)
        {
            for(int x=0;x< Objects.Count;x++)
            {
                if (Objects[x].GetName() == Nome)
                {
                    return Objects[x];
                }
            }
            return null;
        }

        public static GameObject[] FindObjectsByName(String Nome)
        {
            List<GameObject> objetos = new List<GameObject>();
            for (int x = 0; x < Objects.Count; x++)
            {
                if (Objects[x].GetName() == Nome)
                {
                    objetos.Add(Objects[x]);
                }
            }
            if(objetos.Count > 0)
            {
                return objetos.ToArray();
            }
            return null;
        }


        public static GameObject[] GetAll()
        {
            if (Objects.Count > 0)
            {
                return Objects.ToArray();
            }
            return null;
        }
    }
}
