using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeScript
{
    class GameObject
    {
        private Panel Object = new Panel();
        private Vector2D Position;
        private Vector2D Size;

        public GameObject()
        {
            Object.BackColor = Color.DarkBlue;
            Object.Show();
        }

        public void Update()
        {
            this.UpdateLocation();
            this.UpdateSize();
        }

        void UpdateLocation()
        {
            Object.Location = new Point(Position.X, Position.Y);
        }

        void UpdateSize()
        {
            Object.Size = new Size(Size.X, Size.Y);
        }

        public void SetSize(Vector2D Info)
        {
            Size = Info;
        }

        public void SetLocation(Vector2D Info)
        {
            this.Position = Info;
        }

        public Vector2D GetLocation()
        {
            return this.Position;
        }
        public Vector2D GetSize()
        {
            return this.Size;
        }

        public void AddLocation(Vector2D Info)
        {
            this.Position.X += Info.X;
            this.Position.Y += Info.Y;
        }
        public Panel ReturnGameObject()
        {
            return this.Object;
        }
    }
}
