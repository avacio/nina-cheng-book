using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageAnimationController : MonoBehaviour
{
    [Header("Page 17-18")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color dstColor;
    [SerializeField] private Image[] imagesToColorLerp;
    [SerializeField] private float colorLerpTimeDuration = 5f;

    /// <summary>
    /// Hide page containers if they are not adjacent to the user's currently
    /// visible page
    /// </summary>
    /// <param name="currentPage"></param>
    public void OnFlip(int currentPage)
    {
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
}
