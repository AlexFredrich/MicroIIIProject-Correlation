using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{

    public void OnButtonClicked()
    {

            SceneManager.LoadScene("2nd Level");
        
    }
}