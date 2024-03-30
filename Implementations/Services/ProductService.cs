

using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISellerRepository _sellerRepository;
        public ProductService(IProductRepository productRepository, IUserRepository userRepository, ISellerRepository sellerRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<BaseResponse> CreateProductAsync(CreateProductRequestModel model, int sellerId)
        {
            var product = await _productRepository.GetProductByProductName(model.ProductName, sellerId);
            if (product != null)
            {
                
                product.InitialQuantity = model.InitialQuantity;
                product.Quantity = model.InitialQuantity;

                await _productRepository.UpdateAsync(product);
                return new BaseResponse
                {
                    Message = "Product quantity updated successfully",
                    Success = true,
                };
            }


            var newProduct = new Product()
            {

                ProductName = model.ProductName,
                Price = model.Price,
                InitialQuantity = model.InitialQuantity,
                Quantity = model.InitialQuantity,
                ImageUrl = model.ImageUrl,
                SellerId = sellerId,

            };

            var addProduct = await _productRepository.CreateAsync(newProduct);
            if (addProduct == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Create Product",
                    Success = false,
                };
            }
            else
            {

                return new BaseResponse()
                {
                    Message = "Successfully Created Product",
                    Success = true,
                };
            }
        }

        public async Task<ProductResponseModel> GetById(int id, int sellerId)
        {
            var product = await _productRepository.GetProduct(id, sellerId);
            if (product == null)
            {
                return new ProductResponseModel
                {
                    Message = "Product not found",
                    Success = false,
                };
            }

            return new ProductResponseModel
            {
                Message = "Product Retrived Successfully",
                Success = true,
                Data = new ProductDto
                {
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Id = product.Id,
                    InitialQuantity = product.InitialQuantity,
                    ImageUrl = product.ImageUrl,
                    Quantity = product.Quantity,
                    SellerId = product.SellerId,
                    SellerDto = new SellerDto
                    {
                        Logo = product.Seller.Logo,
                        StoreName = product.Seller.StoreName,
                        AccountNumber = product.Seller.AccountNumber,
                        Id = product.Seller.Id,
                        Address = new AddressDto
                        {
                            HouseNumber = product.Seller.Address.HouseNumber,
                            StreetName = product.Seller.Address.StreetName,
                            LGA = product.Seller.Address.LGA,
                            Town = product.Seller.Address.Town,
                            State = product.Seller.Address.State,
                            Country = product.Seller.Address.Country
                        }
                    }
                }
            };
        }
        public async Task<ProductResponseModel> GetByProductName(string productName, int sellerId)
        {
            var product = await _productRepository.GetProductByProductName(productName, sellerId);
            if (product == null)
            {
                return new ProductResponseModel
                {
                    Message = "Product not found",
                    Success = false,
                };
            }

            return new ProductResponseModel
            {
                Message = "Product Retrived Successfully",
                Success = true,
                Data = new ProductDto
                {
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Id = product.Id,
                    InitialQuantity = product.InitialQuantity,
                    ImageUrl = product.ImageUrl,
                    Quantity = product.Quantity,
                    SellerId = product.SellerId,
                    SellerDto = new SellerDto
                    {
                        Logo = product.Seller.Logo,
                        StoreName = product.Seller.StoreName,
                        AccountNumber = product.Seller.AccountNumber,
                        Id = product.Seller.Id,
                        Address = new AddressDto
                        {
                            HouseNumber = product.Seller.Address.HouseNumber,
                            StreetName = product.Seller.Address.StreetName,
                            LGA = product.Seller.Address.LGA,
                            Town = product.Seller.Address.Town,
                            State = product.Seller.Address.State,
                            Country = product.Seller.Address.Country
                        }
                    }
                }
            };
        }

        public async Task<ProductResponseModel> GetProductByProductName(string productName)
        {
            var product = await _productRepository.GetProductByProductName(productName);
            if (product == null)
            {
                return new ProductResponseModel
                {
                    Message = "Product not found",
                    Success = false,
                };
            }

            return new ProductResponseModel
            {
                Message = "Product Retrived Successfully",
                Success = true,
                Data = new ProductDto
                {
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Id = product.Id,
                    InitialQuantity = product.InitialQuantity,
                    ImageUrl = product.ImageUrl,
                    Quantity = product.Quantity,
                    SellerId = product.SellerId,
                    SellerDto = new SellerDto
                    {
                        Logo = product.Seller.Logo,
                        StoreName = product.Seller.StoreName,
                        AccountNumber = product.Seller.AccountNumber,
                        Id = product.Seller.Id,
                        Address = new AddressDto
                        {
                            HouseNumber = product.Seller.Address.HouseNumber,
                            StreetName = product.Seller.Address.StreetName,
                            LGA = product.Seller.Address.LGA,
                            Town = product.Seller.Address.Town,
                            State = product.Seller.Address.State,
                            Country = product.Seller.Address.Country
                        }
                    }
                }
            };
        }


        public async Task<ProductResponseModel> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
            {
                return new ProductResponseModel
                {
                    Message = "Product not found",
                    Success = false,
                };
            }

            return new ProductResponseModel
            {
                Message = "Product Retrived Successfully",
                Success = true,
                Data = new ProductDto
                {
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Id = product.Id,
                    InitialQuantity = product.InitialQuantity,
                    ImageUrl = product.ImageUrl,
                    Quantity = product.Quantity,
                    SellerId = product.SellerId,
                    SellerDto = new SellerDto
                    {
                        Logo = product.Seller.Logo,
                        StoreName = product.Seller.StoreName,
                        AccountNumber = product.Seller.AccountNumber,
                        Id = product.Seller.Id,
                        Address = new AddressDto
                        {
                            HouseNumber = product.Seller.Address.HouseNumber,
                            StreetName = product.Seller.Address.StreetName,
                            LGA = product.Seller.Address.LGA,
                            Town = product.Seller.Address.Town,
                            State = product.Seller.Address.State,
                            Country = product.Seller.Address.Country
                        }
                    }
                }
            };
        }

        public async Task<BaseResponse> UpdateProduct(UpdateProductRequestModel updatedProduct, string productName, int sellerId)
        {
            var product = await _productRepository.GetProductByProductName(productName, sellerId);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product Not Found",
                    Success = false,
                };
            }
            product.Price  = product.Price != 0 ? updatedProduct.Price : product.Price;
            product.InitialQuantity  = product.InitialQuantity != 0 ? updatedProduct.InitialQuantity : product.InitialQuantity;
            product.Quantity  = product.Quantity != 0 ? updatedProduct.Quantity : product.InitialQuantity;
            product.ProductName = product.ProductName != null ? updatedProduct.ProductName : product.ProductName;
            product.ImageUrl = product.ImageUrl != null ? updatedProduct.ImageUrl : product.ImageUrl;


            await _productRepository.UpdateAsync(product);
            return new BaseResponse
            {
                Message = "Product updated successfully",
                Success = true,
            };
        }
    
        public async Task<ProductsResponseModel> GetBySellerId(int id)
        {
            var products = await _productRepository.GetProducts(id);
            if (products == null)
            {
                return new ProductsResponseModel
                {
                    
                    Message = "No Products yet",
                    Success = false,
                };
            }
            return new ProductsResponseModel
            {
                Message = "Product(s) found",
                Success = true,
                Data = products.Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    InitialQuantity = x.InitialQuantity,
                    Quantity = x.Quantity,
                    ImageUrl = x.ImageUrl,
                }).ToList(),

            };

        }   

        public async Task<ProductsResponseModel> GetAllProducts()
        {
            var products = await _productRepository.GetProducts();
            if (products == null)
            {
                return new ProductsResponseModel
                {
                    
                    Message = "No Products yet",
                    Success = false,
                };
            }
            return new ProductsResponseModel
            {
                Message = "Product(s) found",
                Success = true,
                Data = products.Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    InitialQuantity = x.InitialQuantity,
                    Quantity = x.Quantity,
                    ImageUrl = x.ImageUrl,
                }).ToList(),

            };

        }
    }
}