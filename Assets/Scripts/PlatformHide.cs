using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHide : MonoBehaviour
{
    private void Start()
    {
    }

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("hidePlatform");
            Destroy(gameObject, 2.0f);
        }
    }

    private IEnumerator hidePlatform()
    {
        for (int i = 0; i<20; i++)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, Color.red, Time.deltaTime*7);
            transform.Translate(0, 0.005f, 0);
            yield return new WaitForSeconds (0.03f);
        }
        for (int i = 0; i < 20; i++)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, Color.white, Time.deltaTime * 7);
            transform.Translate(0, -0.005f, 0);
            yield return new WaitForSeconds(0.03f);
        }
        
       
    }
}
