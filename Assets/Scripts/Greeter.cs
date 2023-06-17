using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace hYu
{
    public class Greeter : MonoBehaviour
    {
        const string KEY_PLAYERNAME = "PLAYERNAME";

        [SerializeField] TMP_InputField inputField;
        [SerializeField] StringVar playerName;

        [SerializeField] string mainSceneName;

        void Start()
        {
            //Retrieve and set player name is there's existing
            var ppName = PlayerPrefs.GetString(KEY_PLAYERNAME);
            if (ppName == null)
                return;

            inputField.text = playerName.value = ppName;
        }

        public void OnNameInput(string inputName)
        {
            // playerName.value = inputName;
            PlayerPrefs.SetString(KEY_PLAYERNAME, playerName.value = inputName);
            SceneManager.LoadScene(mainSceneName);
        }
    }
}