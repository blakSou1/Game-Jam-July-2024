using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] private GameObject notificationImage;

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
    private void OnDisable()
    {
        if(notificationImage.activeInHierarchy)
            notificationImage.SetActive(false);
    }
}
