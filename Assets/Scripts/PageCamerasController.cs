using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCamerasController : MonoBehaviour
{
    [SerializeField] private GameObject[] pageContainers = null;

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
}
