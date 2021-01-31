using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private int brothersToWin = 4;
    private int currentBrothers = 0;
    private GameObject player;
    private GameObject sewerExit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sewerExit = GameObject.Find("SewerExit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        currentBrothers = player.GetComponent<DuckMovement>().ducklingStack.Count;
        if (currentBrothers == brothersToWin) {
            Destroy(sewerExit);
        }
    }
}
