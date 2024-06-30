using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreatScene : MonoBehaviour
{
    [SerializeField] private string sceneLoad;
    private void LoadScene()
    {
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
