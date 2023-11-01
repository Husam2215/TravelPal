using TravelPal.Enums;

namespace TravelPal.TravelModels
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, int travellers, Countries countries, bool allInclusive) : base(destination, travellers, countries)
        {
            AllInclusive = allInclusive;
        }
    }
}
