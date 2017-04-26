using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]

public class BehaviourScript : NetworkBehaviour
{
    public float playerSpeed;
    public GameObject explosion;
    public static bool playerAlive;
    private float buff_dur;
    private float buff_speed;
    private bool is_buffed;
    private float speed;

    private Animator anim;

    public override void OnStartServer()
    {
        playerAlive = true;
        anim = GetComponent<Animator>();
        is_buffed = false;
        buff_speed = playerSpeed * 1.5f;
    }

    public override void OnStartLocalPlayer() {       
        Camera.main.GetComponent<cameraControl>().setTarget(gameObject.transform); //sets camera to follow this player
    }

    // fixed update is best used for physics related things.
    // use the regular Update for everything else
    void FixedUpdate() {
        if (!isLocalPlayer) { return; }

        if (is_buffed)
        {
            speed = buff_speed;
            buff_dur -= Time.deltaTime;
            if (buff_dur <= 0)
            {
                is_buffed = false;
            }
        }
        else
        {
            speed = playerSpeed;
        }

        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * speed;

        if(Input.GetAxisRaw("Horizontal") == -1){
            anim.SetTrigger("playerLeft");
        }
        else if(Input.GetAxisRaw("Horizontal") == 1){
            anim.SetTrigger("playerRight");
        } else {
            anim.SetTrigger("playerIdle");
        }
    }

    // we use this function to check to see if the cat has come in contact with the player
    // we also use this function to check if the player comes in contact with a pickup
    //      if a pickup is found another function will deal with what to do
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("cat")) {        
            Instantiate(explosion, transform.position, Quaternion.identity);
            playerAlive = false;
            //anim.SetTrigger("GameOver");
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("pickup")) {
            NetworkServer.Destroy(other.gameObject);
            buff_dur = 5;
            is_buffed = true;
        }
    }



    //void get_hazard() {
    //    for(int i = 0; i < hazard_bar.Length; i++) {
    //        if(hazard_bar[i] == hazard_type.EMPTY) {
    //            hazard_bar[i] = (hazard_type)Random.Range((float)hazard_type.DEFUSE, (float)hazard_type.SEE_THE_FUTURE);
    //            break;
    //        }
    //    }
    //}
}