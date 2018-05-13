using Caliburn.Micro;
using SourceGSI.UI.Core.Entities;
using SourceGSI.UI.Core.Events;

namespace SourceGSI.UI.Screens
{
    public class DashboardViewModel : Screen, IHandle<GameStateReceived>
    {
        private GameState _gameState;

        public DashboardViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);

            // TODO: (Re)move mock game state
            GameState = new GameState
            {
                Hero = new Hero
                {
                    Name = "Bristleback",
                    Level = 25,
                    Health = 333,
                    MaxHealth = 666,
                    HealthPercent = 50,
                    Mana = 333,
                    MaxMana = 666,
                    ManaPercent = 50,
                    IsAlive = true
                },
                Abilities = new Abilities
                {
                    Ability0 = new Ability
                    {
                        Name = "Viscous Nasal Goo"
                    },
                    Ability1 = new Ability
                    {
                        Name = "Quill Spray"
                    },
                    Ability2 = new Ability
                    {
                        Name = "Bristleback",
                        IsPassive = true
                    },
                    Ability3 = new Ability
                    {
                        Name = "Warpath",
                        IsUltimate = true,
                        IsPassive = true
                    },
                }
            };
        }

        public GameState GameState
        {
            get => _gameState;
            set
            {
                _gameState = value;

                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => HeroName);
                NotifyOfPropertyChange(() => HeroLevel);
                NotifyOfPropertyChange(() => Health);
                NotifyOfPropertyChange(() => Mana);
            }
        }

        public string HeroName => GameState.Hero.Name.ToUpper();
        public int HeroLevel => GameState.Hero.Level;

        public string Health => $"{GameState.Hero.Health} / {GameState.Hero.MaxHealth}";
        public string Mana => $"{GameState.Hero.Mana} / {GameState.Hero.MaxMana}";

        public void Handle(GameStateReceived message)
        {
            GameState = message.GameState;
        }
    }
}
