using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject hoverOver;
    [SerializeField] private string path = "Assets/TileList.txt";
    [SerializeField] private GameObject tilePrefab;
    private List<Tile> bag = new List<Tile>();


    private void Start()
    {
        populateBag();
        shuffleBag();
    }

    public void drawFromBagAndSet(Space s)
    {
        if (bag.Count > 0)
        {
            GameObject t = (GameObject)Instantiate(tilePrefab);
            Tile item = bag[0];
            bag.RemoveAt(0);
            t.GetComponent<Tile>().setLetter(item.getLetter());
            t.GetComponent<Tile>().setValue(item.getValue());
            s.setTile(t.GetComponent<Tile>());
        }
    }

    private void populateBag()
    {
        StreamReader reader = new StreamReader(path);
        string line;
        while((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(' ');
            char c = char.Parse(parts[0]);
            int v = int.Parse(parts[1]);
            int count = int.Parse(parts[2]);

            for(int i = 0; i < count; i++)
            {
                bag.Add(new Tile(c, v));
            }
        }
    }

    public void shuffleBag()
    {
        for(int i = 0; i < bag.Count; i++)
        {
            int rint = Random.Range(0,bag.Count);
            Tile t = bag[rint];
            bag[rint] = bag[i];
            bag[i] = t;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            hoverOver = hit.collider.gameObject;
        }
        else
        {
            hoverOver = null;
        }
    }

    public GameObject getHoverOver()
    {
        return hoverOver;
    }
}
