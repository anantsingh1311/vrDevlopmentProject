using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    
    void Start()
    {
        playerTransform.position = GameStateManager.Instance.EnteredBar ? new(22, 0, 12) : new(30, 0, -10);
    }
}
