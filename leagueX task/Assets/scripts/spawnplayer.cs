using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class spawnplayer : MonoBehaviour
{

    public GameObject spawnpos;
    public GameObject spawnpos2;
    GameObject playerGO;
    public GameObject player;
    Vector3 spawningposition;
    public Text healthtxt;
    
    // Start is called before the first frame update  
    void Start()
    {
        spawningposition = new Vector3(Random.Range(spawnpos.transform.position.x, spawnpos2.transform.position.x), 0.5f, Random.Range(spawnpos.transform.position.z, spawnpos2.transform.position.z));
        playerGO = PhotonNetwork.Instantiate(player.name, spawningposition, Quaternion.identity);
        playerGO.transform.Find("Main Camera").gameObject.SetActive(true);
    }     
       
    // Update is called once per frame
    void Update()
    {
           
    }
}
