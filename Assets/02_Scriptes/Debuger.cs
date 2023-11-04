using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.Rendering;

[Serializable]
struct DebugTXT
{
    public string textName;
    [ColorUsage(false)]public Color color;
    public GameObject textMeshProOBJ;
    public UnityEvent<float> Value;
}

public class Debuger : MonoBehaviour
{
    [SerializeField] private List<DebugTXT> debugerList;
    [SerializeField] private GameObject _textPrefab;

    private void Start()
    {
        for(int i = 0; i < debugerList.Count; i++)
        {
            GameObject text = Instantiate(_textPrefab);
            text.name = debugerList[i].textName;
            //debugerList[i].textMeshProOBJ = text.gameObject;
        }
    }

    private void LateUpdate()
    {
        
    }
}
