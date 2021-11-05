namespace Utility
{
    public class TextFormatter
    {
        public static string ColorNumber(System.Object input, double currentValue, double highValue, double veryHighValue)
        {
            if (currentValue >= highValue)
            {
                string color = "#ffff00";
                if (currentValue >= veryHighValue)
                {
                    color = "#ff0000";
                }
                return "<color=" + color + ">" + input + "</color>";
            }
            else
            {
                return input.ToString();
            }
        }

        public static string ColorBool(bool currentValue)
        {
            string color = currentValue ? "#00ff00" : "#ff0000";
            return "<color=" + color + ">" + currentValue + "</color>";
        }
    }
}