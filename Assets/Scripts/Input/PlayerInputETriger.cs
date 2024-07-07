using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class PlayerInputETriger : MonoBehaviour
{
    private Collider2D playerCol;
    private int maxColCount = 5;
    public event Action InputE;

    private void Awake()
    {
        playerCol = GetComponent<Collider2D>();
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InputE?.Invoke();
            Collider2D[] hitCol = new Collider2D[maxColCount];
            playerCol.OverlapCollider(new ContactFilter2D().NoFilter(), hitCol);
            if(hitCol.Length > 0)
            {
                foreach (var s in hitCol)
                {
                    if (s != null && s.TryGetComponent(out PointTrigerObject d) && s.gameObject.activeInHierarchy)
                    {
                        d.StartEvent();
                        break;
                    }
                }
            }
        }
    }
}
