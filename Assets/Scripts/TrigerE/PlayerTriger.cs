using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriger : MonoBehaviour
{
    private Collider2D playerCol;
    private int maxColCount = 5;

    private void Awake()
    {
        playerCol = GetComponent<Collider2D>();
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hitCol = new Collider2D[maxColCount];
            playerCol.OverlapCollider(new ContactFilter2D().NoFilter(), hitCol);
            if(hitCol.Length > 0)
            {
                foreach (var s in hitCol)
                {
                    if (s.TryGetComponent(out PointTrigerObject d))
                    {
                        d.StartEvent();
                        break;
                    }
                }
            }
            else
                Debug.Log("1");
        }
    }
}
