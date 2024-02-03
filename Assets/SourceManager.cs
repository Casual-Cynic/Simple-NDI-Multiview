using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class SourceManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private GameObject NDIManger;

    public void GetDropdownValue()
    {
        int currentIndex = dropdown.value;
        string currentSourceName = dropdown.options[currentIndex].text;

        //Debug.Log("Selected Source: " + "["+currentIndex+"] "+currentSourceName);
    }

    public void UpdateDropdownSources(List<string> ndi_names)
    {
        foreach (string _sourceName in ndi_names)
        {
            bool entryExists = false;
            
            for (int i = 0; i < dropdown.options.Count; i++)
            {
                if (dropdown.options[i].text == _sourceName)
                {
                    entryExists = true;
                }
            }

            if (!entryExists)
            {
                dropdown.options.Add(
                    new TMP_Dropdown.OptionData(_sourceName));
                Debug.Log("Added Source: " + _sourceName);
            }

        }

        dropdown.RefreshShownValue();

        Debug.Log("Updated Dropdown List with [" + ndi_names.Count + "] entries");
    }

    public void AddActiveSource()
    {
        int currentIndex = dropdown.value;
        string currentSelectedSourceName = dropdown.options[currentIndex].text;

        GameObject ActiveSource = GameObject.Find(currentSelectedSourceName);
        GameObject PanelGameObj = GameObject.Find("Panel");

        ActiveSource.transform.SetParent(PanelGameObj.transform);
        ActiveSource.tag = "ActiveNdi";
        Debug.Log("Added Active Source: " + ActiveSource.name);
    }

    public void RemoveActiveSource()
    {
        int currentIndex = dropdown.value;
        string currentSelectedSourceName = dropdown.options[currentIndex].text;

        GameObject ActiveSource = GameObject.Find(currentSelectedSourceName);
        
        ActiveSource.transform.SetParent(NDIManger.transform);
        ActiveSource.tag = "Untagged";
        Debug.Log("Removed Active Source: " + ActiveSource.name);
    }
}
