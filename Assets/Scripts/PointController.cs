using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointController : MonoBehaviour
{
    private TextMeshProUGUI pointText;

    private void Start()
    {
        pointText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdatePoints(int points)
    {
        pointText.text = points.ToString();
    }
}
