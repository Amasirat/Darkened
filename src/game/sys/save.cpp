#include "save.h"
#include "log.h"
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
        Log().write("Save::Player pointer contained null address");
        throw Error("pointer to player was null, Saving procedure failed");
    }
}

