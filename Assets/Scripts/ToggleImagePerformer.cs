using System;
using UnityEngine;
using UnityEngine.UI;

namespace hYu
{
    //Toggles image on or off
    [RequireComponent(typeof(Image))]
    public class ToggleImagePerformer : Performer
    {
        [SerializeField] bool enabledOnStart = false;
        [SerializeField] Sprite sourceImage;

        Image image;

        protected override void Awake()
        {
            image = GetComponent<Image>();
        }

        void Start()
        {
            image.sprite = sourceImage;
            image.enabled = enabledOnStart;
        }

        public override void Perform()
        {
            image.enabled = !image.enabled;
        }
    }
}