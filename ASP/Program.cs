using Homework2Library;
using DatabaseLogic;


var builder = WebApplication.CreateBuilder(args);

// NEED THIS (to allow all operations for client to make request to cloud services like firebase, a ruleset for application to talk to each other)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials();
        });
});

// Add services to the container.

var app = builder.Build();

DatabaseAccountrix _databaselogic = new DatabaseAccountrix();
_databaselogic.initDatabase();

//routing codes
//test code
app.MapGet("/", () => "Connection successful!");

//map to endpoint for data saving 


//in  /register endpoint, this will be the API process carried out (for saving userdetail into firebase in the /register page)
app.MapPost("/register", async (UserDetail a_userdetail) =>
{
    await _databaselogic.saveUserData(a_userdetail);
    Console.WriteLine("User data saved successfully");
    return Results.NoContent();
});
//to check email if used or not, fetches userdata with particular user_ID from database, then checks the info of the fetched data from database with the one that current user created, if same email == not valid 
/*
app.MapGet("/register/{user_ID}", async (string a_user_ID) =>
{
    UserDetail user_fetched = await _databaselogic.retrieveUserEmail(a_user_ID);
    return Results.Ok(user_fetched);
});
code not used since decided to dump this feature
*/

//delete user data with regards to specific user_ID
app.MapPost("/register/{user_ID}", async (string a_user_ID) =>
{
    await _databaselogic.deleteUserData(a_user_ID);
    return Results.NoContent();
});

//in /login endpoint , this will be the API process carried out (getting userdetail for validation for logging in in the/login page)
app.MapGet("/login", async () =>
{
    UserDetail userDetailsFetched = await _databaselogic.retrieveUserDataAsDoc();
    return Results.Ok(userDetailsFetched);
});

//retrieve transaction data
app.MapGet("/transactions", async c =>
{
    await _databaselogic.retrieveTransaction();
    c.Response.WriteAsJsonAsync(_databaselogic.tmp_trans.Transactions);
  
});

//to save user transactions
app.MapPost("/transactions", async (UserTransaction a_transcation) =>
{
    await _databaselogic.saveTransaction(a_transcation);
    return Results.NoContent();
});

//to delete transaction
app.MapPost("/transactions/{data}", async (string data) =>
{
    await _databaselogic.deleteTransaction(data);
    return Results.NoContent();
});
//save items
app.MapPost("/assets", async (Item a_item) =>
{
    await _databaselogic.saveAsset(a_item);
    return Results.NoContent();
});
//retrieve items
app.MapGet("/assets", async c =>
{
    await _databaselogic.retrieveItem();
    c.Response.WriteAsJsonAsync(_databaselogic.tmp_items.items);
});
//delete items
app.MapPost("/assets/{data}", async (string data) =>
{
    await _databaselogic.deleteAsset(data);
    return Results.NoContent();
});

//fetch old user_data 
app.MapGet("/usersettings", async () =>
{
    UserDetail userDetailsFetched = await _databaselogic.retrieveUserDataAsDoc();
    return Results.Ok(userDetailsFetched);  
});

//delete user_data                  //this is because we pass parameter therefore need specify in the route //some webapi rules state this
app.MapPost("/usersettings/{user_ID_to_del}", async (string user_ID_to_del) =>
{
    await _databaselogic.deleteUserData(user_ID_to_del);
    return Results.NoContent();
});

//save new user_data
app.MapPost("/usersettings", async (UserDetail newUserDetail) =>
{
    await _databaselogic.saveUserData(newUserDetail);
    return Results.NoContent();
});


app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
// NEED THIS


app.Run();
