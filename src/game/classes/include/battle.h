#ifndef FIGHT_H
#define FIGHT_H
#include "player.h"
#include "enemy.h"
#include <vector>
/*
Battle class tasked with managing fights with player and various enemies
*/
class Battle
{
public:
//default constructor
    Battle(Player* player, std::vector<Enemy*> enemies);
//copy constructor is disabled
    Battle(const Battle&) = delete;
//default destructor
    ~Battle();
//function that handles player and enemy interaction
//returns true if player wins and false if player lost
    bool battle_arena() const;
//function called when player loses
    void lose() const;
//main menu for every battle arena
    void menu() const;
private:
    Player* m_player{};
    std::vector<Enemy*> m_enemies;
//enums for all possible battle actions
    enum actions
    {
        attack,
        items,
        check,
        clear_screen,
    };
    std::vector<actions> m_actions{
        attack,
        items,
        check,
        clear_screen,
    };
//returns the string version of actions enum
    std::string translate_enum(actions action) const;
//function to attempt player decisions in battle, it has side effects
    void battle_actions(int usr_int) const;
};
#endif