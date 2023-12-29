using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateableData : ScriptableObject
{
    public event System.Action OnValuesUpdated;
    public bool autoUpdate;

#if UNITY_EDITOR

    protected virtual void OnValidate()
    {
        if (autoUpdate)
        {
            UnityEditor.EditorApplication.update += NotifyUpdatedValues;
        }
    }

    public void NotifyUpdatedValues()
    {
        UnityEditor.EditorApplication.update -= NotifyUpdatedValues;
        if(OnValuesUpdated != null)
        {
            OnValuesUpdated();
        }
    }

#endif
}