using UnityEngine;

public class Coord
{
    public int x, y, z;
    public Coord(int setX, int setY, int setZ)
    {
        x = setX;
        y = setY;
        z = setZ;

    }
}

public class GridElement : MonoBehaviour
{
    private Coord coord;
    private Collider col;
    private Renderer rend;
    public CornerElement[] corners = new CornerElement[8];

    public void Initialize(int setX, int setY, int setZ)
    {
        int width = LevelGenerator.instance.width;
        int height = LevelGenerator.instance.height;
        coord = new Coord(setX, setY, setZ);
        this.name = "GE_" + this.coord.x + "_" + this.coord.y + "_" + this.coord.z;
        this.col = this.GetComponent<Collider>();
        this.rend = this.GetComponent<Renderer>();

        // setting corner elements
        corners[0] = LevelGenerator.instance.cornerElements[coord.x + (width + 1) * (coord.z + (width + 1) * coord.y)];
        corners[1] = LevelGenerator.instance.cornerElements[coord.x + 1 + (width + 1) * (coord.z + (width + 1) * coord.y)];
        corners[2] = LevelGenerator.instance.cornerElements[coord.x + (width + 1) * (coord.z + 1 + (width + 1) * coord.y)];
        corners[3] = LevelGenerator.instance.cornerElements[coord.x + 1 + (width + 1) * (coord.z + 1 + (width + 1) * coord.y)];
        corners[4] = LevelGenerator.instance.cornerElements[coord.x + (width + 1) * (coord.z + (width + 1) * (coord.y + 1))];
        corners[5] = LevelGenerator.instance.cornerElements[coord.x + 1 + (width + 1) * (coord.z + (width + 1) * (coord.y + 1))];
        corners[6] = LevelGenerator.instance.cornerElements[coord.x + (width + 1) * (coord.z + 1 + (width + 1) * (coord.y + 1))];
        corners[7] = LevelGenerator.instance.cornerElements[coord.x + 1 + (width + 1) * (coord.z + 1 + (width + 1) * (coord.y + 1))];

        // positioning corner elements
        corners[0].SetPosition(col.bounds.min.x, col.bounds.min.y, col.bounds.min.z);
        corners[1].SetPosition(col.bounds.max.x, col.bounds.min.y, col.bounds.min.z);
        corners[2].SetPosition(col.bounds.min.x, col.bounds.min.y, col.bounds.max.z);
        corners[3].SetPosition(col.bounds.max.x, col.bounds.min.y, col.bounds.max.z);
        corners[4].SetPosition(col.bounds.min.x, col.bounds.max.y, col.bounds.min.z);
        corners[5].SetPosition(col.bounds.max.x, col.bounds.max.y, col.bounds.min.z);
        corners[6].SetPosition(col.bounds.min.x, col.bounds.max.y, col.bounds.max.z);
        corners[7].SetPosition(col.bounds.max.x, col.bounds.max.y, col.bounds.max.z);

    }

    public Coord GetCoord()
    {
        return coord;
    }

    public void SetEnable()
    {
        this.col.enabled = true;
        this.rend.enabled = true;
    }

    public void SetDisable()
    {
        this.col.enabled = false;
        this.rend.enabled = false;
    }
}
