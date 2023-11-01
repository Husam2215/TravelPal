using TravelPal.Enums;

namespace TravelPal.TravelModels
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }


        public WorkTrip(string meetingDetails, string destinations, int travellers, Countries countries) : base(destinations, travellers, countries)
        {
            MeetingDetails = meetingDetails;
        }

        // info about trip

        internal string Getinfo()
        {
            return $"MeetingDetails: {MeetingDetails},{Travellers} passenger from {Countries} to {Destinations}";
        }


    }
}
