using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    void OnMouseUp()
    {
        //Debug.Log("TowerSpot clicked.");

        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        if(bm.selectedTower != null)
        {
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            if(sm.coins < bm.selectedTower.GetComponent<Tower>().cost)
            {
                //Debug.Log("Not Enough Coins!");
                return;
            }

            sm.coins -= bm.selectedTower.GetComponent<Tower>().cost;

            Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
            Destroy(transform.parent.gameObject);
        }
    }

}
