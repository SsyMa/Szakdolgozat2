using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphDrawer : MonoBehaviour
{
    public GameObject line;
    public List<Evolution> buttons;
    static Dictionary<int, int> connections = new Dictionary<int, int>
    {
        {1, 0},
        {2, 1},
        {3 , 1},
        {5 , 0},
        {6 , 5},
        {7, 6},
        {8 , 7},
        {26 , 7},
        {27 , 26},
        {9 , 7},
        {4 , 5},
        {24 , 4},
        {23 , 24},
        {22 , 24},
        {14 , 4},
        {25 , 4},
        {10 , 0},
        {11 , 10},
        {12 , 11},
        {13 , 11},
        {15 , 0},
        {16 , 15},
        {17 , 15},
    };

    private void Start()
    {
        DrawGraph();
    }

    public void DrawGraphInEditor()
    {
        Color lineColor = Color.white;
        foreach (int first in connections.Keys)
        {
            Vector2 startPoint = buttons[first].gameObject.transform.position;
            Vector2 endPoint = buttons[connections[first]].gameObject.transform.position;
            Debug.DrawLine(startPoint, endPoint, lineColor, 20);
        }
    }

    public void DrawGraph()
    {
        foreach (int from in connections.Keys)
        {
            GameObject first = buttons[from].gameObject;
            GameObject second = buttons[connections[from]].gameObject;
            float length = (first.transform.position - second.transform.position).magnitude;
            float x = second.transform.position.x - first.transform.position.x;
            float y = second.transform.position.y - first.transform.position.y;
            float angle = Mathf.Atan2 (y, x);
            GameObject go = Instantiate(line, this.transform);
            go.transform.localScale = new(length, 5, 1);
            go.transform.localPosition = first.transform.position;
            go.transform.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
        }
    }
}
