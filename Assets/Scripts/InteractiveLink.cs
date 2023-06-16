using UnityEngine;
using UnityEngine.Events;

namespace hYu
{
    //Links one or more interactives together so that if one is interacted with, the rest will 
    [RequireComponent(typeof(AudioSource))]
    public class InteractiveLink : MonoBehaviour
    {
        Interactive[] linkedInteractives;

        void Awake()
        {
            linkedInteractives = GetComponentsInChildren<Interactive>();
        }

        void OnEnable()
        {
            foreach (var li in linkedInteractives)
            {
                li.onInteracted.AddListener(() => OnArrayInteract(li));
            }
        }

        void OnDisable()
        {
            foreach (var li in linkedInteractives)
            {
                li.onInteracted.RemoveAllListeners();
            }
        }

        //When at least one interactive has been interacted with
        void OnArrayInteract(Interactive first)
        {
            foreach (Interactive i in linkedInteractives)
            {
                if (i != first)
                    i.Run();
            }
        }
    }
}