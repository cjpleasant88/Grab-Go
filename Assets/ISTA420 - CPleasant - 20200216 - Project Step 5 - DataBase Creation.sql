/*-------1---------2---------3---------4---------5---------6---------7--------*/
/*******************************************************************************
					Project Step 5
			ISTA420 SQL and Application Development
					16 February 2002
					Caleb Pleasant
*******************************************************************************/
						--ASSIGNMENT:
--Project Step 5
--In weeks 1 & 2, concept investigation led to solution description and 
--high-level requirements and solution description presented in week 3 and 4 and
--extended to database entity (ERD) design.

--For STEP 5, continue to develop the database design including preliminary
--database table schema design and draft implementation.

--Review database normalization ( 1NF... ), Data Integrity, Data Constraints, 
--Types, Database Diagrams
--------------------------------------------------------------------------------
						--REQUIREMENTS:
--Submit sql script(s) to
--1) create your database,

--2) create your tables (including primary keys and relations consistent with 
--your ERD)

--3) populate preliminary data for implementation and test.
--------------------------------------------------------------------------------
/******************************************************************************/
					--1) CREATE YOUR DATABASE
USE Master;
DROP DATABASE IF EXISTS Grab_and_Go;
GO

CREATE DATABASE Grab_and_Go;
GO
--------------------------------------------------------------------------------
/******************************************************************************/
					--2) CREATE YOUR TABLES

USE Grab_and_Go;
GO

--Store Table
DROP TABLE IF EXISTS Store;
CREATE TABLE Store
(
	StoreId		INT PRIMARY KEY				NOT NULL,
	StoreName	varchar(30)					NOT NULL,
	Street		varchar(30)					NOT NULL,
	City		varchar(30)					NOT NULL,
	State		varchar(15)					NOT NULL,
	ZipCode		INT							NOT NULL
);
GO

--Category Table
DROP TABLE IF EXISTS Category;
CREATE TABLE Category
(
	CategoryID		INT PRIMARY KEY NOT NULL,
	CategoryName	varchar(80)		NOT NULL
);
GO

--Aisle Table
DROP TABLE IF EXISTS Aisle;
CREATE TABLE Aisle
(
	StoreID			INT FOREIGN KEY REFERENCES dbo.Store(StoreID),
	AisleID			INT							NOT NULL,
	CategoryType	INT	FOREIGN KEY REFERENCES dbo.Category(CategoryID)	NOT NULL,
	PRIMARY KEY (StoreID, AisleID)
);
GO

--Sections Table
DROP TABLE IF EXISTS Section;
CREATE TABLE Section
(
	SectionID INT PRIMARY KEY NOT NULL,
	SectionName varchar(50) NOT NULL
);
GO

--Shelf Table
DROP TABLE IF EXISTS Shelf;
CREATE TABLE Shelf
(
StoreID INT NOT NULL,
AisleID INT NOT NULL,
ShelfID INT NOT NULL,
SectionID INT NOT NULL,
FOREIGN KEY (StoreID, AisleID) REFERENCES Aisle (StoreID, AisleID),
PRIMARY KEY (StoreID, AisleID, ShelfID),
FOREIGN KEY (SectionID) REFERENCES Section (SectionID)
);
GO

--Product Table
DROP TABLE IF EXISTS Product;
CREATE TABLE Product
(
	ProductID		INT PRIMARY KEY	NOT NULL,
	ProductName		varchar(30)					NOT NULL,
	Price			MONEY						NOT NULL,
	SectionID		INT							NOT NULL,
	FOREIGN KEY (SectionID) REFERENCES Section (SectionID)
);
GO

--Users Table
DROP TABLE IF EXISTS [User];
CREATE TABLE [User]
(
	UserID			INT PRIMARY KEY				NOT NULL,
	FirstName		varchar(30)					NOT NULL,
	LastName		varchar(30)					NOT NULL,
	ListId			INT,
	ListName		varchar(30),
	StorePref		INT							NOT NULL,
	FOREIGN KEY (StorePref) REFERENCES Store (StoreID)
);
GO

--ShoppingList Table
DROP TABLE IF EXISTS ShoppingList;
CREATE TABLE ShoppingList
(
	ListID		INT			NOT NULL,
	ProductID	INT		NOT NULL,
	Quantity	INT				NOT NULL,
	ListName	varchar(30)		NOT NULL,
	PRIMARY KEY (ListID, ProductID),
	FOREIGN KEY (ProductID) REFERENCES Product (ProductID),
	FOREIGN KEY (ListID) REFERENCES [User] (UserID)
);
GO


--------------------------------------------------------------------------------
/******************************************************************************/
		--3) POPULATE PRELIMINARY DATA FOR IMPLEMENTATION AND TEST

--Populate The Store Table
INSERT INTO Store (StoreID, StoreName, Street, City, State, ZipCode) VALUES (1, 'Commissary', 'Bldg 20850, Vandegrift Blvd', 'Camp Pendelton', 'CA', 92055);
INSERT INTO Store (StoreID, StoreName, Street, City, State, ZipCode) VALUES (2, 'Target', '2255 S El Camino Real', 'Oceanside', 'CA', 92054);
INSERT INTO Store (StoreID, StoreName, Street, City, State, ZipCode) VALUES (3, 'Ralphs', '101 Old Grove Rd', 'Oceanside', 'CA', 92057);
GO

--Populate the Categories Table
INSERT INTO Category (CategoryID, CategoryName) VALUES (1, 'Baby');
INSERT INTO Category (CategoryID, CategoryName) VALUES (2, 'Beer, Wine & Spirits');
INSERT INTO Category (CategoryID, CategoryName) VALUES (3, 'Beverages:  tea, coffee, soda, juice, Kool-Aid, hot chocolate, water, etc.');
INSERT INTO Category (CategoryID, CategoryName) VALUES (4, 'Bread & Bakery');
INSERT INTO Category (CategoryID, CategoryName) VALUES (5, 'Breakfast & Cereal');
INSERT INTO Category (CategoryID, CategoryName) VALUES (6, 'Canned Goods & Soups');
INSERT INTO Category (CategoryID, CategoryName) VALUES (7, 'Condiments/Spices & Bake');
INSERT INTO Category (CategoryID, CategoryName) VALUES (8, 'Cookies, Snacks & Candy');
INSERT INTO Category (CategoryID, CategoryName) VALUES (9, 'Dairy, Eggs & Cheese');
INSERT INTO Category (CategoryID, CategoryName) VALUES (10, 'Deli & Signature Cafe');
INSERT INTO Category (CategoryID, CategoryName) VALUES (11, 'Flowers');
INSERT INTO Category (CategoryID, CategoryName) VALUES (12, 'Frozen Foods');
INSERT INTO Category (CategoryID, CategoryName) VALUES (13, 'Produce: Fruits & Vegetables');
INSERT INTO Category (CategoryID, CategoryName) VALUES (14, 'Grains, Pasta & Sides');
INSERT INTO Category (CategoryID, CategoryName) VALUES (15, 'International Cuisine');
INSERT INTO Category (CategoryID, CategoryName) VALUES (16, 'Meat & Seafood');
INSERT INTO Category (CategoryID, CategoryName) VALUES (17, 'Miscellaneous – gift cards/wrap, batteries, etc.');
INSERT INTO Category (CategoryID, CategoryName) VALUES (18, 'Paper Products – toilet paper, paper towels, tissues, paper plates/cups, etc.');
INSERT INTO Category (CategoryID, CategoryName) VALUES (19, 'Cleaning Supplies – laundry detergent, dishwashing soap, etc.');
INSERT INTO Category (CategoryID, CategoryName) VALUES (20, 'Health & Beauty, Personal Care & Pharmacy – pharmacy items, shampoo, toothpaste');
INSERT INTO Category (CategoryID, CategoryName) VALUES (21, 'Pet Care');
INSERT INTO Category (CategoryID, CategoryName) VALUES (22, 'Pharmacy');
INSERT INTO Category (CategoryID, CategoryName) VALUES (23, 'Tobacco');

GO

--Populate the Aisle Table
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 1, 1);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 2, 2);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 3, 3);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 4, 4);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 5, 5);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 6, 6);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 7, 7);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 8, 8);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 9, 9);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 10, 10);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 11, 11);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (1, 12, 12);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 1, 3);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 2, 2);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 3, 1);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 4, 4);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 5, 5);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 6, 10);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 7, 7);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 8, 8);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 9, 9);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 10, 11);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 11, 6);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (2, 12, 12);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 1, 12);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 2, 2);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 3, 10);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 4, 4);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 5, 5);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 6, 6);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 7, 7);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 8, 8);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 9, 9);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 10, 1);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 11, 11);
INSERT INTO Aisle (StoreID, AisleID, CategoryType) VALUES (3, 12, 3);
GO


--Populate the Sections Table
INSERT INTO Section (SectionID, SectionName) VALUES (1, ' Carbonated Beverages');
INSERT INTO Section (SectionID, SectionName) VALUES (2, ' Milk');
INSERT INTO Section (SectionID, SectionName) VALUES (3, ' Fresh Bread & Rolls');
INSERT INTO Section (SectionID, SectionName) VALUES (4, ' Salty Snacks');
INSERT INTO Section (SectionID, SectionName) VALUES (5, ' Beer/Ale/Alcoholic Cider');
INSERT INTO Section (SectionID, SectionName) VALUES (6, ' Natural Cheese');
INSERT INTO Section (SectionID, SectionName) VALUES (7, ' Wine');
INSERT INTO Section (SectionID, SectionName) VALUES (8, ' Fz Dinners/Entrees');
INSERT INTO Section (SectionID, SectionName) VALUES (9, ' Cold Cereal');
INSERT INTO Section (SectionID, SectionName) VALUES (10, ' Cigarettes');
INSERT INTO Section (SectionID, SectionName) VALUES (11, ' Yogurt');
INSERT INTO Section (SectionID, SectionName) VALUES (12, ' Rfg Juices/Drinks');
INSERT INTO Section (SectionID, SectionName) VALUES (13, ' Ice Cream/Sherbet');
INSERT INTO Section (SectionID, SectionName) VALUES (14, ' Bottled Water');
INSERT INTO Section (SectionID, SectionName) VALUES (15, ' Soup');
INSERT INTO Section (SectionID, SectionName) VALUES (16, ' Crackers');
INSERT INTO Section (SectionID, SectionName) VALUES (17, ' Cookies');
INSERT INTO Section (SectionID, SectionName) VALUES (18, ' Bottled Juices');
INSERT INTO Section (SectionID, SectionName) VALUES (19, ' Coffee');
INSERT INTO Section (SectionID, SectionName) VALUES (20, ' Luncheon Meats');
INSERT INTO Section (SectionID, SectionName) VALUES (21, ' Breakfast Meats');
INSERT INTO Section (SectionID, SectionName) VALUES (22, ' Rfg Fresh Eggs');
INSERT INTO Section (SectionID, SectionName) VALUES (23, ' Toilet Tissue');
INSERT INTO Section (SectionID, SectionName) VALUES (24, ' Dog Food');
INSERT INTO Section (SectionID, SectionName) VALUES (25, ' Total Chocolate Candy');
INSERT INTO Section (SectionID, SectionName) VALUES (26, ' Fz Pizza');
INSERT INTO Section (SectionID, SectionName) VALUES (27, ' Rfg Salad/Coleslaw');
INSERT INTO Section (SectionID, SectionName) VALUES (28, ' Fz Novelties');
INSERT INTO Section (SectionID, SectionName) VALUES (29, ' Laundry Detergent');
INSERT INTO Section (SectionID, SectionName) VALUES (30, ' Vegetables');
INSERT INTO Section (SectionID, SectionName) VALUES (31, ' Fz Seafood');
INSERT INTO Section (SectionID, SectionName) VALUES (32, ' Spirits/Liquor');
INSERT INTO Section (SectionID, SectionName) VALUES (33, ' Snack Bars/Granola Bars');
INSERT INTO Section (SectionID, SectionName) VALUES (34, ' Baby Formula/Electrolytes');
INSERT INTO Section (SectionID, SectionName) VALUES (35, ' Processed Cheese');
INSERT INTO Section (SectionID, SectionName) VALUES (36, ' Shortening & Oil');
INSERT INTO Section (SectionID, SectionName) VALUES (37, ' Fz/Rfg Poultry');
INSERT INTO Section (SectionID, SectionName) VALUES (38, ' Cat Food');
INSERT INTO Section (SectionID, SectionName) VALUES (39, ' Spices/Seasonings');
INSERT INTO Section (SectionID, SectionName) VALUES (40, ' Dinner Sausage');
INSERT INTO Section (SectionID, SectionName) VALUES (41, ' Paper Towels');
INSERT INTO Section (SectionID, SectionName) VALUES (42, ' Fz Plain Vegetables');
INSERT INTO Section (SectionID, SectionName) VALUES (43, ' Creams/Creamers');
INSERT INTO Section (SectionID, SectionName) VALUES (44, ' Processed Fz/Rfg Poultry');
INSERT INTO Section (SectionID, SectionName) VALUES (45, ' Frankfurters');
INSERT INTO Section (SectionID, SectionName) VALUES (46, ' Pastry/Doughnuts');
INSERT INTO Section (SectionID, SectionName) VALUES (47, ' Sports Drinks');
INSERT INTO Section (SectionID, SectionName) VALUES (48, ' Fz Breakfast Food');
INSERT INTO Section (SectionID, SectionName) VALUES (49, ' Pasta');
INSERT INTO Section (SectionID, SectionName) VALUES (50, ' Spaghetti/Italian Sauce');
INSERT INTO Section (SectionID, SectionName) VALUES (51, ' Pickles/Relish/Olives');
INSERT INTO Section (SectionID, SectionName) VALUES (52, ' Mexican Foods');
INSERT INTO Section (SectionID, SectionName) VALUES (53, ' Canned/Bottled Fruit');
INSERT INTO Section (SectionID, SectionName) VALUES (54, ' Snack Nuts/Seeds/Corn Nuts');
INSERT INTO Section (SectionID, SectionName) VALUES (55, ' Seafood – Ss');
INSERT INTO Section (SectionID, SectionName) VALUES (56, ' Food & Trash Bags');
INSERT INTO Section (SectionID, SectionName) VALUES (57, ' Salad Dressings – Ss');
INSERT INTO Section (SectionID, SectionName) VALUES (58, ' Rfg Side Dishes');
INSERT INTO Section (SectionID, SectionName) VALUES (59, ' Rice');
INSERT INTO Section (SectionID, SectionName) VALUES (60, ' Total Non-Chocolate Candy');
INSERT INTO Section (SectionID, SectionName) VALUES (61, ' Butter');
INSERT INTO Section (SectionID, SectionName) VALUES (62, ' Dry Packaged Dinners');
INSERT INTO Section (SectionID, SectionName) VALUES (63, ' Fz Meat');
INSERT INTO Section (SectionID, SectionName) VALUES (64, ' Margarine/Spreads/Butter Blen');
INSERT INTO Section (SectionID, SectionName) VALUES (65, ' Dough/Biscuit Dough – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (66, ' Tea/Coffee Ready-To-Drink');
INSERT INTO Section (SectionID, SectionName) VALUES (67, ' Mayonnaise');
INSERT INTO Section (SectionID, SectionName) VALUES (68, ' Baking Needs');
INSERT INTO Section (SectionID, SectionName) VALUES (69, ' Sugar');
INSERT INTO Section (SectionID, SectionName) VALUES (70, ' Ss Dinners');
INSERT INTO Section (SectionID, SectionName) VALUES (71, ' Cups & Plates');
INSERT INTO Section (SectionID, SectionName) VALUES (72, ' Baking Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (73, ' Tomato Products');
INSERT INTO Section (SectionID, SectionName) VALUES (74, ' Vitamins');
INSERT INTO Section (SectionID, SectionName) VALUES (75, ' Fz Potatoes/Onions');
INSERT INTO Section (SectionID, SectionName) VALUES (76, ' Rfg Meat');
INSERT INTO Section (SectionID, SectionName) VALUES (77, ' Soap');
INSERT INTO Section (SectionID, SectionName) VALUES (78, ' Bakery Snacks');
INSERT INTO Section (SectionID, SectionName) VALUES (79, ' Diapers');
INSERT INTO Section (SectionID, SectionName) VALUES (80, ' Household Cleaner');
INSERT INTO Section (SectionID, SectionName) VALUES (81, ' Pies & Cakes');
INSERT INTO Section (SectionID, SectionName) VALUES (82, ' Mexican Sauce');
INSERT INTO Section (SectionID, SectionName) VALUES (83, ' Ss Meat & Rfg Ham');
INSERT INTO Section (SectionID, SectionName) VALUES (84, ' Fz Appetizers/Snack Rolls');
INSERT INTO Section (SectionID, SectionName) VALUES (85, ' Dish Detergent');
INSERT INTO Section (SectionID, SectionName) VALUES (86, ' Cream Cheese/Cr Chs Spread');
INSERT INTO Section (SectionID, SectionName) VALUES (87, ' Peanut Butter');
INSERT INTO Section (SectionID, SectionName) VALUES (88, ' Jellies/Jams/Honey');
INSERT INTO Section (SectionID, SectionName) VALUES (89, ' Internal Analgesics');
INSERT INTO Section (SectionID, SectionName) VALUES (90, ' Gravy/Sauce Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (91, ' Cottage Cheese');
INSERT INTO Section (SectionID, SectionName) VALUES (92, ' Energy Drinks');
INSERT INTO Section (SectionID, SectionName) VALUES (93, ' Aseptic Juices');
INSERT INTO Section (SectionID, SectionName) VALUES (94, ' Gum');
INSERT INTO Section (SectionID, SectionName) VALUES (95, ' Rfg Entrees');
INSERT INTO Section (SectionID, SectionName) VALUES (96, ' Hot Cereal');
INSERT INTO Section (SectionID, SectionName) VALUES (97, ' Lunches – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (98, ' Sour Cream');
INSERT INTO Section (SectionID, SectionName) VALUES (99, ' Mustard & Ketchup');
INSERT INTO Section (SectionID, SectionName) VALUES (100, ' All Other Sauces');
INSERT INTO Section (SectionID, SectionName) VALUES (101, ' Baby Food');
INSERT INTO Section (SectionID, SectionName) VALUES (102, ' Cold/Allergy/Sinus Tablets');
INSERT INTO Section (SectionID, SectionName) VALUES (103, ' Toothpaste');
INSERT INTO Section (SectionID, SectionName) VALUES (104, ' Tea – Bags/Loose');
INSERT INTO Section (SectionID, SectionName) VALUES (105, ' Weight Con/Nutrition Liq/Pwd');
INSERT INTO Section (SectionID, SectionName) VALUES (106, ' Fz Bread/Fz Dough');
INSERT INTO Section (SectionID, SectionName) VALUES (107, ' Pet Supplies');
INSERT INTO Section (SectionID, SectionName) VALUES (108, ' Gastrointestinal – Tablets');
INSERT INTO Section (SectionID, SectionName) VALUES (109, ' Facial Tissue');
INSERT INTO Section (SectionID, SectionName) VALUES (110, ' Sanitary Napkins/Tampons');
INSERT INTO Section (SectionID, SectionName) VALUES (111, ' Flour/Meal');
INSERT INTO Section (SectionID, SectionName) VALUES (112, ' Cat/Dog Litter');
INSERT INTO Section (SectionID, SectionName) VALUES (113, ' Dried Fruit');
INSERT INTO Section (SectionID, SectionName) VALUES (114, ' Shampoo');
INSERT INTO Section (SectionID, SectionName) VALUES (115, ' Popcorn/Popcorn Oil');
INSERT INTO Section (SectionID, SectionName) VALUES (116, ' Syrup/Molasses');
INSERT INTO Section (SectionID, SectionName) VALUES (117, ' Deodorant');
INSERT INTO Section (SectionID, SectionName) VALUES (118, ' Drink Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (119, ' Baking Nuts');
INSERT INTO Section (SectionID, SectionName) VALUES (120, ' Batteries');
INSERT INTO Section (SectionID, SectionName) VALUES (121, ' Air Fresheners');
INSERT INTO Section (SectionID, SectionName) VALUES (122, ' Gelatin/Pudding Prd And Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (123, ' Foils & Wraps');
INSERT INTO Section (SectionID, SectionName) VALUES (124, ' Desserts -Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (125, ' Baked Beans/Canned Bread');
INSERT INTO Section (SectionID, SectionName) VALUES (126, ' Fz Desserts/Topping');
INSERT INTO Section (SectionID, SectionName) VALUES (127, ' Skin Care');
INSERT INTO Section (SectionID, SectionName) VALUES (128, ' Blades');
INSERT INTO Section (SectionID, SectionName) VALUES (129, ' English Muffins');
INSERT INTO Section (SectionID, SectionName) VALUES (130, ' Spreads – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (131, ' Rfg Whipped Toppings');
INSERT INTO Section (SectionID, SectionName) VALUES (132, ' Canned Juices – Ss');
INSERT INTO Section (SectionID, SectionName) VALUES (133, ' Rfg Dips');
INSERT INTO Section (SectionID, SectionName) VALUES (134, ' Fz Pies');
INSERT INTO Section (SectionID, SectionName) VALUES (135, ' Cleaning Tools/Mops/Brooms');
INSERT INTO Section (SectionID, SectionName) VALUES (136, ' Toaster Pastries/Tarts');
INSERT INTO Section (SectionID, SectionName) VALUES (137, ' Dry Fruit Snacks');
INSERT INTO Section (SectionID, SectionName) VALUES (138, ' Toothbrush/Dental Accesories');
INSERT INTO Section (SectionID, SectionName) VALUES (139, ' Barbeque Sauce');
INSERT INTO Section (SectionID, SectionName) VALUES (140, ' Rfg Teas/Coffee');
INSERT INTO Section (SectionID, SectionName) VALUES (141, ' Charcoal');
INSERT INTO Section (SectionID, SectionName) VALUES (142, ' Sugar Substitutes');
INSERT INTO Section (SectionID, SectionName) VALUES (143, ' Fz Fruit');
INSERT INTO Section (SectionID, SectionName) VALUES (144, ' Asian Food');
INSERT INTO Section (SectionID, SectionName) VALUES (145, ' Paper Napkins');
INSERT INTO Section (SectionID, SectionName) VALUES (146, ' Fabric Softener Liquid');
INSERT INTO Section (SectionID, SectionName) VALUES (147, ' Hair Conditioner');
INSERT INTO Section (SectionID, SectionName) VALUES (148, ' Seafood – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (149, ' Moist Towelettes');
INSERT INTO Section (SectionID, SectionName) VALUES (150, ' Juices – Frozen');
INSERT INTO Section (SectionID, SectionName) VALUES (151, ' Dip/Dip Mixes – Ss\Candles');
INSERT INTO Section (SectionID, SectionName) VALUES (152, ' Dry Beans/Vegetables');
INSERT INTO Section (SectionID, SectionName) VALUES (153, ' Mouthwash');
INSERT INTO Section (SectionID, SectionName) VALUES (154, ' Misc');
INSERT INTO Section (SectionID, SectionName) VALUES (155, ' Instant Potatoes');
INSERT INTO Section (SectionID, SectionName) VALUES (156, ' Coffee Creamer');
INSERT INTO Section (SectionID, SectionName) VALUES (157, ' Kitchen Storage');
INSERT INTO Section (SectionID, SectionName) VALUES (158, ' Vinegar');
INSERT INTO Section (SectionID, SectionName) VALUES (159, ' Eye/Contact Lens Care Product');
INSERT INTO Section (SectionID, SectionName) VALUES (160, ' Evaporated/Condensed Milk');
INSERT INTO Section (SectionID, SectionName) VALUES (161, ' Milk Flavoring/Cocoa Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (162, ' Frosting');
INSERT INTO Section (SectionID, SectionName) VALUES (163, ' Fz Prepared Vegetables');
INSERT INTO Section (SectionID, SectionName) VALUES (164, ' Hand & Body Lotion');
INSERT INTO Section (SectionID, SectionName) VALUES (165, ' Hair Coloring');
INSERT INTO Section (SectionID, SectionName) VALUES (166, ' Bleach');
INSERT INTO Section (SectionID, SectionName) VALUES (167, ' Breadcrumbs/Batters');
INSERT INTO Section (SectionID, SectionName) VALUES (168, ' Other Rfg Products');
INSERT INTO Section (SectionID, SectionName) VALUES (169, ' Non-Fruit Drinks');
INSERT INTO Section (SectionID, SectionName) VALUES (170, ' Light Bulbs');
INSERT INTO Section (SectionID, SectionName) VALUES (171, ' Fz Pasta');
INSERT INTO Section (SectionID, SectionName) VALUES (172, ' Laundry Care');
INSERT INTO Section (SectionID, SectionName) VALUES (173, ' Salad Toppings');
INSERT INTO Section (SectionID, SectionName) VALUES (174, ' Smokeless Tobacco');
INSERT INTO Section (SectionID, SectionName) VALUES (175, ' Fz Pot Pies');
INSERT INTO Section (SectionID, SectionName) VALUES (176, ' Dessert Toppings');
INSERT INTO Section (SectionID, SectionName) VALUES (177, ' Foil Pans');
INSERT INTO Section (SectionID, SectionName) VALUES (178, ' Pest Control');
INSERT INTO Section (SectionID, SectionName) VALUES (179, ' Tea – Instant Tea Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (180, ' Baked Goods – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (181, ' Salad Dressing – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (182, ' Misc Health Remedies');
INSERT INTO Section (SectionID, SectionName) VALUES (183, ' Adult Incontinence');
INSERT INTO Section (SectionID, SectionName) VALUES (184, ' Rfg Tortlla/Eggrll/Wontn Wrap');
INSERT INTO Section (SectionID, SectionName) VALUES (185, ' Dried Meat Snacks');
INSERT INTO Section (SectionID, SectionName) VALUES (186, ' Sponges & Scouring Pads');
INSERT INTO Section (SectionID, SectionName) VALUES (187, ' Pizza – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (188, ' Steak/Worcestershire Sauce');
INSERT INTO Section (SectionID, SectionName) VALUES (189, ' Rug/Upholstery/Fabric Treatmt');
INSERT INTO Section (SectionID, SectionName) VALUES (190, ' Pancake Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (191, ' Pasta – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (192, ' Fz Side Dishes');
INSERT INTO Section (SectionID, SectionName) VALUES (193, ' Stuffing Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (194, ' First Aid Treatment');
INSERT INTO Section (SectionID, SectionName) VALUES (195, ' First Aid Accessories');
INSERT INTO Section (SectionID, SectionName) VALUES (196, ' Premixed Cocktails/Coolers');
INSERT INTO Section (SectionID, SectionName) VALUES (197, ' Fabric Softener Sheets');
INSERT INTO Section (SectionID, SectionName) VALUES (198, ' Gastrointestinal – Liquid');
INSERT INTO Section (SectionID, SectionName) VALUES (199, ' Hair Styling Gel/Mousse');
INSERT INTO Section (SectionID, SectionName) VALUES (200, ' Cold/Allergy/Sinus Liquids');
INSERT INTO Section (SectionID, SectionName) VALUES (201, ' Cosmetics – Eye');
INSERT INTO Section (SectionID, SectionName) VALUES (202, ' Suntan Products');
INSERT INTO Section (SectionID, SectionName) VALUES (203, ' Firelog/Firestarter/Firewood');
INSERT INTO Section (SectionID, SectionName) VALUES (204, ' Pickles/Relish – Rfg');
INSERT INTO Section (SectionID, SectionName) VALUES (205, ' Disposable Tableware');
INSERT INTO Section (SectionID, SectionName) VALUES (206, ' Rice/Popcorn Cakes');
INSERT INTO Section (SectionID, SectionName) VALUES (207, ' Croutons');
INSERT INTO Section (SectionID, SectionName) VALUES (208, ' Hair Spray/Spritz');
INSERT INTO Section (SectionID, SectionName) VALUES (209, ' Household Cleaner Cloths');
INSERT INTO Section (SectionID, SectionName) VALUES (210, ' Cocktail Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (211, ' Cough Drops');
INSERT INTO Section (SectionID, SectionName) VALUES (212, ' Cosmetics – Facial');
INSERT INTO Section (SectionID, SectionName) VALUES (213, ' Baby Accessories');
INSERT INTO Section (SectionID, SectionName) VALUES (214, ' Nasal Products');
INSERT INTO Section (SectionID, SectionName) VALUES (215, ' Baby Needs');
INSERT INTO Section (SectionID, SectionName) VALUES (216, ' Hair Accessories');
INSERT INTO Section (SectionID, SectionName) VALUES (217, ' Marshmallows');
INSERT INTO Section (SectionID, SectionName) VALUES (218, ' Foot Care Products');
INSERT INTO Section (SectionID, SectionName) VALUES (219, ' Office Products');
INSERT INTO Section (SectionID, SectionName) VALUES (220, ' Coffee Filters');
INSERT INTO Section (SectionID, SectionName) VALUES (221, ' Cigars');
INSERT INTO Section (SectionID, SectionName) VALUES (222, ' Cosmetics – Nail');
INSERT INTO Section (SectionID, SectionName) VALUES (223, ' Cheesecakes');
INSERT INTO Section (SectionID, SectionName) VALUES (224, ' Feminine Needs');
INSERT INTO Section (SectionID, SectionName) VALUES (225, ' Specialty Nut Butter');
INSERT INTO Section (SectionID, SectionName) VALUES (226, ' Cough Syrup');
INSERT INTO Section (SectionID, SectionName) VALUES (227, ' Shaving Cream');
INSERT INTO Section (SectionID, SectionName) VALUES (228, ' Fz Corn On The Cob');
INSERT INTO Section (SectionID, SectionName) VALUES (229, ' Denture Products');
INSERT INTO Section (SectionID, SectionName) VALUES (230, ' Cotton Balls/Swabs');
INSERT INTO Section (SectionID, SectionName) VALUES (231, ' All Other Breakfast Food');
INSERT INTO Section (SectionID, SectionName) VALUES (232, ' Pizza Products');
INSERT INTO Section (SectionID, SectionName) VALUES (233, ' Socks');
INSERT INTO Section (SectionID, SectionName) VALUES (234, ' Shaving Lotion/Mens Fragrance');
INSERT INTO Section (SectionID, SectionName) VALUES (235, ' Ice Cream Cones/Mixes');
INSERT INTO Section (SectionID, SectionName) VALUES (236, ' Razors');
INSERT INTO Section (SectionID, SectionName) VALUES (237, ' Childrens Art Supplies');
INSERT INTO Section (SectionID, SectionName) VALUES (238, ' Cosmetics – Lip');
INSERT INTO Section (SectionID, SectionName) VALUES (239, ' Lighters');
INSERT INTO Section (SectionID, SectionName) VALUES (240, ' Furniture Polish');
INSERT INTO Section (SectionID, SectionName) VALUES (241, ' Water Softeners/Treatment');
INSERT INTO Section (SectionID, SectionName) VALUES (242, ' Other Frozen Foods');
INSERT INTO Section (SectionID, SectionName) VALUES (243, ' Writing Instruments');
INSERT INTO Section (SectionID, SectionName) VALUES (244, ' Automobile Fluids/Antifreeze');
INSERT INTO Section (SectionID, SectionName) VALUES (245, ' Contraceptives');
INSERT INTO Section (SectionID, SectionName) VALUES (246, ' External Analgesic Rubs');
INSERT INTO Section (SectionID, SectionName) VALUES (247, ' Gloves');
INSERT INTO Section (SectionID, SectionName) VALUES (248, ' Charcoal Lighter Fluids');
INSERT INTO Section (SectionID, SectionName) VALUES (249, ' Floor Cleaners/Wax Removers');
INSERT INTO Section (SectionID, SectionName) VALUES (250, ' Anti-Smoking Products');
INSERT INTO Section (SectionID, SectionName) VALUES (251, ' Sleeping Remedies');
INSERT INTO Section (SectionID, SectionName) VALUES (252, ' Water Filters/Devices');
INSERT INTO Section (SectionID, SectionName) VALUES (253, ' All Other Tobacco Products');
INSERT INTO Section (SectionID, SectionName) VALUES (254, ' Motor Oil');
INSERT INTO Section (SectionID, SectionName) VALUES (255, ' Family Planning');
INSERT INTO Section (SectionID, SectionName) VALUES (256, ' Pantyhose/Nylons');
INSERT INTO Section (SectionID, SectionName) VALUES (257, ' Fragrances – Women’s');
INSERT INTO Section (SectionID, SectionName) VALUES (258, ' Baking Cups/Paper');
GO


--Populate the Shelf Table
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 1, 1, 2);
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 1, 2, 22);
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 1, 3, 3);
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 1, 4, 12);
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 1, 5, 20);
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 2, 1, 113);
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 2, 2, 113);
INSERT INTO Shelf (StoreID, AisleID, ShelfID, SectionID) VALUES (1, 2, 3, 11);
GO


--Populate the Product Table
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (1, 'Milk', 4.39, 2);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (2, 'Eggs', 3.12, 22);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (3, 'Bread', 3.54, 3);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (4, 'Orange Juice', 5.76, 12);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (5, 'Lunch Meat Turkey', 6.99, 20);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (6, 'Apples', 1.08, 113);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (7, 'Bannanas', 1.13, 113);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (8, 'Yogurt', 4.34, 11);
INSERT INTO Product (ProductID, ProductName, Price, SectionID) VALUES (9, 'Ramon Noodles', 0.1, 49);
GO

--Populate the User Table
INSERT INTO [User] (UserID, FirstName, LastName, ListID,ListName, StorePref) VALUES (1, 'Caleb', 'Pleasant', 1, 'Weekly List', 3);
INSERT INTO [User] (UserID, FirstName, LastName, ListID,ListName, StorePref) VALUES (2, 'John', 'Smith', 2, '', 2);
INSERT INTO [User] (UserID, FirstName, LastName, ListID,ListName, StorePref) VALUES (3, 'Melanie', 'Pleasant', 1, 'Weekly List', 1);
GO

--Populate the ShoppingList Table
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 1,1, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 2,2, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 3,2, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 4,1, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 5,3, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 6,2, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 7,1, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 8,2, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (1, 9,1, 'Pleasant Home');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (2, 1,2, 'Johns Stuff');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (2, 2,2, 'Johns Stuff');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (2, 3,1, 'Johns Stuff');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (2, 4,2, 'Johns Stuff');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (2, 5,4, 'Johns Stuff');
INSERT INTO ShoppingList (ListID, ProductID, Quantity, ListName) VALUES (2, 6,1, 'Johns Stuff');
GO