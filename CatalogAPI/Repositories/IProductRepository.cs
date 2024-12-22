using CatalogAPI.Entities;

namespace CatalogAPI.Repositories;

public interface IProductRepository
{
    /// <summary>
    /// Obtém todos os produtos de forma assíncrona.
    /// </summary>
    /// <returns>Uma lista enumerável de produtos.</returns>
    Task<IEnumerable<Product>> GetProductsAsync();

    /// <summary>
    /// Obtém um único produto pelo seu identificador de forma assíncrona.
    /// </summary>
    /// <param name="id">O identificador único do produto.</param>
    /// <returns>O produto correspondente ao identificador fornecido.</returns>
    Task<Product> GetProductAsync(string id);

    /// <summary>
    /// Obtém os produtos cujo nome corresponde ao termo fornecido de forma assíncrona.
    /// </summary>
    /// <param name="name">O nome ou parte do nome a ser pesquisado.</param>
    /// <returns>Uma lista enumerável de produtos com nomes correspondentes.</returns>
    Task<IEnumerable<Product>> GetProductByNameAsync(string name);

    /// <summary>
    /// Obtém os produtos que pertencem a uma categoria específica de forma assíncrona.
    /// </summary>
    /// <param name="categoryName">O nome da categoria dos produtos.</param>
    /// <returns>Uma lista enumerável de produtos da categoria especificada.</returns>
    Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName);

    /// <summary>
    /// Cria um novo produto de forma assíncrona.
    /// </summary>
    /// <param name="product">O objeto do tipo produto a ser criado.</param>
    Task CreateProductAsync(Product product);

    /// <summary>
    /// Atualiza as informações de um produto existente de forma assíncrona.
    /// </summary>
    /// <param name="product">O objeto do tipo produto com as informações atualizadas.</param>
    /// <returns>True se a atualização for bem-sucedida; caso contrário, False.</returns>
    Task<bool> UpdateProductAsync(Product product);

    /// <summary>
    /// Exclui um produto pelo seu identificador de forma assíncrona.
    /// </summary>
    /// <param name="id">O identificador único do produto a ser excluído.</param>
    /// <returns>True se a exclusão for bem-sucedida; caso contrário, False.</returns>
    Task<bool> DeleteProductAsync(string id);
}
