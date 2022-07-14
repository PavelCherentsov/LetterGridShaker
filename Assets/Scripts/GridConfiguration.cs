using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridConfiguration : MonoBehaviour
{
    public int CountColumn { get; set; }
    public int CountRow { get; set; }

    private void Awake()
    {
        CountColumn = 4;
        CountRow = 4;
    }
}
