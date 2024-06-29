using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriger : MonoBehaviour
{
    [SerializeField] private TextAsset textDialog;
    [SerializeField] private GameObject dialogPanel;

    InkExample dialogScripts;

    private void Start()
    {
        dialogScripts = dialogPanel.GetComponent<InkExample>();
    }
    private void OnEnable()
    {
        GetComponent<PointTrigerObject>().trigerE += StartDialog;
    }
    private void StartDialog()
    {
        dialogScripts.StartDialog(textDialog);
    }
    private void OnDisable()
    {
        GetComponent<PointTrigerObject>().trigerE -= StartDialog;
    }
}
