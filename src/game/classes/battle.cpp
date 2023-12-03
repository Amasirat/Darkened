#include "battle.h"
#include "input_output.h"
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
    bool is_player_alive{true};
    while(!m_enemies.empty())
    {
        menu();
    //player's turn
        int usr_input{int_input("We have been confronted! What to do hero?!")};
        switch(usr_input)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                clrscreen();
                break;
        }
        
    //enemies' turn
    }
    return player_win;
}
//main menu for every battle arena
void Battle::menu() const
{
    clrscreen();
//std::cout << "1.Attack\t\t2.Items\t\t3.Check Enemy\t\t4.Clear Screen\t\t\n";
    for(int ii{0}; ii < m_actions.size(); ++ii)
    {
        std::cout << translate_enum(m_actions.at(ii));
        if(ii != m_actions.size() - 1)
        {
            std::cout << "\t\t";
        }
    }
    std::cout << '\n';
}
//function to attempt player decisions in battle, it has side effects
void Battle::battle_actions(int usr_int) const
{
    switch(usr_int)
    {
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            clrscreen();
            break;
    }
}
//returns the string version of actions enum
std::string Battle::translate_enum(actions action) const
{
    switch(action)
    {
        case attack:
            return "Attack";
        case items:
            return "Items";
        case check:
            return "Check Enemy";
        case clear_screen:
            return "Clear Screen";
    }
}