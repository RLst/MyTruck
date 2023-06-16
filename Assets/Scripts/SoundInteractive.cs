using System;
using UnityEngine;

namespace hYu
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundInteractive : Interactive
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

            if (soundCollection != null && soundCollection.clips.Length > 0)
                playCollection = true;
        }

        public override void Run()
        {
            Debug.Log($"Running: {name}");

            //Stop any current playing sound and play new one
            audioSource.Stop();
            if (playCollection)
            {
                audioSource.PlayOneShot(soundCollection.GetRandomClip());
            }
            else
                audioSource.PlayOneShot(sound);
        }
    }
}