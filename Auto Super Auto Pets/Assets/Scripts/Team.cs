using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public int Health;
    public int Coins;
    public PetData[] Pets { get; } = new PetData[ 5 ];
    public ShopData Shop { get; set; }
}
