using Encore.Application.Persons.Commands;
using Encore.Application.Persons.Queries;
using Encore.Application.Zip.Queries;
using Encore.Domain.Services.ESUS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ApiController
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            //new EsusService().GerarXMLXSD();
            return CustomResponse("Sucesso");
        }

        [HttpGet("download")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDownload()
        {
            var pathToFile = @"/app/xmlzip"; // Caminho do arquivo que você deseja fornecer para download
            var mimeType = "application/zip"; // Mimetype apropriado para o arquivo .xml

            if (!System.IO.File.Exists(pathToFile))
                return NotFound();

            var fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            return File(fileStream, mimeType, Path.GetFileName(pathToFile));
        }


        [HttpGet("zip")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDownloadZip([FromQuery] GetZipByPeriodQuery query)
        {
            var response = await _mediator.Send(query);

            var pathToFile = @"/app/xmlzip"; // Caminho do arquivo que você deseja fornecer para download
            var mimeType = "application/zip"; // Mimetype apropriado para o arquivo .xml

            return File(response.File, mimeType, "teste.zip");

            //FileStream file = null;// await new EsusService().GerarFichasZip();            

            //return File(file, mimeType, Path.GetFileName(pathToFile));
        }

    }
}