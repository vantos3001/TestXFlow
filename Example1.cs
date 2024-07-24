namespace Example1
{
    public class Player
    {
        public int Health { get; private set; }

        public Player(int health)
        {
            Health = health;
        }

        public void SetHealth(int value)
        {
            Health = value;
        }

        public void Hit(int damage)
        {
            SetHealth(Health - damage);
        }
    }

    class Program
    {
        private const string SettingsPath = "Settings.json";

        protected static Player player;

        public static void Main(string[] args)
        {
            var settings = Serializer.LoadFromFile<Settings>(x: SettingsPath);

            player = new Player(settings.PlayerHealth);
            player.Hit(settings.Damage);
        }
    }
}
