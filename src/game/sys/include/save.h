#ifndef SAVE_H
#define SAVE_H
#include "player.h"
#include "global.h"

#include <fstream>
#include <filesystem>
namespace fs = std::filesystem;

class Save {
public:
//default Constructor
    Save(const std::string& save_path = sys::homedir + "/.local/share/darkened", Player* player = nullptr);
//default destructor
    ~Save();
private:
    Player* m_player{};
    std::string m_save_path{};
};
#endif