using UnityEngine;

namespace hYu
{
    [CreateAssetMenu]
    public class AudioCollection : ScriptableObject
    {
        [field: SerializeField] public AudioClip[] clips { get; private set; }

        AudioClip lastClip;

        public AudioClip GetRandomClip(bool dontRepeat = true)
        {

            if (clips.Length == 0)
                return null;

            if (clips.Length == 1)
            {
                return clips[0];
            }

            //Lazy set default clip
            if (lastClip == null)
                lastClip = clips[0];

            if (dontRepeat)
            {
                AudioClip randomClip;

                do
                {
                    randomClip = getRandomClip();
                } while (lastClip == randomClip);

                lastClip = randomClip;
                return randomClip;
            }
            else
                return getRandomClip();

            //----------------
            AudioClip getRandomClip()
            {
                return clips[Random.Range(0, clips.Length)];
            }
        }
    }
}