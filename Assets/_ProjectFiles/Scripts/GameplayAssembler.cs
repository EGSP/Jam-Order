
using Game.GameEvents;
using Game.Scenes;
using Game.Scenes.Exceptions;
using Game.Visual;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game
{
    public class GameplayAssembler : SerializedMonoBehaviour
    {
        [TitleGroup("Day timer")]
        [SerializeField] private DayTimer dayTimer;
        
        [TitleGroup("Order")]
        [SerializeField] private OrderVisualManager orderVisualManager;

        [TitleGroup("Game events")]
        [SerializeField] private GameEventManager gameEventManager;

        [ReadOnly][OdinSerialize]
        private Order order;

        private void StartGame()
        {
            Debug.Log("Game started");
            dayTimer.OnDayEnded += () => Debug.Log("Day ended");
            dayTimer.OnDaysExpired += Lose;
            
            dayTimer.StartTimer();
            
            gameEventManager.ShowRandomEvent();

            order.OnMaxAdoption += (i) => Win(false);
            order.OnMaxTerror += (i) => Win(true);
        }

        public void StartGameWithParams(SceneParams sceneParams)
        {
            var gameParams = sceneParams as GameStartParams;
            if(gameParams == null)
                throw new SceneParamsException<GameStartParams>(sceneParams);
            
            // Params
            order = CreateOrder(gameParams.OrderName);
            
            // Ui
            orderVisualManager.Accept(order);
            
            // Events
            gameEventManager.Order = order;
            gameEventManager.OnEventAction += OnGameEventAction;

            // Start
            StartGame();
        }

        private Order CreateOrder(string orderName)
        {
            return new Order(orderName, 1, 40, 600);
        }

        private void OnGameEventAction(IGameEventAction gameEventAction)
        {
            var nextStage = gameEventAction.NextStage;

            if (nextStage == null)
            {
                gameEventManager.ShowRandomEvent();
            }
            else
            {
                gameEventManager.ShowGameEvent(nextStage);
            }
        }

        private void StopAllSystems()
        {
            dayTimer.TimeFactor = 0;
            gameEventManager.CloseGameEvent();
        }

        private void Win(bool terror)
        {
            StopAllSystems();
            
            if (terror)
            {
                Debug.Log("Победа террором!");
            }
            else
            {
                Debug.Log("Победа благочестием!");
            }
        }

        private void Lose()
        {
            StopAllSystems();
            
            Debug.Log("Проигрыш.");
        }
    }

    public class GameStartParams : SceneParams
    {
        public string OrderName;
    }
}