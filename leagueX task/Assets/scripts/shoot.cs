using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shoot : MonoBehaviourPunCallbacks
{

    Ray rayposition;
    RaycastHit shotpoint;
    spawnplayer sp;
    public ParticleSystem muzzle;
    public GameObject hiteffect;
    GameObject hiteffectholder;
    PhotonView view;
    public Animator animator;
    int health =100;  
    public Button fir;
    // Start is called before the first frame update
    void Start()
    {
        sp = FindObjectOfType<spawnplayer>();
        muzzle.gameObject.SetActive(false);
        view = GetComponent<PhotonView>();
        fir = FindObjectOfType<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        rayposition = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Physics.Raycast(rayposition, out shotpoint, 1000f);
        Debug.DrawRay(rayposition.origin, rayposition.direction*1000f,Color.blue);
        //Debug.Log(fir.name);


        //Debug.Log(shotpoint.collider.tag);


        sp.healthtxt.text = "Health : " + health;
        if (view.IsMine)
        {
            shootfire();
            muzzleflash();
            //fir.onClick.AddListener(shootfire);
            //fir.onClick.AddListener(muzzleflash);
           
        }
          
        if(health<=0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            view.RPC("gameoverscreen", RpcTarget.Others, "Gameover");
            PhotonNetwork.Destroy(view);
            SceneManager.LoadScene("win");
        }  
           
    }

    
    public void shootfire()
    {
        if(Input.GetMouseButtonDown(0))   
        { 
       
           
                animator.SetTrigger("shoot");
                hiteffectholder = PhotonNetwork.Instantiate(hiteffect.name, shotpoint.point, Quaternion.LookRotation(shotpoint.normal));
                if (shotpoint.transform.tag == "Player")
                {
                    //health = health - 10;
                    view.RPC("healthsc", RpcTarget.All, 10);
                    sp.healthtxt.text = "Health : " + health;
                    Debug.Log(health);
                }
            
        
        }
          
    }
         
    public void muzzleflash()  
    {
        if (Input.GetMouseButtonDown(0))
        {
       
           
                muzzle.gameObject.SetActive(true);
                muzzle.Play();
            
        }
        
       
    }
    [PunRPC]
    void healthsc(int hel)    
    {
        health = health - hel;
    }
    [PunRPC]
    void gameoverscreen(string goname)
    {
        
        SceneManager.LoadScene(goname);
    }
    
}   
