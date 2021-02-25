using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _Pos = Vector3.zero;
    private float _speed = 1.5f;
    private float x = 0;
    private float y = 0;
    [SerializeField] Camera _cam = null;
    [SerializeField] bool _ground = false;
    private Rigidbody rb = null;
    [SerializeField] GameObject gr = null;
    [SerializeField] GameObject jump = null;
    [SerializeField] GameObject jump2 = null;

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
                rb.velocity += Vector3.up*2;
        }


  
        RaycastHit hit;
        var ray = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetKey(KeyCode.Mouse0))
        {
            _Pos = hit.point;
            transform.LookAt(new Vector3 (_Pos.x, transform.position.y, _Pos.z));
            //rb.velocity = Vector3.forward*_speed;
            transform.Translate(Vector3.forward * _speed*Time.fixedDeltaTime);
        }
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
        }
