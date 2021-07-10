using Catalog.Service.EH;
using Catalog.Service.EH.Commands;
using Catalog.Service.EH.Exceptions;
using Catalog.Test.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using static Catalog.Common.Enums;

namespace Catalog.Test
{
    [TestClass]
    public class ProductInStockUpdateStockEHTest
    {
        private ILogger<ProductInStockUpdateStockEH> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateStockEH>>()
                    .Object;
            }
        }



        [TestMethod]
        public void TryToSubstrackStockWhenProductHasStock()
        {
            //Preparamos el contexto para almacenar en la BD simulada
            var context = ApplicationDBContextInMemory.Get();

            var productInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new Domain.ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            //Instanciamos la clase Handler 
            var hanler = new ProductInStockUpdateStockEH(context, GetLogger);


            //Simulamos la accion de substraer del stock.
            hanler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Substract
                    }
                }

            }, new System.Threading.CancellationToken()).Wait(); 

        }



        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstrackStockWhenProductHasntStock()
        {
            //Preparamos el contexto para almacenar en la BD simulada
            var context = ApplicationDBContextInMemory.Get();

            var productInStockId = 2;
            var productId = 2;

            context.Stocks.Add(new Domain.ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            //Instanciamos la clase Handler 
            var hanler = new ProductInStockUpdateStockEH(context, GetLogger);

            //Se agrega el try y catch para controlar la excepcion por el tipo de metodo y que es de tipo asincrono.
            try 
            {
                //Simulamos la accion de substraer del stock.
                hanler.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Substract
                    }
                }

                }, new System.Threading.CancellationToken()).Wait();
            }
            catch (AggregateException ae)
            {
                //var exception = ae.GetBaseException();

                if (ae.GetBaseException() is ProductInStockUpdateStockCommandException)
                {
                    throw new ProductInStockUpdateStockCommandException(ae.InnerException?.Message);
                }
            }
        }



        [TestMethod]
        public void TryToAddStockWhenProductExist()
        {
            //Preparamos el contexto para almacenar en la BD simulada
            var context = ApplicationDBContextInMemory.Get();

            var productInStockId = 3;
            var productId = 3;

            context.Stocks.Add(new Domain.ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            //Instanciamos la clase Handler 
            var hanler = new ProductInStockUpdateStockEH(context, GetLogger);


            //Simulamos la accion de substraer del stock.
            hanler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }

            }, new System.Threading.CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.ProductId == productId).Stock;

            Assert.AreEqual(stockInDb, 3);
        }



        [TestMethod]
        public void TryToAddStockWhenProductNotExist()
        {
            //Preparamos el contexto para almacenar en la BD simulada
            var context = ApplicationDBContextInMemory.Get();

            var productId = 4;

            
            //Instanciamos la clase Handler 
            var hanler = new ProductInStockUpdateStockEH(context, GetLogger);


            //Simulamos la accion de substraer del stock.
            hanler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }

            }, new System.Threading.CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.ProductId == productId).Stock;

            Assert.AreEqual(stockInDb, 2);
        }




    }
}
