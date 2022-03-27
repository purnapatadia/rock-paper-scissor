using System.Collections;
using System.Collections.Generic;
using RPS.Util;
using UnityEngine;

namespace RPS.Manager
{
    public class GamePlayTimerManager : MonoBehaviour
    {
        #region Variables

        private Coroutine _timeCoroutine;

        #endregion

        #region UnityCallbacks

        private void OnEnable()
        {
            GameRoundEvents.onRoundStart += StartTimer;
        }

        private void OnDisable()
        {
            GameRoundEvents.onRoundStart -= StartTimer;
        }


        #endregion

        #region EventCallbacks

        internal void StartTimer()
        {
            GameRoundEvents.onRoundEnd += StopTimer;

            if (_timeCoroutine != null)
            {
                StopCoroutine(_timeCoroutine);
                _timeCoroutine = null;
            }
            _timeCoroutine = StartCoroutine(CountTime(Constants.RoundTime));
        }

        internal void StopTimer()
        {
            GameRoundEvents.onRoundEnd -= StopTimer;

            if (_timeCoroutine != null)
            {
                StopCoroutine(_timeCoroutine);
                _timeCoroutine = null;
            }

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

            GameRoundEvents.onRoundEnd -= StopTimer;

            TimeEvents.NotifyOnTimeOver();
            _timeCoroutine = null;

        }

        #endregion
    }
}
