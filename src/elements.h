#ifndef ELEMENTS_H
#define ELEMENTS_H
/*
The Elements header is here to keep track of all different elements of the game like stats, weapons, armors 
and other things. containing structs

enums are here for easy reference and identification to specific objects of that type that exist in the entire game
*/
//list of all stat values for all player and enemy characters and also equipables listed as enum
enum stat_name
{
    hp,
    attack,
    defense,
    agility,
    luck,
};
//list of all weapon values in game equipable by player and enemies as enum
enum weapon_name
{
    none,
};
//list of all armor values in game equipable by both player and enemies as enum
enum armor_name
{
    none,

};
//list of all shoe values in game equipable by both players and enemies
enum shoe_name
{
    none,

};
#endif