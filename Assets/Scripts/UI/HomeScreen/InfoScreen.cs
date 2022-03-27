using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPS.Util;
using TMPro;
using UnityEngine.UI;
using RPS.Manager;
using RPS.Data;

namespace RPS.UI
{
    public class InfoScreen : UIScreen
    {
        #region Variables

        #endregion

        #region PanelCallbacks

        #endregion

        #region UICallbacks

        public void OnCloseClicked()
        {
            ScreenStacker.CloseScreen(this);
        }

        #endregion

        #region EventCallbacks

        #endregion

    }
}