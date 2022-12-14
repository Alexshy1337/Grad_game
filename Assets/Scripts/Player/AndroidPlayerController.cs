using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D player;
    public FixedJoystick MJ, FJ;
    //public float bullet_speed = 10; // скорость пули
    //public Rigidbody2D bullet; // префаб нашей пули
    //public Transform gunPoint; // точка рождения
    //public float fireRate = 1; // скорострельность

    //public Transform zRotate; // объект для вращения по оси Z


    //private float curTimeout;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //if (Input.GetMouseButton(0))
        //{
        //    Fire();
        //}

        //transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePos.y ? ang : -ang);//немного магии напоследок



    }

    void FixedUpdate()
    {
        player.velocity = MJ.Direction * speed;
        if(FJ.Direction != Vector2.zero)
        {
            //function to gradually turn the player sprite to the engle of the joystick
            //transform.eulerAngles
            
            
        }
    }

    double FindAngle(Vector2 v)
    {
        double a = 0;
        v = v.normalized;
        if (v.x >= 0 && v.y >= 0)
        {
            //if (v.x != 0)
                a = Mathf.Acos(v.x);
            //else
                //a = Mathf.Asin(v.y);
        } 
        else if (v.x <= 0 && v.y <= 0)
        {
            a = -Mathf.Acos(v.x);
        }
            
            return a;
    }

    //void Fire()
    //{

        //transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePos.y ? ang : -ang);//немного магии напоследок


        //curTimeout += Time.deltaTime;
        //if (curTimeout > fireRate)
        //{
        //    curTimeout = 0;
        //    Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
        //    clone.velocity = gameObject.transform.rotation.eulerAngles * bullet_speed; /*transform.TransformDirection(gunPoint.right * bullet_speed); new Vector3(0f, 0f, transform.position.y < mousePos.y ? ang : -ang) * bullet_speed;*/
        //    clone.transform.right = gunPoint.right;
        //}
    //}

}



/*
 
    //This script allows to drag rigidbody2D elements on the scene with orthographic camera
//Attach this script to your camera

using UnityEngine;
using System.Collections;

public class DragRigidbody2D : MonoBehaviour
{
    public float Damper = 5f;
    public float Frequency = 3;
    public float Drag = 10f;
    public float AngularDrag = 5f;
   
    private SpringJoint2D _springJoint;

    private Camera _camera;
    private RaycastHit2D _rayHit;

        void Start ()
        {
        _camera = gameObject.GetComponent<Camera>();
        }
       
        void Update ()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        //Looking for any collider2D under mouse position
        _rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (_rayHit.collider == null)
            return;
       
        if (!_rayHit.collider.rigidbody2D || _rayHit.collider.rigidbody2D.isKinematic)
            return;


        if (!_springJoint)
        {
            //Create spring joint
            GameObject go = new GameObject("[Rigidbody2D_dragger]");
            Rigidbody2D body = go.AddComponent<Rigidbody2D>();
            _springJoint = go.AddComponent<SpringJoint2D>();
            body.isKinematic = true;
        }

            _springJoint.transform.position = _rayHit.point;

            _springJoint.anchor = Vector2.zero;

        //Apply parameters to spring joint
            _springJoint.frequency = Frequency;
            _springJoint.dampingRatio = Damper;
            _springJoint.distance = 0;
            _springJoint.connectedBody = _rayHit.collider.rigidbody2D;

            StartCoroutine("DragObject");
        }

    IEnumerator DragObject()
    {
        var oldDrag = _springJoint.connectedBody.drag;
        var oldAngDrag = _springJoint.connectedBody.angularDrag;

        _springJoint.connectedBody.drag = Drag;
        _springJoint.connectedBody.angularDrag = AngularDrag;

        while (Input.GetMouseButton(0))
        {
            Vector2 newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _springJoint.transform.position = new Vector2(newPos.x, newPos.y);
            yield return new WaitForSeconds(0.1f);
        }

        if (_springJoint.connectedBody)
        {
            _springJoint.connectedBody.drag = oldDrag;
            _springJoint.connectedBody.angularDrag = oldAngDrag;
            _springJoint.connectedBody = null;
        }
    }
}
 

 */
