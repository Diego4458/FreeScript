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
            GameObject Novo = new GameObject();
            Novo.SetName(Name);
            Screen.Controls.Add(Novo.ReturnGameObject());
            Objects.Add(Novo);
        }

        public void Add()
        {
            GameObject Novo = new GameObject();
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

        public GameObject FindByName(String Nome)
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
    }
}
