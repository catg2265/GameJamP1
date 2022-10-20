using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = System.Diagnostics.Debug;

public class Hunter : MonoBehaviour
{
    public GameObject newArrow;
    public GameObject arrow;
    public GameObject crosshair;
    public GameObject crosshair1;

    private Rigidbody2D rb;
    public Animator anime;
    public Transform shotPoint;

    private float moveX;

    public float speed = 5f;
    public float jumpHeight = 0;

    private bool touchGrass = false;
    private bool move;

    private float yes;

    public bool Gamebow;
    public bool GamenonBow;

    private Animator Bow;

    public Vector3 targetoffset;
    public Stopwatch stopwatch;
    public float TimeToMaxDistance;

    public LineRenderer lineRenderer;
    public int positionResolution;
    
    public bool Gamedeath;
    private Animator Death;
    public Transform Lv2;
    public Transform Lv3;
    public int KuduhitCounter = 1;
    public bool KuduHit = false;

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGrass = true;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            GetComponent<Animator>().SetTrigger("Death?");
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.2f, 0.5f);
            speed = 0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGrass = false;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveX = movementVector.x;
        anime.SetFloat("speed", Mathf.Abs(moveX));

        if (touchGrass && movementVector.y >= 0.6f && !move)
        {
            Vector2 jump = new Vector2(0f, jumpHeight);
            rb.AddForce(jump * jumpHeight);
            touchGrass = false; 
        }
    }

    public void OnFireStart(InputValue context)
    {
        yes = context.Get<float>();
        if (yes == 1f && stopwatch == null)
        {
            Gamebow = true;
            move = true;
            stopwatch = Stopwatch.StartNew();
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (yes == 0f)
        {
            Gamebow = false;
            move = false;
            Shoot(crosshair.transform.position);
            stopwatch = null;
        }
    }

    private void Shoot(Vector3 launchForce)
    {
        newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        launchForce -= transform.position;
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1).normalized * Mathf.Abs(launchForce.x);
    }

    Vector2 LinePos(float t, Vector3 launchForce)
    {
        launchForce -= transform.position;
        var temporaryDirection = new Vector2(1, 1).normalized;
        Vector2 shotPosition = (Vector2)shotPoint.position;
        Vector2 tempDirection = (temporaryDirection * Mathf.Abs(launchForce.x) *t);
        Vector2 gravityCalc = 0.5f * Physics2D.gravity * (t * t);
        Vector2 pos =  shotPosition +  tempDirection + gravityCalc;
        return pos;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        crosshair.transform.position += Vector3.down;
        Bow = gameObject.GetComponent<Animator>();
        lineRenderer = FindObjectOfType<LineRenderer>();
        lineRenderer.positionCount = positionResolution*4;
        Death = gameObject.GetComponent<Animator>();

    }
    void FixedUpdate()
    {
        if (yes == 1 && move)
        {
            if(stopwatch != null && ((stopwatch.ElapsedMilliseconds / 1000f) / TimeToMaxDistance) <= 1f)
            {
                crosshair.gameObject.SetActive(true);
                crosshair1.gameObject.SetActive(true);
                lineRenderer.enabled = true;
                crosshair.transform.position = Vector3.Lerp(transform.position + Vector3.down, transform.position +  Vector3.down + targetoffset, (stopwatch.ElapsedMilliseconds / 1000f) / TimeToMaxDistance);
                
                Vector3[] ps = new Vector3[positionResolution*4+1];
                Vector3 pointNearZero = Vector3.zero;
                for(int i = 0; i <= positionResolution*4; i++)
                {
                    var linePosition2D = LinePos(i/((float)positionResolution), crosshair.transform.position);
                    Vector3 linePos = new Vector3(linePosition2D.x, linePosition2D.y, 0);
                    if (linePos.y<0)
                    {
                        ps[i] = pointNearZero;
                    }
                    else
                    {
                        ps[i] = linePos;
                        pointNearZero = linePos;
                        Vector3 crosshairX = new Vector3(pointNearZero.x, 0, 0);
                        crosshair1.transform.position = crosshairX;
                    }
                }
                lineRenderer.SetPositions(ps);
            }
        }
        else if(yes == 0)
        {
            crosshair.transform.position = transform.position + Vector3.down;
            crosshair.gameObject.SetActive(false);
            crosshair1.gameObject.SetActive(false);

            lineRenderer.enabled = false;
        }

        if (touchGrass && !move)
        {   
                Vector2 movement = new Vector2(moveX, 0f);
                rb.AddForce(movement * speed);
            
        }
        else if(!touchGrass && !move)
        {
            Vector2 movement = new Vector2(moveX, 0f);
            rb.AddForce(movement * (speed * 0.2f));   
        }
        if(moveX > 0 && !move)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(moveX < 0 && !move) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
        if (KuduhitCounter == 2 && KuduHit)
        {
            transform.position = Lv2.position;
            KuduHit = false;
            GameObject.FindWithTag("Kudu").GetComponent<KuduController>().tpPlayerCounter = 0f;
        }

        if (KuduhitCounter == 3 && KuduHit)
        {
            transform.position = Lv3.position;
            KuduHit = false;
            GameObject.FindWithTag("Kudu").GetComponent<KuduController>().tpPlayerCounter = 0f;
        }

        
    }
    private void Update()
    {
        GetComponent<Animator>().SetBool("Bow", Gamebow);

        
    }
    
}