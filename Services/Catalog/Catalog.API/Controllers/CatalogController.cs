using System.Net;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class CatalogController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Route("[action]/{id:length(24)}", Name = "GetProductById")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductResponse>> GetProductById(string id)

    {
        var query = new GetProductByIdQuery(id);
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetProductsByName/{productName}", Name = "GetProductsByName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductsByName(string productName)
    {
        var query = new GetProductsByNameQuery(productName);
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetProductsByBrand/{brand}", Name = "GetProductsByBrand")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductsByBrand(string brand)
    {
        var query = new GetProductsByBrandQuery(brand);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllProducts", Name = "GetAllProducts")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts(
        [FromQuery] CatalogSpecParams catalogSpecParams)
    {
        var query = new GetAllProductsQuery(catalogSpecParams);
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetProductTypes", Name = "GetProductTypes")]
    [ProducesResponseType(typeof(IList<ProductTypeResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductTypeResponse>>> GetProductTypes()
    {
        var query = new GetAllTypesQuery();
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetProductBrands", Name = "GetProductBrands")]
    [ProducesResponseType(typeof(IList<ProductBrandResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductBrandResponse>>> GetProductBrands()
    {
        var query = new GetAllBrandsQuery();
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    [Route("[action]", Name = "CreateProduct")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await mediator.Send(command);

        return CreatedAtRoute("GetProductById", new { id = result.Id }, result);
    }

    [HttpPut]
    [Route("[action]", Name = "UpdateProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        var resul = await mediator.Send(command);
        return Ok(resul);
    }

    [HttpDelete]
    [Route("[action]/{id}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteProduct(string id)
    {
        var command = new DeleteProductCommand(id);
        var result = await mediator.Send(command);
        return Ok(result);
    }
}