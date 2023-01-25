namespace TribalWarsPlayerInfo.Models;

public class Player
{
    public int Classification { get; }
    public string Name { get; }
    public string Tribe { get; }
    public int Points { get; }
    public int Villages { get; }
    public decimal PointsPerVillage { get; }

    public Player(int classification, string name, string tribe, int points, int villages, decimal pointsPerVillage)
    {
        Classification = classification;
        Name = name;
        Tribe = tribe;
        Points = points;
        Villages = villages;
        PointsPerVillage = pointsPerVillage;
    }
}