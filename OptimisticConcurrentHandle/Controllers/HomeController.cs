using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimisticConcurrentHandle.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OptimisticConcurrentHandle.Controllers
{
    [Route("home")]
    public class HomeController : ControllerBase
    {
        private readonly DatabaseContext _database;

        public HomeController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet("user1")]
        public async System.Threading.Tasks.Task<IActionResult> Get()
        {
            var allUser = _database.User.AsNoTracking().Take(2).ToList();

            var firstProduct = _database.Pencil.AsNoTracking().First();

            var order1 = new Order()
            {
                OrderId = Guid.NewGuid(),
                ProductId = firstProduct.PencilId,
                Buyer = allUser[0].UserId
            };

            var task1 = Task.Run(async () =>
            {
                try
                {
                    var product = firstProduct.DeepCopy();

                    product.Buyed = true;
                    product.LastUpdate = DateTime.Now;
                    product.UpdateBy = allUser[0].UserId;
                    _database.Order.Add(order1);

                    _database.Pencil.Update(product);

                    await Task.Delay(5000);

                    await _database.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            });


            try
            {
                await Task.WhenAll(task1);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("user2")]
        public async System.Threading.Tasks.Task<IActionResult> Get2()
        {
            var allUser = _database.User.AsNoTracking().Take(2).ToList();

            var firstProduct = _database.Pencil.AsNoTracking().First();

            var order1 = new Order()
            {
                OrderId = Guid.NewGuid(),
                ProductId = firstProduct.PencilId,
                Buyer = allUser[1].UserId
            };

            var task1 = Task.Run(async () =>
            {
                try
                {
                    var product = firstProduct.DeepCopy();

                    product.Buyed = true;
                    product.LastUpdate = DateTime.Now;
                    product.UpdateBy = allUser[1].UserId;
                    _database.Order.Add(order1);

                    _database.Pencil.Update(product);

                    await _database.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            });


            try
            {
                await Task.WhenAll(task1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
