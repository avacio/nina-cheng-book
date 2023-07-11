using System;
using TMPro;
using UnityEngine;

public class DynamicAge : MonoBehaviour
{
    private static DateTime BIRTH_DATE = new DateTime(1997, 07, 11);
    [SerializeField] private TextMeshProUGUI textLabel = null;

    private void Reset()
    {
        textLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        var ageYears = (DateTime.Now - BIRTH_DATE).Days / 365f;
        string liveAgeString = Math.Floor(ageYears).ToString();
        textLabel.text = liveAgeString;
    }
}
