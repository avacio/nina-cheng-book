using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpriteReplace : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private float timePerSprite = 2f;

    private int currentSprite = 0;

    private void Reset()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    private void OnEnable()
    {
        if (image)
        {
            StartCoroutine(SpriteReplaceCoroutine());
        }
    }

    IEnumerator SpriteReplaceCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timePerSprite);
            int nextIndex = (currentSprite + 1) % sprites.Length;
            image.sprite = sprites[nextIndex];
            currentSprite = nextIndex;
        }
    }
}
