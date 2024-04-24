using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;

    public int points=0;
    public TextMeshProUGUI PointsText;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        PointsText.text = points.ToString("N0");

    }

    public void addPoints(int PointsToAdd)
    {
        points += PointsToAdd;
        Debug.Log("Puntos: " + points);
    }
}

