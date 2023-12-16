﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Produto> GetAll();
        ActionResult<Produto> GetById(int id);
        IEnumerable<Produto> GetByCategoria(int categoriaId);  
        ActionResult Create(Produto produto);
        ActionResult Delete(int id);
        ActionResult Update(Produto produto);
        IEnumerable<Produto> GetByName(string searchString);
        ActionResult PatchQnt(Produto produto);
    }
}
