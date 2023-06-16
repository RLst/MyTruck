using UnityEngine;
using UnityEngine.UI;

namespace hYu
{
    public abstract class Performer : MonoBehaviour
    {
        protected Button button;
        protected bool hasButton => button != null;

        protected virtual void Awake()
        {
            TryHookUpButton();
        }

        protected void TryHookUpButton()
        {
            button = GetComponent<Button>();
            if (hasButton)
                button.onClick.AddListener(Perform);
        }

        public abstract void Perform();
    }
}