using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigationPrompt : MonoBehaviour {

    bool showDialog;
    public string destination;

	void OnCollisionEnter2D(Collision2D col)
    {
        showDialog = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        showDialog = false;
    }

    void OnGUI()
    {
        if (showDialog)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
            GUI.Box(new Rect(0, 0, 300, 250), "");
            GUI.Label(new Rect(15, 10, 300, 68), "Do you want to travel to " + destination + "?");
            if (GUI.Button(new Rect(55, 100,180,40), "Travel"))
            {
                showDialog = false;
                // TODO
                //SceneManager.LoadScene(1)
            }

            if (GUI.Button(new Rect(55, 150, 180, 40), "Stay"))
            {
                showDialog = false;
            }

            GUI.EndGroup();
        }
    }
}
