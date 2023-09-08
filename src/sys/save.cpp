#include "save.h"
#include "player.h"
#include "global.h"
#include "error.h"

#include <fstream>
//save player stats
Save::Save(const std::string& save_path, Player* player) :
m_player{player}
{
    if(player == nullptr)
    {
        throw Error("pointer to player was null, Saving procedure failed");
    }
}

