using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquareExercise.Interface;
using SquareExercise.Models;

namespace SquareExercise.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/perfect-square")]
    public class PerfectSquareShapeController : ControllerBase
    {
        private readonly IRepositoryQueryCalls _repositoryQueryCalls;
        private readonly PerfectSquareService.PerfectSquareService _perfectSquare;

        public PerfectSquareShapeController(IRepositoryQueryCalls repositoryQueryCalls)
        {
            _repositoryQueryCalls = repositoryQueryCalls;
            _perfectSquare = new PerfectSquareService.PerfectSquareService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("get-existing-points")]
        public ActionResult<List<PointModel>> GetAllCoordinates()
        {
            return _repositoryQueryCalls.GetAllExistingCoordinates();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("get-existing-points/{id}")]
        public ActionResult<PointModel> GetSpecificCoordinatesByIndex(int id)
        {
            int lastId = _repositoryQueryCalls.GetLastIdIfExistsOrReturnZero();

            if (id > lastId)
            {
                return NotFound($"There is no coordinates with this id: {id}");
            }

            return _repositoryQueryCalls.GetSpecificCoordinateById(id);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("get-perfect-square-possibilities")]
        public ActionResult<List<CountPerfectSquareModel>> GetAllPossiblePerfectSquareByAllExistingPoints()
        {
           return _perfectSquare.GetAllPointPossibilities(_repositoryQueryCalls.GetAllExistingCoordinates());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("add-points/add-new-point")]
        public ActionResult<List<PointModel>> AddCoordinateToList([FromBody] PointModel points)
        {
            int newId = _repositoryQueryCalls.GetNewId();
            _repositoryQueryCalls.AddNewCoordinates(points, newId);
            return CreatedAtAction(nameof(GetSpecificCoordinatesByIndex), new {newId} ,points);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("add-points")]
        public ActionResult<List<PointModel>> AddCoordinates([FromBody] List<PointModel> coordinatesList)
        {
            _repositoryQueryCalls.AddNewCoordinateList(coordinatesList);
            return CreatedAtAction(nameof(GetAllCoordinates), coordinatesList);
        }
        
    }
}
