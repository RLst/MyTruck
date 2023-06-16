using UnityEngine;

namespace hYu
{
    [RequireComponent(typeof(AudioSource))]
    public class ToggleSoundInteractive : Interactive
    {
        [SerializeField] AudioClip sound;

        [Space]
        [SerializeField] AudioCollection soundCollection;

        bool playCollection = false;

        AudioSource audioSource;

        protected override void Awake()
        {
            base.Awake();
            audioSource = GetComponent<AudioSource>();
        }

        void Start()
        {
            Debug.Assert(audioSource != null, "No audiosource found");
            audioSource.loop = true;

            if (soundCollection != null && soundCollection.clips.Length > 0)
                playCollection = true;
        }

        public override void Run()
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                if (playCollection)
                {
                    audioSource.clip = soundCollection.GetRandomClip();
                    audioSource.Play();
                }
                else
                {
                    audioSource.clip = sound;
                    audioSource.Play();
                }
            }
        }
    }
}