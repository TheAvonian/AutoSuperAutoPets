using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TeamSO : ScriptableObject
{
    public int Turn;
    public List< TempPetData > Pets;
}

[System.Serializable]
public class TempPetData
{
    public PetData.AllPets Pet;
    public FoodData.Food Food;
    public int Level = 1;
    public int Health;
    public int Damage;
}