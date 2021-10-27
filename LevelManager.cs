using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public CameraFollow cameraFollow;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public Camera cam;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
