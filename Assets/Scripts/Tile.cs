using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private char letter;
    [SerializeField] private int value = 1;
    private bool verticalChecked = false;
    private bool horizontalChecked = false;
    private Sprite ts;

    public Tile(char l, int v)
    {
        letter = l;
        value = v;
    }

    public void setLetter(char l)
    {
        letter = l;
    }

    public void setValue(int v)
    {
        value = v;
    }

    public char getLetter()
    {
        return letter;
    }

    public int getValue()
    {
        return value;
    }

    // Start is called before the first frame update
    void Start()
    {

        ts = Resources.Load(letter.ToString(), typeof(Sprite)) as Sprite;
        GetComponent<SpriteRenderer>().sprite = ts;
    }

}
