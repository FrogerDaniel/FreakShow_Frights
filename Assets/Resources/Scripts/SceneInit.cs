using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{
    void Start()
    {
        InitializeGameManager();
    }

    private void InitializeGameManager()
    {
        GameManager existingGameManager = FindObjectOfType<GameManager>();
        if (existingGameManager == null)
        {
            Debug.Log("CREATING PREFAB!");
            GameObject gameManagerPrefab = Resources.Load<GameObject>("prefabs/GameManager");
            GameObject instantiatedManager = Instantiate(gameManagerPrefab);
            DontDestroyOnLoad(instantiatedManager);
        }
    }
}
