using System;
using Egsp.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Visual.Scenes.Preloader
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField orderNameInput;
        [SerializeField] private Button startButton;

        private void Awake()
        {
            startButton.interactable = false;
        }

        public void ValidateOrderName(string orderName)
        {
            if (string.IsNullOrWhiteSpace(orderName))
            {
                startButton.interactable = false;
            }
            else
            {
                startButton.interactable = true;
            }
        }

        public void LoadGameplayScene()
        {
            var pm = new GameStartParams();
            pm.OrderName = orderNameInput.text;

            GameSceneManager.Instance
                .LoadSceneSingle("gameplay",true,pm,pm);
        }
    }
}