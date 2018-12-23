using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Point : MonoBehaviour
{
    public bool passable = true;
    public int x = 0;
    public int y = 0;
    public GameObject[] linkedPoints = new GameObject[8];


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //just override/overload this
    public void create(int x, int y)
    {
        this.x = x;
        this.y = y;
        Vector3 pos = new Vector3(x, 0, y);
        gameObject.transform.position = pos;
    }

    public void OnMouseDown()
    {
        Debug.Log("Click!");
        Destroy(gameObject);
    }

    public override string ToString()
    {
        string str = this.GetType().ToString() + "{ TransformX:" + gameObject.transform.position.x + " TransformY:" + gameObject.transform.position.z + " X:" + x + " Y:" + y + " }";
        return str;
    }
}
