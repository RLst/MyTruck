using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace hYu
{
    //Button interactive relay cover class
    [RequireComponent(typeof(Button))]
    public abstract class Interactive : MonoBehaviour
    {
        public UnityEvent onInteracted;

        protected Button button;

        protected virtual void Awake()
        {
            Initialize();
        }

        void OnEnable()
        {
            button.onClick.AddListener(OnClickRelay);
        }

        void OnDisable()
        {
            button.onClick.RemoveListener(OnClickRelay);
        }

        protected void Initialize()
        {
            button = GetComponent<Button>();

            Debug.Assert(button != null, "Button not found");
        }

        protected virtual void OnClickRelay()
        {
            Run();
            onInteracted.Invoke();
        }

        //Run the main interactive action
        public abstract void Run();
    }
}