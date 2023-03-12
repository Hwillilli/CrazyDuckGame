using UnityEngine;
using UnityEngine.SceneManagement;


public class CallWallpaper : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        LoadSceneAdditive();
    }

    // Update is called once per frame
    void LoadSceneAdditive()
    {
        SceneManager.LoadScene("wallpapaer", LoadSceneMode.Additive);
    }
}
