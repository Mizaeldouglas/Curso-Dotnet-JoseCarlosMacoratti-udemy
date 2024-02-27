using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _contex;

        public ProdutosController(AppDbContext contex)
        {
            _contex = contex;
        }


        // GET: /Default3
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _contex.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }

            return produtos;
        }

        // GET: /Default3/5
        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produtos = _contex.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produtos is null)
            {
                return NotFound("Esse Produto não foi encontrado");
            }

            return produtos;
        }

        // POST: /Default3
        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }

            _contex.Produtos.Add(produto);
            _contex.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        // PUT: /Default3/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _contex.Entry(produto).State = EntityState.Modified;
            _contex.SaveChanges();
            
            return Ok(produto);
        }

        // DELETE: /ApiWithActions/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _contex.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            
            if (produto == null)
            {
                return NotFound("Produto não localizado...");
            }
            
            _contex.Produtos.Remove(produto);
            _contex.SaveChanges();
            return Ok(produto);
        }
    }
}