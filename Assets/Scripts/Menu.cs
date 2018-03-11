using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public Transition transitionPrefab;

    public void PlayGame()
    {
        Vector2 pos = new Vector2(0f, 2.4f);
        Transition tra = Instantiate(transitionPrefab, pos, Quaternion.identity) as Transition;
        tra.destinationScene = "Level01";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
