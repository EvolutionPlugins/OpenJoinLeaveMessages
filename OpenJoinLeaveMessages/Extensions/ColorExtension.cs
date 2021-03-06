using System.Drawing;

namespace OpenJoinLeaveMessages.Extensions
{
    public static class ColorExtension
    {
        public static Color ParseColor(this string name, Color refColor)
        {
            var color = ColorTranslator.FromHtml(name);
            return color == Color.Empty ? refColor : color;
        }
    }
}
