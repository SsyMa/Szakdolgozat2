using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HideIfNotOwner : NetworkBehaviour
{
    void LateUpdate()
    {
        if (!IsOwner)
        {
            gameObject.SetActive(false);
        }
    }
}
