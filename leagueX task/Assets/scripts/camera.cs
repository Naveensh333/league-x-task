using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class camera : MonoBehaviourPunCallbacks
{
    float mouseX;
    float mouseY;
    public float sensitivity;
    float xrotat;
    PhotonView view;
   
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        view = GetComponent<PhotonView>();

          
          
    }
   
    // Update is called once per frame
    void Update()
    {

        mousepoint();
        
            if (view.IsMine)
            {
                camrotat();
            }
        
       
       
    }

    void camrotat()
    {
        
        mouseX = SimpleInput.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = SimpleInput.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xrotat -= mouseY;
        xrotat = Mathf.Clamp(xrotat, -30f, 20f);
          
        transform.localRotation = Quaternion.Euler(xrotat,0f, 0f);
      
        

        player.transform.Rotate(Vector3.up * mouseX);
        
    }
    void mousepoint()

    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;  
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}   
