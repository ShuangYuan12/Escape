using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Floor
{
    F2,
    F3,
    F4,
    F5
}

public enum Scene
{
    Start,
    Escape,
    BE1,
    BE2,
    BE3,
    TE,
    HE
}

public class GameManager : MonoBehaviour
{
    public static Scene endScene;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void changeScene(Scene scene)
    {
        SceneManager.LoadScene("End");
        switch (scene)
        {
            case Scene.BE1:
                endScene = Scene.BE1;
                break;
            case Scene.BE2:
                endScene = Scene.BE2;
                break;
            case Scene.BE3:
                endScene = Scene.BE3;
                break;
            case Scene.TE:
                endScene = Scene.TE;
                break;
            case Scene.HE:
                endScene = Scene.HE;
                break;
            default:
                break;
        }
    }

    public static void moveEnable(bool c, bool m)
    {
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        mainCamera.GetComponent<CameraController>().enabled = c;
        player.GetComponent<Player>().enabled = m;
    }

    public static void Fade(RawImage rawImage, Color color, float fadeSpeed)
    {
        rawImage.color = Color.Lerp(rawImage.color, color, fadeSpeed * Time.deltaTime);
    }

}
