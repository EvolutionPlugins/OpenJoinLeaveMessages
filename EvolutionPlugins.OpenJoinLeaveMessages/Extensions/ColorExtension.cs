using System.Drawing;

namespace EvolutionPlugins.OpenJoinLeaveMessages.Extensions
{
    public static class ColorExtension
    {
        public static Color ParseColor(this string name, Color refColor)
        {
            if (string.IsNullOrEmpty(name))
            {
                return refColor;
            }

            var color = ColorTranslator.FromHtml(name);
            return color == Color.Empty ? refColor : color;
        }
    }
}
