using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Project.Scripts
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PopUp : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public MenuButton dismissButton, cancelButton;
        private CanvasGroup _canvasGroup;

        private void OnEnable()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
            
            DOTween.Sequence()
                .Append(transform.DOShakeScale(.3f, Vector3.one * 0.1f, 5))
                .Join(_canvasGroup.DOFade(1, .3f));
        }

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
            DOTween.Sequence()
                .Append(transform.DOScale(Vector3.zero, .3f))
                .Join(_canvasGroup.DOFade(0, .3f))
                .AppendCallback(() => Destroy(gameObject));
        }
    }
}