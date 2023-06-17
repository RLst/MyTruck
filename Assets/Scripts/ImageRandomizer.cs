using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace hYu
{
    public class ImageRandomizer : MonoBehaviour
    {
        [SerializeField] Sprite[] images;
        Image image;

        void Awake()
        {
            image = GetComponent<Image>();
        }

        void Start()
        {
            if (images.Length > 0)
                image.sprite = images[Random.Range(0, images.Length)];
        }
    }
}
