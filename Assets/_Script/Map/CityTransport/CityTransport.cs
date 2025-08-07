using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityTransport : MonoBehaviour
{

    protected string sceneName = "CityDemo";
    protected virtual void OnMouseDown()
    {
        LoadNewCity();
        Debug.Log("Transport to new city successful");
    }

    protected virtual void LoadNewCity()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
