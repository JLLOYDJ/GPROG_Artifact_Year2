using UnityEngine;

// Don't worry, it's not for states Adam.

// These are the traditional Pokemon Type (Normal ETC)
public enum PokemonTypes
{ // Changed from the original, having typeless as 0 as there might be new types in the future.
    typeless = 0,
    normal = 1, 
    fire = 2, 
    water = 3,
    grass = 4, 
    electric = 5,
    ice = 6,
    fighting = 7,
    poison = 8, 
    ground = 9,
    flying = 10,
    psychic = 11,
    bug = 12,
    rock = 13,
    ghost = 14,
    dragon = 15,
    dark = 16,
    steel = 17,
    fairy = 18
}

// These are who gets targetted when a move is used.
public enum Target
{
    self = 0,
    ally = -1,
    allyX2 = -2,
    allyX3 = -3,
    allyX4 = -4,
    allyX5 = -5,
    allyX6 = -6,
    enemy = 1,
    enemyX2 = 2,
    enemyX3 = 3,
    enemyX4 = 4,
    enemyX5 = 5,
    enemyX6 = 6
}

// These are the Stats that DND uses (Strength ETC)
public enum movePower
{
    none = 0,
    strength = 1,
    dexterity = 2,
    consitution = 3,
    intelligence = 4,
    wisdom = 5,
    charisma = 6
}
public enum monsterSize
{
    tiny = 0,
    small = 1,
    medium = 2,
    large = 3, 
    huge = 4, 
    gargantuan = 5
}
public enum DiceAdvantage
{
    normal = 0,
    disadvantage = 1,
    advantage = 2
}