using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace hYu
{
    //Links all performers together to run them all at once 
    public class PerformerLink : MonoBehaviour
    {
        Button[] buttons;
        Performer[] performers;

        void Awake()
        {
            var rootAndChildButtons = GetComponents<Button>().ToList();
            rootAndChildButtons.AddRange(GetComponentsInChildren<Button>());
            buttons = rootAndChildButtons.ToArray();

            var rootAndChildPerformers = GetComponents<Performer>().ToList();
            rootAndChildPerformers.AddRange(GetComponentsInChildren<Performer>());
            performers = rootAndChildPerformers.ToArray();
        }
        void OnEnable()
        {
            foreach (var b in buttons)
                b.onClick.AddListener(PerformAll);
        }
        void OnDisable()
        {
            foreach (var b in buttons)
                b.onClick.RemoveListener(PerformAll);
        }

        void PerformAll()
        {
            foreach (Performer p in performers)
            {
                p.Perform();
            }
        }
    }
}