namespace WeatherModule
{
    public enum WindDirections { N, NNE, NE, ENE, E, ESE, SE, SSE, S, SSW, SW, WSW, W, WNW, NW, NNW };

    public class Wind
    {
        public double? Speed { get; set; }

        public WindDirections Direction { get; set; }
    }
}
