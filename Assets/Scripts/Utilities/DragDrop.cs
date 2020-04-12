using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    // private bool isDragging;

    // private Vector2 startPosition;
    // private Transform currentDragging;

    // void check2DObjectClicked()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Debug.Log("Mouse is pressed down");
    //         Camera cam = Camera.main;

    //         //Raycast depends on camera projection mode
    //         Vector2 origin = Vector2.zero;
    //         Vector2 dir = Vector2.zero;

    //         if (cam.orthographic)
    //         {
    //             origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         }
    //         else
    //         {
    //             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //             origin = ray.origin;
    //             dir = ray.direction;
    //         }

    //         RaycastHit2D hit = Physics2D.Raycast(origin, dir, Mathf.Infinity);

    //         //Check if we hit anything
    //         if (hit)
    //         {
    //             Debug.Log(hit.collider.name);
    //             if(hit.collider.tag == "Tower") {
    //                 startPosition = hit.collider.transform.position;
    //                 currentDragging = hit.collider.transform;
    //                 isDragging = true;
    //                 // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - hit.collider.transform.position;
    //                 // hit.collider.gameObject.transform.Translate(mousePosition);
    //             }
    //         }
    //     }
    // }   

    // void Update()
    // {
    //     check2DObjectClicked();

    //     if (Input.GetMouseButtonUp(0)) {
    //         if (currentDragging != null) {
    //             isDragging = false;
    //             currentDragging.position = startPosition;
    //         }
    //     }

    //     if (isDragging) {
    //         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - currentDragging.position;
    //         currentDragging.Translate(mousePosition);
    //     }
    // }

    private bool isDragging;
    private Vector2 startPosition;
    private SpawnTower SpawnTower;


    public void OnMouseDown()
    {
        startPosition = transform.position;
        isDragging = true;

    }

    public void OnMouseUp()
    {
        isDragging = false;
        SpawnTower.Combine(gameObject);
        transform.position = startPosition;
    }

    void Start() {
        SpawnTower = GameObject.Find("Nodes").GetComponent<SpawnTower>();
    }

    void Update()
    {
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    
}
