//add new key=>value to the HTML5 storage
function SaveItem()
{		
	var name = document.forms.ShoppingList.name.value;
	var data = document.forms.ShoppingList.data.value;
	localStorage.setItem(name, data);
	doShowAll();
}
//------------------------------------------------------------------------------
//change an existing key=>value in the HTML5 storage
function ModifyItem()
{
	var name = document.forms.ShoppingList.name.value;
	var data = document.forms.ShoppingList.data.value;
	//check if name1 is already exists
	
//check if key exists
			if (localStorage.getItem(name) !=null)
			{
			  //update
			  localStorage.setItem(name,data);
			  document.forms.ShoppingList.data.value = localStorage.getItem(name);
			}
	doShowAll();
}
//-------------------------------------------------------------------------
//delete an existing key=>value from the HTML5 storage
function RemoveItem()
{
	var name = document.forms.ShoppingList.name.value;
	document.forms.ShoppingList.data.value = localStorage.removeItem(name);
	doShowAll();
}
//-------------------------------------------------------------------------------------
//restart the local storage
function ClearAll()
{
	localStorage.clear();
	doShowAll();
}
//--------------------------------------------------------------------------------------
// dynamically populate the table with shopping list items
//below step can be done via PHP and AJAX too. 
function doShowAll()
{
	var key = "";
	var list = "<tr><th>Item</th><th>Value</th></tr>\n";
	var i = 0;
	//for more advance feature, you can set cap on max items in the cart
	for (i = 0; i < localStorage.length; i++)
	{
		key = localStorage.key(i);
		list += "<tr><td>" + key + "</td>\n<td>"
				+ localStorage.getItem(key) + "</td></tr>\n";
	}
	//if no item exists in the cart
	if (list == "<tr><th>Item</th><th>Value</th></tr>\n")
	{
		list += "<tr><td><i>No Items in Cart</i></td>\n<td><i>empty</i></td></tr>\n";
	}
	//bind the data to html table
	//you can use jQuery too....
	document.getElementById('list').innerHTML = list;
}
