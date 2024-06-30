using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameFaer : MonoBehaviour
{
    [SerializeField] private GameObject objectNaGolove;
    [SerializeField] private bool statusObject = false;

    private void OnEnable()
    {
        if(statusObject)
            GetComponent<PointTrigerObject>().trigerE += TrueObject;
        else
            GetComponent<PointTrigerObject>().trigerE += FalseObject;
    }
    private void OnDisable()
    {
        if (statusObject)
            GetComponent<PointTrigerObject>().trigerE -= TrueObject;
        else
            GetComponent<PointTrigerObject>().trigerE -= FalseObject;
    }
    private void TrueObject()
    {
        if(!objectNaGolove.activeSelf)
            objectNaGolove.SetActive(true);
    }
    private void FalseObject()
    {
        if(objectNaGolove.activeSelf)
            objectNaGolove.SetActive(false);
    }
}
