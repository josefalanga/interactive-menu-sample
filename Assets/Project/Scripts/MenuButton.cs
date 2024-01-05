using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    [RequireComponent(typeof(Button))]
    public class MenuButton : MonoBehaviour
    {
        public void Initialize(string text, Action onClick)
        {
            var buttonComponent = GetComponent<Button>();
            var textComponent = buttonComponent.GetComponentInChildren<TextMeshProUGUI>();
            textComponent.text = text;
            if (onClick != null) 
                buttonComponent.onClick.AddListener(()=>Animate(onClick));
        }

        void Animate(Action onClick)
        {
            DOTween.Sequence()
                .Append(transform.DOPunchScale(Vector3.one * 0.1f, .2f))
                .AppendCallback(onClick.Invoke);
        }
    }
}