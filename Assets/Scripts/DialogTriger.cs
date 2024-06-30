using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriger : MonoBehaviour
{
    [SerializeField] private List<TextAsset> textDialog;
    [SerializeField] private GameObject dialogPanel;

    InkExample dialogScripts;
    int ind = 0;

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
        if (dialogScripts.enabled == false)
        {
            dialogScripts.enabled = true;
            dialogScripts.EndHistory += EndIs;
            GetComponent<PointTrigerObject>().trigerE -= StartDialog;

            dialogScripts.StartDialog(textDialog[ind]);
            if(ind != textDialog.Count - 1)
                ind++;
        }
    }
    private void EndIs()
    {
        dialogScripts.EndHistory -= EndIs;
        Invoke("EventE", 1f);
    } 
    private void EventE()
    {
        GetComponent<PointTrigerObject>().trigerE += StartDialog;
    }
    private void OnDisable()
    {
        GetComponent<PointTrigerObject>().trigerE -= StartDialog;
    }
}
