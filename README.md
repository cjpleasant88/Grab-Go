# Grab&Go Application

## Table of Contents

- [1. Inspiration](#inspiration)
- [2. Concept](#concept)
- [3. Implementation](#implementation)
- [4. Entity Relationship Diagram (ERD)](#entity-relationship-diagram)
- [5. Requirements](#requirements)
- [6. Wire-Frames (DRAFT)](#wire-frames)
- [7. Feature List](#feature-list)

## INSPIRATION

After having a newborn this past year, I have discovered how precious and valuable all those 86,400 seconds in the day are.  This application is an attempt to gain back a few of them each week. It was thought of after many trips of going to the store trying to find the few items on my list quickly, only to find myself backtracking down aisles as if I am on a scavenger hunt. 

## CONCEPT
The Concept is simple. 
Have a list of grocery store items listed in a way that allows you to traverse a store in the most efficient/quickest manner. This way you are not going down an aisle more than once. 

## IMPLEMENTATION

To accomplish this task, a few inventories would have to be maintained:

 - List of Aisles in a particular store
 - The sections that each Aisle contains
 - A Catalog of items along with the section they belong to
 - A list of items on a users Shopping List

## ENTITY RELATIONSHIP DIAGRAM

![Grab&Go ERD](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Grab%20and%20Go%20ERD.png)

## REQUIREMENTS

*[Requirements Page](https://github.com/cjpleasant88/Grab-Go/blob/master/Requirements.md)*

## WIRE FRAMES (DRAFT)

The Landing Page would be a login Screen with the Grab & Go Logo and a tab to be able to sign up:
![Landing Page](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Landing%20Page.png)

After selecting the "Sign Up' Tab, the user can enter their information where it can be validated and submitted for account creation:
![Sign Up Screen](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Sign%20Up%20Screen.png)

One logged in, the user can create a shopping list in an arbitrary order. This list can be shared with other users such as a family member or spouse:
![Shopping List](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Shopping%20List.png)

Once the "Let's go shopping" being has been clicked, the app will take the users list of items and reorder them in a way that creates the "fastest path" through the store. A map view can also be shown identifying the location of the items in the store with a bird's eye view of the store:
![Store Map](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Store%20Map.png)


## Feature List
Additional features that would be welcomed would be:

 - Ability to scan bar codes of items and add to list
 - Have different Store maps/information to choose from
 - Integration of Available coupons
 - Recipe Integration
 - Home Pantry Inventory
