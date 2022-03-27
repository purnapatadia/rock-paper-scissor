using RPS.Manager;

namespace RPS.Util
{
    public class Constants
    {
        public const string HOME_SCENE = "HomeScene";
        public const string GAME_SCENE = "GameScene";

        public static int ElementCount = GameManager.instance.ElementData.ElementCount;
        public const float RoundTime = 1;
        public const int NextRoundCountDown = 3;
    }
}