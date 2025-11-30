using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private Transform Player;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    // 1. New variable to track where the finger started
    private Vector2 startTouch;

    private void Start()
    {
        Player = GetComponent<Transform>();
        Vector2 position = transform.position;
        position.x = 0;
        transform.position = position;
    }

    void Update()
    {
        // 2. logic to detect swipe
        bool swipeLeft = false;
        bool swipeRight = false;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            
            if (t.phase == TouchPhase.Began)
            {
                startTouch = t.position;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                // Check if finger moved left or right more than 50 pixels
                if (t.position.x < startTouch.x - 50) swipeLeft = true;
                if (t.position.x > startTouch.x + 50) swipeRight = true;
            }
        }

        // 3. Added "|| swipeLeft" and "|| swipeRight" to your existing checks
        if (Input.GetKeyDown(KeyCode.LeftArrow) || swipeLeft)
        {
            //ako je u prvom lejnu ne radi nista
            if (Lane2)
            {
                Lane2 = false;
                Lane1 = true;
                PomeriNa1();
            }
            else if (Lane3) // Added 'else' to prevent double jumping in one frame
            {
                Lane3 = false;
                Lane2 = true;
                PomeriNa2();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || swipeRight)
        {
            if (Lane2)
            {
                Lane2 = false;
                Lane3 = true;
                PomeriNa3();
            }
            else if (Lane1) // Added 'else' here too
            {
                Lane1 = false;
                Lane2 = true;
                PomeriNa2();
            }
        }
    }

    void PomeriNa1()
    {
        Vector2 position = transform.position;
        position.x = (float)-1.5;
        transform.position = position;
    }
    void PomeriNa2()
    {
        Vector2 position = transform.position;
        position.x = (float)0;
        transform.position = position;
    }
    void PomeriNa3()
    {
        Vector2 position = transform.position;
        position.x = (float)1.5;
        transform.position = position;
    }
}