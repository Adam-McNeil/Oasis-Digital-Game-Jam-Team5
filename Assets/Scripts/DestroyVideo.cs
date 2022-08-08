using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyVideo : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StartSceneSwitch());
    }

    IEnumerator StartSceneSwitch()
    {
        yield return new WaitForSeconds(96);
        SceneManager.LoadScene("Main");
    }
}
