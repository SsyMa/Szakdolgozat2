using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HideOnSpawn : NetworkBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
