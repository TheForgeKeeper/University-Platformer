using JdnUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JdnUniPlat.Orbs
{
    public class OrbStackUI : MonoBehaviour
    {
        [SerializeField] private float imageSize = 30;
        [SerializeField] private float imagePadding = 10;

        [SerializeField] private RectTransform stackBase;
        [SerializeField] private List<Sprite> OrbSprites;
        [SerializeField] private GameObject imagePrefab;
        
        private Stack<Image> ImagePool;
        private Stack<Image> ActiveImages = new Stack<Image>();
        private int orbsInStack;

        private void Start()
        {
            int totalImagesToPool = 10;
            ImagePool = new Stack<Image>(totalImagesToPool);
            for (int i = 0; i < totalImagesToPool; i++)
            {
                Image currentImage = Instantiate(imagePrefab,stackBase).GetComponent<Image>();
                currentImage.rectTransform.sizeDelta = Swizzle.XX(imageSize);
                currentImage.enabled = false;
                currentImage.rectTransform.anchoredPosition = new Vector2(0,(imageSize + imagePadding) * (totalImagesToPool - i));
                ImagePool.Push(currentImage);
            }
            
        }

        public void AddOrb(JdnOrbs orbType)
        {
            if (ImagePool.Count > 0)
            {
                Image currentImage = ImagePool.Pop();
                currentImage.sprite = OrbSprites[(int)orbType];
                currentImage.enabled = true;
                ActiveImages.Push(currentImage);
            }
            else
            {
                Debug.LogError($"Ran out of PooledImages ln 44 orbStackUI from {this.gameObject.name}");
            }
        }

        public void RemoveOrb()
        {
            if(ActiveImages.Count > 0)
            {
                Image currentImage = ActiveImages.Pop();
                currentImage.sprite = null;
                currentImage.enabled = false;
                ImagePool.Push(currentImage);
            }
            else
            {
                Debug.LogError($"There are no orbs in UI stack to remove ln52 OrbStackUI from {this.gameObject.name}");
            }
        }
    }
}