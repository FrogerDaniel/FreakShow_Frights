using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitializeGameManager();
    }

    private void InitializeGameManager(){
        //if there is no gameManager
        GameManager existingGameManager = FindObjectOfType<GameManager>();
        if(existingGameManager == null){
            Debug.Log("CREATING PREFAB!");
            //create one
            GameObject gameManagerPrefab = Resources.Load<GameObject>("prefabs/GameManager");
            Instantiate(gameManagerPrefab);
        }
    }
}
