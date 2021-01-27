using System;
using DG.Tweening;
using Egsp.Other;
using TMPro;
using UnityEngine;

namespace Game.Visuals.Scenes.Preloader
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextFadeInOutTweener : MonoBehaviour
    {
        [SerializeField] private CurveHandler fadeCurve;

        private TMP_Text text;
        private Tweener currentTweener;
        
        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        public void Play(float time)
        {
            if (currentTweener != null)
            {
                currentTweener.Kill();
            }
            
            var textColor = text.color;
            textColor.a = 0f;
            text.color = textColor;

            currentTweener = DOVirtual.Float(0, 1, time, (float f) =>
            {
                var tempColor = text.color;
                tempColor.a = fadeCurve.Get(f);
                text.color = tempColor;
            });

            currentTweener.OnComplete(() =>
            {
                currentTweener = null;
            });
        }
    }
}