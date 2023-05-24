using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class hareket : MonoBehaviour
{
     

    // Update is called once per frame
    void Update()
    {
        hareketEt();
    }

    void hareketEt()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(GetComponent<PhotonView>().IsMine)
            {
               
            }
        }
    }

    
}
