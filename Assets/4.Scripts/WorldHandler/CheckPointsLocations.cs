
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsLocations : MonoBehaviour
{
    public float gap;
    public List<GameObject> checkPoints;
    public List<GameObject> bouncePoints;
    
    private void Awake()
    {
        _SetCheckPointsPositions();
    }

    private void _SetCheckPointsPositions()
    {
        int j = 0;
        for (int i = checkPoints.Count-2; i >= -1; i--)
        {
            checkPoints[j].transform.position = new Vector3(0,0,gap*i);
            j++;
        }
    }
}
