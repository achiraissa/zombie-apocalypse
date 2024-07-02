using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPlayer,flashMuzzle;
    public float nextFire = 0.0f;
    public float fireRate = 0.1f;
    public AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        flashMuzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1) && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Fire();
            gunSound.Play();
            flashMuzzle.SetActive(true);
            StartCoroutine(HideMuzzle(0.12f));
        }
    }

    public void Fire(){
        Instantiate(BulletPlayer, transform.position, transform.rotation);
    }

    IEnumerator HideMuzzle(float secondUntilDestroy){
        yield return new WaitForSeconds(secondUntilDestroy);
        flashMuzzle.SetActive(false);
    }
}
