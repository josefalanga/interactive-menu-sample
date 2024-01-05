using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts
{
    public class PopUp : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public MenuButton dismissButton, cancelButton;
        public void Initialize(string text, Action onDismiss, Action onCancel)
        {
            textComponent.text = text;
            
            if (onDismiss != null)
            {
                onDismiss += Close;
                dismissButton.Initialize("Ok", onDismiss);
            }
            else
            {
                dismissButton.Initialize("Ok", Close);
            }
            
            if (onCancel != null)
            {
                onCancel += Close;
                cancelButton.Initialize("Cancel", onCancel);
            }
            else
            {
                cancelButton.gameObject.SetActive(false);
            }
        }

        void Close()
        {
            Destroy(gameObject);
        }
    }
}