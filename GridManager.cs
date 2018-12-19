using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public int xSize = 1;
    public int ySize = 1;
    public GameObject[] grid;
    public GameObject[] pointCollection;

	// Use this for initialization
	void Start () {
        grid = generateGrid(xSize, ySize);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject[] generateGrid(int xSize, int ySize)
    {
        List<GameObject> field = new List<GameObject>();
        for (int xn = 0; xn < xSize; xn++)
        {
            GameObject pointX = Instantiate(pointCollection[Random.Range(0, 2)]);
            pointX.GetComponent<Point>().create(xn , 0);
            field.Add(pointX);
            for (int yn = 0; yn < ySize; yn++)
            {
                GameObject pointY = Instantiate(pointCollection[Random.Range(0, 2)]);
                pointY.GetComponent<Point>().create(xn, yn);
                field.Add(pointY);
            }
        }
        GameObject[] fieldArray = new GameObject[field.Count];
        fieldArray = field.ToArray();
        return fieldArray;
    }

    public Point getPointByPosition(int x, int y)
    {
        Point result = null;

        for (int n = 0; n < grid.Length; n++)
        {
            Point point = grid[n].GetComponent<Point>();
            if (point.x == x && point.y == y)
            {
                result = point;
            }
        }

        return result;
    }

    public Point[] getNeighbourPoints(int xPos, int yPos)
    {
        Point rootPos = this.getPointByPosition(xPos, yPos);
        Point[] neighbours = new Point[]
        {
                this.getPointByPosition(xPos - 1, yPos - 1), // NW point
				this.getPointByPosition(xPos, yPos - 1), //N point
				this.getPointByPosition(xPos + 1, yPos - 1), //NE point
				this.getPointByPosition(xPos - 1, yPos), //E point
				this.getPointByPosition(xPos + 1, yPos), //W point
				this.getPointByPosition(xPos - 1, yPos + 1), //SE point
				this.getPointByPosition(xPos, yPos + 1), //S point
				this.getPointByPosition(xPos + 1, yPos + 1) //SW point
				
		};

        return neighbours;
    }

    public void debugGetPoint()
    {
        Debug.Log(getPointByPosition(2, 4).ToString());
        Point[] neighbours = getNeighbourPoints(2, 4);
        Debug.Log(neighbours.Length);
        for (int n = 0; n < neighbours.Length; n++)
        {
            try
            {
                Debug.Log(neighbours[n].gameObject.ToString());
            }
            catch
            {

            }

        }
    }
}
