using System;
using UnityEngine;

/**
 * Bijzonderheden wegens beperkingen van JsonUtility:
 * - Models hebben variabelen met kleine letters omdat JsonUtility anders de velden uit de JSON niet correct overzet naar het C# object.
 * - De id is een string in plaats van een Guid omdat JsonUtility Guid niet ondersteunt. Gelukkig geeft dit geen probleem indien we gewoon een string gebruiken in Unity en een Guid in onze backend API.
*/
[Serializable]
public class Progressie1
{
    public string id; // JSON veld, string in plaats van Guid

    public int numberCompleet; // JSON veld, kleine letters

    public bool vakje1;

    public bool vakje2;
  
    public bool vakje3;
    
    public bool vakje4;
    
    public bool vakje5;
    
    public bool vakje6;

    public string profielKeuzeId;
}