using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriger : MonoBehaviour
{
    [SerializeField] private TextAsset textDialog;
    [SerializeField] private GameObject dialogPanel;

    InkExample dialogScripts;
    bool statDialog = false;

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
        if (!statDialog)
        {
            statDialog = true;
            dialogScripts.enabled = true;
            dialogScripts.EndHistory += EndIstory;

            dialogScripts.StartDialog(textDialog);
        }
    }
    private void EndIstory()
    {
        statDialog = false;
    }
    private void OnDisable()
    {
        GetComponent<PointTrigerObject>().trigerE -= StartDialog;
    }
}
