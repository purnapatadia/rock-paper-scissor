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
    public class PlayerLosePanel : UIScreen
    {
        #region Variables

        [Header("Score")]
        [SerializeField] private TextMeshProUGUI highscoreText;
        [SerializeField] private TextMeshProUGUI currentScoreText;

        [Header("Data")]
        [SerializeField] private Image playerElement;
        [SerializeField] private Image botElement;
        [SerializeField] private TextMeshProUGUI elementAction;

        [Space]
        [SerializeField] private GameObject newHighScore;

        #endregion

        #region PanelCallbacks

        internal override void OnScreenOpened()
        {
            base.OnScreenOpened();

            newHighScore.SetActive(false);
            InitData();
            InitScores();
        }

        #endregion

        #region PrivateMethods

        private void InitData()
        {
            var elementData = GameManager.instance.ElementData;
            playerElement.sprite = elementData.GetSprite(RoundManager.instance.PlayerElement);
            playerElement.gameObject.SetActive(playerElement.sprite != null);

            botElement.sprite = elementData.GetSprite(RoundManager.instance.BotElement);
            elementAction.text = elementData.GetAction(RoundManager.instance.BotElement, RoundManager.instance.PlayerElement);
        }

        private void InitScores()
        {
            if (RoundManager.instance.HasBrokeHighScore)
            {
                highscoreText.text = PlayerProfile.PreviousHighScore.ToString();
                newHighScore.SetActive(true);
            }
            else
                highscoreText.text = PlayerProfile.HighScore.ToString();

            currentScoreText.text = RoundManager.instance.CurrentScore.ToString();

            //PlayHighScoreAnimation();

        }

        private void PlayHighScoreAnimation()
        {
            ///Todo
            ///Some animation
            highscoreText.text = PlayerProfile.HighScore.ToString();

        }

        #endregion

        #region UICallbacks

        public void OnGameOverClicked()
        {
            ScreenStacker.Clear();
            UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.HOME_SCENE);
        }

        #endregion

        #region EventCallbacks

        #endregion

    }
}