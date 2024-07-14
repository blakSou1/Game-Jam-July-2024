using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishTrigger : MonoBehaviour
{
    public event Action Dead;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Assets.Scripts.PlayerMove.Swimming>() != null)
        {
            gameObject.SetActive(false);
            Dead?.Invoke();
        }
    }
}
