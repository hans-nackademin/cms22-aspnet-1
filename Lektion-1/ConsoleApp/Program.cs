
using ConsoleApp.Abstractions;
using ConsoleApp.Models;
using ConsoleApp.Services;

var productService = new ProductService();
productService.Create(new ProductModel { });

var userService = new UserService();
userService.Create(new UserModel { });

productService.Get(x => x.ArticleNumber == "A12341");
userService.Get(x => x.Email == "hans@domain.com");
