using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDebug : MonoBehaviour {

    public Point position;
    public GameObject gridMan;

    private bool moving = false;
    public Point movingTarget = null;
    public GameObject sprite;

	// Use this for initialization
	void Start () {
        gridMan = GameObject.Find("GridManager");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            teleportToPoint(gridMan.GetComponent<GridManager>().getPointByPosition(0, 0));
            position = gridMan.GetComponent<GridManager>().getPointByPosition(0, 0);
            StartCoroutine(randomMove());
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            int roll = UnityEngine.Random.Range(0, position.linkedPoints.Length);
            try
            {
                Point target = position.linkedPoints[roll].GetComponent<Point>();
                if (target != null)
                {
                    teleportToPoint(target);
                }

            }
            catch
            {

            }

        }

        if (movingTarget != null)
        {
            moveToPoint(movingTarget);
        }
    }

    public void teleportToPoint(Point point)
    {
        if(point != null)
        {
            Vector3 targetPos = new Vector3(point.x, gameObject.transform.position.y, point.y);
            gameObject.transform.position = targetPos;
            position = gridMan.GetComponent<GridManager>().getPointByPosition(point.x, point.y);
        }

    }

    public void moveToPoint(Point point)
    {
        
        Vector3 target = point.gameObject.transform.position;
        if (movingTarget != null && gameObject.transform.position.x < target.x - 0.01f || gameObject.transform.position.x > target.x + 0.01f || gameObject.transform.position.z < target.z - 0.01f || gameObject.transform.position.z > target.z + 0.01f)
        {
            //Debug.Log("mooving");
            alignToPoint(target);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,target,Time.deltaTime);
        }
        else
        {
            position = gridMan.GetComponent<GridManager>().getPointByPosition(point.x, point.y);
            movingTarget = null;
        }


    }

    private void alignToPoint(Vector3 point)
    {
        if(gameObject.transform.position.x < point.x)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(gameObject.transform.position.x > point.x)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private IEnumerator randomMove()
    {
        while(true)
        {
            if(movingTarget == null)
            {
                
                try
                {
                    Point target = null;
                    while (target == null)
                    {
                        int roll = UnityEngine.Random.Range(0, position.linkedPoints.Length);
                        target = position.linkedPoints[roll].GetComponent<Point>();

                    }
                    if (target != null)
                    {
                        movingTarget = gridMan.GetComponent<GridManager>().getAStar(position, gridMan.GetComponent<GridManager>().getPointByPosition(5, 11));                   
                    }

                }
                catch (Exception e)
                {
                    //Debug.Log(e);
                }
            }

            yield return new WaitForSeconds(1.5f);
        }

    }
}
