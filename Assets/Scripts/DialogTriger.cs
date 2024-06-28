using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriger : MonoBehaviour
{
    [SerializeField] private TextAsset textDialog;
    [SerializeField] private GameObject dialogPanel;

    InkExample dialogScripts;

    void Start()
    {
        dialogScripts = dialogPanel.GetComponent<InkExample>();

        dialogScripts.StartDialog(textDialog);
    }

}
