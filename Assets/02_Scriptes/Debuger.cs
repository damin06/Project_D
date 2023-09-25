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
    public TextMeshProUGUI textMeshPro;
    public UnityEvent<float> Value;
}

public class Debuger : MonoBehaviour
{
    [SerializeField] private List<DebugTXT> debugerList;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        
    }
}
