using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    [SerializeField] private float AutoSaveFrequency;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
            StartCoroutine(AutoSave());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        DetectionData.size = DetectionData.IDs.Count;
        PlayerPrefs.SetInt("size", DetectionData.size);
        for(int i = 0; i < DetectionData.IDs.Count; i++)
        {
            PlayerPrefs.SetInt("Detector" + i.ToString(), DetectionData.IDs[i]);
            PlayerPrefs.SetInt("left" + i.ToString(), DetectionData.LeftDetect[i]);
            PlayerPrefs.SetInt("right" + i.ToString(), DetectionData.RightDetect[i]);
        }
    }

    public void Load()
    {
        DetectionData.size = PlayerPrefs.GetInt("size");
        for (int i = 0; i < DetectionData.size; i++)
        {
            DetectionData.IDs.Add(PlayerPrefs.GetInt("Detector" + i.ToString()));
            DetectionData.LeftDetect.Add(PlayerPrefs.GetInt("left" + i.ToString()));
            DetectionData.RightDetect.Add(PlayerPrefs.GetInt("right" + i.ToString()));
        }
    }

    public IEnumerator AutoSave()
    {
        while (true)
        {
            Save();
            yield return new WaitForSeconds(AutoSaveFrequency);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(AutoSave());
    }
}
