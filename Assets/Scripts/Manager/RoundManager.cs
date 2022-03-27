using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPS.Util;
using RPS.Data;

namespace RPS.Manager
{
    public class RoundManager : MonoBehaviour
    {
        #region Variables

        public static RoundManager instance;
        private bool _isRoundActive;
        private Element _botElement;
        private Element _playerElement;
        private int _playerScore;
        private bool _breakedHighScore;


        #endregion

        #region Properties

        public bool HasBrokeHighScore => _breakedHighScore;
        public int CurrentScore => _playerScore;
        public Element PlayerElement => _playerElement;
        public Element BotElement => _botElement;

        #endregion

        #region UnityCallbacks

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }

            instance = this;
        }

        private void OnEnable()
        {
            GameStateEvents.onGameStart += OnGameStart;
            GameStateEvents.onGameEnd += OnGameEnd;
            TimeEvents.onTimeOver += OnTimerCompleted;
            BotEvents.onBotMoved += OnBotMoved;
            PlayerEvents.onPlayerMoved += OnPlayerMoved;
        }

        private void OnDisable()
        {
            GameStateEvents.onGameStart -= OnGameStart;
            GameStateEvents.onGameEnd -= OnGameEnd;
            GameRoundEvents.onRoundStart -= OnTimerCompleted;
            BotEvents.onBotMoved -= OnBotMoved;
            PlayerEvents.onPlayerMoved -= OnPlayerMoved;
        }


        #endregion

        #region PublicMethods

        public void PrepareForNextRound()
        {
            if (!_isRoundActive)
            {
                GameRoundEvents.NotifyOnPrepareForNextRound();
                StartCoroutine(PrepareNextRoundCoroutine(StartRound));
            }

        }

        #endregion

        #region PrivateMethods

        private void StartRound()
        {
            _isRoundActive = true;
            _botElement = Element.None;
            _playerElement = Element.None;
            GameRoundEvents.NotifyOnRoundStart();
        }

        private void EndRound()
        {
            _isRoundActive = false;
            GameRoundEvents.NotifyOnRoundEnd();
            ComputeResult(_playerElement, _botElement);
        }

        #endregion

        #region PrivateMethods

        private void OnGameStart()
        {
            _playerScore = 0;
            _breakedHighScore = false;
            PrepareForNextRound();
        }

        private void OnGameEnd()
        {

        }

        private void ComputeResult(Element playerElement, Element botElement)
        {
            int playerWin = GameManager.instance.ElementData.CanBeat(playerElement, botElement);// _elementGraph.CanBeat(playerElement, botElement);

            if (playerWin == 1)
            {
                UpdateScore();
            }

            GameRoundEvents.NotifyOnPlayerWin(playerWin);
        }

        private void UpdateScore()
        {
            _playerScore++;
            ScoreEvents.NotifyOnScoreChanged(_playerScore);

            CheckHighScoreBroke(_playerScore);
            PlayerProfile.UpdateHighScore(_playerScore);

        }

        private void CheckHighScoreBroke(int score)
        {
            var hasBrokeHighScore = score > PlayerProfile.HighScore;
            _breakedHighScore |= score > PlayerProfile.HighScore;
        }


        #endregion

        #region Coroutines

        IEnumerator PrepareNextRoundCoroutine(System.Action onComplete)
        {
            int countDown = Constants.NextRoundCountDown;
            while (countDown > 0)
            {
                GameRoundEvents.NotifyOnNextRoundCountDownChanged(countDown);
                yield return new WaitForSeconds(1);
                countDown--;
            }
            GameRoundEvents.NotifyOnNextRoundCountDownChanged(countDown);

            onComplete?.Invoke();
        }

        #endregion

        #region EventCallbacks

        private void OnTimerCompleted()
        {
            EndRound();
        }

        private void OnBotMoved(Element element)
        {
            if (_isRoundActive)
                _botElement = element;
        }

        private void OnPlayerMoved(Element element)
        {
            if (_isRoundActive)
            {
                _playerElement = element;
                EndRound();
            }
        }

        #endregion

    }
}