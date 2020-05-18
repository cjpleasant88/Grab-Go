# <div align="center">Grab&Go Application</div>

<div align="center"><img src="https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/blankicon.png"width="100" height="100"/></div>

## <div align="center">Table of Contents</div>

- [1. Inspiration](#inspiration)
- [2. Concept](#concept)
- [3. Implementation](#implementation)
- [4. Entity Relationship Diagram (ERD)](#entity-relationship-diagram)
- [5. User Stories](#user-stories)
- [6. Use Cases](#use-cases)
- [7. Use Case Diagram](#use-case-diagram)
- [8. Requirements](#requirements)
- [9. Wire-Frames (DRAFT)](#wire-frames)
- [10. Requirements Table](#requirements-table)
- [11. Tests Table](#tests-table)
- [12. Feature List](#feature-list)
- [13. Prototype](#prototype)
- [14. Database Diagram](#database-diagram)
- [15. Web Application Source Code (In-Development)](https://github.com/cjpleasant88/Grab-Go/tree/master/GrabAndGo)

## <div align="center">INSPIRATION</div>
[(back to top)](#table-of-contents)

After having a newborn this past year, I have discovered how precious and valuable all those 86,400 seconds in the day are.  This application is an attempt to gain back a few of them each week. It was thought of after many trips of going to the store trying to find the few items on my list quickly, only to find myself backtracking down aisles to retrieve the items on my list. 

## <div align="center">CONCEPT</div>
[(back to top)](#table-of-contents)

The Concept is simple. 
Have a list of grocery store items that automatically re-arranges the items on the list in a way that allows you to traverse a store in the most efficient/quickest manner. This way you are not going down an aisle more than once, and not spending time before the trip to organize your list.

## <div align="center">IMPLEMENTATION</div>
[(back to top)](#table-of-contents)

To accomplish this task, a few inventories would have to be maintained:

 - List of Aisles in a particular store
 - The Category of items that each Aisle contains
 - A Catalog of items along with the category they belong to
 - A list of items on a users Shopping List
 
 Also, to be able to order the list based on different stores and have multiple users we need:
 - To maintain a List of Stores 
 - To maintain a Database of unique users

## <div align="center">ENTITY RELATIONSHIP DIAGRAM</div>
[Preliminary Database](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/ISTA420%20-%20CPleasant%20-%2020200216%20-%20Project%20Step%205%20-%20DataBase%20Creation.sql)

![Grab&Go ERD](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Grab%20and%20Go%20ERD%20(20200404).png)

## <div align="center">USER STORIES</div>
[(back to top)](#table-of-contents)

1) As a User, I need to input Grocery Items, So that I can track what I need.

2) As a User, I need to re-order my grocery List items, So they are listed in a way relating to their location in a Grocery store.

3) As a User, I need to view a map the store aisles and my listed items, So I can have a better visual of my items and where they are in the store. - *future Update*

4) As a User, I need to select the store that I would like to shop at, so my list is tailored to the aisle layout of the specific store I select.

5) As a User, I need to be able to share my list with another user, so that I can coordinate my shopping efforts with another user.

6) As an Administrator, I need to add additional stores and layouts, So that my users have more options with their shopping efforts.

7) As a user, I need to indicate the items I have physically obtained when shopping, so that I can see what items are left to get on my list.

## <div align="center">USE CASES</div>
[(back to top)](#table-of-contents)

1) Given the user has never logged in,
	When the user attempts to login,
	Then they are prompted to sign up via the Sign Up page

2) Given the user has created an account,
	When they have successfully logged in,
	Then their list of items will be displayed
	And they will in the order they have previously inputted the items.

3) Given that the user has one or more items in their list,
	When they select “Let’s Go Shopping” Button,
	Then their list will reorder based on the relative location in the store,
	And based on the items relative location to other items in the list.

4) Given that the user does not want to shop at the default store selected,
	When they select the Store name,
	Then the user can select a different store to shop at,
	And the ordered list will be tailored to the newly selected store.

5) Given the user has a combination of refrigerated and non-refrigerated items in their list,
When the user selects “Let’s Go Shopping” Button,
Then the ordered list will ensure refrigerated items are at the end of the list.

6) Given that the Administrator has a new Store Layout to add to the system,
When they add all of the information for the additional store,
Then the added store is available for all users to select as their store to shop from.

7) Given the user is shopping and obtained a grocery item in a store,
When they check off an item on their ordered list of grocery items,
Then the item is displayed in strike through font
And moved to the bottom of the list.

## <div align="center">USE CASE DIAGRAM</div>
[(back to top)](#table-of-contents)

![Use Case Diagram](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/UML%20Use-Case%20Diagram.png)

## <div align="center">REQUIREMENTS</div>
[(back to top)](#table-of-contents)

* 1.0\. User Shall Input Grocery Items into personal List by selecting items from a pre-populated list

	* 1.1\. System Shall show user categories of items or all items for user to select from

		* 1.1.1\. The software shall maintain the relationship of items and their parent category

		* 1.1.2\. The software shall allow searching an filtering of users typed values with values in the stored list of grocery items

* 2.0\. User Shall view their list in an ordered manner

	* 2.1\. The System shall compare user list with specific store layout to generate an ordered list

		* 2.1.1\. The software shall display the users list in the newly ordered format

* 3.0\. User shall select a map view of the were their items are in the store

	* 3.1\. The system shall map the location of users items onto a known store map

* 4.0\. User shall be able to create an account

	* 4.1\. The system shall store a users username and password for sign in purposes

		* 4.1.1\. The software shall validate the email is in a valid email format

		* 4.1.2\. The software shall ensure that the username is not already in the system database

		* 4.1.3\. The system shall alert the user if validation fails and gives reason why validation failed

		* 4.1.4\. The system will generate a new Shopping list record and associate the Shopping List ID with the user account

	* 4.2\. The system shall link a user account with a grocery list that the user creates

* 5.0\. User shall be able to share their list with another user

	* 5.1\. The system will ensure that another user exists

		* 5.1.1\. The software will compare requested username with list of created accounts

		* 5.1.2\. The software will notify original user of the requested user does not exists and halt shopping list linking

	* 5.2\. The system will prompt requested user upon next login that they have been selected to share list

	* 5.3\. The system will link list upon requested users acceptance

		* 5.3.1\. The software will drop the requested users shopping list table from the database

		* 5.3.2\. The software will add the Shopping List ID of the original user to the requested users account to compete the linking process

* 6.0 \. The Administrator shall add new grocery items to the Master Grocery List

	* 6.1\. The system shall display a form to the administrator for all required information of a grocery item

		* 6.1.1\. The Software shall run script(s) to take form data and create a new record of the item in the Master Grocery List Table

* 7.0\. The Administrator shall be able to add a new Store and Layout to the System

	* 7.1\. The System shall display a form to the administrator for all required information of a Store entity

		* 7.1.1\. The software shall run script(s) to take form data and create a new record of the item in the Store Table

## <div align="center">WIRE FRAMES</div>
[(back to top)](#table-of-contents)

The Landing Page would be a login Screen with the Grab & Go Logo and a tab to be able to sign up:
![Landing Page](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Landing%20Page.png)

After selecting the "Sign Up' Tab, the user can enter their information where it can be validated and submitted for account creation:
![Sign Up Screen](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Sign%20Up%20Screen.png)

One logged in, the user can create a shopping list in an arbitrary order. This list can be shared with other users such as a family member or spouse:
![Shopping List](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Shopping%20List.png)

Once the "Let's go shopping" being has been clicked, the app will take the users list of items and reorder them in a way that creates the "fastest path" through the store.
![Ordered Shopping List](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Ordered%20Shopping%20List.PNG)

*Future Update*
A map view can also be shown identifying the location of the items in the store with a bird's eye view of the store:
![Store Map](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Store%20Map.png)

## <div align="center">REQUIREMENTS TABLE</div>
[(back to top)](#table-of-contents)

| Requirement  ID | Requirement Description                                      | Test Method   | TEST ID      |
| --------------- | ------------------------------------------------------------ | ------------- | ------------ |
| 1.0.0           | User Shall Input Grocery  Items into personal List by selecting items from a pre-populated list | Demonstration | TC005        |
| 1.1.0           | System Shall show user  categories of items or all items for user to select from | Inspection    | TC005        |
| 1.1.1           | The software shall  maintain the relationship of items and their parent category | Inspection    | TC006        |
| 1.1.2           | The software shall allow  searching an filtering of users typed values with values in the stored list  of grocery items | Demonstration | TC006        |
| 2.0.0           | User Shall view their list  in an ordered manner             | Demonstration | TC007        |
| 2.1.0           | The System shall compare  user list with specific store layout to generate an ordered list | Test          | TC007        |
| 2.1.1           | The software shall  display the users list in the newly ordered format | Demonstration | TC007        |
| 3.0.0           | User shall select a map  view of the were their items are in the store | Test          | TC008        |
| 3.1.0           | The system shall map the  location of users items onto a known store map | Test          | TC008        |
| 4.0.0           | User shall be able to  create an account                     | Demonstration | TC001        |
| 4.1.0           | The system shall store a  users username and password for sign in purposes | Inspection    | TC001        |
| 4.1.1           | The software shall  validate the email is in a valid email format | Test          | TC001, TC003 |
| 4.1.2           | The software shall ensure  that the username is not already in the system database | Demonstration | TC001, TC003 |
| 4.1.3           | The system shall alert  the user if validation fails and gives reason why validation failed | Demonstration | TC001        |
| 4.1.4           | The system will generate  a new Shopping list record and associate the Shopping List ID with the user  account | Inspection    | TC002        |
| 4.2.0           | The system shall link a  user account with a grocery list that the user creates | Inspection    | TC002        |
| 5.0.0           | User shall be able to share  their list with another user    | Demonstration | TC003, TC004 |
| 5.1.0           | The system will ensure that  another user exists             | Test          | TC003, TC004 |
| 5.1.1           | The software will compare  requested username with list of created accounts | Demonstration | TC003        |
| 5.1.2           | The software will notify  original user of the requested user does not exists and halt shopping list  linking | Test          | TC003        |
| 5.2.0           | The system will prompt  requested user upon next login that they have been selected to share list | Demonstration | TC004        |
| 5.3.0           | The system will link list  upon requested users acceptance   | Test          | TC004        |
| 5.3.1           | The software will drop  the requested users shopping list table from the database | Inspection    | TC004        |
| 5.3.2           | The software will add the  Shopping List ID of the original user to the requested users account to  compete the linking process | Inspection    | TC004        |
| 6.0.0           | The Administrator shall  add new grocery items to the Master Grocery List | Inspection    | TC009        |
| 6.1.0           | The system shall display a  form to the administrator for all required information of a grocery item | Demonstration | TC009        |
| 6.1.1           | The Software shall run  script(s) to take form data and create a new record of the item in the Master  Grocery List Table | Inspection    | TC009        |
| 7.0.0           | The Administrator shall be  able to add a new Store and Layout to the System | Inspection    | TC010        |
| 7.1.0           | The System shall display a  form to the administrator for all required information of a Store entity | Demonstration | TC010        |
| 7.1.1           | The software shall run  script(s) to take form data and create a new record of the item in the Store  Table | Inspection    | TC010        |

## <div align="center">TESTS TABLE</div>
[(back to top)](#table-of-contents)

| Test ID | Requirement ID(s)                        | Test Procedure                                               | Current Status | Time Stamp | Version |
| ------- | ---------------------------------------- | ------------------------------------------------------------ | -------------- | ---------- | ------- |
| TC001   | 4.0.0, 4.1.0, 4.1.1, 4.1.2, 4.1.3        | User login w/o having logged in before, taken to signup screen to create  account. Sign out and login with new signup information. | :heavy_check_mark:    | 5/6/2020   | N/A     |
| TC002   | 4.1.4, 4.2.0                             | Check system database for list id of a new account creation  | :heavy_check_mark:     | 5/6/2020   | N/A     |
| TC003   | 5.0.0, 5.1.0, 5.1.1, 5.1.2, 4.1.2, 4.1.1 | Add new user, click share list, select user that does not already exist | :heavy_check_mark:     | 5/16/2020   | N/A     |
| TC004   | 5.0.0, 5.1.1, 5.2.0, 5.3.0, 5.3.1, 5.3.2 | using user from TC003, click share list, select user from TC001, login to  user from TC001 and verify shared list prompt, click approve | :heavy_check_mark:     | 5/12/2020   | N/A     |
| TC005   | 1.0.0, 1.1.0                             | Add bread, milk, eggs to an existing users list              | :heavy_check_mark:     | 5/6/2020   | N/A     |
| TC006   | 1.1.1, 1.1.2                             | Have administrator look at SQL data base and verify that report can be  pulled by category, and that the list in the application id the same items | :heavy_check_mark:     | 5/12/2020   | N/A     |
| TC007   | 2.0.0, 2.1.0, 2.1.1                      | Logged in user can select "Let's go Shopping" and see their  list in an ordered format according to store layout | :heavy_check_mark:     | 5/12/2020   | N/A     |
| TC008   | 3.0.0, 3.1.0                             | User can select "map View" and see their items on store map,  matching their physical location in the store | Not Implemented :x:     | 3/8/2020   | N/A     |
| TC009   | 6.0.0, 6.1.0, 6.1.1                      | Administrator adds a new item to database, adds a non-existing item,  verifies that is shows up in the application | :heavy_check_mark:     | 5/6/2020   | N/A     |
| TC010   | 7.0.0, 7.1.0, 7.1.1                      | Administrator add a new store and layout to the database, verifies that  store and layout populate in the application | :heavy_check_mark:     | 5/12/2020   | N/A     |

## <div align="center">Feature List</div>
[(back to top)](#table-of-contents)

Additional features that would be welcomed would be:

 - Ability to scan bar codes of items and add to list
 - Have different Store maps/information to choose from
 - Integration of Available coupons
 - Recipe Integration
 - Home Pantry Inventory
 
 ## <div align="center">Prototype</div>
 [(back to top)](#table-of-contents)
 
 Details and Demonstration of the prototype can be found here:
 
 [Grab & Go Prototype](https://github.com/cjpleasant88/Grab-Go/tree/master/docs)
 
 ## <div align="center">Database Diagram</div>
 ![Database Diagram](https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/Database%20Diagram.PNG)
 
 ## <dic align="center">Web Application Source Code (In-Development)</div>
 [Web Application Page](https://github.com/cjpleasant88/Grab-Go/tree/master/GrabAndGo)
 
