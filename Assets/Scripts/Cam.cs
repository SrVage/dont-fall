using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position;
        transform.position = Vector3.Lerp(transform.position, target, 0.9f * Time.deltaTime);
    }
}
