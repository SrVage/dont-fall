using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Vector3 _Pos = Vector3.zero;
    private float _speed = 1.5f;
    private float x = 0;
    private float y = 0;
    [SerializeField] bool _ground = false;
    private Rigidbody rb = null;
    [SerializeField] GameObject jump = null;
    [SerializeField] GameObject jump2 = null;
    private float time = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Debug.DrawRay(gameObject.transform.position, Vector3.down, Color.red);
        Debug.DrawRay(gameObject.transform.position, jump.transform.position - gameObject.transform.position, Color.green);
        Debug.DrawRay(gameObject.transform.position, jump2.transform.position - gameObject.transform.position, Color.green);
        if (playerOnGround() && !forwardGround())
        {
            rb.velocity += Vector3.up * 2;
        }
        transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);

    }

    private bool playerOnGround()
    {
        Ray ray2 = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit onGround;
        if (Physics.Raycast(ray2, out onGround, 0.8f)) return true;
        else return false;
    }

    private bool forwardGround()
    {
        Ray ray = new Ray(gameObject.transform.position, jump.transform.position - gameObject.transform.position);
        Ray ray2 = new Ray(gameObject.transform.position, jump2.transform.position - gameObject.transform.position);
        RaycastHit platf;
        RaycastHit platf2;
        if (Physics.Raycast(ray, out platf, 4f) || Physics.Raycast(ray, out platf2, 4f))
            return true;
        else return false;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time>=Random.Range(1.0f, 3.0f))
        {
            int i = Random.Range(0, 7);
            transform.Rotate(new Vector3(0, 45*i, 0));
            time = 0;
        }
    }
}
