using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPS.UI
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] internal bool shouldHidePreviousPanel;
        [SerializeField] internal GameObject screenRoot;

        internal virtual void OnScreenOpened()
        {
            screenRoot.SetActive(true);
        }

        internal virtual void OnScreenClosed()
        {
            screenRoot.SetActive(false);
        }
    }
}