using System;
using backend.Dto;
using backend.Models;

namespace backend.Mappings;

public static class ProductMappings
{
 public static ProductModel ToEntity (this ProductDto productDto){
    return new ProductModel {
        Name = productDto.Name,
        Description = productDto.Description,
        Image = productDto.Image
    };
 }
}
