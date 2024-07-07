using ExchangeBusiness;
using ExchangeData.DTO;
using ExchangeData.Models;
using ExchangeWebApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController:Controller
    {
        private readonly TransactionBusiness _business;
        public TransactionController()
        {
            _business = new TransactionBusiness();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _business.GetAll();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await _business.GetById(id);

            if (result != null && result.Status > 0 && result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTransaction transaction)
        {
            //IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            var createTransaction = new Transaction
            {
                Status = 0,
                ProductId = transaction.ProductId,
                Quantity = transaction.Quantity,
                Note = transaction.Note,
                Price = transaction.Price,
                CreateAt = DateTime.Now,
                StudentBuy =1,
                TotalPrice = transaction.Price * transaction.Quantity,
                TypeTransactions = transaction.TypeTransactions,
            };
            try
            {
                var result = await _business.Create(createTransaction);

                if (result != null && result.Status > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("Update")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateTransactionDTO transaction)
        {
            //IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            
            try
            {
                var result = await _business.Update(transaction);

                if (result != null && result.Status > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        //[ValidateAntiForgeryToken]        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _business.Delete(id);

                if (result != null && result.Status > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
