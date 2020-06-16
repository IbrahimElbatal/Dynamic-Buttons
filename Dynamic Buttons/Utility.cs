using System.Drawing;
using System.Windows.Forms;

namespace Dynamic_Buttons
{
    class Utility
    {
        public static Color GetColor(string color)
        {
            Color returnedColor = Control.DefaultBackColor;
            switch (color)
            {
                case "red":
                    returnedColor = Color.Red;
                    break;

                case "blue":
                    returnedColor = Color.Blue;
                    break;
                case "green":
                    returnedColor = Color.Green;
                    break;
                case "white":
                    returnedColor = Color.White;
                    break;
                case "black":
                    returnedColor = Color.Black;
                    break;
                case "silver":
                    returnedColor = Color.Silver;
                    break;
                default:
                    returnedColor = Control.DefaultForeColor;
                    break;
            }

            return returnedColor;
        }

    }
}
