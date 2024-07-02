using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float Speed = 0.5f;
    public float secondUntilDestroy = 1.2f;
    float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Speed * this.gameObject.transform.forward;
        if (Time.time - startTime >= secondUntilDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}