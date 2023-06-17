using TMPro;
using UnityEngine;

namespace hYu
{
    [RequireComponent(typeof(TMP_Text))]
    public class GreetTextUpdater : MonoBehaviour
    {
        [SerializeField] StringVar playerName;
        [SerializeField] string prefix = "Xe tải của ";
        [SerializeField] string defaultName = "bạn";
        [SerializeField] string postfix = "";

        TMP_Text greetText;

        void Awake()
        {
            greetText = GetComponent<TMP_Text>();
        }

        void Start()
        {
            if (string.IsNullOrEmpty(playerName.value))
                playerName.value = defaultName;

            greetText.text = prefix + playerName.value + postfix;
        }
    }
}