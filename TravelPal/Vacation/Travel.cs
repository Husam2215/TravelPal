using TravelPal.Enum;

namespace TravelPal.Vacation
{
    internal abstract class Travel
    {
        public string Destinations { get; set; }

        public int Travellers { get; set; }

        public Countries Countries { get; set; }


        public Travel(string destinations, int travellers, Countries countries)
        {
            Destinations = destinations;
            Travellers = travellers;
            Countries = countries;

        }

        internal virtual string GetInfo()
        {
            return $"{Travellers} passenger from {Countries} to {Destinations}";
        }

    }
}
