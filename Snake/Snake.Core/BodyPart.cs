namespace Snake.Core
{
    public class BodyPart
    {
        public BodyPart(Location location)
        {
            Location = location;
        }
        public Location Location { get; private set; }
        public Location PreviousLocation { get; private set; }

        public void ChangeLocation(Location location)
        {
            PreviousLocation = new Location(Location.X, Location.Y);
            Location = new Location(location.X, location.Y);
        }
    }
}
