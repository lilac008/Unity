using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject goBullet = Instantiate(bulletPrefab);
        goBullet.transform.position = new Vector3(Random.Range(-4f, 4f),0);
        
    }
}
