using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointTrigerObject))]
public class MiniGameFaer : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectUse = new();
    [SerializeField] private bool oneUse = false;

    private void OnEnable()
    {
        GetComponent<PointTrigerObject>().trigerE += ObjectActiveAne;
    }
    private void OnDisable()
    {
        GetComponent<PointTrigerObject>().trigerE -= ObjectActiveAne;
    }

    private void ObjectActiveAne()
    {
        foreach(var a in objectUse)
        {
            a.SetActive(!a.activeInHierarchy);
        }
        if (oneUse)
            this.enabled = false;
    }
}
