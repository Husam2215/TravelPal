using System.Collections.Generic;

namespace TravelPal.Vacation
{
    internal class TravelManeger
    {
        List<Travel> Travels = new();

        public void AddTravel(Travel travel)
        {
            Travels.Add(travel);
        }
        public void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
        }
    }
}
