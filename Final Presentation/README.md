# <div align="center">Product Release / Project Presentation</div>

1. Describe project experience including each phase of the SDLC and the project artifacts (design documents, requirements trace, test reports...)

   <div  align="center"><span><img src="https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/blankicon.png"width="500"/></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span><img src="https://github.com/cjpleasant88/Grab-Go/blob/master/Assets/sdlccycle.png" width="300"/></span></div>
   
   ## <div align="center">INSPIRATION</div>

After having a newborn this past year, I have discovered how precious and valuable all those 86,400 seconds in the day are.  This application is an attempt to gain back a few of them each week. It was thought of after many trips of going to the store trying to find the few items on my list quickly, only to find myself backtracking down aisles to retrieve the items. 

## <div align="center">CONCEPT</div>

The Concept is simple. 
Have a list of grocery store items that automatically re-arranges the items on the list in a way that allows you to traverse a store in the most efficient/quickest manner. This way you are not going down an aisle more than once, and not spending time before the trip to organize your list.

## <div align="center">IMPLEMENTATION</div>

To accomplish this task, a few inventories would have to be maintained:

 - List of Aisles in a particular store
 - The Category of items that each Aisle contains
 - A Catalog of items along with the category they belong to
 - A list of items on a users Shopping List
 
 Also, to be able to order the list based on different stores and have multiple users we need:
 - To maintain a List of Stores 
 - To maintain a Database of unique users

   Requirement Analysis

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

   ## 

   Design

   Implementation

   Testing

   ## <div align="center">TESTS TABLE</div>

   | Test ID | Requirement ID(s)                        | Test Procedure                                               | Current Status      | Time Stamp | Version |
   | ------- | ---------------------------------------- | ------------------------------------------------------------ | ------------------- | ---------- | ------- |
   | TC001   | 4.0.0, 4.1.0, 4.1.1, 4.1.2, 4.1.3        | User login w/o having logged in before, taken to signup screen to create  account. Sign out and login with new signup information. | :heavy_check_mark:  | 5/6/2020   | N/A     |
   | TC002   | 4.1.4, 4.2.0                             | Check system database for list id of a new account creation  | :heavy_check_mark:  | 5/6/2020   | N/A     |
   | TC003   | 5.0.0, 5.1.0, 5.1.1, 5.1.2, 4.1.2, 4.1.1 | Add new user, click share list, select user that does not already exist | :heavy_check_mark:  | 5/16/2020  | N/A     |
   | TC004   | 5.0.0, 5.1.1, 5.2.0, 5.3.0, 5.3.1, 5.3.2 | using user from TC003, click share list, select user from TC001, login to  user from TC001 and verify shared list prompt, click approve | :heavy_check_mark:  | 5/12/2020  | N/A     |
   | TC005   | 1.0.0, 1.1.0                             | Add bread, milk, eggs to an existing users list              | :heavy_check_mark:  | 5/6/2020   | N/A     |
   | TC006   | 1.1.1, 1.1.2                             | Have administrator look at SQL data base and verify that report can be  pulled by category, and that the list in the application id the same items | :heavy_check_mark:  | 5/12/2020  | N/A     |
   | TC007   | 2.0.0, 2.1.0, 2.1.1                      | Logged in user can select "Let's go Shopping" and see their  list in an ordered format according to store layout | :heavy_check_mark:  | 5/12/2020  | N/A     |
   | TC008   | 3.0.0, 3.1.0                             | User can select "map View" and see their items on store map,  matching their physical location in the store | Not Implemented :x: | 3/8/2020   | N/A     |
   | TC009   | 6.0.0, 6.1.0, 6.1.1                      | Administrator adds a new item to database, adds a non-existing item,  verifies that is shows up in the application | :heavy_check_mark:  | 5/6/2020   | N/A     |
   | TC010   | 7.0.0, 7.1.0, 7.1.1                      | Administrator add a new store and layout to the database, verifies that  store and layout populate in the application | :heavy_check_mark:  | 5/12/2020  | N/A     |

   | Requirements ID | Test ID            |||||||||| Total Tests              |
   | --------------- | ------------------ | ------------------ | ------------------ | ------------------ | ------------------ | ------------------ | ------------------ | ---- | ------------------ | ------------------ | ---- |
   |                 | T001               | T002               | T003               | T004               | T005               | T006               | T007               | T008 | T009               | T010               |      |
   | 1.0.0           |                    |                    |                    |                    | :heavy_check_mark: |                    |                    |      |                    |                    | 1     |
   | 1.1.0           |                    |                    |                    |                    | :heavy_check_mark: |                    |                    |      |                    |                   | 1     |
   | 1.1.1           |                    |                    |                    |                    |                    | :heavy_check_mark: |                    |      |                    |                   |1      |
   | 1.1.2           |                    |                    |                    |                    |                    | :heavy_check_mark: |                    |      |                    |                  |1     |
   | 2.0.0           |                    |                    |                    |                    |                    |                    | :heavy_check_mark: |      |                    |                   | 1     |
   | 2.1.0           |                    |                    |                    |                    |                    |                    | :heavy_check_mark: |      |                    |                   | 1     |
   | 2.1.1           |                    |                    |                    |                    |                    |                    | :heavy_check_mark: |      |                    |                   | 1     |
   | 3.0.0           |                    |                    |                    |                    |                    |                    |                    | :x:  |                    |                    | 1    |
   | 3.1.0           |                    |                    |                    |                    |                    |                    |                    | :x:  |                    |                    | 1    |
   | 4.0.0           | :heavy_check_mark: |                    |                    |                    |                    |                    |                    |      |                    |                   | 1     |
   | 4.1.0           | :heavy_check_mark: |                    |                    |                    |                    |                    |                    |      |                    |                   | 1     |
   | 4.1.1           | :heavy_check_mark: |                 |  :heavy_check_mark:  |                    |                    |                    |                    |      |                   |                    | 2     |
   | 4.1.2           | :heavy_check_mark: |                 |   :heavy_check_mark: |                    |                    |                    |                    |      |                   |                    | 2     |
   | 4.1.3           | :heavy_check_mark: |                    |                    |                    |                    |                    |                    |      |                    |                   |1      |
   | 4.1.4           |                    | :heavy_check_mark: |                    |                    |                    |                    |                    |      |                    |                   | 1     |
   | 4.2.0           |                    | :heavy_check_mark: |                    |                    |                    |                    |                    |      |                    |                  |1      |
   | 5.0.0           |                    |                    | :heavy_check_mark: | :heavy_check_mark: |                    |                    |                    |      |                    |                   | 2     |
   | 5.1.0           |                    |                    | :heavy_check_mark: |                    |                    |                    |                    |      |                    |                   | 1     |
   | 5.1.1           |                    |                    | :heavy_check_mark: | :heavy_check_mark: |                    |                    |                    |      |                    |                   | 2     |
   | 5.1.2           |                    |                    | :heavy_check_mark: |                    |                    |                    |                    |      |                    |                   | 1     |
   | 5.2.0           |                    |                    |                    | :heavy_check_mark: |                    |                    |                    |      |                    |                   |1      |
   | 5.3.0           |                    |                    |                    | :heavy_check_mark: |                    |                    |                    |      |                    |                  | 1     |
   | 5.3.1           |                    |                    |                    | :heavy_check_mark: |                    |                    |                    |      |                    |                  |1      |
   | 5.3.2           |                    |                    |                    | :heavy_check_mark: |                    |                    |                    |      |                    |                  | 1     |
   | 6.0.0           |                    |                    |                    |                    |                    |                    |                    |      | :heavy_check_mark: |                   |1      |
   | 6.1.0           |                    |                    |                    |                    |                    |                    |                    |      | :heavy_check_mark: |                   | 1     |
   | 6.1.1           |                    |                    |                    |                    |                    |                    |                    |      | :heavy_check_mark: |                   | 1     |
   | 7.0.0           |                    |                    |                    |                    |                    |                    |                    |      |                    | :heavy_check_mark: | 1    |
   | 7.1.0           |                    |                    |                    |                    |                    |                    |                    |      |                    | :heavy_check_mark: | 1    |
   | 7.1.1           |                    |                    |                    |                    |                    |                    |                    |      |                    | :heavy_check_mark: | 1    |

   Evolution

   

2. code and architecture walk-through

3. product demonstration

4. lessons learned:

- what did you do right?
- what did you do wrong?
- where were you lucky?
- what would you change / what do you know now that you wish you knew "then"?

