using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Ndi;
using System.Linq;
using UnityEngine.UI;

public class CellScaling : MonoBehaviour
{
    [SerializeField]
    GameObject NDIManager;

    void Update()
    {
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        grid.cellSize = NDIManager.GetComponent<NDIManger>().CurrentCellSize;
    }
}
