using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class cameraControl : MonoBehaviour
{
    public Transform player;    
    private Vector3 offset; 
    private Vector3 origin = new Vector3(0, 0);
   // private Animator anim;

    void Start()
    {
     //   anim = GetComponent<Animator>();
        offset = transform.position; // - player.position; there was some issue with camera offset so im leaving the old code just in case
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        //if (player.gameObject.active)
        //{
            transform.position = player.position + offset;
        //} else
       // {
          //  transform.position = origin + offset;
            //Camera.main.orthographicSize = 25f;
        //}
    }

    public void setTarget(Transform target)
    {
        player = target;
    }
}
