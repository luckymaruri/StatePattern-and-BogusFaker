namespace StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var trafficLight = new TrafficLight(new RedState());
            trafficLight.Change(); //Red to Yellow
            trafficLight.Change(); //Yellow to Green
            trafficLight.Change(); //Green to Red
            Console.ReadKey();
        }
    }
}
