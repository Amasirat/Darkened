#ifndef ERROR_H
#define ERROR_H
#include <string>
class Error
{
public:
//default value constructor
    Error(const std::string& error);
//default destructor
    ~Error() = default;
//print error message on screen
    void print();
private:
    std::string m_error_message{};
};
#endif