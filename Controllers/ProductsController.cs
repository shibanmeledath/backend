using System;
using backend.Data;
using backend.Dto;
using backend.Mappings;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

public static class ProductsController
{
    public static WebApplication MapProductController(this WebApplication app){
        
app.MapPost("/addproduct", async (ProductDto newProduct, ProductStoreContext ProductContext) =>
{
    bool productExist = await ProductContext.Product.AnyAsync(u => u.Name == newProduct.Name);

    if (productExist)
    {
           return  Results.Json(new 
        {
            status = "Error",
            message = "product alreday addeed."
        }, statusCode: 401);
    }

  
    ProductModel product = newProduct.ToEntity();


    ProductContext.Product.Add(product);
    await ProductContext.SaveChangesAsync();


      return Results.Json(new 
    {
        status = "Success",
        message = "Product Added.",
      
    },statusCode:200);
});


app.MapPost("/viewproduct", async (ProductDto newProduct, ProductStoreContext ProductContext) =>{
    var product = await ProductContext.Product.SingleOrDefaultAsync(u => u.Name == newProduct.Name);
    if (product == null)
    {
        return Results.Json(new{
            status ="Error",
            message="Product not found",
        },statusCode:404);
    }
 else{

       return Results.Json(new 
    {
        status = "Success",
        message = "Product got.",
        Data = new 
        {
            product.Name,
            product.Description,
            product.Image
        }
    },statusCode:200);
 }
});

        return app;
    }
}
