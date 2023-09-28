using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{
    //Call this method on the Play Button when it is clicked.
    public void StartGame()
    {
        //Make sure to click ADD OPEN SCENES in the Build Settings
        //Scenes indexed from 0, 1, 2, etc. instead of 1, 2, 3 (like Arrays).
        //0 = Title Screen, 1 = DemoScene
        SceneManager.LoadScene(1);
    }

    //Call this method on the Quit Button when it is clicked.
    //Call Unity's built-in Application class and it's built-in Quit() method
    //To exit the Application. This only works in Builds, and not in Unity Editor.
    public void QuitGame()
    {
        Application.Quit();
    }
}
