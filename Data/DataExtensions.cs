using System;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        // Migrate UsersStoreContext
        var usersContext = scope.ServiceProvider.GetRequiredService<UsersStoreContext>();
        await usersContext.Database.MigrateAsync();

        // Migrate ProductStoreContext
        var productsContext = scope.ServiceProvider.GetRequiredService<ProductStoreContext>();
        await productsContext.Database.MigrateAsync();
    }
}
