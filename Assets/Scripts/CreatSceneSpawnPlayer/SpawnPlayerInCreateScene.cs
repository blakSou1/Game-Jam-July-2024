using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerInCreateScene : MonoBehaviour
{
    [SerializeField] private List<Transform> positionSpawnPlayer = new();
    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        if(StaticCreatScenePosition.trigerSceneSpawnNumber == positionSpawnPlayer.Count - 1)
        {
            playerTransform.position = positionSpawnPlayer[StaticCreatScenePosition.trigerSceneSpawnNumber].position;
        }
    }
}
