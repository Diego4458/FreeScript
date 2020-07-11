using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeScript.Managers
{
    class InputManager
    {
        private static KeyEventArgs KeyUpArgs = null;

        private static KeyEventArgs KeyDownArgs = null;

        private static KeyPressEventArgs KeyPressArgs = null;


        public static void Render_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUpArgs = e;
        }

        public static void Render_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressArgs = e;
        }

        public static void Render_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownArgs = e;
        }

        public static object GetCurrentKey()
        {
            object data = null;
            if(KeyUpArgs!= null)
            {
                data = KeyUpArgs.KeyCode;
            }
            if (KeyDownArgs != null)
            {
                data = KeyDownArgs.KeyCode;
            }
            if (KeyPressArgs != null)
            {
                
            }
            return data;
        }

        public static bool GetKey(Keys key)
        {

            if (KeyDownArgs != null && KeyDownArgs.KeyCode == key)
            {
                return true;
            }
            if (KeyPressArgs != null && KeyPressArgs.KeyChar == (char)key)
            {
                return true;
            }

            return false;
        }

        public static bool KeyUp(Keys key)
        {
            if (KeyUpArgs == null)
                return false;
            if(KeyUpArgs.KeyCode == key)
            {
                return true;
            }
            return false;
        }

        public static bool KeyDown(Keys key)
        {
            if (KeyDownArgs == null)
                return false;
            if (KeyDownArgs.KeyCode == key)
            {
                return true;
            }
            return false;
        }

        public static bool KeyHold(Keys key)
        {
            if (KeyPressArgs == null)
                return false;
            if (KeyPressArgs.KeyChar == (char)key)
            {
                return true;
            }
            return false;
        }

        public static void Reset()
        {
            KeyPressArgs = null;
            KeyDownArgs = null;
            KeyUpArgs = null;
        }
    }
}
