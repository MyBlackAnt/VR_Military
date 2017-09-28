using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private List<player> playerList = new List<player>();
    private List<player> mySoldierList = new List<player>();
    private List<player> AISoldierList = new List<player>();
    public Path path;
    public Path aiPath;

	void Start ()
    {
        //Invoke("SpawnPlayer", 1);
        //Invoke("SpawnTank", 5);
        Invoke("MySpawnSoldier", 1f);
        Invoke ("AISpawnSoldier", 1f);
    }
	
	void Update ()
    {
		
	}

    public void RemovePlayer(player p)
    {
        playerList.Remove(p);
    }
    void AISpawnSoldier()
    {
        GameObject obj = Instantiate(Resources.Load("Soldier")) as GameObject;
        player p = obj.GetComponent<player>();
        p.tag = "enemy";
        p.SetTag("player");
        p.name = "Enemy";
        p.SetPath(aiPath);
        AISoldierList.Add(p);
    }
    void MySpawnSoldier()
    {
        GameObject obj = Instantiate(Resources.Load("Soldier")) as GameObject;
        player p = obj.GetComponent<player>();
        p.name = "MySoldier";
        p.tag = "player";
        p.SetTag("enemy");
        p.SetPath(path);
        mySoldierList.Add(p);
    }
    void SpawnPlayer()
    {
        //int random = Random.Range(0, paths.Length);
        GameObject obj = Instantiate(Resources.Load("Player")) as GameObject;
        player p = obj.GetComponent<player>();
        
        p.SetPath(path);
        playerList.Add(p);
    }

    void SpawnTank()
    {
        //int random = Random.Range(0, paths.Length);
        GameObject obj = Instantiate(Resources.Load("Tank")) as GameObject;
        player p = obj.GetComponent<player>();
        p.SetPath(path);
        playerList.Add(p);
    }

    public void OnButtonClick()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].Attacked(10);
        }
    }

}
