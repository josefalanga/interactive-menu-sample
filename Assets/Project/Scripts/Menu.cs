using System;
using UnityEngine;

namespace Project.Scripts
{
    public class Menu : MonoBehaviour
    {
        public MenuButton buttonPrefab;
        public GameObject buttonParent;

        public PopUp popupPrefab;

        void Start()
        {
            Instantiate(buttonPrefab.gameObject, buttonParent.transform)
                .GetComponent<MenuButton>()
                .Initialize("Info", OnInfoTapped);


            Instantiate(buttonPrefab.gameObject, buttonParent.transform)
                .GetComponent<MenuButton>()
                .Initialize("Exit", OnExitTapped);
        }

        void OnExitTapped()
        {
            ShowPopup("Are you sure you want to quit?",
                Application.Quit,
                () => { });
        }

        void OnInfoTapped()
        {
            var info = $"deviceName: {SystemInfo.deviceName}\ndeviceType: {SystemInfo.deviceType}\ndeviceModel: {SystemInfo.deviceModel}\ndeviceUniqueIdentifier: {SystemInfo.deviceUniqueIdentifier} ";
            ShowPopup(info, () => { });
        }

        void ShowPopup(string text, Action onDismiss, Action onCancel = null)
        {
            Instantiate(popupPrefab, transform)
                .GetComponent<PopUp>()
                .Initialize(text, onDismiss, onCancel);
        }
    }
}