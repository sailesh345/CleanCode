public void OldRequestModule(string url)
{
    // ...  Some logic
}

public void NewRequestModule(string url)
{
    // ... Some logic
}

var request = NewRequestModule(requestUrl);
// var request = OldRequestModule(requestUrl); Not in use 
InventoryTracker("apples", request, "www.inventory-awesome.io");