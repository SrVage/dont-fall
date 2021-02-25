using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    private int game = 0;
    public int _players = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        _players = players.Length;
        Application.targetFrameRate = 120;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.name == "Player") endOfGame();
        else _players--;
        if (_players == 1) winOfGame();


    }

    private void endOfGame()
    {
        game = 1;
        Time.timeScale = 0;
    }    

    private void winOfGame()
    {
        game = 2;
        Time.timeScale = 0;
    }

    private void OnGUI()
    {
        GUIStyle style = GUI.skin.GetStyle("label");
        style.fontSize = 60;
        if (game == 0) return;
        else if (game == 1) GUI.Label(new Rect(200, 200, 200, 100), "Loose");
       else GUI.Label(new Rect(200, 200, 200, 100), "Win");
    }
}
