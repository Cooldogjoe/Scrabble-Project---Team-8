using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private List<Space> rack;
    [SerializeField] private GameManager manager;

    public List<Space> getRack()
    {
        return rack;
    }

    public void replenishTiles()
    {
        for (int i = 0; i < rack.Count; i++)
        {
            if (rack[i].getTile() == null)
            {
                manager.drawFromBagAndSet(rack[i]);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
