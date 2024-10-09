using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Transform movePoint;

    public LayerMask whatStopsMovement;

    void Start()
    {
        movePoint.parent = null;  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            //Debug.Log("cLOSEeNOUGH");
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                Debug.Log("Hori");
                if (!Physics.CheckBox(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), new Vector3(0.2f, 0.2f, 0.2f), new Quaternion(0f, 0f, 0f, 0f), whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                if(Physics.CheckBox(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), new Vector3(0.2f, 0.2f, 0.2f), new Quaternion(0f, 0f, 0f, 0f), whatStopsMovement))
                {
                    Debug.Log("wall");
                    AudioManager.instance.PlayOneShot(FmodsEvents.instance.wallInTheWay, this.transform.position);
     
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                Debug.Log("Verti");
                if (!Physics.CheckBox(movePoint.position + new Vector3(0f, 0f, Input.GetAxisRaw("Vertical")), new Vector3(0.2f, 0.2f, 0.2f), new Quaternion(0f, 0f, 0f, 0f), whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
                    Debug.Log("nowall");
                }
                //if (Physics.CheckBox(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), new Vector3(0.2f, 0.2f, 0.2f), new Quaternion(0f, 0f, 0f, 0f), whatStopsMovement))
                else{
                    Debug.Log("wall");
                    AudioManager.instance.PlayOneShot(FmodsEvents.instance.wallInTheWay, this.transform.position);
                    
                }
            }

        }
    }
}
