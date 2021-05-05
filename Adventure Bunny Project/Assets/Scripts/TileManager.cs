using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap tilemap;
    public void DestroySingleTile(Vector2 hitPosition) //Destroys single tile when collided with.
    {
        //Debug.Log(hitPosition);
        tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

    }
}

/*
 * 
    public void DestroySingleTile(ContactPoint2D collisionPosition) //Destroys single tile when collided with.
    {
        Debug.Log(collisionPosition);
        //tilemap.
        Vector3 worldPosition = new Vector3(collisionPosition.point.x, collisionPosition.point.y, 0);
        Debug.Log(worldPosition);
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        Debug.Log(cellPosition);
        tilemap.SetTile(cellPosition, null);
    }
}
*/