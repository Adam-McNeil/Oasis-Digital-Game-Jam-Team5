using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltControler : MonoBehaviour
{
    [SerializeField] private List<Material> materials;

    public void UpdateColor(int points)
    {
        
        if (points < 100)
        {
            this.GetComponent<Renderer>().material = materials[0];
        }
        else if (points < 150)
        {
            this.GetComponent<Renderer>().material = materials[1];

        }
        else if (points < 200)
        {
            this.GetComponent<Renderer>().material = materials[2];

        }
        else if (points < 250)
        {
            this.GetComponent<Renderer>().material = materials[3];

        }
        else if (points < 300)
        {
            this.GetComponent<Renderer>().material = materials[4];
        }
        else 
        {
            this.GetComponent<Renderer>().material = materials[5];
        }
    }
}
