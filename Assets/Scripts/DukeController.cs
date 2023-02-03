using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeController : MonoBehaviour
{
    public GameObject target, projectile, exit, death, deathAudio;

    [Tooltip("Duke's speed")]
    public float speed = .25f;

    [Tooltip("Max. proyectiles before Duke dies")]
    public int maxProyectiles = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartShooting());
    }

    IEnumerator StartShooting()
    {
        for (int i = 0; i < maxProyectiles; i++)
        {
            yield return new WaitForSeconds(.5f);
            Shoot();
            if (Globals.LevelScore <= -3500) break;
        }
        exit.transform.position = new Vector3(0, 3, 0);
        deathAudio.GetComponent<AudioSource>().Play();
        Instantiate(death, transform.position, transform.rotation);        
        gameObject.SetActive(false);
    } 

    void Shoot()
    {
        var t = transform.position + new Vector3(0, 3, 0);
        var pos = (t - target.transform.position) * -1;
        var p = Instantiate(projectile, t, transform.rotation);
            p . GetComponent<Rigidbody>()
              . AddForce(pos * 100);
    }
}
