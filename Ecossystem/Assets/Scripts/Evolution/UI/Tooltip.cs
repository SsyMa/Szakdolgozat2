using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;
    Evolution e;
    EvolutionManager em;
    private void Start()
    {
        em = GameObject.Find("EvolutionManager").GetComponent<EvolutionManager>();
        em.Update += UpdateMessage;

        e = gameObject.GetComponent<Evolution>();
        message = e.ToString();
    }

    private void UpdateMessage()
    {
        if(e != null)
        {
            message = e.ToString();
        }
        else
        {
            e = gameObject.GetComponent<Evolution>();
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TooltipManager._instance.SetAndShowTooltip(message);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TooltipManager._instance.HideToolTip();
    }
}