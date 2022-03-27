using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPS.Util
{
    public class ScoreEvents
    {
        internal delegate void ChangeScore(int score);
        internal static event ChangeScore onScoreChanged;
        internal static void NotifyOnScoreChanged(int updatedScore)
        {
            onScoreChanged?.Invoke(updatedScore);
        }

        internal delegate void BreakedHighScore();
        internal static event BreakedHighScore onHighScoreBreaked;
        internal static void NotifyOnHighScoreBreaked()
        {
            onHighScoreBreaked?.Invoke();
        }

    }

    public class TimeEvents
    {
        internal delegate void TimeChanged(float remainingTime);
        internal static event TimeChanged onTimeChanged;
        internal static void NotifyOnTimeChanged(float remainingTime)
        {
            onTimeChanged?.Invoke(remainingTime);
        }

        internal delegate void TimeOver();
        internal static event TimeOver onTimeOver;
        internal static void NotifyOnTimeOver()
        {
            onTimeOver?.Invoke();
        }
    }

    public class GameStateEvents
    {
        internal delegate void GameStart();
        internal static event GameStart onGameStart;
        internal static void NotifyOnGameStart()
        {
            onGameStart?.Invoke();
        }

        internal delegate void GameEnd();
        internal static event GameEnd onGameEnd;
        internal static void NotifyOnGameEnd()
        {
            onGameEnd?.Invoke();
        }

    }

    public class GameRoundEvents
    {
        internal delegate void RoundStart();
        internal static event RoundStart onRoundStart;
        internal static void NotifyOnRoundStart()
        {
            onRoundStart?.Invoke();
        }

        internal delegate void RoundEnd();
        internal static event RoundEnd onRoundEnd;
        internal static void NotifyOnRoundEnd()
        {
            onRoundEnd?.Invoke();
        }

        internal delegate void PlayerWin(int value);
        internal static event PlayerWin onPlayerWin;
        internal static void NotifyOnPlayerWin(int value)
        {
            onPlayerWin?.Invoke(value);
        }

        internal delegate void PrepareForNextRound();
        internal static event PrepareForNextRound onPrepareForNextRound;
        internal static void NotifyOnPrepareForNextRound()
        {
            onPrepareForNextRound?.Invoke();
        }


        internal delegate void NextRoundCountDown(int countDownTime);
        internal static event NextRoundCountDown onNextRoundCountDownChanged;
        internal static void NotifyOnNextRoundCountDownChanged(int countDownTime)
        {
            onNextRoundCountDownChanged?.Invoke(countDownTime);
        }
    }

    public class BotEvents
    {
        internal delegate void BotMoved(Element element);
        internal static event BotMoved onBotMoved;
        internal static void NotifyOnBotMoved(Element element)
        {
            onBotMoved?.Invoke(element);
        }


    }

    public class PlayerEvents
    {
        internal delegate void PlayerMoved(Element element);
        internal static event PlayerMoved onPlayerMoved;
        internal static void NotifyOnPlayerMoved(Element element)
        {
            onPlayerMoved?.Invoke(element);
        }


    }

}