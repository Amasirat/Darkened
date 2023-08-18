#ifndef ITEM_H
#define ITEM_H
#include <string>
//Item is a pure abstract class meant to for other classes of the similar type to inherit
//its functionality and implement them themselves
class Item
{
public:
//use item
    virtual void use() const = 0;
//describe item
    virtual std::string describe() const = 0;
};
//class for the map item inheriting from abstract Item class
class Map : Item
{
//default constrcutor
    Map();
//default destructor
    ~Map();
//use override for Map
    void use() const override;
//describe
    std::string describe() const override;
};
#endif