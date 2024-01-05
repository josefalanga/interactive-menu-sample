using System;
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
                buttonComponent.onClick.AddListener(onClick.Invoke);
        }
    }
}