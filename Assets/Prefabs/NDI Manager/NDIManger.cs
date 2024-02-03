using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Ndi;
using System.Linq;
using UnityEngine.UI;
using JetBrains.Annotations;

public class NDIManger : MonoBehaviour
{
    [SerializeField]
    public GameObject NDI_RECEIVER_OBJ;
    [SerializeField]
    public GameObject SOURCE_DROPDOWN;
    [SerializeField]
    public Vector2 INPUT_RESOLUTION;
    public List<string> ndi_names;

    public Vector2 CurrentCellSize;

    void Start()
    {
        //StartCoroutine(NDISearch());
    }

    void Update()
    {
        CurrentCellSize = GetCurrentCellSize();
    }

    public Vector2 GetCurrentCellSize()
    {
        int ndi_count = GameObject.FindGameObjectsWithTag("ActiveNdi").Count();
        if (ndi_count <= 1)
        {
            ndi_count = 1;
        }

        Vector2 resolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        int square_size = Mathf.CeilToInt(Mathf.Sqrt(ndi_count));
        Vector2 CurrentCellSize = new Vector2(resolution.x / square_size, resolution.y / square_size);
        return CurrentCellSize;
    }

    public void RefreshNDI()
    {
        List<string> activeNdiList = new List<string>();
        foreach (string _sourceName in ndi_names)
        {
            GameObject _source = GameObject.Find(_sourceName);
            if (_source.tag == "ActiveNdi")
            {
                activeNdiList.Add(_sourceName);
            }
            GameObject.Destroy(_source);
        }

        ndi_names = NdiFinder.sourceNames.ToList();
        NDISearch();
        SOURCE_DROPDOWN.GetComponent<SourceManager>().UpdateDropdownSources(ndi_names);

        Debug.Log(activeNdiList.Count);
        if (activeNdiList != null)
        {
            Debug.Log("activeNdiList != null");
            foreach (string _activeNdi in activeNdiList)
            {
                GameObject _source = GameObject.Find(_activeNdi);
                GameObject PanelGameObj = GameObject.Find("Panel");

                _source.transform.SetParent(PanelGameObj.transform);
                _source.tag = "ActiveNdi";
                Debug.Log("Readded Active Source: " + _source.name);
            }
        }
        Debug.Log("There are [" + ndi_names.Count + "] entries in ndi_names");
    }

    public void NDISearch()
    {
        int i = 0;
        foreach (string _sourceName in ndi_names)
        {
            NdiReceiver _receiver;
            GameObject _ndiReceiver = Instantiate(NDI_RECEIVER_OBJ);
            RawImage _ndiImg = _ndiReceiver.GetComponent<RawImage>();
            RenderTexture _ndiRenderTex = new RenderTexture(1280, 720, 16);

            _ndiRenderTex.name = _sourceName + "_rTex";
            _ndiReceiver.name = _sourceName;
            _receiver = _ndiReceiver.GetComponent<NdiReceiver>();
            _receiver.ndiName = _sourceName;
            _receiver.targetTexture = _ndiRenderTex;
            _ndiImg.texture = _ndiRenderTex;

            _ndiImg.GetComponent<RectTransform>().sizeDelta = CurrentCellSize;

            Debug.Log(i + " : " + _sourceName.ToString());
            i ++;
        }
    }
}
