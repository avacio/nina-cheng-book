using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCamerasController : MonoBehaviour
{
    [SerializeField] private GameObject[] pageContainers = null;

    [Header("Page 17-18")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color dstColor;
    [SerializeField] private Image[] imagesToColorLerp;
    [SerializeField] private float colorLerpTimeDuration = 5f;

    public void Reset()
    {
        pageContainers = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            pageContainers[i] = transform.GetChild(i).gameObject;
        }
    }

    void Start()
    {
        OnFlip(0);
    }

    /// <summary>
    /// Hide page containers if they are not adjacent to the user's currently
    /// visible page
    /// </summary>
    /// <param name="currentPage"></param>
    public void OnFlip(int currentPage)
    {
        UpdatePagesActiveState(currentPage);

        if (currentPage == 19 | currentPage == 20)
        {
            AnimatePage17_18(true);
        }
        else if (currentPage == 17 || currentPage == 18
                                   || currentPage == 21 || currentPage == 22)
        {
            AnimatePage17_18(false);
        }
    }

    private void UpdatePagesActiveState(int currentPage)
    {
        bool shouldShow(int index)
        {
            return index == currentPage
                   || index == currentPage + 1
                   || index == currentPage + 2
                   || index == currentPage - 1
                   || index == currentPage - 2
                   || index == currentPage - 3;
        }
        for (int i = 0; i < pageContainers.Length; i++)
        {
            pageContainers[i].SetActive(shouldShow(i));
        }
    }

    /// <summary>
    /// If {shouldAnimate} is true then it will lerp color.
    /// Else reset colors to initial state to prep for next
    /// animation.
    /// </summary>
    /// <param name="shouldAnimate"></param>
    private void AnimatePage17_18(bool shouldAnimate)
    {
        if (shouldAnimate)
        {
            foreach (var image in imagesToColorLerp)
            {
                StartCoroutine(LerpImageColor(image, dstColor, colorLerpTimeDuration));
            }
        }
        else
        {
            foreach (var image in imagesToColorLerp)
            {
                image.color = startColor;
            }
        }
    }

    private IEnumerator LerpImageColor(Image image, Color dstColor, float timeDuration)
    {
        Color initialColor = image.color;

        float elapsedTime = 0f;
        while (elapsedTime < timeDuration)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(initialColor, dstColor, elapsedTime / timeDuration);
            yield return null;
        }
    }

    // public static void LerpImageColor(Image image, Color dstColor, float timeDuration)
    // {
    //
    // }
}
