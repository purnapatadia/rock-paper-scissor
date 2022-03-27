using System.Collections;
using System.Collections.Generic;
using RPS.Util;
using UnityEngine;
using System.Linq;


namespace RPS.Data
{
    [System.Serializable]
    public class ElementAction
    {
        public Element element;
        public string action;
    }

    [System.Serializable]
    public class ElementInfo
    {
        public string name;
        public Sprite sprite;
        public Element element;
        [SerializeField]
        public List<ElementAction> nextElements;

    }

    [CreateAssetMenu(fileName = "ElementData", menuName = "SO/Data")]
    public class ElementData : ScriptableObject
    {
        #region Variables

        [SerializeField] private List<ElementInfo> elements;
        public int ElementCount => elements.Count;

        #endregion

        #region PublicMethods

        public Sprite GetSprite(Element element)
        {
            return elements.FirstOrDefault(e => e.element == element)?.sprite;
        }

        public string GetAction(Element currentElement, Element nextElement)
        {
            var element = elements.FirstOrDefault(e => e.element == currentElement);
            if (element == null)
                return string.Empty;

            return element.nextElements.FirstOrDefault(e => e.element == nextElement)?.action;
        }

        public int CanBeat(Element playerElement, Element botElement)
        {
            if (playerElement == Element.None)
                return -1;

            if (playerElement == botElement)
                return 0;

            var pElement = elements.FirstOrDefault(e => e.element == playerElement);

            if (pElement.nextElements.FirstOrDefault(e => e.element == botElement) == null)
                return -1;
            else
                return 1;

        }

        #endregion
    }
}