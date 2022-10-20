using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hunter : MonoBehaviour

{
    public GameObject line;
    List <GameObject> lines;
    public int numOfLines;
    public float spaceBetweenPoints;
    float dist;
    
    

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
    Vector2 direction;
    public int positionResolution;
    public float seconds = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGrass = true;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveX = movementVector.x;
        anime.SetFloat("speed", Mathf.Abs(moveX));
            
        if (touchGrass && movementVector.y >= 0.6f)
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
            stopwatch = Stopwatch.StartNew();
        }
        else if (yes == 0f)
        {
            Gamebow = false;
            Shoot(crosshair.transform.position);
            stopwatch = null;
        }
        move = true;
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
        print("t = " +t);
        Vector2 tempDirection = (temporaryDirection * Mathf.Abs(launchForce.x) *t);
        Vector2 gravityCalc = 0.5f * Physics2D.gravity * (t * t);
        Vector2 pos =  shotPosition +  tempDirection + gravityCalc;
        UnityEngine.Debug.Log(pos);
        return pos;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        crosshair.transform.position += Vector3.down;

        Bow = gameObject.GetComponent<Animator>();

        lines = new List<GameObject>();
        lineRenderer = FindObjectOfType<LineRenderer>();
        lineRenderer.positionCount = positionResolution*4;
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
                
                dist = Vector2.Distance(crosshair.transform.position, transform.position);
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
                numOfLines = Mathf.RoundToInt(dist / line.gameObject.transform.localScale.x);
                UnityEngine.Debug.Log(numOfLines);

                //foreach (var line in lines)
                //{
                //    Destroy(line);

                //} 
                //for (int i = 0; i < numOfLines; i++)
                //{
                //    lines.Add(Instantiate(line, shotPoint.position, shotPoint.rotation));
                    
                //}
                /*for(int i = 0; i < numOfLines; i++)
                {
                    lines[i].transform.position = LinePos(i * numOfLines, crosshair.transform.position);
                }*/



            }
        }
        else if(yes == 0)
        {
            
            crosshair.transform.position = transform.position + Vector3.down;
            crosshair.gameObject.SetActive(false);
            crosshair1.gameObject.SetActive(false);

            lineRenderer.enabled = false;
            lines = new List<GameObject>();
        }

        Vector2 bowPosition = transform.position + Vector3.down;
        Vector2 crosshairPos = crosshair.transform.position;
        direction = crosshairPos - bowPosition;
        transform.right = direction;

        



        if (touchGrass)
        {
            if (rb.velocity.x <= speed)
            {
                Vector2 movement = new Vector2(moveX, 0f);
                rb.AddForce(movement * speed);
            }
        }
        else if(!touchGrass)
        {
            Vector2 movement = new Vector2(moveX, 0f);
            rb.AddForce(movement * (speed * 0.4f));
            
        }

        if(moveX > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        if(moveX < 0) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

       


    }

    private void Update()
    {
        GetComponent<Animator>().SetBool("Bow", Gamebow);
        
    }






}
