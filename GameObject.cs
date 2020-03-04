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
        private String Name;
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
            ImOutOfBound();
            this.UpdateSize();
        }

        public void SetName( String Nome)
        {
            Name = Nome;
        }

        public String GetName()
        {
            return Name;
        }

        void ImOutOfBound()
        {
            if (Position.X < 0)
            {
                Position.X = 0;
            }
            else if (Position.Y < 0)
            {
                Position.Y = 0;
            }
            else if (Position.Y+Size.X >= 500 && Position.X + Size.X >= 500)
            {
                Position.X = 500 - Size.X;
                Position.Y = 500 - Size.Y;
            }
            else if (Position.X+Size.X >= 500 )
            {
                Position.X = 500 - Size.X;
            }
            else if (Position.Y+ Size.Y >= 500)
            {
                Position.Y = 500 - Size.Y;
            }
            this.UpdateLocation();
        }

        public Directions ofCourse()
        {
            if (Position.X <= 0 && Position.Y <= 0)
            {
                return Directions.LeftUp;
            }
            else if (Position.X <= 0 && Position.Y + Size.Y >= 500)
            {
                return Directions.LeftDown;
            }
            else if (Position.X + Size.X  >= 500 && Position.Y + Size.Y >= 500)
            {
                return Directions.RightDown;
            }
            else if (Position.X + Size.X >= 500 && Position.Y  <= 0)
            {
                return Directions.RightUp;
            }
            else
            { 
            return Directions.Noone ;
            }
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
