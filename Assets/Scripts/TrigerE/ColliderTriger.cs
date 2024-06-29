using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.TryGetComponent<PlayerTriger>(out _))
            GetComponent<PointTrigerObject>().StartEvent();
    }
}
