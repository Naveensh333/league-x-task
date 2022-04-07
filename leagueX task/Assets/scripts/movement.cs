using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class movement : MonoBehaviourPunCallbacks
{
    public Animator anim;
    float ver;
    float hor;
    PhotonView view;
    
    float cent;
    // Start is called before the first frame update
    void Start()
    {    
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame   
    void Update()
    {
        if (view.IsMine)
        {
            playermovement();
        }
       
        
    }


    void playermovement()
    {
        hor =SimpleInput.GetAxis("Horizontal");   
        ver = SimpleInput.GetAxis("Vertical");
        anim.SetFloat("hori", hor);
        anim.SetFloat("vert", ver);
    }

   
}   
     