using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float playerSpeed = 1000;
    public float directionalSpeed = 20;

    public AudioClip scoreUP;
    public AudioClip damage;

    public GameObject sceneManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position,
                                         new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f),
                                                                    gameObject.transform.position.y,
                                                                    gameObject.transform.position.z),
                                         directionalSpeed * Time.deltaTime);
#endif
        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;

        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
        if(Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z );
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "scoreup")
        {
            GetComponent<AudioSource>().PlayOneShot(scoreUP);
        }

        if (other.gameObject.tag == "triangle")
        {
            GetComponent<AudioSource>().PlayOneShot(damage);
            sceneManager.GetComponent<AppInitilize>().GameOver();
        }
    }
}
