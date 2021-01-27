using Game.GameEvents;

namespace Game.Visuals.GameEvents
{
    public interface IGameEventActionListener
    {
        void OnEventAction(IGameEventAction eventAction);
    }
}