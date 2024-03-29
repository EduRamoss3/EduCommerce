﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interfaces
{
    public interface IProductService
    {
        Task<ActionResult<IEnumerable<Produto>>> GetAll();
        Task<ActionResult<Produto>> GetById(int id);
        Task<IEnumerable<Produto>> GetByCategoria(int categoriaId);  
        Task<IActionResult> Create(Produto produto);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update(Produto produto, int id);
        Task<IEnumerable<Produto>> GetByName(string searchString);
        Task<IActionResult> PatchQnt(Produto produto);
        Task<bool> Any(int id);
        IQueryable<Produto> PaginationProduct();
    }
}
