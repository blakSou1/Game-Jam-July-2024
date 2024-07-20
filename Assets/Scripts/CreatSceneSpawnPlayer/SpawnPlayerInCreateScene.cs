using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerInCreateScene : MonoBehaviour
{
    [SerializeField] private List<Transform> positionSpawnPlayer = new();

    private void Start()
    {
        if(StaticCreatScenePosition.trigerSceneSpawnNumber < positionSpawnPlayer.Count)
        {
            transform.position = positionSpawnPlayer[StaticCreatScenePosition.trigerSceneSpawnNumber].position;
        }
    }
}
