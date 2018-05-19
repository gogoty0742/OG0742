using UnityEngine;
using System.Collections;



public class GunScript : MonoBehaviour {

    public AudioClip gunSound;
    public GameObject explosion;
    public GameObject sparks;
    AudioSource audioSource;
    RaycastHit hit;


	// ゲームが始まった時に1回呼ばれるメソッド
	void Start () {

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = gunSound;

	}

	// ゲームの1フレームごとに呼ばれるメソッド
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            Shot();
            Instantiate(explosion, transform.position, Quaternion.identity);

        }

	}

    // 銃をうつ時に行いたいことをこの中に書く
    void Shot() {
        
         float distance = 100f;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(center);
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, distance))
        {
            Instantiate(sparks, hit.point, Quaternion.identity);
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.SendMessage("Damage");
            }
        }
    }

	}

