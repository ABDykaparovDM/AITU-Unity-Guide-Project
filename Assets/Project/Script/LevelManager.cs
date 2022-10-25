using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Player player;
    Door door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        if (player.currentDoor)
        {
            door = player.currentDoor.GetComponent<Door>();
            if (door.enter)
            {
                player.transform.position = door.startPosition;
                SceneManager.LoadScene(door.nextRoom);
            }
        }
    }
}
