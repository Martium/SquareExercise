using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquareExercise.DependencyInjectionClass.Repository;
using SquareExercise.Models;
using SquareExercise.SqlLiteRepository;

namespace SquareExercise.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/perfectSquare")]
    public class PerfectSquareShapeController : ControllerBase
    {
        private readonly RepositoryQueryCalls _repositoryQueryCalls;
        private readonly PerfectSquareService.PerfectSquareService _perfectSquare;

        public PerfectSquareShapeController()
        {
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
            _perfectSquare = new PerfectSquareService.PerfectSquareService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("existingCoordinates")]
        public ActionResult<List<CoordinateModel>> GetAllCoordinates()
        {
            return _repositoryQueryCalls.GetAllExistingCoordinates();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("existingCoordinates/{id}")]
        public ActionResult<CoordinateModel> GetSpecificCoordinatesByIndex(int id)
        {
            int lastId = _repositoryQueryCalls.GetLastId();

            if (id > lastId)
            {
                return NotFound($"There is no coordinates with this id: {id}");
            }

            return _repositoryQueryCalls.GetSpecificCoordinatesById(id);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("PerfectSquarePossibilities")]
        public ActionResult<List<CountPerfectSquareModel>> GetAllPossiblePerfectSquareByAllExistingPoints()
        {
           return _perfectSquare.GetAllPointPossibilities(_repositoryQueryCalls.GetAllExistingCoordinates());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("addPoint")]
        public ActionResult<List<CoordinateModel>> AddCoordinateToList([FromBody] CoordinateModel coordinates)
        {
            int newId = _repositoryQueryCalls.GetNewId();
            _repositoryQueryCalls.AddNewCoordinates(coordinates, newId);
            return CreatedAtAction(nameof(GetSpecificCoordinatesByIndex), new {newId} ,coordinates);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("addPoint/List")]
        public ActionResult<List<CoordinateModel>> AddCoordinates([FromBody] List<CoordinateModel> coordinatesList)
        {
            _repositoryQueryCalls.AddNewCoordinateList(coordinatesList);
            return CreatedAtAction(nameof(GetAllCoordinates), coordinatesList);
        }
        
    }
}
