using System.Collections;
using System.Collections.Generic;
using RPS.Data;
using RPS.Util;
using TMPro;
using UnityEngine;

namespace RPS.UI
{
    public class HomeScreen : UIScreen
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI highscoreText;

        #endregion

        private void Start()
        {
            ScreenStacker.OpenScreen(this);
        }

        #region PanelCallbacks

        internal override void OnScreenOpened()
        {
            base.OnScreenOpened();
            highscoreText.text = PlayerProfile.HighScore.ToString();
        }

        #endregion

        #region UiCallbacks

        public void OnStartClicked()
        {
            ScreenStacker.Clear();
            UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.GAME_SCENE);
        }

        public void OnInfoClicked()
        {
            ScreenStacker.OpenScreen<InfoScreen>();
        }

        #endregion
    }
}