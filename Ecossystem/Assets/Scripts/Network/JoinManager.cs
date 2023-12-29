using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class JoinManager
{
    public static JoinManager instance;
    private int playerNumber = 0;
    Dictionary<int, GameObject> playerCameras = new();

    private JoinManager() { }

    public static JoinManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new JoinManager();
            }
            return instance;
        }
    }

    public int OnPlayerJoined(GameObject cam)
    {
        playerCameras.Add(playerNumber, cam);
        return playerNumber++;
    }

    public GameObject GetCam(int playerNumber)
    {
        return playerCameras[playerNumber];
    }
}
