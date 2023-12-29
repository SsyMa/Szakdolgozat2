using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TechTreeManager : NetworkBehaviour
{
    public GameObject canvas;

    public void OpenTechTree()
    {
        if (IsOwner || IsHost)
        {
            canvas.SetActive(true);
        }
    }

    public void CloseTechTree()
    {
        if (IsOwner || IsHost)
        {
            canvas.SetActive(false);
        }
    }
}
