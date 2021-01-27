using System;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;

namespace Game.Visuals.Scenes.Preloader
{
    public class PreloadAnimationController : SerializedMonoBehaviour
    {
        [SerializeField] private float textBlockTime;
        [SerializeField] private GameObject textBlocksParent;
        [SerializeField] private TMP_Text textBlockPlace;
        [SerializeField] private TextFadeInOutTweener textFadeInOutTweener;

        [SerializeField] private GameObject inputParent;
        [SerializeField] private TMP_InputField inputField; 

        [OdinSerialize] [MultiLineProperty(2)] 
        private List<string> textBlocks = new List<string>();

        private int textBlockIndex = -1;
        private Tween currentTween;

        private bool inputStage;


        private void Start()
        {
            StartAnimation();     
        }

        private void StartAnimation()
        {
            inputParent.SetActive(false);
            textBlocksParent.SetActive(true);
            ShowNextBlock();    
        }

        private void ShowNextBlock()
        {
            if (inputStage)
                return;
            
            textBlockIndex++;
            if(textBlockIndex >= textBlocks.Count)
            {
                textBlocksParent.SetActive(false);
                ShowInput();
                return;
            }

            // Меняем текст.
            textBlockPlace.text = textBlocks[textBlockIndex];
            textFadeInOutTweener.Play(textBlockTime);
            currentTween = DOVirtual.DelayedCall(textBlockTime, ShowNextBlock);
        }

        private void ShowInput()
        {
            inputParent.SetActive(true);
            inputStage = true;
        }
        
        public void Skip()
        {
            if (inputStage)
                return;
            
            Debug.Log("Skip");
            currentTween.Kill();
            ShowNextBlock();
        }
    }
}