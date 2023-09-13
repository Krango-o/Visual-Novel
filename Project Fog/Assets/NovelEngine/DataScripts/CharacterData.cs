using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterData
{
    public enum Character{
        KOI,
        GRAVEL,
        JIRO,
        JULES,
        XANTI,
        FERNO,
        STRANGER
    }

    public static Character getCharacter(string characterName){
        switch(characterName)
        {
            case "Koi":
                return Character.KOI;
            case "Gravel":
                return Character.GRAVEL;
            case "Jiro":
                return Character.JIRO;
            case "Jules":
                return Character.JULES;
            case "Xanti":
                return Character.XANTI;
            case "Ferno":
                return Character.FERNO;
            case "???":
                return Character.STRANGER;
            default:
                Debug.Log("Could Not Find Character Name: " + characterName);
                return Character.KOI;
        }
    }

    public static string CharacterPlateColor(string characterName){
        switch(getCharacter(characterName))
        {
            case Character.KOI:
                return "#ffff00";
            case Character.GRAVEL:
                return "#ff0000";
            case Character.JIRO:
                return "#00ff00";
            case Character.JULES:
                return "#0000ff";
            case Character.XANTI:
                return "#aaaaaa";
            case Character.FERNO:
                return "#aaaaaa";
            case Character.STRANGER:
                return "#aaaaaa";
            default:
                return "#aaaaaa";
        }
    }
}
