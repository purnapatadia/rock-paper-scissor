using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPS.UI
{
    public class ScreenStacker
    {
        static Dictionary<System.Type, UIScreen> panels = new Dictionary<System.Type, UIScreen>();

        private static Stack<UIScreen> _screenStack = new Stack<UIScreen>();

        internal static void OpenScreen(UIScreen screen)
        {
            if (screen.shouldHidePreviousPanel)
            {
                for (int i = 0; i < _screenStack.Count;)
                {
                    var oldScreen = _screenStack.Pop();
                    if (oldScreen != null)
                    {
                        oldScreen.OnScreenClosed();
                    }
                }
            }

            screen.OnScreenOpened();
            _screenStack.Push(screen);
        }

        internal static void OpenScreen<T>() where T : UIScreen
        {
            if (panels.ContainsKey(typeof(T)))
            {
                OpenScreen(panels[typeof(T)]);
                //panels[typeof(T)].OnScreenOpened();
            }
            else
            {
                var panel = GameObject.FindObjectOfType<T>();
                panels.Add(typeof(T), panel);
                OpenScreen(panel);
                //panel.OnScreenOpened();
            }
        }

        internal static void CloseScreen(UIScreen screen)
        {
            screen.OnScreenClosed();
        }

        internal static void Clear()
        {
            for (int i = 0; i < _screenStack.Count;)
            {
                var oldScreen = _screenStack.Pop();
                if (oldScreen != null)
                {
                    oldScreen.OnScreenClosed();
                }
            }
            panels.Clear();
        }

    }
}