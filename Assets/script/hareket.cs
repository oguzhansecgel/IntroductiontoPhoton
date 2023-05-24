using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class hareket : MonoBehaviour
{

    PhotonView pw;
    int can = 100;
    // Update is called once per frame
    private void Start()
    {
        pw = GetComponent<PhotonView>();
        if(pw.IsMine==true)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void Update()
    {
        if(pw.IsMine==true)
        {
            hareketEt();
            atesEt();
        }
        
    }

    void hareketEt()
    {
        float X = Input.GetAxis("Horizontal") * Time.deltaTime * 30f;
        float Y = Input.GetAxis("Vertical") * Time.deltaTime * 30f;
        transform.Translate(X, 0, Y);
    }
    void atesEt()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.forward, out hit,100f))
            {
                hit.collider.gameObject.GetComponent<PhotonView>().RPC("yokol", RpcTarget.All, 10);
            }
        }
    }
    [PunRPC]

    public void yokol(int deger)
    {

        can -= deger;
        Debug.Log(can);
        if(can <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
        }
        
    }

}
