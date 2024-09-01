using System;
using backend.Data;
using backend.Dto;
using backend.Extensions;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers{

public static  class RegisterController
{
    public static WebApplication MapRegisterController(this WebApplication app){
app.MapPost("/register", async (UserDto newUser, UsersStoreContext DbContext) =>
{
    bool emailExists = await DbContext.Users.AnyAsync(u => u.Email == newUser.Email);

    if (emailExists)
    {
           return  Results.Json(new 
        {
            status = "Error",
            message = "Email already in use."
        }, statusCode: 401);
    }

  
    UserModel user = newUser.ToEntity();


    DbContext.Users.Add(user);
    await DbContext.SaveChangesAsync();


      return Results.Json(new 
    {
        status = "Success",
        message = "Registration  successful.",
      
    },statusCode:200);
});

app.MapPost("/login", async (UserDto newUser, UsersStoreContext DbContext) =>{
    var user = await DbContext.Users.SingleOrDefaultAsync(u => u.Email == newUser.Email);
    if (user == null)
    {
        return Results.Json(new{
            status ="Error",
            message="User not found"
        },statusCode:404);
    }

    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(newUser.Password, user.PasswordHash);

    if (!isPasswordValid)
    {
     
        return  Results.Json(new 
        {
            status = "Error",
            message = "Incorrect password."
        }, statusCode: 401);
    }

       return Results.Json(new 
    {
        status = "Success",
        message = "Login successful.",
        Data = new 
        {
            user.Id,
            user.Username,
            user.Email
        }
    },statusCode:200);
});

        return app;
    }
}
}