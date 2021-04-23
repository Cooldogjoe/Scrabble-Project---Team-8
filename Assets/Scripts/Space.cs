using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    private GameManager manager;
    [SerializeField] private Tile tile;
    private Renderer rend;
    private bool locked = false;
    [SerializeField] private int multiplier = 1;
    [SerializeField] private string multiplierType = "word";
    [SerializeField] private Color baseColor = Color.gray;
    private Color currentColor;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        if(tile != null) this.tile.transform.position = tileInFront();
        rend = GetComponent<Renderer>();
        currentColor = baseColor;
        rend.material.color = baseColor;
    }

    public void setLock(bool b)
    {
        locked = b;
    }

    public bool isLocked()
    {
        return locked;
    }

    public void setTile(Tile t)
    {
        tile = t;
        if(tile!=null) this.tile.transform.position = tileInFront();
    }

    public Tile getTile()
    {
        return tile;
    }

    private Vector3 tileInFront()
    {
        Vector3 v = this.transform.position;
        v.z += -1;
        return v;
    }

    private void OnMouseEnter()
    {
        currentColor = Color.white;
        currentColor.a = 0.5f;
        rend.material.color = currentColor;
    }

    private void OnMouseExit()
    {
        currentColor = baseColor;
        rend.material.color = baseColor;
    }

    private void OnMouseDrag()
    {
        if (tile != null && !locked)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            this.tile.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    private void OnMouseUp()
    {
        if(tile != null && !locked)
        {
            GameObject hoverOver = manager.getHoverOver();
            Space otherSpace = null;
            
            if(hoverOver != null) otherSpace = hoverOver.GetComponent<Space>();

            if (otherSpace != null && otherSpace != this && !otherSpace.isLocked())
            {
                Tile otherTile = otherSpace.getTile();
                otherSpace.setTile(tile);
                this.setTile(otherTile);
            }
            else
            {
                this.tile.transform.position = tileInFront();
            }
        }
    }
}
