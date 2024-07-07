using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointTrigerObject))]
public class ColliderTriger : MonoBehaviour
{
    [SerializeField] private bool deleteColliderNextUpdate = false;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.GetComponent<PlayerInputETriger>() != null)
        {
            GetComponent<PointTrigerObject>().StartEvent();
            if (deleteColliderNextUpdate)
                Destroy(gameObject, 0);
        }
    }
}
