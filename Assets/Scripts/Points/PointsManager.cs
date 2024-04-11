using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    
    public int points;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void addPoints(int PointsToAdd)
    {
        points += PointsToAdd;
        Debug.Log("Puntos: " + points);
    }
}
