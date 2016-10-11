using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour

{
    public bool DontDestroyEnabled = true;

    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }
}
