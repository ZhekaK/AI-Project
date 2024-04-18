using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum direction
{
    Right,
    Left
}
public struct DetectionData
{
    //public static float positionDetect;
    public static int size;
    public static List<int> IDs = new List<int>();
    public static List<int> LeftDetect = new List<int>();
    public static List<int> RightDetect = new List<int>();
}
