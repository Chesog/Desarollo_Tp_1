using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    static Transform playerpos;
    static Transform player_R_Container;

    private void Awake()
    {
        playerpos = GameObject.Find("Player").transform;
        player_R_Container = GameObject.Find("Container_R").transform;

    }

    public static Transform GetPlayerPos() 
    {
        return playerpos;
    }

    public static Transform GetPlayer_R_Container()
    {
        return player_R_Container;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
