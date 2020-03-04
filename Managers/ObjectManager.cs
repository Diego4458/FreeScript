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

        public List<GameObject> Objects = new List<GameObject>();

        private Form Screen;

        public ObjectManager(Form screen)
        {
            Screen = screen;
        }

        public void Add(String Name)
        {
            GameObject Novo = new GameObject(Screen);
            Novo.SetName(Name);
            Screen.Controls.Add(Novo.ReturnGameObject());
            Objects.Add(Novo);
        }

        public void Add()
        {
            GameObject Novo = new GameObject(Screen);
            Screen.Controls.Add(Novo.ReturnGameObject());
            Objects.Add(Novo);
        }

        public void Update()
        {
            for(int x=0;x< Objects.Count; x++)
            {
                Objects[x].Update();
            }
        }

        public GameObject FindObjectByName(String Nome)
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

        public GameObject[] FindObjectsByName(String Nome)
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


        public GameObject[] GetAll()
        {
            if (Objects.Count > 0)
            {
                return Objects.ToArray();
            }
            return null;
        }
    }
}
