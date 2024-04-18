using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]

public class dialog
{
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
}
