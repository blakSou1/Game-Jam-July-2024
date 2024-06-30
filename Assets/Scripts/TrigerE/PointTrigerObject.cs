using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigerObject : MonoBehaviour
{
    public event Action trigerE;
    [SerializeField] private bool statusTrigerCollider = false;
    [SerializeField] private bool deleteTrigCol = false;

    private void Awake()
    {
        if (statusTrigerCollider)
            gameObject.AddComponent<ColliderTriger>();
    }
    public void StartEvent()
    {
        trigerE?.Invoke();
        if(statusTrigerCollider && deleteTrigCol)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
