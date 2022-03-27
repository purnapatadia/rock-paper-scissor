using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RPS.Util;
using RPS.Manager;

namespace RPS.UI
{
    public class GamePlayScreen : UIScreen
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI score;

        [SerializeField] private Image timeProgress;
        [SerializeField] private Image botElement;

        #endregion

        #region UnityCallbacks

        private void Start()
        {
            ScreenStacker.OpenScreen(this);
        }

        #endregion

        #region PanelCallbacks

        internal override void OnScreenOpened()
        {
            base.OnScreenOpened();
            GameStateEvents.onGameStart += OnGameStart;

            GameRoundEvents.onRoundStart += OnRoundStart;
            GameRoundEvents.onRoundEnd += OnRoundEnd;
            GameRoundEvents.onPlayerWin += OnPlayerResult;
            GameRoundEvents.onPrepareForNextRound += PrepareForNextRound;

            ScoreEvents.onScoreChanged += OnScoreChanged;
            TimeEvents.onTimeChanged += OnTimeChanged;
            BotEvents.onBotMoved += OnBotMoved;

            Reset();

        }

        internal override void OnScreenClosed()
        {
            base.OnScreenClosed();
            GameStateEvents.onGameStart -= OnGameStart;

            GameRoundEvents.onRoundStart -= OnRoundStart;
            GameRoundEvents.onRoundEnd -= OnRoundEnd;
            GameRoundEvents.onPlayerWin -= OnPlayerResult;
            GameRoundEvents.onPrepareForNextRound -= PrepareForNextRound;

            ScoreEvents.onScoreChanged -= OnScoreChanged;
            TimeEvents.onTimeChanged -= OnTimeChanged;
            BotEvents.onBotMoved -= OnBotMoved;
        }

        #endregion

        #region PrivateMethods

        private void Reset()
        {
            botElement.gameObject.SetActive(false);
            score.text = "0";
            timeProgress.fillAmount = 0;
        }

        #endregion

        #region UICallbacks

        public void OnPlayerChooseMove(int state)
        {
            PlayerEvents.NotifyOnPlayerMoved((Element)state);
        }

        #endregion

        #region EventCallbacks

        private void OnGameStart()
        {
            score.text = "0";
            Reset();

        }

        private void OnScoreChanged(int score)
        {
            this.score.text = score.ToString();
        }

        private void PrepareForNextRound()
        {
            Reset();
            ScreenStacker.OpenScreen<PrepareRound>();
        }

        private void OnRoundStart()
        {
        }

        private void OnRoundEnd()
        {

        }

        private void OnPlayerResult(int playerWin)
        {
            if (playerWin == -1)
                ScreenStacker.OpenScreen<PlayerLosePanel>();
            else if (playerWin == 0)
                ScreenStacker.OpenScreen<GameTiePanel>();
            else if (playerWin == 1)
                ScreenStacker.OpenScreen<PlayerWinPanel>();

        }

        private void OnTimeChanged(float remainingTime)
        {
            timeProgress.fillAmount = remainingTime / Constants.RoundTime;
        }

        private void OnBotMoved(Element element)
        {
            botElement.gameObject.SetActive(true);
            botElement.sprite = GameManager.instance.ElementData.GetSprite(element);
        }

        #endregion

    }
}