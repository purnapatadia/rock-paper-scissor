using System.Collections;
using System.Collections.Generic;
using RPS.Data;
using RPS.Util;
using UnityEngine;

namespace RPS.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        public static GameManager instance;
        [SerializeField] private ElementData elementData;

        public ElementData ElementData => elementData;

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

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.3f);
            StartGame();
        }

        #endregion

        #region PrivateMethods

        private void StartGame()
        {
            GameStateEvents.NotifyOnGameStart();
        }

        private void EndGame()
        {
            GameStateEvents.NotifyOnGameEnd();
        }

        #endregion


    }
}