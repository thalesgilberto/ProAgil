using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {             
                var results = await _dataContext.Eventos.ToListAsync();   
                return Ok(results);
            }
            catch (System.Exception)
            {                
                throw;
            }            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {            
            try
            {
                var result = await _dataContext.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(result);
            }
            catch (System.Exception)
            {                
                throw;
            }            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _dataContext.Eventos.RemoveRange(_dataContext.Eventos.Where(x => x.EventoId == id)
                                                                     .Select(x => new Evento { EventoId = x.EventoId }));             
                await _dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception)
            {                
                throw;
            }            
        }

        //Estudar melhor forma de fazer o método delete com lamdba
        //public static void Delete<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        //{ 
            //var obj = Expression.Convert(expression.Body, typeof(UnaryExpression));
            //string className = typeof(TEntity).Name;
            //string conditions = expression.Body.ToString().Replace("AndAlso", "AND").Replace("OrElse", "OR").Replace("==", "=");
            //string aliasClassName = expression.Parameters.First().Name;
            //string sqlQuery = $@"DELETE FROM {className} {aliasClassName} WHERE {conditions}";
            //Console.WriteLine(sqlQuery);
        //}
    }
}
