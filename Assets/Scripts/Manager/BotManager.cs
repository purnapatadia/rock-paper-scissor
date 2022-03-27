using System;
using System.Collections;
using System.Collections.Generic;
using RPS.Util;
using UnityEngine;

namespace RPS.Manager
{
    public class BotManager : MonoBehaviour
    {
        #region Variables

        private Coroutine _timeCoroutine;

        #endregion

        #region UnityCallbacks

        private void OnEnable()
        {
            GameRoundEvents.onRoundStart += GetBotMove;
        }

        private void OnDisable()
        {
            GameRoundEvents.onRoundStart -= GetBotMove;
        }

        #endregion

        #region EventCallbacks

        internal void GetBotMove()
        {
            BotEvents.NotifyOnBotMoved((Element)UnityEngine.Random.Range(1, Constants.ElementCount));
        }

        #endregion

        #region Coroutine

        IEnumerator CountTime(float time)
        {
            while (time > 0)
            {
                yield return null;
                time -= Time.deltaTime;
                TimeEvents.NotifyOnTimeChanged(time);
            }
            TimeEvents.NotifyOnTimeOver();
            _timeCoroutine = null;
        }

        #endregion
    }
}

