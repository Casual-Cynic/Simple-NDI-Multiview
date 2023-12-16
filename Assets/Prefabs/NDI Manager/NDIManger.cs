using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Ndi;
using System.Linq;

public class NDIManger : MonoBehaviour
{
    List<string> ndi_names;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NDISearch());
    }

    IEnumerator NDISearch()
    {
        yield return new WaitForSecondsRealtime(1);
        ndi_names = NdiFinder.sourceNames.ToList();
        int i = 0;
        foreach (string name in ndi_names)
        {
            Debug.Log(i + " : " + name.ToString());
            i ++;
        }
        yield return null;
    }
}
