using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPS.Data
{
    public class PlayerProfile
    {
        #region Variables

        //Player related info like name, profile, xp, highscore, etc.
        private static int previousHighScore = -1;
        private static int highScore = -1;

        #endregion

        #region Properties

        public static int PreviousHighScore
        {
            get
            {
                if (previousHighScore == -1)
                    previousHighScore = PlayerPrefs.GetInt("previousHighscore", 0);
                return previousHighScore;
            }
        }
        public static int HighScore
        {
            get
            {
                if (highScore == -1)
                    highScore = PlayerPrefs.GetInt("highscore", 0);
                return highScore;
            }
        }

        #endregion

        #region InternalMethods

        internal static void UpdateHighScore(int newScore)
        {
            if (newScore > HighScore)
            {
                previousHighScore = highScore;
                highScore = newScore;

                PlayerPrefs.SetInt("highscore", highScore);
                PlayerPrefs.SetInt("previousHighscore", previousHighScore);
            }
            //store data
        }

        #endregion
    }
}