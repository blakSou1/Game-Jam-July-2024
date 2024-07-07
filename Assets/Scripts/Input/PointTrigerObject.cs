using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigerObject : MonoBehaviour
{
    public event Action trigerE;

    public void StartEvent()
    {
        trigerE?.Invoke();
    }
}
