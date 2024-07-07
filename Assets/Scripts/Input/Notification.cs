using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] private GameObject notificationImage;
    [SerializeField] private Object myComponent;

    private void OnEnable()
    {
        if(myComponent != null)
        {
            if (myComponent is DialogTriger)
            {
                DialogTriger dt = (DialogTriger)myComponent;
                dt.UseEvent += UseFicha;
            }
        }
    }
    private void OnDisable()
    {
        if (myComponent != null)
        {
            if (myComponent is DialogTriger)
            {
                DialogTriger dt = (DialogTriger)myComponent;
                dt.UseEvent -= UseFicha;
            }
        }
    }

    private void UseFicha()
    {
        notificationImage.SetActive(false);
        //this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerInputETriger>() != null)
            notificationImage.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<PlayerInputETriger>() != null)
        {
            notificationImage.SetActive(false);
        }
    }
}
