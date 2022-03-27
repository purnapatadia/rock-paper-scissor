using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using RPS.Manager;
using RPS.Util;

namespace RPS.UI
{
    public class PrepareRound : UIScreen
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI roundStartText;

        #endregion

        #region PanelCallbacks

        internal override void OnScreenOpened()
        {
            base.OnScreenOpened();
            GameRoundEvents.onNextRoundCountDownChanged += OnNextRoundCountDownChanged;
        }

        internal override void OnScreenClosed()
        {
            base.OnScreenClosed();
            GameRoundEvents.onNextRoundCountDownChanged -= OnNextRoundCountDownChanged;
        }

        #endregion

        #region PrivateMethods

        #endregion

        #region EventCallbacks

        private void OnNextRoundCountDownChanged(int time)
        {
            if (time == 0)
            {
                ScreenStacker.CloseScreen(this);
                return;
            }
            roundStartText.text = $"Round\nstarts in ...{time}";
        }

        #endregion
    }
}