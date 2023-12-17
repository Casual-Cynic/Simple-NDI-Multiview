using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Ndi;
using System.Linq;
using UnityEngine.UI;

public class NDIManger : MonoBehaviour
{
    [SerializeField]
    public GameObject NDI_RECEIVER_OBJ;
    [SerializeField]
    public Vector2 INPUT_RESOLUTION;
    List<string> ndi_names;

    public Vector2 CurrentCellSize;

    void Start()
    {
        StartCoroutine(NDISearch());
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
    IEnumerator NDISearch()
    {
        yield return new WaitForSecondsRealtime(5);
        ndi_names = NdiFinder.sourceNames.ToList();

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
        yield return null;
    }
}
