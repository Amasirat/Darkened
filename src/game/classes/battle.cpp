#include "battle.h"
#include "terminalIO.h"
#include "log.h"
#include "error.h"

#include <iostream>

//default constructor
Battle::Battle(Player* player, std::vector<Enemy*> enemies) :
m_player{player},
m_enemies{enemies}
{
    Log().write("battle area created");
}

//default destructor
Battle::~Battle()
{
    
Log().write("battle area exited");
}
//function that handles player and enemy interaction
//returns true if player wins and false if player lost
bool Battle::battle_arena() const
{
Log().write("entered battle arena");
    Enemy* current_target{m_enemies.at(0)};
    bool player_win{false};
// main battle loop
    while(!m_enemies.empty())
    {
        menu();
        int usr_input{int_input("We have been confronted! What to do hero?!")};
    }
    return true;
}
//main menu for every battle arena
void Battle::menu() const
{
    clrscreen();
    std::cout << "1.Attack\t\t2.Items\t\t3.Check Enemy\t\t4.Clear Screen\t\t\n";
}