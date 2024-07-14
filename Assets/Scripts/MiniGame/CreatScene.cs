using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PointTrigerObject))]
public class CreatScene : MonoBehaviour
{
    [SerializeField] private string sceneLoad;
    [SerializeField] private int trigerNumberSpawnPoint;

    private void LoadScene()
    {
        StaticCreatScenePosition.trigerSceneSpawnNumber = trigerNumberSpawnPoint;
        SceneManager.LoadScene(sceneLoad);
    }
    private void OnEnable()
    {
        GetComponent<PointTrigerObject>().trigerE += LoadScene;
    }
    private void OnDisable()
    {
        GetComponent<PointTrigerObject>().trigerE -= LoadScene;
    }
}
