using System.Collections;
using UnityEngine;

public class TerrainNode: ScriptableObject
{


    public int id;
    public int health;
    public int position;
    public int price;
    public bool purchased;
    public bool observable;


    public TerrainNode(int Id, int h, int pos, int pri, bool pur, bool obs)
    {
        id = Id;
        health = h;
        position = pos;
        price = pri;
        purchased = pur;
        observable = obs;
       
    }

    // Constructor
    public TerrainNode()
    {
        id = 0;
        health = 1;
        position = 1;
        price = 1;
        purchased = false;
        observable = true;
    }
}

