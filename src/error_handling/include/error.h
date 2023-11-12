#ifndef ERROR_H
#define ERROR_H
#include <string>
class Error
{
public:
    enum exceptions
    {
        FileNotFound,
        InvalidInput,
        FileExists,
        DatabaseEntryNotFound,
    };
//default value constructor
    Error(const std::string& error);
//default constructor
    Error(const exceptions& error_type);
//default destructor
    ~Error() = default;
//print error message on screen
    void print() const;


private:
    std::string m_error_message{};
    exceptions m_error_type{};
};
#endif