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
        DateTime today = DateTime.Today;

        int ageYears = today.Year - BIRTH_DATE.Year;

        if (today.Month < BIRTH_DATE.Month ||
            today.Month == BIRTH_DATE.Month && today.Day < BIRTH_DATE.Day)
        {
            ageYears--;
        }

        textLabel.text = ageYears.ToString();
    }
}