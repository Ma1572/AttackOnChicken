using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private List<GameObject> _tips;
#pragma warning restore 0649

    private void Start()
    {
        int tip = Random.Range(0, _tips.Count);
        for (int i = 0; i < _tips.Count; i++)
        {
            if (tip == i)
            {
                _tips[i].SetActive(true);
            }
            else
            {
                _tips[i].SetActive(false); 
            }
        }
    }
}
