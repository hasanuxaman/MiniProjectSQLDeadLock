using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjectSQLDeadLock.Data;
using System.Diagnostics;

namespace MiniProjectSQLDeadLock.Controllers
{
    public class SimulateDeadlockController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<SimulateDeadlockController> _logger;

        public SimulateDeadlockController(AppDbContext db, ILogger<SimulateDeadlockController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SimulateDeadlock")]
    
        public async Task<IActionResult> SimulateDeadlock(bool firstProduct)
        {
            var taskName = firstProduct ? "Transaction A" : "Transaction B";
            await DoTransactionAsync(taskName, firstProduct);
            return Content($"{taskName}: সম্পন্ন হয়েছে অথবা Deadlock হয়েছে।");

            //var rnd = new Random();
            //for (int i = 0; i < 2; i++)
            //{
            //    _ = Task.Run(async () => {
            //        using var tran = await _db.Database.BeginTransactionAsync();

            //        if (i == 0)
            //        {
            //            await _db.Products.Where(p => p.ProductId == 1)
            //              .ExecuteUpdateAsync(s => s.SetProperty(p => p.Qty, p => p.Qty - 1));
            //            await Task.Delay(500);
            //            await _db.Vendors.Where(v => v.VendorId == 1)
            //              .ExecuteUpdateAsync(s => s.SetProperty(v => v.Name, v => v.Name));
            //        }
            //        else
            //        {
            //            await _db.Vendors.Where(v => v.VendorId == 1)
            //              .ExecuteUpdateAsync(s => s.SetProperty(v => v.Name, v => v.Name));
            //            await Task.Delay(500);
            //            await _db.Products.Where(p => p.ProductId == 1)
            //              .ExecuteUpdateAsync(s => s.SetProperty(p => p.Qty, p => p.Qty - 1));
            //        }
            //        await tran.CommitAsync();
            //    });
            //}
            //return Ok("Triggered simulation");

            //var task1 = Task.Run(() => DoTransactionAsync("Task1", true));
            //var task2 = Task.Run(() => DoTransactionAsync("Task2", false));

            //await Task.WhenAll(task1, task2);

            //return Ok("Deadlock simulation triggered.");
        }

        private async Task DoTransactionAsync(string taskName, bool firstProduct)
        {
            try
            {
                _logger.LogInformation($"{taskName}: শুরু হচ্ছে...");
                using var tran = await _db.Database.BeginTransactionAsync();

                if (firstProduct)
                {
                    _logger.LogInformation($"{taskName}: Product → Vendor আপডেট শুরু");
                    await _db.Products.Where(p => p.ProductId == 1)
                        .ExecuteUpdateAsync(s => s.SetProperty(p => p.Quantity, p => p.Quantity - 1));

                    await Task.Delay(500);

                    await _db.Vendors.Where(v => v.VendorId == 1)
                        .ExecuteUpdateAsync(s => s.SetProperty(v => v.VendorName, v => v.VendorName));
                }
                else
                {
                    _logger.LogInformation($"{taskName}: Vendor → Product আপডেট শুরু");
                    await _db.Vendors.Where(v => v.VendorId == 1)
                        .ExecuteUpdateAsync(s => s.SetProperty(v => v.VendorName, v => v.VendorName));

                    await Task.Delay(500);

                    await _db.Products.Where(p => p.ProductId == 1)
                        .ExecuteUpdateAsync(s => s.SetProperty(p => p.Quantity, p => p.Quantity - 1));
                }

                await tran.CommitAsync();
                _logger.LogInformation($"{taskName}: ট্রানজেকশন কমিট হয়েছে।");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{taskName}: Deadlock বা অন্য কোনো exception");
            }
        }
    }
}
