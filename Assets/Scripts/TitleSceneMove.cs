using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleSceneMove : MonoBehaviour
{
    public void SceneMove()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
