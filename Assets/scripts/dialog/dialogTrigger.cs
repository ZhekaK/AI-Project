using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dialogTrigger : MonoBehaviour
{
    public dialog dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<dialogManager>().StartDialog(dialog);
    }
}
